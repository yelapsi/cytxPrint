using Maticsoft.BLL.log;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Maticsoft.BLL.comparison
{
   public class ComparisonUtil
    {
        private static Dictionary<int, String[]> LId2NameDictionary = new Dictionary<int, string[]>() {
            {LicenseContants.License.GAMEIDPLS,new String[]{ "全国联网排列3", "排列3","排列三" }},
        {LicenseContants.License.GAMEIDPLW,new String[]{"排列五","排列5"}},
        {LicenseContants.License.GAMEIDQXC,new String[]{"七星彩","7星彩"}},
        {LicenseContants.License.GAMEIDDLT,new String[]{"大乐透","超级大乐透"}},
        {LicenseContants.License.GAMEIDSFC,new String[]{"胜负彩","14场胜负"}},
        {LicenseContants.License.GAMEIDRXJ,new String[]{"任选9","任选9场胜负"}},
        {LicenseContants.License.GAMEIDBQC,new String[]{"半全场","6场半全场胜负"}},
        {LicenseContants.License.GAMEIDJQC,new String[]{"进球彩","4场进球"}},
        {LicenseContants.License.GAMEIDJCZQ,new String[]{"竞彩足球","竞彩名次"}},
        {LicenseContants.License.GAMEIDJCLQ,new String[]{"竞彩篮球"}},
        {LicenseContants.License.GAMEIDSSQ,new String[]{"双色球"}},
        {LicenseContants.License.GAMEIDF3D,new String[]{"福彩3D"}},
        {LicenseContants.License.GAMEIDQLC,new String[]{"七乐彩"}},
        {LicenseContants.License.GAMEIDLJY,new String[]{"体彩6+1"}},
        {LicenseContants.License.GAMEIDBJDC,new String[]{"北京单场"}},
        {LicenseContants.License.GAMEID20X5,new String[]{"20选5"}},
        {LicenseContants.License.GAMEIDSFGG,new String[]{"胜负过关"}},

         {LicenseContants.License.FREQ_SD11X5,new String[]{"体彩十一运夺金","11选5"}},
        {LicenseContants.License.FREQ_ZHJ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_JX11X5,new String[]{"多乐彩"}},
        {LicenseContants.License.FREQ_GD11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_CQ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_GZ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_LN11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_SHX11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_HLJ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_FJ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_TJ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_SH11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_GX11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_BJ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_SX11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_JS11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_NMG11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_GS11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_AH11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_HB11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_SC11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_YN11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_HN11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_HUB11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_JL11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_XJ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_XZ11X5,new String[]{"11选5"}},
        {LicenseContants.License.FREQ_NX11X5,new String[]{"11选5"}},

        {LicenseContants.License.FREQ_HNXYSC,new String[]{"湖南幸运赛车"}},
        {LicenseContants.License.FREQ_SHSSL,new String[]{"上海时时乐"}},
        {LicenseContants.License.FREQ_KLPK3,new String[]{"快乐扑克3"}},

        {LicenseContants.License.FREQ_JXSSC,new String[]{"江西时时彩"}},
        {LicenseContants.License.FREQ_CQSSC,new String[]{"重庆时时彩"}},
        {LicenseContants.License.FREQ_TJSSC,new String[]{"天津时时彩"}},
        {LicenseContants.License.FREQ_XJSSC,new String[]{"新疆时时彩"}},
        {LicenseContants.License.FREQ_YNSSC,new String[]{"云南时时彩"}},
        {LicenseContants.License.FREQ_HLJSSC,new String[]{"黑龙江时时彩"}},

        {LicenseContants.License.FREQ_SHK3,new String[]{"上海快3"}},
        {LicenseContants.License.FREQ_GXK3,new String[]{"广西快3"}},
        {LicenseContants.License.FREQ_GZK3,new String[]{"贵州快3"}},
        {LicenseContants.License.FREQ_JSK3,new String[]{"江苏快3"}},
        {LicenseContants.License.FREQ_HUBK3,new String[]{"湖北快3"}},
        {LicenseContants.License.FREQ_NMGK3,new String[]{"内蒙快3"}},
        {LicenseContants.License.FREQ_HBK3,new String[]{"河北快3"}},
        {LicenseContants.License.FREQ_JLK3,new String[]{"吉林快3"}},
        {LicenseContants.License.FREQ_FJK3,new String[]{"福建快3"}},
        {LicenseContants.License.FREQ_QHK3,new String[]{"青海快3"}},
        {LicenseContants.License.FREQ_AHK3,new String[]{"安徽快3"}},
        {LicenseContants.License.FREQ_GSK3,new String[]{"甘肃快3"}},
        {LicenseContants.License.FREQ_XZK3,new String[]{"西藏快3"}},

        {LicenseContants.License.FREQ_CQKL10,new String[]{"重庆快乐10分"}},
        {LicenseContants.License.FREQ_HNKL10,new String[]{"湖南快乐10分"}},
        {LicenseContants.License.FREQ_TJKL10,new String[]{"天津快乐10分"}},
        {LicenseContants.License.FREQ_YNKL10,new String[]{"云南快乐10分"}},
        {LicenseContants.License.FREQ_GXKL10,new String[]{"广西快乐10分"}},
        {LicenseContants.License.FREQ_GDKL10,new String[]{"广东快乐10分"}},
        {LicenseContants.License.FREQ_HLJKL10,new String[]{"	黑龙江快乐10分"}},

        {LicenseContants.License.FREQ_LNKL12,new String[]{"辽宁快乐12"}},
        {LicenseContants.License.FREQ_ZHJKL12,new String[]{"浙江快乐12"}},
        {LicenseContants.License.FREQ_SCKL12,new String[]{"四川快乐12"} }
        };

        private static Dictionary<int, Dictionary<int, String[]>> playPId2PNameDictionary = new Dictionary<int, Dictionary<int, String[]>>() { 
            //排列三
        {LicenseContants.License.GAMEIDPLS,new Dictionary<int, String[]>(){
            {PL3PlayType.PLSZHXDS,new String[] { "直选单式","直选票" } },
            {PL3PlayType.PLSZHXFS,new String[] { "直选复式" } },
            {PL3PlayType.PLSZHXZHFS,new String[] { "直选组合复式" } },
            {PL3PlayType.PLSZHXHZ,new String[] { "直选和值" } },
            {PL3PlayType.PLSZHXZHDT,new String[] { "直选组合胆拖" } },
            {PL3PlayType.PLSZXDS,new String[] { "组选", "组选单式" } },
            {PL3PlayType.PLSZSFS,new String[] { "组选三复式", "组选3复式" } },
            {PL3PlayType.PLSZSHZ,new String[] { "组选三和值", "组选3和值" } },
            {PL3PlayType.PLSZSDT,new String[] { "组选三胆拖", "组选3胆拖" } },
            {PL3PlayType.PLSZLDS,new String[] { "组选六单式", "组选6单式", "组选票" } },
            {PL3PlayType.PLSZLFS,new String[] { "组选六复式", "组选6复式" } },
            {PL3PlayType.PLSZLHZ,new String[] { "组选六和值", "组选6和值" } },
            {PL3PlayType.PLSZLDT,new String[] { "组选六胆拖", "组选6胆拖" } }
        }},
        //排列五
        {LicenseContants.License.GAMEIDPLW,new Dictionary<int, String[]>(){
         {PL5PlayType.ZHX_DS,new String[] { "直选单式","直选票" }},
         {PL5PlayType.ZHX_FS,new String[] { "直选复式","直选定位复式" }}
        }},
        //七星彩
        {LicenseContants.License.GAMEIDQXC,new Dictionary<int, String[]>(){
        {QXCPlayType.ZHX_DS,new String[] { "直选单式","单式" }},
        {QXCPlayType.ZHX_FS,new String[] { "直选复式", "定位复式" }}
        }},
        //大乐透
        {LicenseContants.License.GAMEIDDLT,new Dictionary<int, String[]>(){
        {DLTPlayType.DS,new String[] { "单式","直选单式","Do_not_show" }}, //不显示-有的票面上不显示玩法
        {DLTPlayType.FS,new String[] { "复式","直选复式" }},
        {DLTPlayType.DT,new String[] { "胆拖","直选胆拖" }}
        }},
        //胜负彩
        {LicenseContants.License.GAMEIDSFC,new Dictionary<int, String[]>(){
         {SFCPlayType.DS,new String[] { "单式","直选单式" }},
        {SFCPlayType.FS,new String[] { "复式","直选复式" }}
        }},
        //任选九
        {LicenseContants.License.GAMEIDRXJ,new Dictionary<int, String[]>(){
         {R9PlayType.DS,new String[] { "单式","直选单式" }},
        {R9PlayType.FS,new String[] { "复式","直选复式" }}
        }},
        //六场半全场
        {LicenseContants.License.GAMEIDBQC,new Dictionary<int, String[]>(){
         {BQCPlayType.DS,new String[] { "单式","直选单式" }},
        {BQCPlayType.FS,new String[] { "复式","直选复式" }}
        }},
        //进球彩
        {LicenseContants.License.GAMEIDJQC,new Dictionary<int, String[]>(){
         {JQCPlayType.DS,new String[] { "单式", "直选单式" }},
        {JQCPlayType.FS,new String[] { "复式","直选复式" }}
        }},
        //竞彩足球
        {LicenseContants.License.GAMEIDJCZQ,new Dictionary<int, String[]>(){
        {JCZQPlayType.SPF,new String[] { "胜平负" }},
        {JCZQPlayType.RQSPF,new String[] { "让球胜平负" }},
        {JCZQPlayType.ZJQ,new String[] { "总进球数" }},
        {JCZQPlayType. BQC,new String[] { "半全场胜平负" }},
        {JCZQPlayType.BF,new String[] { "比分" }},
        {JCZQPlayType.HHGG,new String[] { "混合过关" }},
        {JCZQPlayType.ECUP,new String[] { "欧冠" }},
        {JCZQPlayType.WCUP,new String[] { "世界杯冠军" }},
        {JCZQPlayType.WCUPGYJ,new String[] { "世界杯冠亚军" }},
        {JCZQPlayType.ECUPGJ,new String[] { "竞彩名次-冠军","冠军" }},
        {JCZQPlayType.ECUPGYJ,new String[] { "竞彩名次-冠亚军","冠亚军" }}
        }},
        //竞彩篮球
        {LicenseContants.License.GAMEIDJCLQ,new Dictionary<int, String[]>(){
        {JCLQPlayType.SF,new String[] { "胜负" }},
        {JCLQPlayType.RFSF,new String[] { "让分胜负" }},
        {JCLQPlayType.SFC,new String[] { "胜分差" }},
        {JCLQPlayType. DXF,new String[] { "大小分" }},
        {JCLQPlayType.HHGG,new String[] { "混合过关" }}
        }},
        //双色球
        {LicenseContants.License.GAMEIDSSQ,new Dictionary<int, String[]>(){

        }},
        //福彩3d
        {LicenseContants.License.GAMEIDF3D,new Dictionary<int, String[]>(){}},
        //七乐彩
        {LicenseContants.License.GAMEIDQLC,new Dictionary<int, String[]>(){}},
         //十一选五
        {LicenseContants.License.FREQ_SD11X5,new Dictionary<int, String[]>(){
            {SD11X5PlayType.Q1DS,new String[] { "前一单式","任选一复式" }},
            {SD11X5PlayType.Q1FS,new String[] { "前一复式","任选一复式" }},
            {SD11X5PlayType.R2DS,new String[] { "任选二单式" }},
            {SD11X5PlayType.R2FS,new String[] { "任选二复式" }},
            {SD11X5PlayType.R2DT,new String[] { "任选二胆拖" }},
            {SD11X5PlayType.Q2ZX,new String[] { "前二直选单式", "选前2直选单式" }},
            {SD11X5PlayType.Q2ZX_DS,new String[] { "选前2组选单式","前二组选单式" }},
            {SD11X5PlayType.Q2ZXFS,new String[] { "前二直选复式","前2直选复式"}},
            {SD11X5PlayType.Q2ZX_FS,new String[] { "前二组选复式","前2组选复式" }},
            {SD11X5PlayType.Q2ZX_DT,new String[] { "前二组选胆拖" }},
            {SD11X5PlayType.R3DS,new String[] { "任选三单式","任选三普通单式" }},
            {SD11X5PlayType.R3FS,new String[] { "任选三复式","任选三普通复式" }},
            {SD11X5PlayType.R3DT,new String[] { "任选三胆拖" }},
            {SD11X5PlayType.Q3ZX,new String[] { "前三直选","前三直选单式","选前三直选单式" }},
            {SD11X5PlayType.Q3ZXFS,new String[] { "前三直选复式" }},
            {SD11X5PlayType.Q3ZX_DS,new String[] { "前三组选普通单式","选前三组选单式" }},
            {SD11X5PlayType.Q3ZX_FS,new String[] { "前三组选复式","选前三组选复式", "前三组选普通复式"}},
            {SD11X5PlayType.Q3ZX_DT,new String[] { "前三组选胆拖","选前三组选胆拖" }},
            {SD11X5PlayType.R4DS,new String[] { "任选四单式","任选四普通单式" }},
            {SD11X5PlayType.R4FS,new String[] { "任选四复式","任选四普通复式" }},
            {SD11X5PlayType.R4DT,new String[] { "任选四胆拖" }},
            {SD11X5PlayType.R5DS,new String[] { "任选五单式","任选五普通单式"  }},
            {SD11X5PlayType.R5FS,new String[] { "任选五复式","任选五普通复式" }},
            {SD11X5PlayType.R5DT,new String[] { "任选五胆拖" }},
            {SD11X5PlayType.R6DS,new String[] { "任选六单式","任选六普通单式" }},
            {SD11X5PlayType.R6FS,new String[] { "任选六复式","任选六普通复式" }},
            {SD11X5PlayType.R6DT,new String[] { "任选六胆拖" }},
            {SD11X5PlayType.R7DS,new String[] { "任选七单式","任选七普通单式" }},
            {SD11X5PlayType.R7FS,new String[] { "任选七复式","任选七普通复式" }},
            {SD11X5PlayType.R7DT,new String[] { "任选七胆拖" }},
            {SD11X5PlayType.R8DS,new String[] { "任选八单式","任选八普通单式" }},
            {SD11X5PlayType.R8FS,new String[] { "任选八复式","任选八普通复式" }},
            {SD11X5PlayType.R8DT,new String[] { "任选八胆拖" }}
    }
}
        };

        /// <summary>
        /// 彩种比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonLicenseName(lottery_ticket lt,String reInfo) {
            try
            {
                //传入的参数有误，直接比对失败
                if (null == lt || String.IsNullOrEmpty(reInfo))
                {
                    return false;
                }

                if (ComparisonUtil.LId2NameDictionary.ContainsKey((int)lt.license_id))
                {
                    String[] lNames = ComparisonUtil.LId2NameDictionary[(int)lt.license_id];
                    Boolean innit = false;
                    foreach (String item in lNames)
                    {
                        if (reInfo.Contains(item))
                        {
                            innit = true;
                            lt.return_license_name = item;
                            break;
                        }
                    }

                    return innit;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }            
        }

        /// <summary>
        /// 玩法比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonPlayName(lottery_ticket lt, String reInfo)
        {
            try
            {
                //传入的参数有误，直接比对失败
                if (null == lt || String.IsNullOrEmpty(reInfo))
                {
                    return false;
                }

                String play = lt.play_type;
                if (lt.license_id == LicenseContants.License.GAMEIDJCLQ ||
                    lt.license_id == LicenseContants.License.GAMEIDJCZQ)
                {
                    play = play.Split('-')[0];
                }

                int licenseid = (((int)lt.license_id) > 100 && ((int)lt.license_id) < 200) ? 101 : (int)lt.license_id;

                if (ComparisonUtil.playPId2PNameDictionary.ContainsKey(licenseid) &&
                    ComparisonUtil.playPId2PNameDictionary[licenseid].ContainsKey(int.Parse(play)))
                {
                    String[] PNames = ComparisonUtil.playPId2PNameDictionary[licenseid][int.Parse(play)];
                    Boolean innit = false;
                    foreach (String item in PNames)
                    {
                        if (reInfo.Contains(item))
                        {
                            innit = true;
                            lt.return_play_name = item;
                            break;
                        }
                        else if (item.Equals("Do_not_show"))//穗彩大乐透单式不显示玩法
                        {
                            innit = true;
                            lt.return_play_name = "单式";
                            break;
                        }
                    }
                    return innit;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 过关方式比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonPassType(lottery_ticket lt, String reInfo)
        {
            try
            {
                //传入的参数有误，直接比对失败
                if (null == lt || String.IsNullOrEmpty(reInfo))
                {
                    return false;
                }

                String play = lt.play_type;
                if (lt.license_id == LicenseContants.License.GAMEIDJCLQ ||
                    lt.license_id == LicenseContants.License.GAMEIDJCZQ)
                {
                    play = play.Split('-')[1].Replace("c","x").Replace("null", "1x1");
                    if (play.Equals("1x1"))
                    {
                        play = "单场固定";                        
                    }

                    lt.return_pass_type = play;
                    return reInfo.Contains(play);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 倍数比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonMultile(lottery_ticket lt, String reInfo)
        {
            //传入的参数有误，直接比对失败
            if (null == lt || String.IsNullOrEmpty(reInfo))
            {
                return false;
            }
            try
            {
                lt.return_multiple = long.Parse(new Regex(@"倍数[:]?[ ]*\d+", RegexOptions.IgnoreCase).Match(reInfo).Value.Replace("倍数", "").Replace(":", "").Replace(" ", "").Replace("元", ""));
                return Int64.Parse(lt.multiple) == lt.return_multiple;                
            }
            catch (Exception)
            {
                try
                {
                    lt.return_multiple = long.Parse(new Regex(@"倍[:]?\d+", RegexOptions.IgnoreCase).Match(reInfo).Value.Replace("倍", "").Replace(":", "").Trim());
                    return Int64.Parse(lt.multiple) == lt.return_multiple;
                }
                catch (Exception)
                {
                    try
                    {
                        lt.return_multiple = long.Parse(new Regex(@"\d+倍", RegexOptions.IgnoreCase).Match(reInfo).Value.Replace("倍", "").Trim());
                        return Int64.Parse(lt.multiple) == lt.return_multiple;
                    }
                    catch (Exception e1)
                    {
                        LogUtil.getInstance().addLogDataToQueue("倍数解析异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                        lt.return_multiple = 0;
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 金额比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonMoney(lottery_ticket lt, String reInfo)
        {
            try
            {
                //传入的参数有误，直接比对失败
                if (null == lt || String.IsNullOrEmpty(reInfo))
                {
                    return false;
                }
                lt.return_money = long.Parse(new Regex(@"合计[:]?[ ]*\d+", RegexOptions.IgnoreCase).Match(reInfo).Value.Replace("合计", "").Replace(":", "").Replace(" ", "").Replace("元", "").Trim());
                return Int64.Parse(lt.bet_price) == lt.return_money;
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("购彩金额异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                lt.return_money = 0;
                return false;
            }
        }

        /// <summary>
        /// 期号比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonIssue(lottery_ticket lt, String reInfo)
        {
            try
            {
                //传入的参数有误，直接比对失败
                if (null == lt || String.IsNullOrEmpty(reInfo))
                {
                    return false;
                }
                lt.return_issue = new Regex(@"第[ ]*\d+期", RegexOptions.IgnoreCase).Match(reInfo).Value.Replace("第", "").Replace("期", "").Trim();
                return lt.issue.Equals(lt.return_issue);
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("期号解析异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                lt.return_issue = "0";
                return false;
            }
        }

        /// <summary>
        /// 号码比对
        /// </summary>
        /// <param name="lt"></param>
        /// <param name="reInfo"></param>
        /// <returns></returns>
        private static Boolean ComparisonBetCodeInfo(lottery_ticket lt, String reInfo)
        {
            try
            {
                //传入的参数有误，直接比对失败
                if (null == lt || String.IsNullOrEmpty(reInfo))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       /// <summary>
       /// 取当前的赔率
       /// </summary>
       /// <param name="lt"></param>
       /// <param name="reInfo"></param>
       /// <returns></returns>
        public static void getTicketOddsRqs(lottery_ticket lt, String reInfo)
        {
            
            try
            {
                String[] strArr = reInfo.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                Regex ConnotePNO = new Regex(@"\w*-\w*-\w*-\w* \w* \w*");
                String pno = String.Empty;
                foreach (String item in strArr)
                {
                    Match rqsmatch = ConnotePNO.Match(item.Trim());
                    if (rqsmatch.Success)
                    {
                        pno = item;
                        break;
                    }
                }
                String odds = String.Empty;
                String rqs = String.Empty;

                Regex ConnoteOdds = new Regex(@"@(.*?)元");
                Regex ConnoteRqs = new Regex(@"(让分:主|预设总分:|让球:主)[0-9\.\-\+]*");

                reInfo = reInfo.Substring(0, reInfo.LastIndexOf("@") + 7);

                int changci = 0,m=0;
                if (lt.license_id == LicenseContants.License.GAMEIDJCZQ || lt.license_id == LicenseContants.License.GAMEIDJCLQ)
                {
                    if (lt.play_type.Contains("null"))
                    {
                        m=1;
                    }
                    else
                    {
                        Match rqsmatch = (new Regex(@"\d*c\d*")).Match(lt.play_type);
                        int.TryParse(rqsmatch.Success? rqsmatch.Value.Split('c')[0]:"0",out m);
                    }

                    MatchCollection strmc = new Regex(@"周.\d\d\d([^周])*", RegexOptions.IgnoreCase).Matches(reInfo.Replace(Environment.NewLine, " "));                    
                    foreach (Match item in strmc)
                    {
                        odds += changci == 0 ? "" : ", ";//不是第一关，补一个
                        rqs += changci == 0 ? "" : ",";//不是第一关，补一个
                        //取当前场次的赔率
                        Match rqsmatch = ConnoteRqs.Match(item.Value.Trim());
                        rqs += rqsmatch.Success ? rqsmatch.Value.Trim().Replace("让分:主", "")
                            .Replace("预设总分:", "").Replace("让球:主", ""): "+0";


                        int shaiguo = 0;
                        foreach (Match mch in ConnoteOdds.Matches(item.Value.Trim()))
                        {
                            odds += shaiguo == 0 ? "" : "@";//不是第一关，补一个
                            odds += mch.Value.Trim().Replace("@", "").Replace("元", "");
                            shaiguo++;
                        }

                        changci++;
                    }
                }

                if (m==changci)//赔率格式正确
                {
                    if (!String.IsNullOrEmpty(pno))
                    {
                        lt.ticket_odds = odds + ":" + pno;
                    }
                    else
                    {
                        lt.ticket_odds = odds;
                    }
                    lt.ticket_rqs = rqs;
                }
                else
                {
                    if (!String.IsNullOrEmpty(pno))
                    {
                        lt.ticket_odds = ":" + pno+"####"+ odds+"****"+ rqs;
                    }
                    else
                    {
                        lt.ticket_odds = ":" + pno + "####" + odds + "****" + rqs;
                    }
                }               
            }
            catch
            { }
        }

        /// <summary>
        ///  比对方法
        /// </summary>
        /// <returns></returns>
        public static Boolean comparisonFunction(lottery_ticket lt, String reInfo,out String resultStr) {

            //先初始化各项值，保证插入数据库的时候不会出错            
            Boolean result = true;
            StringBuilder resb = new StringBuilder("比对结果:");
            //比对彩种
            if (!ComparisonLicenseName(lt,reInfo))
            {
                result = result & false;
                resb.Append("彩种比对失败!");
            }

            //比对玩法
            if (!ComparisonPlayName(lt, reInfo))
            {
                result = result & false;
                resb.Append("玩法比对失败!");
            }

            //比对过关方式
            if (lt.license_id == LicenseContants.License.GAMEIDJCLQ ||
                    lt.license_id == LicenseContants.License.GAMEIDJCZQ)
            {
                //比对过关方式
                if (!ComparisonPassType(lt, reInfo))
                {
                    result = result & false;
                    resb.Append("过关方式比对失败!");
                }
            }
            else
            {
                //比对期号
                if (!ComparisonIssue(lt, reInfo))
                {
                    result = result & false;
                    resb.Append("期号比对失败!");
                }
            }

            //比对倍数
            if (!ComparisonMultile(lt, reInfo))
            {
                result = result & false;
                resb.Append("倍数比对失败!");
            }

            //比对金额
            if (!ComparisonMoney(lt, reInfo))
            {
                result = result & false;
                resb.Append("金额比对失败!");
            }

            //出票赔率
            getTicketOddsRqs(lt, reInfo);

            resb.Append(result?"比对成功!":"");
            resultStr = resb.ToString();
            return result;
        }
    }
}
