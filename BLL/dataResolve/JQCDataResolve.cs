using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class JQCDataResolve : IDataResolve
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
                    case JQCPlayType.DS:
                        cmdstr = this.JQC_DS(data);
                        break;
                    case JQCPlayType.FS:
                        cmdstr = this.JQC_FS(data);
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
        private String JQC_DS(String data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "");
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
        private String JQC_FS(String data)
        {
            try
            {
                return data.Replace(",", ">");
            }
            catch (Exception e)
            {
                throw e;
            }           
        }
    }
}
