using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class JCZQDataResolve : IDataResolve
    {
        //比分结果转换
        //JCZQ_INDEX_BF.put("0", "胜其他");
        //JCZQ_INDEX_BF.put("1", "1:0");
        //JCZQ_INDEX_BF.put("2", "2:0");
        //JCZQ_INDEX_BF.put("3", "2:1");
        //JCZQ_INDEX_BF.put("4", "3:0");
        //JCZQ_INDEX_BF.put("5", "3:1");
        //JCZQ_INDEX_BF.put("6", "3:2");
        //JCZQ_INDEX_BF.put("7", "4:0");
        //JCZQ_INDEX_BF.put("8", "4:1");
        //JCZQ_INDEX_BF.put("9", "4:2");
        //JCZQ_INDEX_BF.put("10", "5:0");
        //JCZQ_INDEX_BF.put("11", "5:1");
        //JCZQ_INDEX_BF.put("12", "5:2");	
        //JCZQ_INDEX_BF.put("13", "平其他");
        //JCZQ_INDEX_BF.put("14", "0:0");
        //JCZQ_INDEX_BF.put("15", "1:1");
        //JCZQ_INDEX_BF.put("16", "2:2");
        //JCZQ_INDEX_BF.put("17", "3:3");		
        //JCZQ_INDEX_BF.put("18", "负其他");
        //JCZQ_INDEX_BF.put("19", "0:1");
        //JCZQ_INDEX_BF.put("20", "0:2");
        //JCZQ_INDEX_BF.put("21", "1:2");
        //JCZQ_INDEX_BF.put("22", "0:3");
        //JCZQ_INDEX_BF.put("23", "1:3");
        //JCZQ_INDEX_BF.put("24", "2:3");
        //JCZQ_INDEX_BF.put("25", "0:4");
        //JCZQ_INDEX_BF.put("26", "1:4");
        //JCZQ_INDEX_BF.put("27", "2:4");
        //JCZQ_INDEX_BF.put("28", "0:5");
        //JCZQ_INDEX_BF.put("29", "1:5");
        //JCZQ_INDEX_BF.put("30", "2:5");
        //比分结果转换
        public static Dictionary<String, String> jz_bfDictionary = new Dictionary<string, string>() {
        {"14","00"},{"19","01"},{"20","02"},
        {"22","03"},{"25","04"},{"28","05"},
        {"18","09"},{"1","10"},{"15","11"},
        {"21","12"},{"23","13"},{"26","14"},
        {"29","15"},{"2","20"},{"3","21"},
        {"16","22"},{"24","23"},{"27","24"},
        {"30","25"},{"4","30"},{"5","31"},
        {"6","32"},{"17","33"},{"7","40"},
        {"8","41"},{"9","42"},{"10","50"},
        {"11","51"},{"12","52"},{"0","90"},
        {"13","99"}
        };
		
        //混合过关中网站的玩法类型和彩机的玩法类型不一致，需要进行转换
        public static Dictionary<String, String> jz_playDictionary = new Dictionary<string, string>() { 
        {"1","1"},{"2","6"},{"3","3"},{"4","4"},{"5","2"}
        };

        
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
                    case JCZQPlayType.SPF:
                        cmdstr = this.JCZQ_SPF(data);
                        break;
                    case JCZQPlayType.RQSPF:
                        cmdstr = this.JCZQ_RQSPF(data);
                        break;
                    case JCZQPlayType.ZJQ:
                        cmdstr = this.JCZQ_ZJQ(data);
                        break;
                    case JCZQPlayType.BQC:
                        cmdstr = this.JCZQ_BQC(data);
                        break;
                    case JCZQPlayType.BF:
                        cmdstr = this.JCZQ_BF(data);
                        break;
                    case JCZQPlayType.HHGG:
                        cmdstr = this.JCZQ_HHGG(data);
                        break;
                    case JCZQPlayType.ECUP:
                        cmdstr = this.JCZQ_ECUP(data);
                        break;
                    case JCZQPlayType.WCUP:
                        cmdstr = this.JCZQ_WCUP(data);
                        break;
                    case JCZQPlayType.WCUPGYJ:
                        cmdstr = this.JCZQ_WCUPGYJ(data);
                        break;
                    case JCZQPlayType.ECUPGJ:
                        cmdstr = this.JCZQ_ECUPGJ(data);
                        break;
                    case JCZQPlayType.ECUPGYJ:
                        cmdstr = this.JCZQ_ECUPGYJ(data);
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
        /// 欧洲杯冠亚军
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string JCZQ_ECUPGYJ(string data)
        {
            try
            {
                String[] ds = data.Split(',');
                StringBuilder sb = new StringBuilder("01");
                foreach (String item in ds)
                {
                    if (!String.IsNullOrEmpty(item) && item.Contains("_"))
                    {
                        String ll = item.Split('_')[0];
                        sb.Append(ll.Length < 2 ? "0" + ll : ll);
                    }
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }             
        }

        /// <summary>
        /// 欧洲杯冠军
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string JCZQ_ECUPGJ(string data)
        {
            try
            {
                String[] ds = data.Split(',');
                StringBuilder sb = new StringBuilder("01");
                foreach (String item in ds)
                {
                    if (!String.IsNullOrEmpty(item) && item.Contains("_"))
                    {
                        String ll = item.Split('_')[0];
                        sb.Append(ll.Length < 2 ? "0" + ll : ll);
                    }
                }

                return sb.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 胜平负
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_SPF(String data)
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
                    sb.Append(dz[1].Replace(",", ""));
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
        /// 让球胜平负
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_RQSPF(String data)
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
                    sb.Append(dz[1].Replace(",", ""));
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
        /// 总进球
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_ZJQ(String data)
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
                    sb.Append(dz[1].Replace(",", ""));
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
        /// 半全场
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_BQC(String data)
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
                    sb.Append(dz[1].Replace(",", ""));
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
        /// 比分
        /// </summary>
        /// <param name="data">20150901002:30:0|20150901003:13:0|20150901004:13:0</param>
        /// <returns></returns>
        private String JCZQ_BF(String data)
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
                        sb.Append(jz_bfDictionary[xx]);
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
        private String JCZQ_HHGG(String data)
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
                            sb.Append(jz_playDictionary[tzx[0]]);
                            round++;
                        }

                        switch (jz_playDictionary[tzx[0]])
                        {
                            case "1"://胜平负
                                sb.Append(tzx[1].Replace(",", ""));
                                break;
                            case "2"://比分
                                sb.Append(jz_bfDictionary[tzx[1]]);
                                break;
                            case "3"://总进球
                                sb.Append(tzx[1].Replace(",", ""));
                                break;
                            case "4"://半全场
                                sb.Append(tzx[1].Replace(",", ""));
                                break;
                            case "5"://上下盘及单双
                                sb.Append(jz_bfDictionary[xx]);
                                break;
                            case "6"://让球胜平负
                                sb.Append(tzx[1].Replace(",", ""));
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
        /// 欧冠
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_ECUP(String data)
        {
            try
            {
                return data.Replace(",", "").Replace(",", "");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 世界杯冠军
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_WCUP(String data)
        {
            try
            {
                return data.Replace(",", "").Replace(",", "");
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 世界杯冠亚军
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private String JCZQ_WCUPGYJ(String data)
        {
            try
            {
                return data.Replace(",", "").Replace(",", "");
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
        private String data2weekDayTranslation(String data) {
           return DateUtil.data2weekDayTranslation(data);
           //return "7";
        }
    }
}
