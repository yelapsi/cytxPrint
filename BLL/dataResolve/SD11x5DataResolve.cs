using Maticsoft.Common.dataResolve;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.dataResolve
{
    public class SD11x5DataResolve : IDataResolve
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
                    case SD11X5PlayType.Q1DS:
                        cmdstr = this.Q1DS(data);
                        break;
                    case SD11X5PlayType.Q1FS:
                        cmdstr = this.Q1FS(data);
                        break;
                    case SD11X5PlayType.R2DS:
                        cmdstr = this.R2DS(data);
                        break;
                    case SD11X5PlayType.R2FS:
                        cmdstr = this.R2FS(data);
                        break;
                    case SD11X5PlayType.R2DT:
                        cmdstr = this.R2DT(data);
                        break;
                    case SD11X5PlayType.Q2ZX:
                        cmdstr = this.Q2ZX(data);
                        break;
                    case SD11X5PlayType.Q2ZXFS: // 前二直选复式
                        cmdstr = this.Q2ZXFS(data);
                        break;
                    case SD11X5PlayType.Q2ZX_DS: //前二组选普通单式
                        cmdstr = this.Q2ZX_DS(data);
                        break;
                    case SD11X5PlayType.Q2ZX_FS://前二组选普通复式
                        cmdstr = this.Q2ZX_FS(data);
                        break;
                    case SD11X5PlayType.Q2ZX_DT://前二组选胆拖
                        cmdstr = this.Q2ZX_DT(data);
                        break;
                    case SD11X5PlayType.R3DS:// 任三普通单式
                        cmdstr = this.R3DS(data);
                        break;
                    case SD11X5PlayType.R3FS:// 任三普通复式
                        cmdstr = this.R3FS(data);
                        break;
                    case SD11X5PlayType.R3DT:// 任三胆拖
                        cmdstr = this.R3DT(data);
                        break;
                    case SD11X5PlayType.Q3ZX: // 前三直选
                        cmdstr = this.Q3ZX(data);
                        break;
                    case SD11X5PlayType.Q3ZXFS: // 前三直选复式
                        cmdstr = this.Q3ZXFS(data);
                        break;
                    case SD11X5PlayType.Q3ZX_DS: //前三组选普通单式
                        cmdstr = this.Q3ZX_DS(data);
                        break;
                    case SD11X5PlayType.Q3ZX_FS: //前三组选普通复式
                        cmdstr = this.Q3ZX_FS(data);
                        break;
                    case SD11X5PlayType.Q3ZX_DT:  //前三组选胆拖
                        cmdstr = this.Q3ZX_DT(data);
                        break;
                    case SD11X5PlayType.R4DS:// 任四普通单式
                        cmdstr = this.R4DS(data);
                        break;
                    case SD11X5PlayType.R4FS: //任四普通复式
                        cmdstr = this.R4FS(data);
                        break;
                    case SD11X5PlayType.R4DT://任四胆拖
                        cmdstr = this.R4DT(data);
                        break;
                    case SD11X5PlayType.R5DS:  // 任五普通单式
                        cmdstr = this.R5DS(data);
                        break;
                    case SD11X5PlayType.R5FS:  // 任五普通复式
                        cmdstr = this.R5FS(data);
                        break;
                    case SD11X5PlayType.R5DT:  // // 任五胆拖
                        cmdstr = this.R5DT(data);
                        break;
                    case SD11X5PlayType.R6DS:// // 任六普通单式
                        cmdstr = this.R6DS(data);
                        break;
                    case SD11X5PlayType.R6FS: //// 任六普通复式
                        cmdstr = this.R6FS(data);
                        break;
                    case SD11X5PlayType.R6DT: // // 任六胆拖
                        cmdstr = this.R6DT(data);
                        break;
                    case SD11X5PlayType.R7DS: // // 任七普通单式
                        cmdstr = this.R7DS(data);
                        break;
                    case SD11X5PlayType.R7FS: // // 任七普通复式
                        cmdstr = this.R7FS(data);
                        break;
                    case SD11X5PlayType.R7DT: //  // 任七胆拖
                        cmdstr = this.R7DT(data);
                        break;
                    case SD11X5PlayType.R8DS: //  // 任八普通单式
                        cmdstr = this.R8DS(data);
                        break;
                    case SD11X5PlayType.R8FS: //  // 任八普通复式
                        cmdstr = this.R8FS(data);
                        break;
                    default: // R8DT// 任八胆拖
                        cmdstr = this.R8DT(data);
                        break;
                }

                return cmdstr;
            }
            catch (Exception e)
            {
                throw e;
            }                        
    }

        private string R8DT(string data)
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

        private string R8FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        private string R8DS(string data)
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

        private string R7DT(string data)
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

        private string R7FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string R7DS(string data)
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

        private string R6DT(string data)
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

        private string R6FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        private string R6DS(string data)
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

        private string R5DT(string data)
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

        private string R5FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string R5DS(string data)
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

        private string R4DT(string data)
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

        private string R4FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string R4DS(string data)
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

        private string Q3ZX_DT(string data)
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

        private string Q3ZX_FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string Q3ZX_DS(string data)
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

        private string Q3ZXFS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string Q3ZX(string data)
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

        private string R3DT(string data)
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

        private string R3FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string R3DS(string data)
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

        private string Q2ZX_DT(string data)
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

        private string Q2ZX_FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private string Q2ZX_DS(string data)
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
        /// 前二直选复式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Q2ZXFS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 前二直选单式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Q2ZX(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "");
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        /// <summary>
        /// 任二胆拖
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string R2DT(string data)
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
        /// 任二复式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string R2FS(string data)
        {
            try
            {
                return data.Replace(",", "").Replace(";", "").Replace("|", "-");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 任二单式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string R2DS(string data)
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
        /// 前一复式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Q1FS(string data)
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
        /// 前一单式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Q1DS(string data)
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
    }
}
