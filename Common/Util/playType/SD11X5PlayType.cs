using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class SD11X5PlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private SD11X5PlayType() { }
        private static SD11X5PlayType instance = new SD11X5PlayType();
        public static SD11X5PlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        public const int Q1DS = 1;      // 前一
        public const int Q1FS = 101;        // 前一复式
        public const int R2DS = 2;  // 任选二单式
        public const int R2FS = 3;  // 任选二普通复式
        public const int R2DT = 4;  // 任选二胆拖
        public const int Q2ZX = 5;  // 前二直选 -
        public const int Q2ZXFS = 55;   // 前二直选复式  -
        public const int Q2ZX_DS = 6;//前二组选普通单式 -
        public const int Q2ZX_FS = 7;//前二组选普通复式  -
        public const int Q2ZX_DT = 8;//前二组选胆拖   -
        public const int R3DS = 9;  // 任选三普通单式
        public const int R3FS = 10; // 任选三普通复式
        public const int R3DT = 11;  // 任选三胆拖
        public const int Q3ZX = 12; // 前三直选
        public const int Q3ZXFS = 1212; // 前三直选复式
        public const int Q3ZX_DS = 13;//前三组选普通单式
        public const int Q3ZX_FS = 14;//前三组选普通复式
        public const int Q3ZX_DT = 15;//前三组选胆拖
        public const int R4DS = 16; // 任选四普通单式
        public const int R4FS = 17; // 任选四普通复式
        public const int R4DT = 18; // 任选四胆拖
        public const int R5DS = 19; // 任选五普通单式
        public const int R5FS = 20; // 任选五普通复式
        public const int R5DT = 21; // 任选五胆拖
        public const int R6DS = 22; // 任选六普通单式
        public const int R6FS = 23; // 任选六普通复式
        public const int R6DT = 24; // 任选六胆拖
        public const int R7DS = 25; // 任选七普通单式
        public const int R7FS = 26; // 任选七普通复式
        public const int R7DT = 27; // 任选七胆拖
        public const int R8DS = 28; // 任选八普通单式
        public const int R8FS = 29; // 任选八普通复式
        public const int R8DT = 30;	// 任选八胆拖

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {Q1DS.ToString(),"前一单式"},
            {Q1FS.ToString(),"前一复式"},
            {R2DS.ToString(),"任选二单式"},
            {R2FS.ToString(),"任选二复式"},
            {R2DT.ToString(),"任选二胆拖"},
            {Q2ZX.ToString(),"前二直选单式"},
            {Q2ZXFS.ToString(),"前二直选复式"},
            {Q2ZX_DS.ToString(),"前二组选单式"},
            {Q2ZX_FS.ToString(),"前二组选复式"},
            {Q2ZX_DT.ToString(),"前二组选胆拖"},
            {R3DS.ToString(),"任选三普通单式"},
            {R3FS.ToString(),"任选三普通复式"},
            {R3DT.ToString(),"任选三胆拖"},
            {Q3ZX.ToString(),"前三直选"},
            {Q3ZXFS.ToString(),"前三直选复式"},
            {Q3ZX_DS.ToString(),"前三组选普通单式"},
            {Q3ZX_FS.ToString(),"前三组选普通复式"},
            {Q3ZX_DT.ToString(),"前三组选胆拖"},
            {R4DS.ToString(),"任选四普通单式"},
            {R4FS.ToString(),"任选四普通复式"},
            {R4DT.ToString(),"任选四胆拖"},
            {R5DS.ToString(),"任选五普通单式"},
            {R5FS.ToString(),"任选五普通复式"},
            {R5DT.ToString(),"任选五胆拖"},
            {R6DS.ToString(),"任选六普通单式"},
            {R6FS.ToString(),"任选六普通复式"},
            {R6DT.ToString(),"任选六胆拖"},
            {R7DS.ToString(),"任选七普通单式"},
            {R7FS.ToString(),"任选七普通复式"},
            {R7DT.ToString(),"任选七胆拖"},
            {R8DS.ToString(),"任选八普通单式"},
            {R8FS.ToString(),"任选八普通复式"},
            {R8DT.ToString(),"任选八胆拖"}
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
