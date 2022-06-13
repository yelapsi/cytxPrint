using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class JCLQDataResolve : IDataResolve
    {

        //混合过关中网站的玩法类型和彩机的玩法类型不一致，需要进行转换
        public static Dictionary<String, String> playDictionary = new Dictionary<string, string>() { 
        {"1","2"},{"2","1"},{"3","3"},{"4","4"}
        };

        //胜负结果转换1胜、2负     ------{ "3", "主胜" },{ "0", "主负" }
        public static Dictionary<String, String> sfDictionary = new Dictionary<string, string>() {
        {"3","1"},{"0","2"}
        };

        //让分胜负结果转换-1胜、2负------{ "0", "客胜(让)" }, { "3", "主胜(让)" } 
        public static Dictionary<String, String> rfsfDictionary = new Dictionary<string, string>() {
        {"3","1"},{"0","2"}
        };

        //大小分结果转换
        public static Dictionary<String, String> dxfDictionary = new Dictionary<string, string>() {
        {"0","1"},{"1","2"}
        };


        //胜分差结果转换
        public static Dictionary<String, String> sfcDictionary = new Dictionary<string, string>() {
        {"6","01"},{"7","02"},{"8","03"},{"9","04"},{"10","05"},{"11","06"},
        {"0","11"},{"1","12"},{"2","13"},{"3","14"},{"4","15"},{"5","16"}
        };
        //JCLQ_INDEX_SFC.put("0", "客胜1-5");
        //JCLQ_INDEX_SFC.put("1", "客胜6-10");
        //JCLQ_INDEX_SFC.put("2", "客胜11-15");
        //JCLQ_INDEX_SFC.put("3", "客胜16-20");
        //JCLQ_INDEX_SFC.put("4", "客胜21-25");
        //JCLQ_INDEX_SFC.put("5", "客胜26+");
        //JCLQ_INDEX_SFC.put("6", "主胜1-5");
        //JCLQ_INDEX_SFC.put("7", "主胜6-10");
        //JCLQ_INDEX_SFC.put("8", "主胜11-15");
        //JCLQ_INDEX_SFC.put("9", "主胜16-20");
        //JCLQ_INDEX_SFC.put("10", "主胜21-25");
        //JCLQ_INDEX_SFC.put("11", "主胜26+");

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
                    case JCLQPlayType.SF:
                        cmdstr = this.JCLQ_SF(data);
                        break;
                    case JCLQPlayType.RFSF:
                        cmdstr = this.JCLQ_RFSF(data);
                        break;
                    case JCLQPlayType.SFC:
                        cmdstr = this.JCLQ_SFC(data);
                        break;
                    case JCLQPlayType.DXF:
                        cmdstr = this.JCLQ_DXF(data);
                        break;
                    case JCLQPlayType.HHGG:
                        cmdstr = this.JCLQ_HHGG(data);
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
        /// 胜负
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCLQ_SF(String data)
        {
            try
            {
                String[] ds = data.Split('|');
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (String s in ds)
                {
                    String[] dz = s.Split(':');
                    //赛事
                    sb.Append(data2weekDayTranslation(dz[0].Substring(0, 8)) + dz[0].Substring(8, 3));
                    //竟猜选项
                    String[] jcxx = dz[1].Split(',');
                    foreach (String xx in jcxx)
                    {
                        sb.Append(sfDictionary[xx]);
                    }
                    sb.Append(count < ds.Length ? "=" : "");
                    count++;
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 让分胜负
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCLQ_RFSF(String data)
        {
            try
            {
                String[] ds = data.Split('|');
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (String s in ds)
                {
                    String[] dz = s.Split(':');
                    //赛事
                    sb.Append(data2weekDayTranslation(dz[0].Substring(0, 8)) + dz[0].Substring(8, 3));
                    //竟猜选项
                    String[] jcxx = dz[1].Split(',');
                    foreach (String xx in jcxx)
                    {
                        sb.Append(rfsfDictionary[xx]);
                    }
                    sb.Append(count < ds.Length ? "=" : "");
                    count++;
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 胜分差
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCLQ_SFC(String data)
        {
            try
            {
                String[] ds = data.Split('|');
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (String s in ds)
                {
                    String[] dz = s.Split(':');
                    //赛事
                    sb.Append(data2weekDayTranslation(dz[0].Substring(0, 8)) + dz[0].Substring(8, 3));
                    //竟猜选项
                    String[] jcxx = dz[1].Split(',');
                    foreach (String xx in jcxx)
                    {
                        sb.Append(sfcDictionary[xx]);
                    }
                    sb.Append(count < ds.Length ? "=" : "");
                    count++;
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        /// <summary>
        /// 大小分
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCLQ_DXF(String data)
        {
            try
            {
                String[] ds = data.Split('|');
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (String s in ds)
                {
                    String[] dz = s.Split(':');
                    //赛事
                    sb.Append(data2weekDayTranslation(dz[0].Substring(0, 8)) + dz[0].Substring(8, 3));
                    //竟猜选项
                    String[] jcxx = dz[1].Split(',');
                    foreach (String xx in jcxx)
                    {
                        sb.Append(dxfDictionary[xx]);
                    }
                    sb.Append(count < ds.Length ? "=" : "");
                    count++;
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 混合过关
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCLQ_HHGG(String data)
        {
            try
            {
                String[] ds = data.Split('|');
                StringBuilder sb = new StringBuilder();
                int count = 1;
                foreach (String s in ds)
                {
                    String[] dz = s.Split(':');
                    int round = 0;
                    //赛事
                    sb.Append(data2weekDayTranslation(dz[0].Substring(0, 8)) + dz[0].Substring(8, 3));
                    //竟猜选项
                    String[] jcxx = dz[1].Split(',');
                    foreach (String xx in jcxx)
                    {
                        String[] tzx = xx.Split('-');
                        if (round == 0)
                        {//同一赛事只有统一玩法（玩法只需要输入一次，多个结果拼在后面即可）
                            sb.Append(playDictionary[tzx[0]]);
                            round++;
                        }

                        switch (tzx[0])
                        {
                            case "1"://胜负
                                sb.Append(sfDictionary[tzx[1]]);
                                break;
                            case "2"://让分胜负
                                sb.Append(rfsfDictionary[tzx[1]]);
                                break;
                            case "3"://胜分差
                                sb.Append(sfcDictionary[tzx[1]]);
                                break;
                            case "4"://大小分
                                sb.Append(dxfDictionary[tzx[1]]);
                                break;
                        }

                    }
                    sb.Append(count < ds.Length ? "=" : "");
                    count++;
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">20150831->1</param>
        /// <returns></returns>
        private String data2weekDayTranslation(String data)
        {
            return DateUtil.data2weekDayTranslation(data);
            //return "7";
        }
    }
}
