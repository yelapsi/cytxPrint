using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util
{
   public class DateUtil
    {
       /// <summary>
        /// //第一种时间格式 yyyy-MM-dd HH:mm:ss
       /// </summary>
       public static String DATE_FMT_STR1 = "yyyy-MM-dd HH:mm:ss";//第一种时间格式
       
       /// <summary>
       /// //第二种时间格式 yyyy年MM月dd日 HH:mm:ss
       /// </summary>
       public static String DATE_FMT_STR2 = "yyyy年MM月dd日 HH:mm:ss";//第二种时间格式
       
       /// <summary>
       /// //第三种时间格式 yyMMdd
       /// </summary>
       public static String DATE_FMT_STR3 = "yyMMdd";//第三种时间格式

       /// <summary>
       /// //四种时间格式 yyyy-MM-dd
       /// </summary>
       public static String DATE_FMT_STR4 = "yyyy-MM-dd";//第四种时间格式

       /// <summary>
       /// 获取服务器时间
       /// </summary>
       /// <param name="formatStr"></param>
       /// <returns></returns>
       public static String getServerDateTime(String formatStr) {

           DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
           dt = dt.AddMilliseconds(Global.SysDateMillisecond);
           return dt.ToLocalTime().ToString(formatStr);
       }

       /// <summary>
       /// 获取服务器时间
       /// </summary>
       /// <param name="formatStr"></param>
       /// <returns></returns>
       public static String getServerDateTime(String formatStr,int second)
       {

           DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
           dt = dt.AddMilliseconds(Global.SysDateMillisecond + second*1000);
           return dt.ToLocalTime().ToString(formatStr);
       }

       public static DateTime getServerDateTime()
       {
           DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
           return dt.AddMilliseconds(Global.SysDateMillisecond);
       }

       /// <summary>
       ///  把日期翻译成星期(1-7)
       /// </summary>
       /// <param name="data">20150831->1</param>
       /// <returns></returns>
       public static String data2weekDayTranslation(String data) {
           DateTime d = DateTime.ParseExact(data, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            int w = (int)d.DayOfWeek;
            return w==0?(7).ToString():(w).ToString();
        }

       /// <summary>
       ///  把日期翻译成星期(周日---周六)
       /// </summary>
       /// <param name="date">20150831->周一</param>
       /// <returns></returns>
       public static String data2weekDayCStrTranslation(String date)
       {
           try {
               DateTime d = DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
               string[] weekdays = { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
               string week = weekdays[Convert.ToInt32(d.DayOfWeek)];

              return week;
           }catch(Exception){
               return null;
           }          
       }

       /// <summary>
       /// 把秒数翻译成时分秒的显示格式
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static String secondToHHmmss(long s,int type) {
           String[] type1 = new String[] { "小时 ","分 ","秒"};
           String[] type2 = new String[] { "H", "M", "S" };
           String[] type3 = new String[] { "h", "m", "s" };
           long hh=0,mm=0,ss=0;

           hh = s / (60 * 60);
           s = s % (60 * 60);

           mm = s / 60;
           ss = s % 60;

           if (type == 1) {
               return hh + type1[0] + mm + type1[1]+ss+type1[2];
           }

           if (type == 2)
           {
               return hh + type2[0] + mm + type2[1] + ss + type2[2];
           }
           return hh + type3[0] + mm + type3[1] + ss + type3[2];
       }
    }
}
