using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common;
using Maticsoft.Common.dbUtility;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Maticsoft.BLL.serviceimpl
{
   public class AutoTaskServiceImpl : IAutoTaskService
    {
       /// <summary>
        /// 是否存在可备份的数据
       /// </summary>
       /// <returns></returns>
        public bool isHasCanBackUpData()
        {            
            String sql = "SELECT count(*) FROM lottery_order WHERE is_feedback IN ('{0}','{1}') AND ticket_date < datetime('now', 'start of day','-7 day');";
            sql = String.Format(sql, new String[] { GlobalConstants.FeedbackState.SUCCESS.ToString(), GlobalConstants.FeedbackState.FAILED_PROCESSED.ToString() });
            try
            {
                int count = 0;

              object o =  SQLiteHelper.getBLLInstance().GetSingle(sql);
              int.TryParse(o.ToString(), out count);
              return count != 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

       /// <summary>
       /// 备份数据
       /// </summary>
       /// <param name="count"></param>
        public Boolean backUpData()
        {
            try
            {
                //1、查出要备份的订单
                String sql = String.Format("SELECT * FROM lottery_order WHERE is_feedback IN ('{0}','{1}') AND ticket_date < datetime('now', 'start of day','-7 day') limit 0,100;", new String[] { GlobalConstants.FeedbackState.SUCCESS.ToString(), GlobalConstants.FeedbackState.FAILED_PROCESSED.ToString() });

                List<lottery_order> olist = new List<lottery_order>();
                DataSet ds = SQLiteHelper.getBLLInstance().Query(sql, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    olist = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(ds);
                }
                else
                {
                    return false;
                }

                ArrayList sqllist = new ArrayList();
                foreach (lottery_order item in olist)
                {
                    //把订单插入备份表
                    sqllist.Add(String.Format("INSERT INTO lottery_order_history SELECT * FROM lottery_order where id ='{0}';", item.id.ToString()));
                    //把彩票插入彩票表
                    sqllist.Add(String.Format("INSERT INTO lottery_ticket_history SELECT * FROM lottery_ticket where order_id ='{0}';", item.id.ToString()));
                    //清除彩票
                    sqllist.Add(String.Format("DELETE FROM lottery_ticket where order_id ='{0}';", item.id.ToString()));
                    //清除订单
                    sqllist.Add(String.Format("DELETE FROM lottery_order where id ='{0}';", item.id.ToString()));
                    
                }

                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 清理过期数据
        /// </summary>
        public Boolean clearExpiredData()
        {
           try
           {
               //1、查出要备份的订单
               String sql = String.Format ( "SELECT * FROM lottery_order_history WHERE ticket_date < datetime('now', 'start of day','{0}') limit 0,100;", GlobalConstants.DataKeepTimeSQLDic [ Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME ] ] );

               List<lottery_order> olist = new List<lottery_order>();
               DataSet ds = SQLiteHelper.getBLLInstance().Query(sql, null);
               if (ds.Tables[0].Rows.Count > 0)
               {
                   olist = (List<lottery_order>)CollectionHelper.ConvertTo<lottery_order>(ds);
               }
               else
               {
                   return false;
               }

               ArrayList sqllist = new ArrayList();
               foreach (lottery_order item in olist)
               {
                   //清除彩票
                   sqllist.Add(String.Format("DELETE FROM lottery_ticket_history where order_id ='{0}';", item.id.ToString()));
                   //清除订单
                   sqllist.Add(String.Format("DELETE FROM lottery_order_history where id ='{0}';", item.id.ToString()));                   
               }

               SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
               return true;
           }
           catch (Exception)
           {
               throw new Exception("删除过期数据出错!");
           }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slclist"></param>
        /// <param name="slcmdlist"></param>
        /// <returns></returns>
        public Boolean updateSpeedLevel(List<SpeedLevelConfig> slclist, List<SpeedLevelCmd> slcmdlist)
        {
            //1、清空speed_level_cmd；2、清空speed_level_config；3、插入speed_level_config；4、插入speed_level_cmd

            ArrayList sqllist = new ArrayList();
            //1、清空speed_level_cmd
            sqllist.Add("DELETE FROM speed_level_cmd;");
            //1、清空speed_level_config
            sqllist.Add("DELETE FROM speed_level_config;");

            //3、插入speed_level_config
            foreach (SpeedLevelConfig slconfig in slclist)
            {
                speed_level_config item = new speed_level_config(slconfig);
                sqllist.Add(String.Format("INSERT INTO speed_level_config VALUES({0},{1},{2},{3},{4},{5},{6});", new String[] { item.speed_level, item.ticket_interval.ToString(), item.digital_interval.ToString(), item.enter_interval.ToString(), item.dynamic_interval_min.ToString(), item.dynamic_interval_max.ToString(), item.state.ToString() }));
            }

            //4、插入speed_level_cmd
            foreach (SpeedLevelCmd slcmd in slcmdlist)
            {
                speed_level_cmd item = new speed_level_cmd(slcmd);
                //加密入库
                item.Encrypt(GlobalConstants.KEY);
                sqllist.Add(String.Format("INSERT INTO speed_level_cmd VALUES('{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}');", new String[] { item.speed_level, item.cmd_code, item.cmd_type, item.license_id.ToString(), item.license_name, item.play_id.ToString(), item.play_name, item.ggfs_dfs, item.description, item.start_flow, item.first_flow, item.second_flow, item.third_flow, item.fourth_flow, item.fifth_flow, item.large_pass_flow }));
            }

            try
            {
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("更新速度级别配置出错!");
            }
        }
    }
}
