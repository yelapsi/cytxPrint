using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class JCZQPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private JCZQPlayType() { }
        private static JCZQPlayType instance = new JCZQPlayType();
        public static JCZQPlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        public const int SPF = 1;   // 胜平负
        public const int RQSPF = 2; // 让球胜平负
        public const int ZJQ = 3;   // 总进球
        public const int BQC = 4;   // 半全场
        public const int BF = 5;    // 比分
        public const int HHGG = 6;  // 混合过关
        public const int ECUP = 7;  // 欧冠
        public const int WCUP = 8;  // 世界杯冠军
        public const int WCUPGYJ = 9;// 世界杯冠亚军
        public const int ECUPGJ = 10;// 世界杯冠亚军
        public const int ECUPGYJ = 11;// 世界杯冠亚军

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {SPF.ToString(),"胜平负"},
        {RQSPF.ToString(),"让球胜平负"},
        {ZJQ.ToString(),"总进球"},
        {BQC.ToString(),"半全场"},
        {BF.ToString(),"比分"},
        {HHGG.ToString(),"混合过关"},
        {ECUP.ToString(),"欧冠"},
        {WCUP.ToString(),"世界杯冠军"},
        {WCUPGYJ.ToString(),"世界杯冠亚军"},
        {ECUPGJ.ToString(),"竞彩名次-冠军"},
        {ECUPGYJ.ToString(),"竞彩名次-冠亚军"}
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
