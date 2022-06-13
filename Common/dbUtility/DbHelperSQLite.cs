using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Maticsoft.Common.dbUtility
{
    /// <summary>
    /// Copyright (C) 2011 Maticsoft 
    /// 数据访问基础类(基于SQLite)
    /// 可以用户可以修改满足自己项目的需要。
    /// </summary>
    public abstract class DbHelperSQLite
    {

        #region 公用方法

        public abstract int GetMaxID(string FieldName, string TableName);
        public abstract bool Exists(string strSql);
        public abstract bool Exists(string strSql, params SQLiteParameter[] cmdParms);

        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public abstract int ExecuteSql(string SQLString);

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public abstract void ExecuteSqlTran(ArrayList SQLStringList);
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public abstract int ExecuteSql(string SQLString, string content);
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public abstract int ExecuteSqlInsertImg(string strSQL, byte[] fs);

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public abstract object GetSingle(string SQLString);
        /// <summary>
        /// 执行查询语句，返回SQLiteDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SQLiteDataReader</returns>
        public abstract SQLiteDataReader ExecuteReader(string strSQL);

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public abstract DataSet Query(string SQLString);

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public abstract int ExecuteSql(string SQLString, params SQLiteParameter[] cmdParms);

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SQLiteParameter[]）</param>
        public abstract void ExecuteSqlTran(Hashtable SQLStringList);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="SQLParasList"></param>
        /// <returns></returns>
        public abstract int ExecuteSqlParasTran(string SQLString, List<SQLiteParameter[]> SQLParasList);

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public abstract object GetSingle(string SQLString, params SQLiteParameter[] cmdParms);

        /// <summary>
        /// 执行查询语句，返回SQLiteDataReader
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SQLiteDataReader</returns>
        public abstract SQLiteDataReader ExecuteReader(string SQLString, params SQLiteParameter[] cmdParms);


        /// <summary>
        /// insert、delete、update
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns> return the number of the altered lines </returns>
        public abstract int ExecuteNonQuery(string SQLString, params SQLiteParameter[] ps);

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public abstract DataSet Query(string SQLString, params SQLiteParameter[] cmdParms);


        /// <summary>
        /// 查询，返回表
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="ps"></param>
        /// <returns></returns>
        public abstract DataTable ExecuteTable(string SQLString, params SQLiteParameter[] ps);

        public abstract void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText, SQLiteParameter[] cmdParms);

        #endregion
    }
}
