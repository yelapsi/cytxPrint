using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class JCLQPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private JCLQPlayType() { }
        private static JCLQPlayType instance = new JCLQPlayType();
        public static JCLQPlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        public const int SF = 1;    // 胜负
        public const int RFSF = 2;  // 让分胜负
        public const int SFC = 3;   // 胜分差
        public const int DXF = 4;   // 大小分
        public const int HHGG = 6;	// 混合过关

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {SF.ToString(),"胜负"},
        {RFSF.ToString(),"让分胜负"},
        {SFC.ToString(),"胜分差"},
        {DXF.ToString(),"大小分"},
        {HHGG.ToString(),"混合过关"}
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
