using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Maticsoft.BLL.cmdResolve
{
   public class CmdResovleUtil
    {       
        /// <summary>
        /// 特殊节点的相关数据
        /// </summary>
        public static class SPECIAL_KEY_DATAS {
            public static String[] lineBreaks = new String[] {"1B-64-01" };  // 代替换行
            public static String[] nonStandardpcmd = new String[] {//非标准打印命令
                "1B-21-00","1B-21-01","1B-4D-00","1B-4D-01","1B-4D-04","1D-21-10","1D-21-00","1B-61-01","1B-61-00","00-30-00","00-30-01",
                "1D-50-CB-CB","1C-28-41-02"
                ,"1D-57-40-02","1D-57-70-02"//这两个字符串是跟在开始字符之后的，为了使开始字符量少一点，单独提出来
            }; //非标准打印命令
            public static String[] Prt_Cmd4_Str = new String[] { "1B-63-30-99", "1B-1D-49-01" }; //四字节打印命令1B-1D-49-01-1B-61-31
            public static String[] Prt_Cmd3_Str = new String[] {"1B-33-17","1B-33-1A","1B-33-1B","1B-33-1D","1B-33-1E","1B-33-20","1B-33-21","1B-33-22","1B-33-25","1B-33-2A","1B-45-01", "1B-45-00",
"1B-4A-01","1B-4A-02","1B-4A-03","1B-4A-04","1B-61-31","1B-63-30","1B-64-02","1B-64-03","1B-64-04","1B-64-05"};//三字节打印命令         

            public static String[] Prt_Cmd_Start_Str = new String[] { "4C-00-00-", "4C-03-00-" };    // 开始字节 
            public static String[] Prt_Cmd_End_Str = new String[] {"-A3-A1-A3-A1-A3-A1",
                "-1B-1D-78-53-30","-1D-70-04","-1D-28-6B-03-00",
            "-1D-56-01","-1D-56-42"//这两个是参考老版本，并没有验证
            }; // 结束字节""-A3-A1-A3-A1-A3-A1测试机型"
        }

        /// <summary>
        /// 把回馈数据翻译成可读的票花数据
        /// </summary>
        /// <param name="rData"></param>
        /// <returns></returns>
        public static String CMD2TicketInfo(String rData)
        {
            //1、去掉多余的小横杠
            rData = SysUtil.RemoveExcessBars(rData);
            //2、换行符的处理
            rData = lineBreaksHandler(rData, SPECIAL_KEY_DATAS.lineBreaks);
            //3、非标准打印命令处理
            rData = printCMDHandler(rData, SPECIAL_KEY_DATAS.nonStandardpcmd);
            //4、4字节打印命令处理
            rData = printCMDHandler(rData, SPECIAL_KEY_DATAS.Prt_Cmd4_Str);
            //5、3字节打印命令处理
            rData = printCMDHandler(rData, SPECIAL_KEY_DATAS.Prt_Cmd3_Str);

            int count = 0;
            rData = SysUtil.RemoveExcessBars(rData);
            String[] datas = rData.Split('-');
            byte[] vBytes = new byte[datas.Length];
            foreach (String d in datas)
            {
                if (!String.IsNullOrEmpty(d))
                {
                    int num = Convert.ToInt32(d,16);
                    if (num > 31 || (num >= 10 && num <= 13))//退格\水平制表符\垂直制表符\换页键\换行和空格保留
                    {
                        if (!byte.TryParse(d, NumberStyles.HexNumber, null, out vBytes[count]))
                        {
                            vBytes[count] = 0;
                        }
                        count++;
                        //string sssss = CommandProcessor.bytes2String(vBytes);
                    }                    
                    
                }                
            }

            byte[] rBytes = new byte[count];
            Array.Copy(vBytes, 0, rBytes, 0, count);
            return CommandProcessor.bytes2String(rBytes);
        }

        /// <summary>
        /// 从返回命令中取出票数据——如果取到，那么rdata将是一条完整的出票票花数据
        /// </summary>
        /// <param name="rcmd">返回命令</param>
        /// <param name="rdata">出票数据</param>
        /// <returns>是否取到</returns>        
        public static Boolean getCompleteTicketData(ref String rcmd, ref String rdata)
        {
            try
            {
                //rcmd = rcmd.Replace(GlobalConstants.BASE_CMD.RECEIVE_START_PRINT, "").Replace(GlobalConstants.BASE_CMD.CMD_END, "");
                rcmd = SysUtil.RemoveExcessBars(rcmd);//去掉多余的小横杠
                //rdata = rcmd;
                //return true;
                foreach (String hitem in CmdResovleUtil.SPECIAL_KEY_DATAS.Prt_Cmd_Start_Str)
                {
                    if (rcmd.Contains(hitem))
                    {
                        rcmd = rcmd.Substring(rcmd.IndexOf(hitem));//这一步的时候先保留开头字符串，只有当找到尾的时候才把它丢弃
                        //有的竞彩票带着竞彩网的网址，那么直接从竞彩网的网址截取即可
                        string url = "-68-74-74-70-3A-2F-2F-77-77-77-2E-73-70-6F-72-74-74-65-72-79-2E-63-6E";

                        if (rcmd.Contains(url))
                        {
                            rdata = rcmd.Substring(hitem.Length, rcmd.IndexOf(url) + url.Length - hitem.Length);
                            rcmd = rcmd.Substring(rcmd.IndexOf(url) + url.Length);
                            return true;
                        }

                        foreach (String item in CmdResovleUtil.SPECIAL_KEY_DATAS.Prt_Cmd_End_Str)
                        {
                            if (rcmd.Contains(item))
                            {
                                rdata = rcmd.Substring(hitem.Length, rcmd.IndexOf(item) - hitem.Length);
                                rcmd = rcmd.Substring(rcmd.IndexOf(item) + item.Length);
                                return true;
                            }
                        }

                        //包含了头但是没包含尾巴的情况
                        rdata = String.Empty;
                        return false;
                    }
                }

                //头和尾都没有的情况，直接清空当前数据
                rdata = String.Empty;
                //rcmd = String.Empty; //不能清空，因为很多时候回来的命令是一部分一部分的
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 换行符的处理
        /// </summary>
        /// <param name="ticketInfoCMD"></param>
        /// <param name="lineBreaks"></param>
        /// <returns></returns>
        public static String lineBreaksHandler(String ticketInfoCMD, String[] lineBreaksArray)
        {
            ticketInfoCMD = ticketInfoCMD.ToUpper();
            foreach (String lineBreaks in lineBreaksArray)
            {
                while (ticketInfoCMD.Contains(lineBreaks))
                {
                    ticketInfoCMD = ticketInfoCMD.Replace(lineBreaks, "0A");
                }
            }

            return ticketInfoCMD;
        }


        /// <summary>
        /// 打印命令处理——需要移除的各种命令
        /// </summary>
        /// <param name="ticketInfoCMD"></param>
        /// <param name="printcmd"></param>
        /// <returns></returns>
        public static String printCMDHandler(String ticketInfoCMD, String[] printcmd)
        {
            ticketInfoCMD = ticketInfoCMD.ToUpper();

            if (null != printcmd && printcmd.Length > 0)
            {
                foreach (String cmd in printcmd)
                {
                    ticketInfoCMD = ticketInfoCMD.Replace(cmd, "");
                }
            }
            return ticketInfoCMD;
        }

        #region 根据错误命令获取错误编码
        /// <summary>
        /// 根据错误命令获取错误编码
        /// </summary>
        /// <param name="spi"></param>
        public static String errorCmd2ErrorCode(String cmd)
        {

            // 主机收到读票机数据后, 数据转发器的USB端口已关闭 !
            if (cmd.Contains(GlobalConstants.ERROR_CMD.MACHINE_READ_ED_USBERROR))
            {
                return GlobalConstants.ERROR_CODE.MACHINE_READ_ED_USBERROR;
            }
            // 主机收到读票机数据后, 无玩法类型票和玩法类型错误票 
            if (cmd.Contains(GlobalConstants.ERROR_CMD.MACHINE_READ_ED_PLAYERROR))
            {
                return GlobalConstants.ERROR_CODE.MACHINE_READ_ED_PLAYERROR;
            }
            // 主机收到读票机数据后, 原始数据错误
            if (cmd.Contains(GlobalConstants.ERROR_CMD.MACHINE_READ_ED_DATAERROR))
            {
                return GlobalConstants.ERROR_CODE.MACHINE_READ_ED_DATAERROR;
            }
            // 数据转发器内存检查错误 
            if (cmd.Contains(GlobalConstants.ERROR_CMD.MACHINE_READ_ED_RAMERROR))
            {
                return GlobalConstants.ERROR_CODE.MACHINE_READ_ED_RAMERROR;
            }
            // 主机收到读票机数据后, 数据校验错误 
            if (cmd.Contains(GlobalConstants.ERROR_CMD.MACHINE_READ_ED_CHECKERROR1))
            {
                return GlobalConstants.ERROR_CODE.MACHINE_READ_ED_CHECKERROR1;
            }
            else
            // 主机收到读票机数据后, 数据校验错误
            //(cmd.Contains(GlobalConstants.cmdDataKey.MACHINE_READ_ED_CHECKERROR2))
            {
                return GlobalConstants.ERROR_CODE.MACHINE_READ_ED_CHECKERROR2;
            }

        }
        #endregion
    }
}
