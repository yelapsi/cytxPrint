using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Common.model;
using System.Text.RegularExpressions;

namespace Maticsoft.Common.Util
{
   public class CommandProcessor
    {
        #region 获取对应的命令
        /// <summary>
        /// 投注数据转换成命令
        /// </summary>
        /// <param name="data">命令数据</param>
        /// <param name="dataSign">数据长度</param>
        /// <returns></returns>
        public static byte[] betDataToCommand(String data, out int cmd_length)
        {
            try
            {
                cmd_length = data.Length;
                byte[] cmd = CommandProcessor.string2Bytes_ASCII(data);
                for (int i = 0; i < cmd.Length; i++)
                {//替换特殊字符
                    if (cmd[i].Equals(44) || cmd[i].Equals(45))
                    {//44把逗号换成下箭头；45把-换成下箭头
                        cmd[i] = 0xC2;
                    }
                    else if (cmd[i].Equals(62))
                    {
                        //把>换成右箭头
                        cmd[i] = 0xC3;
                    }
                    else if (cmd[i].Equals(61))
                    {
                        //把=换成F1
                        cmd[i] = 0xB0;
                    }
                    else if (cmd[i].Equals(94))
                    {
                        //把^换成一个50延时
                        cmd[i] = 0xE0;
                    }
                }
                return cmd;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 十六进制数据转换成命令
        /// </summary>
        /// <param name="data">十六进制数据</param>
        /// <param name="dataSign">数据长度</param>
        /// <returns></returns>
        public static byte[] HexDataToCommand(String[] data)
        {
            try
            {
                int discarded = 0;
                byte[] sendbyteTemp = new byte[256];
                for (int i = 0; i < data.Length; i++)
                {
                    sendbyteTemp[i] = CommandProcessor.hexStrToBytes(data[i], out discarded)[0];
                }
                return sendbyteTemp;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        #endregion

       /// <summary>
       /// 打包命令——加上头尾等
       /// </summary>
       /// <param name="cmdbody"></param>
       /// <param name="cmdlength"></param>
       /// <returns></returns>
        public static byte[] packCommand(byte[] cmdbody, String dataSign,int cmdlength)
        {
            try
            {
                byte[] sendbyteTemp = new byte[256];
                int discarded = 0;
                //命令头部
                Array.Copy(GlobalConstants.CMDByteArrays.cmdhead, 0, sendbyteTemp, 0, 4); // 投注数据开始头
                sendbyteTemp[4] = CommandProcessor.hexStrToBytes(dataSign, out discarded)[0];//数据标识
                sendbyteTemp[5] = BitConverter.GetBytes(cmdlength)[0]; // 投注数据长度
                Array.Copy(cmdbody, 0, sendbyteTemp, 6, cmdlength);

                Array.Copy(GlobalConstants.CMDByteArrays.cmdend, 0, sendbyteTemp, 6 + cmdlength, 4); // 投注数据结尾
                cmdlength += 10;
                return sendbyteTemp;
            }
            catch (Exception e)
            {
                throw e;
            }            
       }

        

        #region 数据是否包含某个指定命令
        /// <summary>
       /// 数据是否包含某个指定命令
       /// </summary>
       /// <param name="data">命令数据</param>
       /// <param name="cmdKey">命令关键字</param>
       /// <returns></returns>
        public static bool isHasCmd(String data,String cmdKey) {
            return data.Contains(cmdKey);
        }
        #endregion

        #region 取所有的命令，余下的字符串原样返回
        public static List<String> getAllCompeleteCMD(ref StringBuilder sb) {

            List<String> cmdarrays = new List<string>();
            String infostr = SysUtil.RemoveExcessBars(sb.ToString()); 
            sb.Remove(0,sb.Length);

            Regex ConnoteCCMD = new Regex(@"FF-11-FF-13-43((?!FF-11-FF-13-43)(?!FF-0D-FF-0A).)*FF-0D-FF-0A");
            Regex ConnotePCMD = new Regex(@"FF-11-FF-13-50((?!FF-11-FF-13-50)(?!FF-0D-FF-0A).)*FF-0D-FF-0A");

            foreach (Match item in ConnoteCCMD.Matches(infostr))
            {
                cmdarrays.Add(item.ToString());
                infostr = infostr.Replace(item.ToString(),"");
            }

            infostr = SysUtil.RemoveExcessBars(infostr);
            foreach (Match item in ConnotePCMD.Matches(infostr))
            {
                cmdarrays.Add(item.ToString());
                infostr = infostr.Replace(item.ToString(), "");
            }

            sb.Insert(0, SysUtil.RemoveExcessBars(infostr));
            return cmdarrays;
        }
        #endregion 取所有的命令，余下的字符串原样返回

        #region 取第一条命令的内容(返回余下的数据)
        /// <summary>
        /// 取第一条命令的内容(返回余下的数据)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String getFristCmd(ref StringBuilder sb)
        {
            String cmd = String.Empty;
            String sbstring = sb.ToString();
            try
            {
                //先找又没有头部
                if (sbstring.Contains(GlobalConstants.BASE_CMD.CMD_HEAD))
                {
                    sbstring = sbstring.Substring(sbstring.IndexOf(GlobalConstants.BASE_CMD.CMD_HEAD));//有一个完整的头部了
                    //再看看有没有尾巴
                    if (sbstring.Contains(GlobalConstants.BASE_CMD.CMD_END))//有一个完整的尾巴了
                    {
                        cmd = sbstring.Substring(0, sbstring.IndexOf(GlobalConstants.BASE_CMD.CMD_END) + GlobalConstants.BASE_CMD.CMD_END.Length);
                        sbstring = sbstring.Substring(sbstring.IndexOf(GlobalConstants.BASE_CMD.CMD_END) + GlobalConstants.BASE_CMD.CMD_END.Length);
                    }

                    sb.Remove(0, sb.Length);
                    sb.Append(sbstring);
                }

                return cmd;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        #endregion 

        #region 流程命令翻译
        /// <summary>
        /// 流程命令翻译
        /// </summary>
        /// <param name="prostr"></param>
        /// <returns></returns>
        public static String processCmdTran(String prostr,long delaytime)
        {
            try
            {
                String cmdstr = String.Empty;
                String dtstr = String.Empty;
                if (delaytime > 0 && delaytime<17)
                {
                    String delay_key = ("D" + (delaytime >= 10 ? "" : "0") + delaytime.ToString());
                    dtstr = GlobalConstants.delay_Time_Dictionary[delay_key] + "+";
                }
                cmdstr = prostr.Replace("F01", "B0").Replace("F02", "B1")
                    .Replace("F03", "B2").Replace("F04", "B3")
                    .Replace("F05", "B4").Replace("F06", "B5")
                    .Replace("F07", "B6").Replace("F08", "B7")
                    .Replace("F09", "B8").Replace("F10", "B9")
                    .Replace("F11", "BA").Replace("F12", "BB")
                    .Replace("Esc", "1B").Replace("Tab", "9")
                    .Replace("Backspace", "8").Replace("UA", "C0")
                    .Replace("LA", "C1").Replace("DA", "C2")
                    .Replace("RA", "C3").Replace("End", "C7")
                    .Replace("PgUp", "C5").Replace("PgDn", "C8")
                    .Replace("Ins", "C5").Replace("Delete", "C6")
                    .Replace("Caps", "C9").Replace("H", dtstr + "48").Replace("ZJ", "2B");

                String[] cmds = cmdstr.Split('+');
                StringBuilder cmdsb = new StringBuilder();

                for (int i = 0; i < cmds.Length; i++)
                {
                    int num = 0;
                    if (cmds[i].StartsWith("D"))
                    {
                        cmdsb.Append(GlobalConstants.delay_Time_Dictionary[cmds[i]] + (i == cmds.Length - 1 ? "" : "+"));
                    }
                    else if (int.TryParse(cmds[i], out num) && num < 10)
                    {
                        cmdsb.Append(CommandProcessor.bytesToHexString(CommandProcessor.string2Bytes_ASCII(cmds[i])) + (i == cmds.Length - 1 ? "" : "+"));
                    }
                    else
                    {
                        cmdsb.Append(cmds[i] + (i == cmds.Length - 1 ? "" : "+"));
                    }
                }

                return cmdsb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        #endregion


       /// <summary>
        /// string类型转成byte[]
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
        public static byte[] string2Bytes(String s) {
            return System.Text.Encoding.Default.GetBytes(s);
        }

       /// <summary>
        /// byte[]转成string
       /// </summary>
       /// <param name="bs"></param>
       /// <returns></returns>
       public static String bytes2String(byte[] bs){
           return System.Text.Encoding.Default.GetString(bs);
       }


       /// <summary>
       /// string类型转成byte[]——ASCII(string类型转成ASCII byte[]：（"01" 转成 byte[] = new byte[]{ 0x30, 0x31}）)
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static byte[] string2Bytes_ASCII(String s)
       {
           return System.Text.Encoding.ASCII.GetBytes(s);
       }

       /// <summary>
       /// byte[]转成string——ASCII
       /// </summary>
       /// <param name="bs"></param>
       /// <returns></returns>
       public static String bytes2String_ASCII(byte[] bs)
       {
           return System.Text.Encoding.ASCII.GetString(bs);
       }


       /// <summary>
       /// byte[] 转成原16进制格式的string，例如0xae00cf, 转换成 "ae00cf"；new byte[]{ 0x30, 0x31}转成"3031"
       /// </summary>
       /// <param name="bytes"></param>
       /// <returns></returns>
       public static string bytesToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
       {
           string hexString = string.Empty;
           if (bytes != null)
           {
               StringBuilder strB = new StringBuilder();

               for (int i = 0; i < bytes.Length; i++)
               {
                   strB.Append(bytes[i].ToString("X2"));
               }
               hexString = strB.ToString();
           }
           return hexString;
       }


       /// <summary>
       /// 反过来，16进制格式的string 转成byte[]，例如, "ae00cf"转换成0xae00cf，长度缩减一半；"3031" 转成new byte[]{ 0x30, 0x31}:
       /// </summary>
       /// <param name="hexString"></param>
       /// <param name="discarded"></param>
       /// <returns></returns>
       public static byte[] hexStrToBytes(string hexString, out int discarded)
       {
           discarded = 0;
           string newString = "";
           char c;
           // remove all none A-F, 0-9, characters
           for (int i = 0; i < hexString.Length; i++)
           {
               c = hexString[i];
               if (Uri.IsHexDigit(c))
               {
                   newString += c;
               }
               else
               {
                   discarded++; 
               }
           }
           // if odd number of characters, discard last character
           if (newString.Length % 2 != 0)
           {
               discarded++;
               newString = newString.Substring(0, newString.Length - 1);
           }

           int byteLength = newString.Length / 2;
           byte[] bytes = new byte[byteLength];
           string hex;
           int j = 0;
           for (int i = 0; i < bytes.Length; i++)
           {
               hex = new String(new Char[] { newString[j], newString[j + 1] });
               bytes[i] = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
               j = j + 2;
           }
           return bytes;
       }

    }
}
