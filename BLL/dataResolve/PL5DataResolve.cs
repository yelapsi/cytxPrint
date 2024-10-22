﻿using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class PL5DataResolve : IDataResolve
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
                    case PL5PlayType.ZHX_DS:
                        cmdstr = this.ZHX_DS(data);
                        break;
                    case PL5PlayType.ZHX_FS:
                        cmdstr = this.ZHX_FS(data);
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
        /// 直选单式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String ZHX_DS(String data)
        {
            try
            {
                return data.Replace(";", "").Replace(",", "");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选复式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String ZHX_FS(String data)
        {
            try
            {
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
