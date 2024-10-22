﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common;
using Maticsoft.Common.dbUtility;
using Maticsoft.Common.model;
using Maticsoft.Common.model.httpmodel;
using Maticsoft.Common.Util;
using Maticsoft.BLL.log;

namespace Maticsoft.BLL.serviceimpl
{
    public class FeedbackServiceImpl : BaseServiceImpl, IFeedbackService
    {
        /// <summary>
        /// 查询所有需要反馈的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getAllFeedbackOrderList()
        {
            try
            {
                //单式上传订单 id < 0，不反馈
                string sql = String.Format("SELECT * FROM lottery_order WHERE id > 0 AND bet_state in('{0}','{1}','{2}','{3}','{4}','{5}') AND is_feedback='{6}';",
                  new String[] { GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(),
               GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString()});
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 查询所有反馈失败的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getAllFeedBackErrorOrders() {
            try
            {
                string sql = String.Format("SELECT * FROM lottery_order WHERE is_feedback='{0}';",
               GlobalConstants.FeedbackState.FAILED.ToString());
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        /// <summary>
        /// 查询所有需要手动反馈的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getAllNeedManualFeedBackOrders(Boolean isAutoFeedBack)
        {
            try
            {
                String sql = String.Empty;
                //如果是自动反馈，只需要查询反馈失败的即可；
                if (isAutoFeedBack)
                {
                    sql = String.Format("SELECT * FROM lottery_order WHERE is_feedback ='{0}';",
                   GlobalConstants.FeedbackState.FAILED.ToString());
                }
                else
                {
                    sql = String.Format("SELECT * FROM lottery_order WHERE bet_state in('{0}','{1}','{2}','{3}','{4}','{5}') AND is_feedback in('{6}','{7}');",
                         new String[] { GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(),
               GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
               GlobalConstants.FeedbackState.FAILED.ToString()});
                }

                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询所有需要手动反馈的订单——分页
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getAllNeedManualFeedBackOrdersPagination(long sno, long psize,
            Boolean isAutoFeedBack, Boolean isIncludeJL)
        {
            try
            {
                String sql = String.Empty;
                //如果是自动反馈，只需要查询反馈失败的即可；
                if (isAutoFeedBack)
                {
                    sql = String.Format("SELECT * FROM lottery_order WHERE is_feedback ='{0}' AND id > 0 ORDER BY is_feedback DESC limit {1},{2};",
                   GlobalConstants.FeedbackState.FAILED.ToString(), sno.ToString(), psize.ToString());
                    //if (isIncludeJL)
                    //{
                    //    sql = String.Format("SELECT * FROM lottery_order WHERE is_feedback ='{0}' ORDER BY is_feedback DESC limit {1},{2};",
                    //GlobalConstants.FeedbackState.FAILED.ToString(), sno.ToString(), psize.ToString());
                    //}
                    //else
                    //{
                    //    sql = String.Format("SELECT COUNT* FROM lottery_order WHERE is_feedback ='{0}' OR(is_feedback DESC ='{1}' AND license_id='{2}') ORDER BY is_feedback limit {3},{4};",
                    // GlobalConstants.FeedbackState.FAILED.ToString(),
                    // GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
                    // LicenseContants.License.GAMEIDJCLQ.ToString(), sno.ToString(), psize.ToString());
                    //}
                }
                else
                {
                    sql = String.Format("SELECT * FROM lottery_order WHERE bet_state in('{0}','{1}','{2}','{3}','{4}','{5}','{6}') AND is_feedback in('{7}','{8}') AND id > 0 ORDER BY is_feedback DESC limit {9},{10};",
                         new String[] { GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
               GlobalConstants.FeedbackState.FAILED.ToString(), sno.ToString(), psize.ToString()});
                }

                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取所有需要手动处理反馈的订单的数量
        /// </summary>
        /// <param name="isAutoFeedBack">是否自动反馈</param>
        /// /// <param name="isIncludeJL">是否反馈篮球</param>
        /// <returns></returns>
        public int getAllNeedManualFeedBackOrderNum(Boolean isAutoFeedBack, Boolean isIncludeJL) {
            try
            {
                String sql = String.Empty;
                //如果是自动反馈，只需要查询反馈失败的即可；
                if (isAutoFeedBack)
                {
                    sql = String.Format("SELECT COUNT(*) FROM lottery_order WHERE is_feedback ='{0}' AND id > 0;",
                   GlobalConstants.FeedbackState.FAILED.ToString());
                    //if (isIncludeJL)
                    //{
                    //    sql = String.Format("SELECT COUNT(*) FROM lottery_order WHERE is_feedback ='{0}';",
                    //GlobalConstants.FeedbackState.FAILED.ToString());
                    //}
                    //else
                    //{
                    //    sql = String.Format("SELECT COUNT(*) FROM lottery_order WHERE is_feedback ='{0}' OR(is_feedback ='{1}' AND license_id='{2}');",
                    // GlobalConstants.FeedbackState.FAILED.ToString(),
                    // GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
                    // LicenseContants.License.GAMEIDJCLQ.ToString());
                    //}                    
                }
                else
                {
                    sql = String.Format("SELECT COUNT(*) FROM lottery_order WHERE bet_state in('{0}','{1}','{2}','{3}','{4}','{5}') AND is_feedback in('{6}','{7}') AND id > 0;",
                         new String[]{ GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(),
               GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
               GlobalConstants.FeedbackState.FAILED.ToString()});
                }

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
        /// 查询所有反馈失败但是未加载到界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getFeedBackErrorNoInFormOrders() {
            try
            {
                string sql = String.Format("SELECT * FROM lottery_order WHERE is_feedback='{0}' AND is_in_feedback_form = '{1}';",
                    new String[] {
               GlobalConstants.FeedbackState.FAILED.ToString(),
               GlobalConstants.TrueFalseSign.FALSE.ToString()});
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 查询所有需要反馈，且已经显示在界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getFeedbackOrderListInForm()
        {
            try
            {
                string sql = String.Format("SELECT * FROM lottery_order WHERE bet_state in('{0}','{1}','{2}','{3}','{4}','{5}') AND is_feedback='{6}' AND is_in_feedback_form = '{7}';",
                new String[] { GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(),
               GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
               GlobalConstants.TrueFalseSign.TRUE.ToString()});
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询所有需要反馈，但未显示在界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getFeedbackOrderListNotInForm()
        {
            try
            {
                string sql = String.Format("SELECT * FROM lottery_order WHERE bet_state in('{0}','{1}','{2}','{3}','{4}','{5}') AND is_feedback='{6}' AND is_in_feedback_form = '{7}';",
                 new String[] { GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(),
               GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString(),
               GlobalConstants.FeedbackState.NOT_FEEDBACK.ToString(),
               GlobalConstants.TrueFalseSign.FALSE.ToString()});
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sql.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();

                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }
                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 修改对应订单是否在反馈界面状态
        /// </summary>
        /// <param name="lol"></param>
        /// <returns></returns>
        public Boolean updateIsInFeedbackForm(List<lottery_order> lol)
        {
            try
            {
                if (null == lol || lol.Count == 0)
                {
                    return false;
                }
                string sql = String.Format("update lottery_order set is_in_feedback_form = {0} WHERE id in (", GlobalConstants.TrueFalseSign.TRUE.ToString());
                for (int i = 0; i < lol.Count; i++)
                {
                    sql += "'" + lol[i].id.ToString() + "'" + (i < lol.Count - 1 ? "," : ")");
                }
                return (SQLiteHelper.getBLLInstance().ExecuteNonQuery(sql) > 0);
            }
            catch (Exception)
            {
                throw new Exception("修改订单已在反馈界面状态出错!");
            }
        }

        /// <summary>
        /// 反馈（一条）
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public Boolean ManualFeedbackSingle(lottery_order lo)
        {
            try
            {

                HttpRequestMsg<Body1001> hrmsg = new HttpRequestMsg<Body1001>("UTF-8", GlobalConstants.TRANSCODE.FEEDBACK, Global.STORE_ID.ToString(), "1.0");

                Body1001 body1001 = new Body1001(lo);

                // 3. 初始化ticket层(error ticket list)
                /*
                 * (1) 根据orderId获取state异常（不为‘打印完成’）的ticketList
                 */
                List<String> states = new List<string>() { GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString(), GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString() };
                IList<lottery_ticket> ltList = this.getTicketsByOrderIdAndStates(lo.id.ToString(), states);
                foreach (lottery_ticket lt in ltList)
                {
                    Body1001.FeedBackTicket errTicket = new Body1001.FeedBackTicket(lt);
                    body1001.ticketsInfo.Add(errTicket);
                }

                hrmsg.body = body1001;
                string request = JSonHelper.ObjectToJson(hrmsg);

                //记录日志
                LogUtil.getInstance().addLogDataToQueue("发送订单" + lo.id + "反馈数据>>>"+ request, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);

                string response = null;
                try
                {
                    response = HTTPHelper.HttpHandler ( request, GlobalConstants.SERVER_URL_MAP [
                        Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE ] ] );
                }
                catch (Exception)
                {
                    
                    throw;
                }

                

                // 6. 解析反馈结果
                HttpResponseMsg<HttpBody> body1001FeedbackResult = (HttpResponseMsg<HttpBody>)JSonHelper.JsonToHttpResponseMsg<HttpBody>(response);

                if (body1001FeedbackResult.head.resultCode.Equals(GlobalConstants.FeedbackResult.SUCCESS))
                {
                    updateOrderAndTicketStateFeedback(lo.id.ToString(), GlobalConstants.FeedbackState.SUCCESS);
                    LogUtil.getInstance().addLogDataToQueue("订单"+lo.id+"反馈成功!", GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                    return true;
                }
                else if (body1001FeedbackResult.head.resultCode.Equals(GlobalConstants.FeedbackResult.NONEXIST))
                {
                    updateOrderAndTicketStateFeedback(lo.id.ToString(), GlobalConstants.FeedbackState.FAILED);
                    LogUtil.getInstance().addLogDataToQueue("服务器没有此订单：" + lo.id, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                    return false;
                }
                else
                {
                    updateOrderAndTicketStateFeedback(lo.id.ToString(), GlobalConstants.FeedbackState.FAILED);
                    LogUtil.getInstance().addLogDataToQueue("订单" + lo.id + "反馈失败!", GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                    return false;
                }
            }
            catch (System.Net.WebException eWeb)
            {
                LogUtil.getInstance().addLogDataToQueue("订单" + lo.id + "反馈发生异常!>>>"+ eWeb.Message, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                throw new Exception("订单反馈出现异常!");
            }

        }

        /// <summary>
        /// 处理出票反馈结果
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public bool updateOrderAndTicketStateFeedback(string orderId, int isFeedback)
        {
            try
            {
                System.Collections.ArrayList sqllist = new System.Collections.ArrayList();
                sqllist.Add(String.Format("UPDATE lottery_order SET is_feedback = '{0}' WHERE id = '{1}';", new String[] { isFeedback.ToString(), orderId }));
                sqllist.Add(String.Format("UPDATE lottery_ticket SET is_feedback='{0}' WHERE order_id = '{1}';", new String[] { isFeedback.ToString(), orderId }));
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);

                return true;
            }
            catch (Exception)
            {
                throw new Exception("修改订单状态操作出错!");
            }
        }

        public bool ManualFeedFailedProcessed(lottery_order lottery_order)
        {
            throw new NotImplementedException();
        }
    }
}
