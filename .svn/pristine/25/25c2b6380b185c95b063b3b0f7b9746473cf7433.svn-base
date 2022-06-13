using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
    /// <summary>
    /// 北京单场玩法
    /// </summary>
   public class BJDCPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private BJDCPlayType() { }
        private static BJDCPlayType instance = new BJDCPlayType();
        public static BJDCPlayType getInstance()
        {
            return BJDCPlayType.instance;
        }
        /*********************单例模式********************************************/
        public const int SFGG = 1;  // 胜负过关
        public const int SPF = 2;   // 胜平负
        public const int BF = 3; //比分
        public const int BQC = 4;//半全场
        public const int ZJQ = 5;//总进球
        public const int SXDS = 6;//上下单双

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<string, String>()
        {
              {SFGG.ToString(),"胜负过关" },
              {SPF.ToString(),"胜平负" },
              {BF.ToString(),"比分" },
              {BQC.ToString(),"半全场" },
              {ZJQ.ToString(),"总进球" },
              { SXDS.ToString(),"上下单双"}
        };

        /// <summary>
        /// 获取玩法名称
        /// </summary>
        /// <param name="playID"></param>
        /// <returns></returns>
        public string getTypeName(string playID)
        {
            if (playPId2PNameDictionary.ContainsKey(playID))
            {
                return playPId2PNameDictionary[playID];
            }

            return "未知玩法";
        }
    }
}
