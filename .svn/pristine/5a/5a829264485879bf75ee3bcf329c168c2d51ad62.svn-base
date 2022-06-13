using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Common.Util;
using Maticsoft.Common.model;
using Maticsoft.Common.dbUtility;
using Maticsoft.BLL.serviceinterface;
using System.Collections;
using Maticsoft.BLL.log;

namespace Maticsoft.BLL.serviceimpl
{
    public class ExpiredCheckingServiceImpl : BaseServiceImpl, IExpiredCheckingService
    {
        public void ExpiredTicketCheckingHandler()
        {
            try
            {
                //读取逾期的票
                string sql = String.Format(@"SELECT {0} FROM lottery_ticket WHERE stop_time < '{1}' AND ticket_state IN ({2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) ", new String[]{
                this.lotteryTicketColumns, 
                DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1,-60),
                GlobalConstants.ORDER_TICKET_STATE.AWAITING_ALLOT.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.MANUAL_PRINTTING.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString(),
                GlobalConstants.ORDER_TICKET_STATE.RE_PRINTTING.ToString()
            });
                List<lottery_ticket> ltList = new List<lottery_ticket>();
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_ticket>)CollectionHelper.ConvertTo<lottery_ticket>(ds);
                }

                if (ltList.Count > 0)
                {               
                    foreach (lottery_ticket lt in ltList)
                    {
                        //sql数据
                        ArrayList sqllist = new ArrayList();

                        lottery_order lo = this.getLotteryOrderById(lt.order_id.ToString());
                        lo.expired_num++;
                        lo.expired_money = lo.expired_money + int.Parse(lt.bet_price);

                        //如果彩票本来是错漏票，那么错漏票的数量要减一
                        if (lt.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()))
                        {
                            lo.errticket_num--;
                        }

                        if (lo.total_tickets_num <= (lo.canceled_num + lo.errticket_num + lo.expired_num + lo.ticket_num))
                        {
                            if (lo.errticket_num >0)
                            {
                                lo.bet_state = GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString();
                            }
                            else if (lo.ticket_num > 0)
                            {
                                lo.bet_state = GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString();
                            }                            
                            else
                            {
                                lo.bet_state = GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString();
                            }
                            string sqlOrder = String.Format(@"UPDATE lottery_order SET errticket_num = '{0}', expired_num = '{1}',expired_money = '{2}',bet_state = '{3}',ticket_date = '{4}' WHERE id = '{5}';", lo.errticket_num, lo.expired_num, lo.expired_money, lo.bet_state, DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), lo.id.ToString());
                            sqllist.Add(sqlOrder);
                        }
                        else
                        {
                            string sqlOrder = sqlOrder = String.Format(@"UPDATE lottery_order SET errticket_num = '{0}', expired_num = '{1}',expired_money = '{2}' WHERE id = '{3}';", lo.errticket_num, lo.expired_num, lo.expired_money, lo.id.ToString());
                            sqllist.Add(sqlOrder);
                        }

                        string sqlTicket = String.Format(@"UPDATE lottery_ticket SET ticket_state = '{0}',ticket_date='{1}' WHERE ticket_id = '{2}' AND order_id = '{3}';", GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(), DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), lt.ticket_id.ToString(), lt.order_id.ToString());
                        sqllist.Add(sqlTicket);

                        //只能一票一票的处理
                        SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                        LogUtil.getInstance().addLogDataToQueue("逾期处理>>>>>订单："+lo.id+"彩票："+lt.ticket_id, GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION);
                    }              

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
