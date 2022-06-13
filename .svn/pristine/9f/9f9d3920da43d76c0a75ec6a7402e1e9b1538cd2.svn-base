using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Maticsoft.Common.dbUtility
{
   public class SQLBuilderUtil
    {
        /// <summary>
        /// 给定对象生成插入语句
        /// </summary>
        /// <param name="IncrePK">自增主键</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String objToInsertSQLString(String IncrePK, Object obj)
        {

            String tablename = obj.GetType().Name;
            StringBuilder sb = new StringBuilder();
            StringBuilder rowssb = new StringBuilder();
            StringBuilder valuesb = new StringBuilder();

            PropertyInfo[] ps = obj.GetType().GetProperties();
            for (int i = 0; i < ps.Length; i++)
            {
                if (String.IsNullOrEmpty(IncrePK) || !IncrePK.Equals(ps[i].Name))
                {
                    rowssb.Append(ps[i].Name + ((i < ps.Length - 1) ? "," : ""));
                    valuesb.Append("'"+ps[i].GetValue(obj, null) + ((i < ps.Length - 1) ? "'," : "'"));
                }
            }

            sb.AppendFormat("INSERT INTO {0} ({1}) VALUES ({2});", new String[] { obj.GetType().Name, rowssb.ToString(), valuesb.ToString() });
            return sb.ToString();
        }

        /// <summary>
        /// 根据字典表生成set 部分语句
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static String dictionaryToSelectSQLString(Type type,Dictionary<String, String> param)
        {

            if (null == param || param.Count == 0)
            {
                return String.Empty;
            }
            StringBuilder rowssb = new StringBuilder();

            PropertyInfo[] ps = type.GetProperties();
            for (int i = 0; i < ps.Length; i++)
            {
                rowssb.Append(ps[i].Name + ((i < ps.Length - 1) ? "," : ""));
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT {0} FROM {1}{2}", new String[] {rowssb.ToString(), type.Name, SQLBuilderUtil.dictionaryToWhereSQLString(param) });
   
            return sb.ToString();
        }

        /// <summary>
        /// 根据字典表生成where 部分语句
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static String dictionaryToWhereSQLString(Dictionary<String, String> param)
        {

            if (null == param || param.Count == 0)
            {
                return String.Empty;
            }
            StringBuilder sb = new StringBuilder(" WHERE ");
            List<string> keys = new List<string>(param.Keys);
            for (int i = 0; i < param.Count; i++)
            {
                sb.Append((keys[i] + "='" + param[keys[i]] + "'") + ((i < param.Count - 1) ? " AND " : ""));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据字典表生成set 部分语句
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static String dictionaryToSetSQLString(Dictionary<String, String> param)
        {

            if (null == param || param.Count == 0)
            {
                return String.Empty;
            }
            StringBuilder sb = new StringBuilder(" SET ");
            List<string> keys = new List<string>(param.Keys);
            for (int i = 0; i < param.Count; i++)
            {
                sb.Append((keys[i] + "='" + param[keys[i]] + "'") + ((i < param.Count - 1) ? "," : ""));
            }
            return sb.ToString();
        }

       /// <summary>
        /// 根据字典表生成修改语句
       /// </summary>
       /// <param name="tablename"></param>
       /// <param name="sparam"></param>
       /// <param name="wparam"></param>
       /// <returns></returns>
        public static String dictionaryToSetAndWhereSQLString(String tablename,Dictionary<String, String> sparam, Dictionary<String, String> wparam)
        {

            if (null == sparam || sparam.Count == 0)
            {
                return String.Empty;
            }
            StringBuilder sb = new StringBuilder("UPDATE " + tablename + SQLBuilderUtil.dictionaryToSetSQLString(sparam) + SQLBuilderUtil.dictionaryToWhereSQLString(wparam));
            return sb.ToString();
        }
    }
}
