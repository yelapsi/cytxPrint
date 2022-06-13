using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
    public class SFCPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private SFCPlayType() { }
        private static SFCPlayType instance =new SFCPlayType();
        public static SFCPlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/

        public const int DS = 1;    // 单式
        public const int FS = 2;	// 复式

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {DS.ToString(),"单式" }, { FS.ToString(),"复式"}
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
