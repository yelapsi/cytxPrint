using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class LNKL12PlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private LNKL12PlayType() { }
        private static LNKL12PlayType instance = new LNKL12PlayType();
        public static LNKL12PlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
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
