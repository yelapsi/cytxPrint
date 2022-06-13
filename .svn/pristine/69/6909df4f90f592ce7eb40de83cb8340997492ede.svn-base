using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL.dataResolve;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;

namespace Maticsoft.Common.dataResolve
{
    class PL3DataResolve :  IDataResolve
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
                    case PL3PlayType.PLSZHXDS:
                        cmdstr = this.ZHX_DS(data);
                        break;
                    case PL3PlayType.PLSZHXFS:
                        cmdstr = this.ZHX_FS(data);
                        break;
                    case PL3PlayType.PLSZHXHZ:
                        cmdstr = this.ZHX_HZ(data);
                        break;
                    case PL3PlayType.PLSZHXZHDT:
                        cmdstr = this.ZHX_ZHDT(data);
                        break;
                    case PL3PlayType.PLSZHXZHFS:
                        cmdstr = this.ZHX_ZHFS(data);
                        break;
                    case PL3PlayType.PLSZLDS:
                        cmdstr = this.ZL_DS(data);
                        break;
                    case PL3PlayType.PLSZLDT:
                        cmdstr = this.ZL_DT(data);
                        break;
                    case PL3PlayType.PLSZLFS:
                        cmdstr = this.ZL_FS(data);
                        break;
                    case PL3PlayType.PLSZLHZ:
                        cmdstr = this.ZL_HZ(data);
                        break;
                    case PL3PlayType.PLSZSDT:
                        cmdstr = this.ZS_DT(data);
                        break;
                    case PL3PlayType.PLSZSFS:
                        cmdstr = this.ZS_FS(data);
                        break;
                    case PL3PlayType.PLSZSHZ:
                        cmdstr = this.ZS_HZ(data);
                        break;
                    case PL3PlayType.PLSZXDS:
                        cmdstr = this.ZHX_ZXDS(data);
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
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZHX_DS(string data)
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
        /// 直选复式
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZHX_FS(String data) {
            try
            {
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选组合复式
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZHX_ZHFS(String data)
        {
            try
            {
                return data.Replace(",", "");
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        /// <summary>
        /// 直选和值
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZHX_HZ(String data)
        {
            try
            {
                String[] ds = data.Split(',');
                data = String.Empty;
                foreach (String d in ds)
                {
                    data += d.Length == 1 ? "0" + d : d;
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        /// <summary>
        /// 直选组合胆拖
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZHX_ZHDT(String data)
        {
            try
            {
                return data.Replace("(", "").Replace(",", "").Replace(")", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选组选单式(组三单式)
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZHX_ZXDS(String data)
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
        /// 直选组三复式
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZS_FS(String data)
        {
            try
            {
                return data.Replace(",", "");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选组三和值
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZS_HZ(String data)
        {
            try
            {
                String[] ds = data.Split(',');
                data = String.Empty;
                foreach (String d in ds)
                {
                    data += d.Length == 1 ? "0" + d : d;
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选组三胆拖
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZS_DT(String data)
        {
            try
            {
                return data.Replace("(", "").Replace(",", "").Replace(")", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选组六单式
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZL_DS(String data)
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
        /// 直选组六复式
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZL_FS(String data)
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

        /// <summary>
        /// 直选组六和值
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZL_HZ(String data)
        {
            try
            {
                String[] ds = data.Split(',');
                data = String.Empty;
                foreach (String d in ds)
                {
                    data += d.Length == 1 ? "0" + d : d;
                }
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 直选组六胆拖
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <returns>解析后的投注内容</returns>
        private String ZL_DT(String data)
        {
            try
            {
                return data.Replace("(", "").Replace(",", "").Replace(")", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
    }
}
