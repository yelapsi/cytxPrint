using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class CQKL10PalyType : IPlayType
    {
        /*********************单例模式********************************************/
        private CQKL10PalyType() { }
        private static CQKL10PalyType instance = new CQKL10PalyType();
        public static CQKL10PalyType getInstance()
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
