using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class RX9DataResolve : IDataResolve
    {
        /// <summary>
        /// 投注数据转换为命令数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ticketDataToCommand(string data, int playType)
        {
            try
            {
                String cmdstr = String.Empty;
                switch (playType)
                {
                    case R9PlayType.DS:
                        cmdstr = this.R9_DS(data);
                        break;
                    case R9PlayType.FS:
                        cmdstr = this.R9_FS(data);
                        break;
                }
                return cmdstr;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 单式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String R9_DS(String data)
        {
            try
            {
                String[] ds = data.Split(';');
                StringBuilder sb = new StringBuilder();
                foreach (String s in ds)
                {
                    String fs = s;
                    fs = fs.Replace("|", "").Replace(",", "");
                    while (fs.EndsWith("#"))
                    {
                        fs = fs.Remove(fs.Length - 1);
                    }

                    sb.Append(fs.Replace("#", ">"));
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 复式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String R9_FS(String data)
        {
            try
            {
                String[] ds = data.Split('|');
                StringBuilder sb = new StringBuilder();
                foreach (String fs in ds)
                {
                    sb.Append(fs.Replace("#", "") + ">");
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
