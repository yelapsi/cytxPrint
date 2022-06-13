using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
    public class F3DPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private F3DPlayType() { }
        private static F3DPlayType instance = new F3DPlayType();
        public static F3DPlayType getInstance()
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
