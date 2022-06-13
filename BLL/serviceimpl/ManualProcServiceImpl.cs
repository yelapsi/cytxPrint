using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common;
using Maticsoft.Common.dbUtility;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Maticsoft.BLL.serviceimpl
{
    public class ManualProcServiceImpl : BaseServiceImpl,IManualProcService
    {
       /// <summary>
       /// 查询所有需要手工处理的订单（用于初始化界面）
       /// </summary>
       /// <returns></returns>
       public List<lottery_order> getAllManualOrders() {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * FROM lottery_order WHERE bet_state in({0},{1});"
                    , new String[]{GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString()});
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sb.ToString());
                return (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(ds);
            }
            catch (Exception e)
            {
                throw e;
            }           
       }

        /// <summary>
        /// 获取所有含有错漏票的订单的数量
        /// </summary>
        /// <returns></returns>
       public int getManualOrderNum() {
            try
            {
                String sql = String.Format("SELECT COUNT(*) FROM lottery_order WHERE bet_state in({0},{1});"
                , new String[]{GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString()});

                int count = 0;
                int.TryParse(SQLiteHelper.getBLLInstance().GetSingle(sql).ToString(), out count);

                return count;
            }
            catch (Exception e)
            {
                throw e;
            }             
       }


       /// <summary>
       /// 撤票
       /// </summary>
       /// <param name="oId"></param>
       /// <param name="tId"></param>
       /// <param name="money"></param>
       /// <returns></returns>
       public Boolean cancelTicket(String oId, String tId, String money) {
           try
           {
                //1、改变彩票状态；2、改变订单金额，出票数量，状态等
                lottery_order lo = this.getLotteryOrderById(oId);
                if (null == lo)
                {
                    throw new Exception("订单不存在!");
                }

                System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
                sqllist.Add(String.Format("UPDATE lottery_ticket SET ticket_state='{0}',ticket_date='{1}' WHERE order_id = '{2}' AND ticket_id ='{3}';", new String[] { GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(), DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), oId, tId }));
                //修改订单
                String bstate = "", ticket_date = "";

                if (lo.total_tickets_num == lo.ticket_num + lo.errticket_num + lo.canceled_num + 1)
                {
                    if (lo.errticket_num > 0)
                    {
                        bstate = GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString();
                    }
                    else if (lo.canceled_num + 1 == lo.total_tickets_num)
                    {
                        bstate = GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString();
                    }
                    else
                    {
                        bstate = GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString();
                    }

                    ticket_date = DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1);
                }
                else
                {
                    bstate = GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString();
                }

                sqllist.Add(String.Format("UPDATE lottery_order SET bet_state = '{0}',canceled_money ='{1}',canceled_num='{2}',ticket_date ='{3}' WHERE id='{4}';", new String[] { bstate, (lo.canceled_money + long.Parse(money)).ToString(), (lo.canceled_num + 1).ToString(), ticket_date, oId }));
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
               return true;
           }
           catch (Exception)
           {
               throw new Exception("撤票处理操作出错!");
           }
       }

       /// <summary>
       /// 撤单——这里的撤单只是撤票的总和（也就是已经出了的票是不能被撤掉的）
       /// </summary>
       /// <param name="oId"></param>
       /// <returns></returns>
       public Boolean cancelOrder(String oId)
       {
           try
           {
                //1、查询涉及到的金额；2、修改彩票状态；修改订单状态和出票金额
                lottery_order lo = this.getLotteryOrderById(oId);
                if (null == lo)
                {
                    throw new Exception("订单不存在!");
                }

                Double money = 0d;
                if (!Double.TryParse(SQLiteHelper.getBLLInstance().GetSingle(
                    String.Format("SELECT COALESCE(SUM(bet_price),0) FROM lottery_ticket Where order_id = '{0}' and ticket_state in({1},{2});",
                    new String[] { oId,GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString() ,
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString()})).ToString(), out money))
                {
                    throw new Exception("统计票金额出错!");
                }
                if (money == 0)
                {
                    throw new Exception("没有可操作的票!");
                }

                System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
                sqllist.Add(String.Format("UPDATE lottery_ticket SET ticket_state='{0}',ticket_date='{1}' WHERE order_id = '{2}' AND ticket_state in('{3}','{4}');", new String[] { GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
           DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), oId, GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString() ,
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString() }));
                //修改订单
                //修改订单
                String bstate = "";

                if (lo.errticket_num > 0)
                {
                    bstate = GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString();
                }
                else if (lo.ticket_num > 0)
                {
                    bstate = GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString();
                }
                else
                {
                    bstate = GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString();
                }
                sqllist.Add(String.Format("UPDATE lottery_order SET bet_state = {0},canceled_money ='{1}',canceled_num='{2}',ticket_date='{3}' WHERE id='{4}';", new String[] { bstate, (lo.canceled_money + money).ToString(), (lo.total_tickets_num - lo.errticket_num - lo.ticket_num).ToString(), DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), oId }));
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
               return true;
           }
           catch (Exception)
           {
               throw new Exception("整单撤票处理操作出错!");
           }
       }


       /// <summary>
       /// 确认完成出票——票上点击
       /// </summary>
       /// <param name="oId"></param>
       /// <param name="tId"></param>
       /// <param name="money"></param>
       /// <returns></returns>
       public Boolean sureCompeletTicket(String oId, String tId, String money)
       {
           try
           {
                //1、改变彩票状态；2、改变订单金额，出票数量，状态等
                lottery_order lo = this.getLotteryOrderById(oId);
                if (null == lo)
                {
                    throw new Exception("订单不存在!");
                }

                System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
                sqllist.Add(String.Format("UPDATE lottery_ticket SET ticket_state='{0}',ticket_date='{1}' WHERE order_id = '{2}' AND ticket_id ='{3}';", new String[] { GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
           DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), oId, tId }));
                //修改订单
                //修改订单
                String bstate = "", ticket_date = "";

                if (lo.total_tickets_num == lo.ticket_num + lo.errticket_num + lo.canceled_num + 1)
                {
                    if (lo.errticket_num > 0)
                    {
                        bstate = GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString();
                    }
                    else
                    {
                        bstate = GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString();
                    }

                    ticket_date = DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1);
                }
                else
                {
                    bstate = GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString();
                }
                sqllist.Add(String.Format("UPDATE lottery_order SET bet_state = '{0}',ticket_money ='{1}',ticket_num='{2}',ticket_date='{3}' WHERE id='{4}';", new String[] { bstate, (lo.ticket_money + long.Parse(money)).ToString(), (lo.ticket_num + 1).ToString(), DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), oId }));
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
               return true;
           }
           catch (Exception)
           {
               throw new Exception("确认出票处理操作出错!");
           }
       }


       /// <summary>
       /// 确认完成出票——订单上点击
       /// </summary>
       /// <param name="oId"></param>
       /// <returns></returns>
       public Boolean sureCompeletOrder(String oId)
       {
           try
           {
                //1、查询涉及到的金额；2、修改彩票状态；修改订单状态和出票金额
                lottery_order lo = this.getLotteryOrderById(oId);
                if (null == lo)
                {
                    throw new Exception("订单不存在!");
                }

                Double money = 0d;
                if (!Double.TryParse(SQLiteHelper.getBLLInstance().GetSingle(
                    String.Format("SELECT COALESCE(SUM(bet_price),0) FROM lottery_ticket Where order_id = '{0}' AND ticket_state in({1},{2});",
                    new String[] {oId, GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString() ,
                GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString()})).ToString(), out money))
                {
                    throw new Exception("统计票金额出错!");
                }

                System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
                if (money > 0)
                {
                    sqllist.Add(String.Format("UPDATE lottery_ticket SET ticket_state='{0}',ticket_date='{1}' WHERE order_id = '{2}' AND ticket_state in('{3}','{4}');", new String[] { GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1),oId, GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString() ,
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString() }));
                }
                else
                {//看一下是否订单已经是完成状态(因为有可能在手工界面上停留太久，在这过程中订单逾期处理完成了)
                    if (lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString())
                        || lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString())
                        || lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString())
                        || lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString())
                        || lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString())
                        || lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
                    {
                        return true;
                    }
                }

                //修改订单
                //修改订单
                String bstate = (lo.errticket_num > 0 ? GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString() :
                     GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString());

                sqllist.Add(String.Format("UPDATE lottery_order SET bet_state = {0},ticket_money ='{1}',ticket_num='{2}',ticket_date='{3}' WHERE id='{4}';",
                    new String[] { bstate, (lo.ticket_money + money).ToString(), (lo.total_tickets_num - lo.errticket_num - lo.canceled_num - lo.expired_num).ToString(), DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), oId }));
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
               return true;
           }
           catch (Exception e)
           {
               throw e;
           }
       }


       /// <summary>
       /// 恢复订单
       /// </summary>
       /// <param name="oId"></param>
       /// <returns></returns>
       public Boolean recoveryOrder(String oId)
       {
           try
           {
               //此处不会把订单状态改为错漏票，因为如果只剩下错漏票，那么上一操作就会终结该订单
               System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
               sqllist.Add(String.Format("UPDATE lottery_ticket SET ticket_state = '{0}' WHERE ticket_state in('{1}','{2}')  AND order_id = '{3}';", 
           new String[]{GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString(),
          GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString(),
          GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString(),oId}));

               sqllist.Add(String.Format("UPDATE lottery_order SET bet_state ='{0}' WHERE id='{1}';", new String[]{
         GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString(),oId }));

               SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);

               return true;
           }
           catch (Exception e)
           {
               throw e;
           }
       }
       

    }
}
