using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
    public class PL3PlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private PL3PlayType() { }
        private static PL3PlayType instance = new PL3PlayType();
        public static PL3PlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        /** 排列三直选单式*/
        public const int PLSZHXDS = 1;
        /** 排列三直选复式*/
        public const int PLSZHXFS = 2;
        /** 排列三直选组合复式*/
        public const int PLSZHXZHFS = 3;
        /** 排列三直选和值*/
        public const int PLSZHXHZ = 4;
        /** 排列三直选组合胆拖*/
        public const int PLSZHXZHDT = 5;
        /** 排列三组选单式*/
        public const int PLSZXDS = 6;
        /** 排列三组三复式*/
        public const int PLSZSFS = 7;
        /** 排列三组三和值*/
        public const int PLSZSHZ = 8;
        /** 排列三组三胆拖*/
        public const int PLSZSDT = 9;
        /** 排列三组六单式*/
        public const int PLSZLDS = 10;
        /** 排列三组六复式*/
        public const int PLSZLFS = 11;
        /** 排列三组六和值*/
        public const int PLSZLHZ = 12;
        /** 排列三组六胆拖*/
        public const int PLSZLDT = 13;


        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {PLSZHXDS.ToString(),"直选单式"},
        {PLSZHXFS.ToString(),"直选复式"},
        {PLSZHXZHFS.ToString(),"直选组合复式"},
        { PLSZHXHZ.ToString(),"直选和值"},
        {PLSZHXZHDT.ToString(),"直选组合胆拖"},
        {PLSZXDS.ToString(),"组选单式"},
        {PLSZSFS.ToString(),"组三复式"},
        {PLSZSHZ.ToString(),"组三和值"},
        {PLSZSDT.ToString(),"组三胆拖"},
        {PLSZLDS.ToString(),"组六单式"},
        {PLSZLFS.ToString(),"组六复式"},
        {PLSZLHZ.ToString(),"组六和值"},
        {PLSZLDT.ToString(),"组六胆拖"}
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
