using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class JXSSCPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private JXSSCPlayType() { }
        private static JXSSCPlayType instance = new JXSSCPlayType();
        public static JXSSCPlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        public const int WXZHXDS = 1;   //	五星直选单式
        public const int WXZHXFS = 2;   //	五星直选复式
        public const int WXTXDS = 3;        //	五星通选单式
        public const int WXTXFS = 4;        //	五星通选复式
        public const int S4XZHXDS = 5;  //	四星直选单式
        public const int S4XZHXFS = 6;  //	四星直选复式
        public const int SXZHXDS = 7;   //	三星直选单式
        public const int SXZHXFS = 8;   //	三星直选复式
        public const int SXHZ = 9;      //	三星和值
        public const int Z3BH = 10;     //	组三包号
        public const int Z3ZHX = 11;        //	组三直选
        public const int Z6BHDS = 12;   //	组六包号单式
        public const int Z6BHFS = 13;   //	组六包号复式
        public const int EXZHXDS = 14;  //	二星直选单式
        public const int EXZHXFS = 15;  //	二星直选复式
        public const int EXHZ = 16;     //	二星和值
        public const int EXZXDS = 17;   //	二星组选单式
        public const int EXZXFS = 18;   //	二星组选复式
        public const int YXZHXDS = 19;  //	一星直选单式
        public const int YXZHXFS = 20;  //	一星直选复式
        public const int DXDSDS = 21;   //	大小单双单式
        public const int DXDSFS = 22;   //	大小单双复式
        public const int RX1 = 23;      //	任选选一
        public const int RX2 = 24;		//	任选选二

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {WXZHXDS.ToString(),"五星直选单式" },
            {WXZHXFS.ToString(),"五星直选复式" },
            {WXTXDS.ToString(),"五星通选单式" },
            {WXTXFS.ToString(),"五星通选复式" },
            {S4XZHXDS.ToString(),"四星直选单式" },
            {S4XZHXFS.ToString(),"四星直选复式" },
            {SXZHXDS.ToString(),"三星直选单式" },
            {SXZHXFS.ToString(),"三星直选复式" },
            {SXHZ.ToString(),"三星和值" },
            {Z3BH.ToString(),"组三包号" },
            {Z3ZHX.ToString(),"组三直选" },
            {Z6BHDS.ToString(),"组六包号单式" },
            {Z6BHFS.ToString(),"组六包号复式" },
            {EXZHXDS.ToString(),"二星直选单式" },
            {EXZHXFS.ToString(),"二星直选复式" },
            {EXHZ.ToString(),"二星和值" },
            {EXZXDS.ToString(),"二星组选单式" },
            {EXZXFS.ToString(),"二星组选复式" },
            {YXZHXDS.ToString(),"一星直选单式" },
            {YXZHXFS.ToString(),"一星直选复式" },
            {DXDSDS.ToString(),"大小单双单式" },
            {DXDSFS.ToString(),"大小单双复式" },
            {RX1.ToString(),"任选选一" },
            { RX2.ToString(),"任选选二"}
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
