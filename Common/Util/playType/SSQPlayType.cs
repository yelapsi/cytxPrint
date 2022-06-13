using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
    public class SSQPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private SSQPlayType() { }
        private static SSQPlayType instance = new SSQPlayType();
        public static SSQPlayType getInstance()
        {
            return null == instance ? new SSQPlayType() : instance;
        }
        /*********************单例模式********************************************/

        public const int DS = 1;    // 单式
        public const int FS = 2;	// 复式
        public const int DT = 3;	// 胆拖

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<string, String>()
        {
            {DS.ToString(),"单式" }, { FS.ToString(),"复式"}, { DT.ToString(),"胆拖"}
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