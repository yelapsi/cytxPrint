using Maticsoft.BLL.serviceinterface;
using Maticsoft.BLL.singleUploadParser;
using Maticsoft.Common.dbUtility;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Maticsoft.BLL.serviceimpl
{
    public class UploadServiceImpl : BaseServiceImpl, IUploadService
    {
        /// <summary>
        /// 解析排列三单式上传文件
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="playId"></param>
        /// <param name="testCode"></param>
        /// <returns></returns>
        public string parsePls(int licenseId, int playId, string line)
        {
            PlsSingleUploadParser sup = (PlsSingleUploadParser)SingleUploadParserFactory.getSingleUploadParser(licenseId);
            return sup.parseLine(playId, line);
        }

        /// <summary>
        /// 解析txt文件 竞彩足球 竞彩篮球
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="playId"></param>
        /// <param name="fileContent"></param>
        /// <param name="schNum"></param>
        /// <param name="passLen"></param>
        /// <param name="withSch"></param>
        /// <returns></returns>
        public string parseGuessLine(int licenseId, int playId, string fileContent, int schNum, int passLen, bool withSch)
        {
            GuessSingleUploadParser sup = (GuessSingleUploadParser)SingleUploadParserFactory.getSingleUploadParser(licenseId);
            return sup.parseSingleFileLine(playId, fileContent, schNum, passLen, withSch);
        }

        public static class SingleUploadParserFactory
        {
            private static Dictionary<int, SingleUploadParser> dic = new Dictionary<int, SingleUploadParser>() {
                {LicenseContants.License.GAMEIDPLS,new PlsSingleUploadParser()},
                {LicenseContants.License.GAMEIDPLW,new PlwSingleUploadParser()},
                {LicenseContants.License.GAMEIDF3D,new PlsSingleUploadParser()},
                {LicenseContants.License.GAMEIDQXC,new QxcSingleUploadParser()},
                {LicenseContants.License.GAMEIDDLT,new DltSingleUploadParser()},
                {LicenseContants.License.GAMEIDSSQ,new SsqSingleUploadParser()},
                {LicenseContants.License.GAMEIDQLC,new QlcSingleUploadParser()},
                {LicenseContants.License.GAMEIDSFC,new FootballSfcSingleUploadParser()},
                {LicenseContants.License.GAMEIDRXJ,new FootballRxjSingleUploadParser()},
                {LicenseContants.License.GAMEIDBQC,new FootballBqcSingleUploadParser()},
                {LicenseContants.License.GAMEIDJQC,new FootballJqcSingleUploadParser()},
                {LicenseContants.License.GAMEIDJCZQ,new GuessFootballSingleUploadParser()},
                {LicenseContants.License.GAMEIDJCLQ,new GuessBasketballSingleUploadParser()}
            };
            public static SingleUploadParser getSingleUploadParser(int licenseId)
            {
                //if (licenseId > 101)
                //{
                //    licenseId = FreqLicenseId.LICENSE_FREQ_SD11X5;
                //}
                return dic[licenseId];
            }
        }

        /// <summary>
        /// 生成单式上传订单
        /// </summary>
        /// <param name="lotteryOrder"></param>
        public int createSingleOrder(lottery_order lo)
        {
            SQLiteParameter[] paras = new SQLiteParameter[]{
                new SQLiteParameter("@bet_code",lo.bet_code),
                new SQLiteParameter("@bet_from",lo.bet_from),
                new SQLiteParameter("@bet_num",lo.bet_num),
                new SQLiteParameter("@bet_price",lo.bet_price),
                new SQLiteParameter("@bet_state",lo.bet_state),
                new SQLiteParameter("@bet_type",lo.bet_type),
                new SQLiteParameter("@canceled_num",lo.canceled_num),
                new SQLiteParameter("@canceled_money",lo.canceled_money),
                new SQLiteParameter("@com_port",lo.com_port),
                new SQLiteParameter("@del_date",lo.del_date),
                new SQLiteParameter("@errticket_num",lo.errticket_num),
                new SQLiteParameter("@ticket_money",lo.ticket_money),
                new SQLiteParameter("@id",lo.id),
                new SQLiteParameter("@issue",lo.issue),
                new SQLiteParameter("@license_id",lo.license_id),
                new SQLiteParameter("@mult_info",lo.mult_info),
                new SQLiteParameter("@multiple",lo.multiple),
                new SQLiteParameter("@order_date",lo.order_date),
                new SQLiteParameter("@err_ticket_sign_num",lo.err_ticket_sign_num),
                new SQLiteParameter("@pass_type",lo.pass_type),
                new SQLiteParameter("@play_type",lo.play_type),
                new SQLiteParameter("@sch_info",lo.sch_info),
                new SQLiteParameter("@single_flag",lo.single_flag),
                new SQLiteParameter("@storeid",lo.storeid),
                new SQLiteParameter("@ticket_num",lo.ticket_num),
                new SQLiteParameter("@ticket_date",lo.ticket_date),
                new SQLiteParameter("@ticket_oper",lo.ticket_oper),
                new SQLiteParameter("@total_money",lo.total_money),
                new SQLiteParameter("@total_tickets_num",lo.total_tickets_num),
                new SQLiteParameter("@userid",lo.userid),
                new SQLiteParameter("@username",lo.username),
                new SQLiteParameter("@is_in_feedback_form",lo.is_in_feedback_form),
                new SQLiteParameter("@is_in_print_form",lo.is_in_print_form),
                new SQLiteParameter("@is_in_error_form",lo.is_in_error_form),
                new SQLiteParameter("@stop_time",lo.stop_time),
                new SQLiteParameter("@expired_num",lo.expired_num),
                new SQLiteParameter("@expired_money",lo.expired_money)
            };

            string sql = String.Format(@"insert into lottery_order({0}) values({1})", lotteryOrderColumns, lotteryOrderParameters);

            try
            {
                return Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().ExecuteNonQuery(sql, paras);

                //object result = Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().GetSingle(@"SELECT max(id) FROM lottery_order");

                //if (result != null)
                //{
                //    return int.Parse(result.ToString());
                //}
                //else
                //{
                //    return 0;
                //}
            }
            catch (Exception e)
            {
                if (createSingleOrder(e))
                {
                    Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().ExecuteNonQuery(sql);

                    object result = Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().GetSingle(@"SELECT min(id) FROM lottery_order");

                    if (result != null)
                    {
                        return int.Parse(result.ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        public new SQLiteParameter[] GetSQLiteParameterArr(lottery_ticket lt)
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

        /// <summary>
        /// 生成单式上传票
        /// </summary>
        /// <param name="lt"></param>
        public int createSingleTicket(IList<lottery_ticket> tList)
        {
            try
            {
                string sql = string.Format("insert into lottery_ticket({0}) values({1})", lotteryTicketColumns, lotteryTicketParameters);
                List<SQLiteParameter[]> sqlParasList = new List<SQLiteParameter[]>();
                int ticketId = 1;
                foreach (lottery_ticket lt in tList)
                {
                    lt.ticket_id = ticketId;
                    sqlParasList.Add(GetSQLiteParameterArr(lt));
                    ticketId++;
                }
                SQLiteHelper.getBLLInstance().ExecuteSql(string.Format("UPDATE lottery_order SET total_tickets_num = '{0}'  WHERE id = '{1}'", tList.Count, tList[0].order_id));
                return SQLiteHelper.getBLLInstance().ExecuteSqlParasTran(sql, sqlParasList);
            }
            catch (Exception e)
            {
                if (createSingleTicket(e))
                {
                    string sql = string.Format("insert into lottery_ticket({0}) values({1})", lotteryTicketColumns, lotteryTicketParameters);
                    List<SQLiteParameter[]> sqlParasList = new List<SQLiteParameter[]>();
                    foreach (lottery_ticket lt in tList)
                    {
                        sqlParasList.Add(GetSQLiteParameterArr(lt));
                    }
                    return SQLiteHelper.getBLLInstance().ExecuteSqlParasTran(sql, sqlParasList);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 解析一行单式串，错误返回null
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        public string parse(int licenseId, string line)
        {
            SingleUploadParser sup = SingleUploadParserFactory.getSingleUploadParser(licenseId);
            return sup.parseLine(line);
        }

        /// <summary>
        /// 判断单式上传订单表是否存在 不存在则创建
        /// </summary>
        /// <returns></returns>
        public bool isSingleOrderExist()
        {
            string strOrderSingle = "SELECT id FROM lottery_order_single LIMIT 0,1";

            try
            {
                Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().Query(strOrderSingle);
                return true;
            }
            catch (Exception e)
            {
                return createSingleOrder(e);
            }
        }

        /// <summary>
        /// 判断单式上传票表是否存在 不存在则创建
        /// </summary>
        /// <returns></returns>
        public bool isSingleTicketExist()
        {
            string strTicketSingle = "SELECT ticket_id FROM lottery_ticket_single LIMIT 0,1";

            try
            {
                Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().Query(strTicketSingle);
                return true;
            }
            catch (Exception e)
            {
                return createSingleTicket(e);
            }
        }

        /// <summary>
        /// 创建单式上传订单表
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool createSingleOrder(Exception e)
        {
            if (e.Message.Contains("no such table"))
            {
                string sql = @"CREATE TABLE lottery_order_single (
'id'  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT 1,
'userid'  INTEGER,
'username'  TEXT(60),
'storeid'  INTEGER,
'license_id'  INTEGER,
'play_type'  TEXT(8),
'pass_type'  TEXT(60),
'order_date'  TEXT(30),
'single_flag'  TEXT(1),
'bet_code'  TEXT,
'bet_num'  INTEGER,
'multiple'  TEXT,
'bet_price'  TEXT,
'bet_state'  TEXT(2),
'issue'  TEXT(10),
'err_ticket_sign_num'  INTEGER NOT NULL DEFAULT 0,
'sch_info'  TEXT(4000),
'mult_info'  TEXT(1000),
'bet_from'  TEXT(1),
'bet_type'  TEXT(1),
'ticket_oper'  TEXT(60),
'canceled_num'  INTEGER NOT NULL DEFAULT 0,
'canceled_money'  INTEGER NOT NULL DEFAULT 0,
'errticket_num'  INTEGER NOT NULL DEFAULT 0,
'ticket_date'  TEXT(30),
'del_date'  TEXT(30),
'ticket_money'  INTEGER NOT NULL DEFAULT 0,
'com_port'  TEXT(10),
'ticket_num'  INTEGER NOT NULL DEFAULT 0,
'total_money'  INTEGER NOT NULL DEFAULT 0,
'total_tickets_num'  INTEGER NOT NULL DEFAULT 0,
'is_in_feedback_form'  INTEGER NOT NULL DEFAULT 0,
'is_in_print_form'  INTEGER NOT NULL DEFAULT 0,
'is_in_error_form'  INTEGER NOT NULL DEFAULT 0,
'stop_time'  TEXT(30),
'is_feedback'  INTEGER NOT NULL DEFAULT 0,
'expired_num'  INTEGER NOT NULL DEFAULT 0,
'expired_money'  INTEGER NOT NULL DEFAULT 0
);";
                Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().Query(sql);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 创建单式上传票表
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool createSingleTicket(Exception e)
        {
            if (e.Message.Contains("no such table"))
            {
                string sql = @"CREATE TABLE 'lottery_ticket_single' (
'ticket_id'  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL DEFAULT '1',
'order_id'  INTEGER NOT NULL DEFAULT '0',
'userid'  INTEGER NOT NULL DEFAULT NULL,
'username'  TEXT(60) NOT NULL DEFAULT NULL,
'storeid'  INTEGER NOT NULL DEFAULT NULL,
'license_id'  INTEGER NOT NULL,
'play_type'  TEXT(30) NOT NULL DEFAULT NULL,
'create_date'  TEXT(30) NOT NULL,
'ticket_date'  TEXT(30) DEFAULT NULL,
'bet_code'  TEXT(4000) NOT NULL DEFAULT NULL,
'bet_num'  TEXT(11) NOT NULL,
'multiple'  TEXT(11) NOT NULL,
'bet_price'  TEXT(19,2) NOT NULL,
'stop_time'  TEXT(30) DEFAULT NULL,
'ticket_state'  TEXT(2) NOT NULL,
'issue'  TEXT(10) NOT NULL,
'order_odds'  TEXT(400) DEFAULT NULL,
'ticket_odds'  TEXT(400) DEFAULT NULL,
'order_rqs'  TEXT(100) DEFAULT NULL,
'ticket_rqs'  TEXT(100) DEFAULT NULL,
'terminal_number'  TEXT(20) DEFAULT NULL,
'exc_handling_record'  TEXT(300) DEFAULT NULL,
'com_port'  TEXT(10) DEFAULT NULL,
'sent_num'  TEXT(256) DEFAULT NULL,
'exception_description'  TEXT(256) DEFAULT NULL,
'cancel_money'  TEXT(19,2) DEFAULT '0.00',
'zj_flag'  TEXT(1) NOT NULL DEFAULT 0,
'err_ticket_sign'  INTEGER NOT NULL DEFAULT 0,
'ticket_info'  TEXT(500),
'is_feedback'  INTEGER NOT NULL DEFAULT 0,
'return_pass_type'  TEXT,
'return_license_id'  INTEGER,
'return_license_name'  TEXT,
'return_issue'  TEXT,
'return_issue_num'  INTEGER,
'return_play_id'  INTEGER,
'return_play_name'  TEXT,
'return_multiple'  INTEGER,
'return_money'  INTEGER,
'return_bet_info'  TEXT
);";
                Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().Query(sql);
                return true;
            }
            else
            {
                return false;
            }
        }


        public int GetSingleOrderId()
        {
            object result = Maticsoft.Common.dbUtility.SQLiteHelper.getBLLInstance().GetSingle(@"SELECT min(id) FROM lottery_order");
            if (result != null)
            {
                if (int.Parse(result.ToString()) < 0)
                {
                    return int.Parse(result.ToString()) - 1; 
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
