﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.Common.model;
using System.Drawing;

namespace Maticsoft.Common.Util
{
    public class SysUtil
    {
        /// <summary>
        /// 去掉多余的小横杠
        /// </summary>
        /// <param name="Info"></param>
        /// <returns></returns>
        public static String RemoveExcessBars(String Info)
        {
            while (!String.IsNullOrEmpty(Info) && Info.Contains("--"))//保证没有两个--
            {
                Info = Info.Replace("--", "-");
            }

            return Info;
        }

        //根据彩种ID获取彩种图片
        public static Image GetLicenseImg(string licenseId)
        {
            if (int.Parse(licenseId) >= 100 && int.Parse(licenseId) < 200)
            {
                licenseId = "101";
            }

            if (GlobalConstants.ImgDictionary.ContainsKey(licenseId))
            {
                return ((Bitmap)global::Maticsoft.Common.Properties.Resource.ResourceManager.GetObject(GlobalConstants.ImgDictionary[licenseId], Maticsoft.Common.Properties.Resource.Culture));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 复原彩机
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static Boolean recoveryMachine(SerialPortInfo sp)
        {
            return true;
        }

        /// <summary>
        /// 发送大票密码
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="passw"></param>
        /// <returns></returns>
        public static Boolean sendLargeTicketPassw(SerialPortInfo sp,String passw)
        {
            return true;
        }

       /// <summary>
       /// 翻译采种名称
       /// </summary>
       /// <param name="licenseId"></param>
       /// <param name="play"></param>
       /// <returns></returns>
        public static String licenseNameTranslation(String licenseId)
        {
            
            StringBuilder sb = new StringBuilder();
            if (LicenseContants.licenseId2NameDictionary.ContainsKey(licenseId))
            {
                sb.Append(LicenseContants.licenseId2NameDictionary[licenseId]);
            }
            else {
                sb.Append("未知彩种");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 把票花翻译成数据库保存的字符串
        /// </summary>
        /// <param name="ticketInfo"></param>
        /// <returns></returns>
        public static String ticketInfoToDBStr(String ticketInfo)
        {
            ticketInfo = ticketInfo.Replace("\0", "&nbsp;");
            ticketInfo = ticketInfo.Replace("'", "’");
            ticketInfo = ticketInfo.Replace("\"", "&quot;");
            ticketInfo = ticketInfo.Replace("<", "&lt;");
            ticketInfo = ticketInfo.Replace(">", "&gt;");
            ticketInfo = ticketInfo.Replace("\n", "<br>");
            return ticketInfo;
        }

        /// <summary>
        /// 把数据库保存的字符串翻译成票花
        /// </summary>
        /// <param name="ticketInfo"></param>
        /// <returns></returns>
        public static String dbStrToTicketInfo(String dbStr)
        {
            //dbStr = dbStr.Replace("&nbsp;", "\0");
            //dbStr = dbStr.Replace( "’","'");
            //dbStr = dbStr.Replace("&quot;", "\"");
            //dbStr = dbStr.Replace("&lt;", "<");
            //dbStr = dbStr.Replace("&gt;", ">");
            //dbStr = dbStr.Replace("<br>", "\n");

            dbStr = dbStr.Replace("&nbsp;", "");
            dbStr = dbStr.Replace("’", "");
            dbStr = dbStr.Replace("&quot;", "");
            dbStr = dbStr.Replace("&lt;", "<");
            dbStr = dbStr.Replace("&gt;", ">");
            dbStr = dbStr.Replace("<br>", "\n");
            return dbStr;
        }


        /// <summary>
        /// 文件是否是音频文件
        /// </summary>
        /// <param name="Extension"></param>
        public static Boolean isAudioFile(String Extension) {
            String[] audioMap = new String[] {".wav",".mp3",".avi", ".swf",".jpg","mid"};
            foreach (String item in audioMap)
            {
                if (Extension.ToUpper().Equals(item.ToUpper()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}