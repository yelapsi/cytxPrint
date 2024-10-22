﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common;
using Maticsoft.Common.dbUtility;
using Maticsoft.Common.model;
using System.Data.SQLite;
using Maticsoft.Model;

namespace Maticsoft.BLL.serviceimpl
{
    /// <summary>
    /// 一些公用的业务，可以在此实现，不需多处实现
    /// </summary>
    public class BaseServiceImpl : IBaseService
    {
        /// <summary>
        /// 根据条件查询订单列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderListByParam(Dictionary<String, String> param)
        {
            try
            {
                StringBuilder sb = new StringBuilder("SELECT * FROM lottery_order");
                sb.Append(SQLBuilderUtil.dictionaryToWhereSQLString(param));
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sb.ToString(), null);
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
        /// 根据状态查询订单列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderListByState(String state)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * FROM lottery_order WHERE bet_state ='{0}';", state);
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sb.ToString(), null);
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
        /// 根据状态查询单式上传订单列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<lottery_order> getSingleOrdersToQueueByState(String state)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * FROM lottery_order_single WHERE bet_state ='{0}';", state);
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sb.ToString(), null);
                List<lottery_order> ltList = new List<lottery_order>();
                if (dt.Tables[0].Rows.Count > 0)
                {
                    ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                }

                foreach (lottery_order lo in ltList)
                {
                    lo.IsSingle = true;
                }

                return ltList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单id查询订单
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        public lottery_order getLotteryOrderById(String oId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * FROM lottery_order WHERE id='{0}';", oId);

                DataSet dt = SQLiteHelper.getBLLInstance().Query(sb.ToString(), null);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    List<lottery_order> ltList = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(dt);
                    return ltList[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderId(String orderId)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * from lottery_ticket WHERE order_id='{0}';", orderId);

                List<lottery_ticket> list = new List<lottery_ticket>();
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sb.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = (List<lottery_ticket>)CollectionHelper.ConvertTo<lottery_ticket>(ds);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderIdAndStates(string orderId, List<String> states)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * from lottery_ticket WHERE order_id='{0}'", orderId);

                //if (null != states && states.Count > 0)
                //{
                //    sb.Append(" AND ticket_state in (");
                //    for (int i = 0; i < states.Count; i++)
                //    {
                //        sb.Append("'" + states[i] + "'" + ((i < states.Count - 1) ? "," : ");"));
                //    }
                //}
                //else
                //{
                //    sb.Append(";");
                //}

                List<lottery_ticket> list = new List<lottery_ticket>();
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sb.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = (List<lottery_ticket>)CollectionHelper.ConvertTo<lottery_ticket>(ds);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票——分页
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderIdPagination(string orderId, Int64 sno, Int64 psize)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("SELECT * from lottery_ticket WHERE order_id='{0}' limit {1},{2};", orderId, sno.ToString(), psize.ToString());

                List<lottery_ticket> list = new List<lottery_ticket>();
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sb.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = (List<lottery_ticket>)CollectionHelper.ConvertTo<lottery_ticket>(ds);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询指定订单下所有票的数量
        /// </summary>
        /// <returns></returns>
        public Int64 getTicketsNumByOrderId(string oId)
        {
            try
            {
                String sql = String.Empty;
                //如果是自动反馈，只需要查询反馈失败的即可；
                sql = String.Format("SELECT COUNT(*) FROM lottery_ticket WHERE order_id ='{0}';",
                   oId);

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
        /// 根据订单Id和状态获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderIdAndStatesPagination(string orderId, List<String> states, Int64 sno, Int64 psize)
        {
            try
            {
                String sql = String.Empty;
                String statestr = String.Empty;
                if (null != states && states.Count > 0)
                {
                    if (states.Count == 1)
                    {
                        statestr = String.Format("AND ticket_state ='{0}'", states[0]);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder("AND ticket_state in (");
                        for (int i = 0; i < states.Count; i++)
                        {
                            sb.Append(states[i] + (i + 1 == states.Count ? ")" : ","));
                        }
                        statestr = sb.ToString();
                    }
                }

                //如果是自动反馈，只需要查询反馈失败的即可；
                sql = String.Format("SELECT * FROM lottery_ticket WHERE order_id ='{0}' {1} limit {2},{3};",
                   new String[] { orderId, statestr, sno.ToString(), psize.ToString() });

                List<lottery_ticket> list = new List<lottery_ticket>();
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    list = (List<lottery_ticket>)CollectionHelper.ConvertTo<lottery_ticket>(ds);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票的数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public long getSingleTicketsNumByOrderIdAndStates(string orderId, List<string> states)
        {
            try
            {
                String sql = String.Empty;
                String statestr = String.Empty;
                if (null != states && states.Count > 0)
                {
                    if (states.Count == 1)
                    {
                        statestr = String.Format("AND ticket_state ='{0}'", states[0]);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder("AND ticket_state in (");
                        for (int i = 0; i < states.Count; i++)
                        {
                            sb.Append(states[i] + (i + 1 == states.Count ? ")" : ","));
                        }
                        statestr = sb.ToString();
                    }
                }

                //如果是自动反馈，只需要查询反馈失败的即可；
                sql = String.Format("SELECT COUNT(*) FROM lottery_ticket_single WHERE order_id ='{0}' {1};",
                   new String[] { orderId, statestr });

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
        /// 根据订单Id和状态获取订单下的所有票的数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Int64 getTicketsNumByOrderIdAndStates(string orderId, List<String> states)
        {
            try
            {
                String sql = String.Empty;
                String statestr = String.Empty;
                if (null != states && states.Count > 0)
                {
                    if (states.Count == 1)
                    {
                        statestr = String.Format("AND ticket_state ='{0}'", states[0]);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder("AND ticket_state in (");
                        for (int i = 0; i < states.Count; i++)
                        {
                            sb.Append(states[i] + (i + 1 == states.Count ? ")" : ","));
                        }
                        statestr = sb.ToString();
                    }
                }

                //如果是自动反馈，只需要查询反馈失败的即可；
                sql = String.Format("SELECT COUNT(*) FROM lottery_ticket WHERE order_id ='{0}' {1};",
                   new String[] { orderId, statestr });

                int count = 0;
                int.TryParse(SQLiteHelper.getBLLInstance().GetSingle(sql).ToString(), out count);

                return count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public SQLiteParameter[] GetSQLiteParameterArr(lottery_ticket lt)
        {
            return new SQLiteParameter[]{
                new SQLiteParameter("@orderId",lt.order_id),
                new SQLiteParameter("@ticketId",lt.ticket_id),
                new SQLiteParameter("@userId",lt.userid),
                new SQLiteParameter("@userName",lt.username),
                new SQLiteParameter("@storeId",lt.storeid),
                new SQLiteParameter("@licenseId",lt.license_id),
                new SQLiteParameter("@playType",lt.play_type),
                new SQLiteParameter("@createDate",lt.create_date),
                new SQLiteParameter("@ticketDate",lt.ticket_date),
                new SQLiteParameter("@betCode",lt.bet_code),
                new SQLiteParameter("@betNum",lt.bet_num),
                new SQLiteParameter("@multiple",lt.multiple),
                new SQLiteParameter("@betPrice",lt.bet_price),
                new SQLiteParameter("@stopTime",lt.stop_time),
                new SQLiteParameter("@ticketState",lt.ticket_state),
                new SQLiteParameter("@issue",lt.issue),
                new SQLiteParameter("@orderOdds",lt.order_odds),
                new SQLiteParameter("@ticketOdds",lt.ticket_odds),
                new SQLiteParameter("@orderRqs",lt.order_rqs),
                new SQLiteParameter("@ticketRqs",lt.ticket_rqs),
                new SQLiteParameter("@sent_num",lt.sent_num),
                new SQLiteParameter("@exception_description",lt.exception_description),
                new SQLiteParameter("@cancelMoney",lt.cancel_money),
                new SQLiteParameter("@zj_flag",lt.zj_flag),
                new SQLiteParameter("@err_ticket_sign",lt.err_ticket_sign),
                new SQLiteParameter("@ticket_info",lt.ticket_info),
                new SQLiteParameter("@return_pass_type",lt.return_pass_type),
                new SQLiteParameter("@return_license_id",lt.return_license_id),
                new SQLiteParameter("@return_license_name",lt.return_license_name),
                new SQLiteParameter("@return_issue",lt.return_issue),
                new SQLiteParameter("@return_issue_num",lt.return_issue_num),
                new SQLiteParameter("@return_play_id",lt.return_play_id),
                new SQLiteParameter("@return_play_name",lt.return_play_name),
                new SQLiteParameter("@return_multiple",lt.return_multiple),
                new SQLiteParameter("@return_money",lt.return_money),
                new SQLiteParameter("@return_bet_info",lt.return_bet_info)
            };
        }

        public string lotteryTicketColumns = @"order_id,ticket_id,userid,username,storeid,license_id,play_type,create_date,ticket_date,bet_code,bet_num,multiple,bet_price,stop_time,ticket_state,issue,order_odds,ticket_odds,order_rqs,ticket_rqs,sent_num,exception_description,cancel_money,zj_flag,err_ticket_sign,ticket_info,return_pass_type,return_license_id,return_license_name,return_issue,return_issue_num,return_play_id,return_play_name,return_multiple,return_money,return_bet_info";

        public string lotteryTicketParameters = @"@orderId,@ticketId,@userId,@userName,@storeId,@licenseId,@playType,@createDate,@ticketDate,@betCode,@betNum,@multiple,@betPrice,@stopTime,@ticketState,@issue,@orderOdds,@ticketOdds,@orderRqs,@ticketRqs,@sent_num,@exception_description,@cancelMoney,@zj_flag,@err_ticket_sign,@ticket_info,@return_pass_type,@return_license_id,@return_license_name,@return_issue,@return_issue_num,@return_play_id,@return_play_name,@return_multiple,@return_money,@return_bet_info";

        public string lotteryOrderColumns = @"bet_code,
                bet_from,
                bet_num,
                bet_price,
                bet_state,
                bet_type,
                canceled_num,canceled_money,
                com_port,
                del_date,
                errticket_num,
                ticket_money,
                id,
                issue,
                license_id,
                mult_info,
                multiple,
                order_date,
                err_ticket_sign_num,
                pass_type,
                play_type,
                sch_info,
                single_flag,
                storeid,
                ticket_num,
                ticket_date,
                ticket_oper,
                total_money,
                total_tickets_num,
                userid,
                username,
                is_in_feedback_form,
                is_in_print_form,
                is_in_error_form,
                stop_time,
                expired_num,
                expired_money";

        public string lotteryOrderParameters = @"@bet_code,
                @bet_from,
                @bet_num,
                @bet_price,
                @bet_state,
                @bet_type,
                @canceled_num,@canceled_money,
                @com_port,
                @del_date,
                @errticket_num,
                @ticket_money,
                @id,
                @issue,
                @license_id,
                @mult_info,
                @multiple,
                @order_date,
                @err_ticket_sign_num,
                @pass_type,
                @play_type,
                @sch_info,
                @single_flag,
                @storeid,
                @ticket_num,
                @ticket_date,
                @ticket_oper,
                @total_money,
                @total_tickets_num,
                @userid,
                @username,
                @is_in_feedback_form,
                @is_in_print_form,
                @is_in_error_form,
                @stop_time,
                @expired_num,
                @expired_money";


        public SQLiteParameter[] GetLiceseParameterArr(license li)
        {
            return new SQLiteParameter[]{
                new SQLiteParameter("@license_id",li.license_id),
                new SQLiteParameter("@license_name",li.license_name),
                new SQLiteParameter("@type",li.type),
                new SQLiteParameter("@state",li.state)
            };
        }
        public string licenseColumns = @"license_id,license_name,type,state";
        public string licenseParameters = @"@license_id,@license_name,@type,@state";

        public SQLiteParameter[] GetPlayParameterArr(play pl)
        {
            return new SQLiteParameter[]{
                new SQLiteParameter("@play_id",pl.play_id),
                new SQLiteParameter("@play_name",pl.play_name),
                new SQLiteParameter("@license_id",pl.license_id),
                new SQLiteParameter("@license_name",pl.license_name)
            };
        }
        public string playColumns = @"play_id,play_name,license_id,license_name";
        public string playParameters = @"@play_id,@play_name,@license_id,@license_name";
    }
}