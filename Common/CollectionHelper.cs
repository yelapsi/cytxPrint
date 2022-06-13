using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
namespace Maticsoft.Common
{
    public class CollectionHelper
    {
        public static IList<T> ConvertTo<T>(DataSet dataSet)
        {
            DataTable table = null;
            if (dataSet.Tables[0].Rows.Count > 0)
	        {
                table = dataSet.Tables[0];
            }
            else
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;
            if (rows != null)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }

        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                try
                {
                    obj = Activator.CreateInstance<T>();
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    object value = null;
                    try
                    {
                        value = row[column.ColumnName];
                        if (DBNull.Value.GetType() == value.GetType())
                        {
                            if (typeof(Int64) == prop.PropertyType)
                            {
                                prop.SetValue(obj, 0, null);
                            }
                            else
                            {
                                prop.SetValue(obj, "", null);
                            }
                        }
                        else
                        {
                            prop.SetValue(obj, value, null);
                        }
                    }
                    catch (Exception)
                    {
                        string str51 = prop.GetType().ToString();
                        string str52 = prop.MemberType.ToString();
                        string str53 = prop.PropertyType.ToString();
                        string str54 = prop.ReflectedType.ToString();
                        string str55 = prop.DeclaringType.ToString();
                        string str4 = DBNull.Value.GetType().ToString();
                        string str3 = value.GetType().ToString();
                        string str2 = obj.GetType().ToString();
                        string str = column.ColumnName;
                        throw;
                    }
                }
            }
            return obj;
        }
    }
}
