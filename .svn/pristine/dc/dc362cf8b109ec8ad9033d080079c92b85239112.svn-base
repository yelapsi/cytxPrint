using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util
{
   public class BettingItemConstant
    {
       /// <summary>
       /// 竞彩足球投注项翻译对应
       /// </summary>
       public static Dictionary<String, Dictionary<String, String>> JZ_BETTINGITEM = new Dictionary<string, Dictionary<string, string>>() {
           //竞彩足球胜平负的投注项
       {JCZQPlayType.SPF.ToString(),new Dictionary<string, string>() { { "3", "胜" }, { "1", "平" }, { "0", "负" } }},
       //竞彩足球让球胜平负的投注项
       {JCZQPlayType.RQSPF.ToString(),new Dictionary<string, string>() { { "3", "胜" }, { "1", "平" }, { "0", "负" } }},
       {JCZQPlayType.BF.ToString(),new Dictionary<string, string>() { 
       {"0", "胜其他" },{"1", "1:0" },{"2", "2:0" },{"3", "2:1" },{"4", "3:0" },{"5", "3:1" },{"6", "3:2" },{"7", "4:0" },
        {"8", "4:1" },{"9", "4:2" },{"10", "5:0" },{"11", "5:1" },{"12", "5:2" },{"13", "平其他" },{"14", "0:0" },
        {"15", "1:1" },{"16", "2:2" },{"17", "3:3" },{"18", "负其他" },{"19", "0:1" },{"20", "0:2" },{"21", "1:2" },
        {"22", "0:3" },{"23", "1:3" },{"24", "2:3" },{"25", "0:4" },{"26", "1:4" },{"27", "2:4" },{"28", "0:5" },
        {"29", "1:5" },{"30", "2:5" }}},
       {JCZQPlayType.BQC.ToString(),new Dictionary<string, string>() {
       {"33","胜胜"},{"31","胜平"},{"30","胜负"},{"13","平胜"},{"11","平平"},{"10","平负"},
		{"03","负胜"},{"01","负平"},{"00","负负"}}},
        {JCZQPlayType.ZJQ.ToString(),new Dictionary<string, string>() {
      {"0","0"},{"1","1"},{"2","2"},{"3","3"},{"4","4"},{"5","5"},{"6","6"},{"7","7+"}}}
       };


       /// <summary>
       /// 竞彩篮球投注项翻译对应
       /// </summary>
       public static Dictionary<String, Dictionary<String, String>> JL_BETTINGITEM = new Dictionary<string, Dictionary<string, string>>() {
           //竞彩篮球胜负的投注项
       {JCLQPlayType.SF.ToString(),new Dictionary<string, string>() { { "3", "主胜" },{ "0", "主负" } }},
       //竞彩篮球让fen胜负的投注项
       {JCLQPlayType.RFSF.ToString(),new Dictionary<string, string>() { { "0", "主负(让)" }, { "3", "主胜(让)" } }},
       {JCLQPlayType.DXF.ToString(),new Dictionary<string, string>() { 
       {"0", "大" },{"1", "小" }}},
       {JCLQPlayType.SFC.ToString(),new Dictionary<string, string>() {
       {"0", "客胜1-5"},{"1", "客胜6-10"},{"2", "客胜11-15"},{"3", "客胜16-20"},{"4", "客胜21-25"},
		{"5", "客胜26+"},{"6", "主胜1-5"},{"7", "主胜6-10"},{"8", "主胜11-15"},{"9", "主胜16-20"},
		{"10", "主胜21-25"},{"11", "主胜26+"}}}
       };

    }
}
