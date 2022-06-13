using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class DLTDataResolve : IDataResolve
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
                    case DLTPlayType.DS:
                        cmdstr = this.DLT_DS(data);
                        break;
                    case DLTPlayType.FS:
                        cmdstr = this.DLT_FS(data);
                        break;
                    case DLTPlayType.DT:
                        cmdstr = this.DLT_DT(data);
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
        private String DLT_DS(String data)
        {
            try
            {
                return data.Replace(",", "").Replace("+", "").Replace(";", "");
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
        private String DLT_FS(String data)
        {
            try
            {
                return "-" + data.Replace(",", "").Replace("+", "--");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 胆拖
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String DLT_DT(String data)
        {
            try
            {
                //前区和后驱分开
                String[] datas = data.Split('+');
                data = "";
                if (!String.IsNullOrEmpty(datas[0]))
                {
                    if (datas[0].Contains("("))
                    {
                        data += datas[0].Replace("(", "").Replace(",", "").Replace(")", "-");
                    }
                    else
                    {
                        data += "-" + datas[0].Replace(",", "");
                    }
                    data += "-";//输完前区调到后驱
                }
                if (!String.IsNullOrEmpty(datas[1]))
                {
                    if (datas[1].Contains("("))
                    {
                        data += datas[1].Replace("(", "").Replace(",", "").Replace(")", "-");
                    }
                    else
                    {
                        data += "-" + datas[1].Replace(",", "");
                    }
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
