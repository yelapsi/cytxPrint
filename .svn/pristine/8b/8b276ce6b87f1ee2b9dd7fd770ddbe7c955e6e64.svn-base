using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
    public class L20x5PlayType:IPlayType
    {
        /*********************单例模式********************************************/
        private L20x5PlayType() { }
        private static L20x5PlayType instance = new L20x5PlayType();
        public static L20x5PlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        /// <summary>
        /// 用playId作为key
        /// </summary>
        public static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        { };

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
