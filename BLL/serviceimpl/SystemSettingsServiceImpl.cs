using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Common.model;
using System.Data.SQLite;
using System.Data;
using System.Collections;
using Maticsoft.Common.dbUtility;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common.Util;

namespace Maticsoft.BLL.serviceimpl
{
    public class SystemSettingsServiceImpl : BaseServiceImpl, ISystemSettingsService
    {

        #region 系统设置
        /// <summary>
        /// 初始化系统设置
        /// </summary>
        /// <returns></returns>
        public int initSystemConfig ( ) {
            //先删除两张废表——其实不删也可以，主要是为了精简
            try
            {
                int num = 0;
                Object o1 = SQLiteHelper.getBLLInstance ( ).GetSingle (
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' and name='reserved_fields';" );
                int.TryParse ( o1.ToString ( ), out num );
                if ( num != 0 )//删除表
                {
                    SQLiteHelper.getBLLInstance ( ).ExecuteSql ( "DROP TABLE reserved_fields;" );
                }

                num = 0;
                Object o2 = SQLiteHelper.getBLLInstance ( ).GetSingle (
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' and name='sys_config';" );
                int.TryParse ( o2.ToString ( ), out num );
                if ( num != 0 )//删除表
                {
                    SQLiteHelper.getBLLInstance ( ).ExecuteSql ( "DROP TABLE sys_config;" );
                }
            }
            catch ( Exception )
            { }
          
            //...........................
            int result = 0;
            Object o = SQLiteHelper.getBLLInstance ( ).GetSingle (
                "SELECT COUNT(*) FROM sqlite_master WHERE type='table' and name='system_config';" );
            int.TryParse (o.ToString(),out result );
            if ( result == 0 )//创建表
            {
                SQLiteHelper.getBLLInstance ( ).ExecuteSql ( @"CREATE TABLE 'system_config' ('key'  TEXT NOT NULL,
                'value'  TEXT,'type'  TEXT NOT NULL,'description'  TEXT,PRIMARY KEY ('key'));" ); 
            }
            List<system_config> sclist = getSystemConfig ( );
            Dictionary<String,String> temp = new Dictionary<string, string> ( );            
            foreach ( system_config item in sclist )
            {
                temp.Add ( item.key, item.value );
            }

            ArrayList sqls = new ArrayList ( );
            foreach ( String key in GlobalConstants.SYSTEM_CONFIG_KEYS_MAP.Keys )
            {
                if ( !temp.ContainsKey ( key ) )
                {
                    String value = String.Empty;
                    switch ( key )
                    {
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL:
                            value = GlobalConstants.PRINTER_MODEL.RGK532;
                            break;
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE:
                            value = GlobalConstants.PRINT_TYPE.MACHINE;
                            break;                        
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE:
                            value = PCodeConstant.CODE.NATIONWIDE;
                            break;
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.SERVER_TYPE:
                            value = GlobalConstants.SERVER_TYPE.O2O;
                            break;
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK:
                            value = GlobalConstants.TrueFalseSign.TRUE.ToString();
                            break;
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE:
                            value = "20";
                            break;
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.DATA_KEEP_TIME:
                            value = "1";
                            break;
                        case GlobalConstants.SYSTEM_CONFIG_KEYS.CONTROLDATA_UPDATE_DATE:
                            value = "2015-12-31";
                            break;
                        default:
                            value = "";
                            break;
                    }
                    sqls.Add ( String.Format ( "INSERT INTO system_config (key,value,type,description) values ('{0}','{1}','{2}','{3}');",
                     new String [ ] { key, value,"String", GlobalConstants.SYSTEM_CONFIG_KEYS_MAP [ key ] } ) );
                }
            }
            SQLiteHelper.getBLLInstance ( ).ExecuteSqlTran ( sqls );
            return sqls.Count;
        }
        /// <summary>
        /// 查询系统配置对象(整个系统只有一条数据)
        /// </summary>
        /// <returns></returns>
        public List<system_config> getSystemConfig ( )
        {
            List<system_config> sclist = new List<system_config> ( );
            try
            {
                DataSet ds = SQLiteHelper.getBLLInstance().Query("SELECT * FROM system_config;");
                if (null != ds && ds.Tables[0].Rows.Count > 0)
                {
                    sclist = ( List<system_config> ) CollectionHelper.ConvertTo<system_config> ( ds );
                }

                return sclist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改sys_config信息
        /// </summary>
        /// <returns></returns>
        public Boolean updateSystemConfig ( Dictionary<String, String> kv )
        {
            try
            {
                ArrayList sql = new ArrayList ( );
                foreach ( String key in kv.Keys )
                {
                    sql.Add ( String.Format ( "UPDATE system_config set value='{0}' WHERE key='{1}';", new String [ ] { kv [ key ], key} ) );
                }
                
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion 系统设置

        #region 店铺彩机
        /// <summary>
        /// 查询所有的店铺彩机
        /// </summary>
        /// <returns></returns>
        public List<store_machine> getAllStoreMachine()
        {
            try
            {
                List<store_machine> sclist = (List<store_machine>)CollectionHelper.ConvertTo<store_machine>(SQLiteHelper.getBLLInstance().Query("SELECT * FROM store_machine;"));
                if (null == sclist || sclist.Count == 0)
                {
                    return new List<store_machine>();
                }
                return sclist;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据Id获取机器信息
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public store_machine getStoreMachineById(String mId)
        {
            try
            {
                SQLiteParameter[] paras = new SQLiteParameter[]{
                new SQLiteParameter("@terminal_number",mId)};
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("SELECT * FROM store_machine where terminal_number = @terminal_number");
                DataTable dt = SQLiteHelper.getBLLInstance().ExecuteTable(sbsql.ToString(), paras);
                return (store_machine)(null == dt || null == dt.Rows ? null : Maticsoft.Common.Util.DataUtil.ToEntity(dt.Rows[0], typeof(store_machine)));
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 插入一条店铺彩机数据
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public Boolean insertStoreMachine(store_machine machine, List<machine_can_print_license> l)
        {
            try
            {
                ArrayList sqllist = new ArrayList();
                //插入店铺彩机
                sqllist.Add(SQLBuilderUtil.objToInsertSQLString("", machine));
                //插入彩机支持彩种
                foreach (machine_can_print_license li in l)
                {
                    sqllist.Add("INSERT INTO machine_can_print_license(terminal_number,machine_name,machine_code,type,license_id,license_name) VALUES('" + machine.terminal_number + "','" + machine.machine_name + "','" + machine.machine_code + "','" + machine.machine_type + "','" + li.license_id + "','" + li.license_name + "');");
                }

                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("插入店铺彩机操作出错!");
            }
        }

        /// <summary>
        /// 修改一条店铺彩机数据
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public Boolean updateStoreMachine(store_machine machine, List<machine_can_print_license> l)
        {
            try
            {
                ArrayList sqllist = new ArrayList();
                Dictionary<String, String> param = new Dictionary<String, String>(){
                {"com_name",machine.com_name},
                {"com_baudrate",machine.com_baudrate.ToString()},
                {"com_databits",machine.com_databits.ToString()},
                {"com_stopbits",machine.com_stopbits},
                {"com_parity",machine.com_parity},
                //{"terminal_number",machine.terminal_number},
                {"is_feed_back",machine.is_feed_back.ToString()},
           {"speed_level",machine.speed_level.ToString()},
            {"big_ticket_amount",machine.big_ticket_amount.ToString()},
            {"big_ticket_pass",machine.big_ticket_pass},
           // {"is_auto_ticket",machine.is_auto_ticket.ToString()},
            {"is_continuous_ticket",machine.is_continuous_ticket.ToString()},
            {"is_compl_auto_stop",machine.is_compl_auto_stop.ToString()}
               };

                sqllist.Add("update store_machine " + SQLBuilderUtil.dictionaryToSetSQLString(param) + " WHERE terminal_number='" + machine.terminal_number + "';");

                //清除彩机对应的彩种
                sqllist.Add("delete from machine_can_print_license  where terminal_number='" + machine.terminal_number + "';");
                //加入彩机对应的彩种
                foreach (machine_can_print_license li in l)
                {
                    sqllist.Add("INSERT INTO machine_can_print_license VALUES('" + machine.terminal_number + "','" + li.license_id + "','" + li.license_name + "');");
                }

                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("修改店铺彩机操作出错!");
            }
        }

        /// <summary>
        /// 删除一条店铺彩机数据
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public Boolean deleteStoreMachineById(String mId)
        {
            try
            {
                ArrayList sqllist = new ArrayList();
                //清除彩机对应的彩种
                sqllist.Add("delete from machine_can_print_license  where terminal_number='" + mId + "';");
                sqllist.Add("delete from store_machine  where terminal_number='" + mId + "'");
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("修改店铺彩机操作出错!");
            }
        }


        /// <summary>
        /// 获取指定彩机所有的支持采种信息
        /// </summary>
        /// <returns></returns>
        public List<machine_supported_license> getMachineSupportedLicenseByTId(String tId)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("SELECT * FROM machine_supported_license where terminal_number='" + tId + "'");
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sbsql.ToString(), null);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    List<machine_supported_license> ltList = (List<machine_supported_license>)CollectionHelper.ConvertTo<machine_supported_license>(dt);
                    return ltList;
                }
                else
                {
                    return new List<machine_supported_license>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取所有彩机支持的采种信息
        /// </summary>
        /// <returns></returns>
        public List<machine_can_print_license> getMachineCanPrintLicense()
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("SELECT * FROM machine_can_print_license;");
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sbsql.ToString(), null);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    List<machine_can_print_license> ltList = (List<machine_can_print_license>)CollectionHelper.ConvertTo<machine_can_print_license>(dt);
                    return ltList;
                }
                else
                {
                    return new List<machine_can_print_license>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 获取指定彩机所有的可打印采种信息
        /// </summary>
        /// <returns></returns>
        public List<machine_can_print_license> getMachineCanPrintLicenseByTId(String tId)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("SELECT * FROM machine_can_print_license where terminal_number='" + tId + "'");
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sbsql.ToString(), null);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    List<machine_can_print_license> ltList = (List<machine_can_print_license>)CollectionHelper.ConvertTo<machine_can_print_license>(dt);
                    return ltList;
                }
                else
                {
                    return new List<machine_can_print_license>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 删除机器彩种表中对应机器的数据
        /// </summary>
        /// <returns></returns>
        public Boolean delMachineLicenseBymId(String mId)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("delete from machine_can_print_license  where terminal_number='" + mId + "'");
                return (SQLiteHelper.getBLLInstance().ExecuteNonQuery(sbsql.ToString()) > 0);
            }
            catch (Exception)
            {
                throw new Exception("删除机器彩种表中对应机器的数据出错!");
            }
        }


        /// <summary>
        /// 向店铺彩机表中插入数据
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public Boolean insertMachineLicense(store_machine sm, List<machine_can_print_license> l)
        {            
            try
            {
                if (null == l || l.Count == 0)
                {
                    return false;
                }

                ArrayList sqllist = new ArrayList();
                foreach (machine_can_print_license li in l)
                {
                    sqllist.Add("INSERT INTO machine_can_print_license VALUES(" + sm.terminal_number + "," + sm.machine_name + "," + sm.machine_code + "," + sm.machine_type + "," + li.license_id + "," + li.license_name + ");");
                }
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("向店铺彩机表中插入数据出错!");
            }
        }
        #endregion

        #region 速度等级、流程控制
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<speed_level_config> getAllSpeedLevelConfig()
        {
            try
            {
                List<speed_level_config> slclist = (List<speed_level_config>)CollectionHelper.ConvertTo<speed_level_config>(SQLiteHelper.getBLLInstance().Query("SELECT * FROM speed_level_config;"));
                if (null == slclist || slclist.Count == 0)
                {
                    return new List<speed_level_config>();
                }
                return slclist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据参数查询对应的流程控制记录
        /// </summary>
        /// <param name="machine_id"></param>
        /// <param name="license_id"></param>
        /// <param name="numbering"></param>
        /// <returns></returns>
        public List<speed_level_cmd> getSpeedLevelCmdByParams(Dictionary<String, String> param)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("SELECT * FROM speed_level_cmd");
                if (null != param && param.Count > 0)
                {
                    sbsql.Append(" where ");

                    List<string> keyslist = new List<string>(param.Keys);
                    for (int i = 0; i < keyslist.Count; i++)
                    {
                        sbsql.Append(keyslist[i] + "='" + param[keyslist[i]] + "'" + (i == keyslist.Count - 1 ? ";" : " and "));
                    }
                }
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sbsql.ToString(), null);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    List<speed_level_cmd> ltList = (List<speed_level_cmd>)CollectionHelper.ConvertTo<speed_level_cmd>(dt);
                    return ltList;
                }
                else
                {
                    return new List<speed_level_cmd>();
                }
            }
            catch (Exception)
            {
                throw new Exception("查询出错!");
            }
        }
        #endregion 速度等级、流程控制

        #region 错误操作选择
        /// <summary>
        /// 查询所有的错误处理方式
        /// </summary>
        /// <returns></returns>
        public List<error_handling> getAllErrorHandling()
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.Append("SELECT * FROM error_handling");
                DataSet dt = SQLiteHelper.getBLLInstance().Query(sbsql.ToString(), null);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    List<error_handling> ltList = (List<error_handling>)CollectionHelper.ConvertTo<error_handling>(dt);
                    return ltList;
                }
                else
                {
                    return new List<error_handling>();
                }
            }
            catch (Exception)
            {
                throw new Exception("查询出错!");
            }
        }

        /// <summary>
        /// 修改错误处理方式
        /// </summary>
        /// <param name="errorhandling"></param>
        /// <returns></returns>
        public Boolean updateErrorHandling(error_handling errorhandling)
        {
            try
            {
                StringBuilder sbsql = new StringBuilder();
                sbsql.AppendFormat("UPDATE error_handling SET handle_code = '{0}' where error_code='{1}';", new String[] { errorhandling.handle_code.ToString(), errorhandling.error_code });
                return (SQLiteHelper.getBLLInstance().ExecuteSql(sbsql.ToString()) > 0);

            }
            catch (Exception)
            {
                throw new Exception("修改错误处理方式出错!");
            }
        }
        #endregion 错误操作选择
    }
}
