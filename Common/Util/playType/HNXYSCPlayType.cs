using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class HNXYSCPlayType : IPlayType
    {
        /*********************单例模式********************************************/
        private HNXYSCPlayType() { }
        private static HNXYSCPlayType instance = new HNXYSCPlayType();
        public static HNXYSCPlayType getInstance()
        {
            return instance;
        }
        /*********************单例模式********************************************/
        public const int Q1DS = 1;      // 前一（冠军）单式，格式：01;02;03
        public const int Q1FS = 2;      // 前一复式，格式：05,06
        public const int Q2DS = 3;      // 前二（冠亚军）单式，格式：01|02;02|03
        public const int Q2FS = 4;      // 前二复式，格式：01,02|03,04
        public const int Q2BH = 5;      // 前二包号，相当于排三的直选组合复式，格式：01,02,03
        public const int Q2BHDT = 6;        // 前二胆拖包号，格式：(01)02,03
        public const int Q3DS = 7;      // 前三单式，格式：01|02|03;02|04|01
        public const int Q3FS = 8;      // 前三复式，格式：01,02,03|03,04|07,09,10
        public const int Q3BH = 9;      // 前三包号，相当于排三的直选组合复式,格式：01,02,03
        public const int Q3BHDT = 10;   // 前三胆拖包号,(01)02,03,04
        public const int WZDCDS = 11;   // 位置，单车选号单式，猜中当期某辆车进入前三名即为中奖,根据奖金对照表派奖,单注浮动奖金最高可获 36 元，格式：05;06;07
        public const int WZDCFS = 12;   // 位置，单车选号复式，格式：05,06,07
        public const int WZSCDS = 13;   // 位置，双车选号单式，预测12辆赛车中获得前三名赛车中的任选意2辆赛车号码(不排序),单注浮动奖金最高可获 1012,格式：04,05;07,11
        public const int WZSCFS = 14;   // 位置，双车选号复式，格式：04,05,09
        public const int WZSCDT = 15;   // 位置，双车选号胆拖，格式：(01)02,03
        public const int YSQ1DS = 16;   // 颜色(6种颜色)前一单式，预测12辆赛车中获得第一名的赛车颜色,单注最高奖金限额为 10 元 ，红色（01,02）:A，蓝色（03,04）:B，绿色（05,06）:C，黄色（07,08）:D，银色（09,10）:E，紫色（11,12）:F
        public const int YSQ1FS = 17;   // 颜色前一复式，格式：A,B
        public const int YSQ2DS = 18;   // 颜色前二单式，预测12辆赛车中按顺序获得前两名的赛车颜色,单注最高奖金限额为 470 元 ，格式：A|B
        public const int YSQ2FS = 19;   // 颜色前二复式，格式：A,B|C,D
        public const int YSQ2BH = 20;   // 颜色前二包号，相当于排三的直选组合复式，格式：B,D
        public const int YSQ2BHDT = 21; // 颜色前二包号胆拖，格式：(A)B,D
        public const int YSQ3DS = 22;   // 颜色前三单式，预测12辆赛车中按顺序获得前三名的赛车颜色,单注最高奖金限额为 3852 元，格式：A|B|C;E|D|F
        public const int YSQ3FS = 23;   // 颜色前三复式，格式：A,B|C|D,E
        public const int YSQ3BH = 24;   // 颜色前三包号，相当于排三的直选组合复式，格式：B,D,E
        public const int YSQ3BHDT = 25; // 颜色前三包号胆拖，格式：(A)B,D,E
        public const int G2GDS = 26;        // 过两关单式，猜中连续两场比赛中获得第一名，根据奖金对照表派奖，单注最高奖金限额为10000元。 01|02;03|04
        public const int G2GFS = 27;        // 过两关复式，01,02|04
        public const int G2GBH = 28;        // 过两关包号，格式：01,02
        public const int G2GBHDT = 29;  // 过两关胆拖包号，格式：(01)02,03
        public const int G3GDS = 30;        // 过三关单式,猜中连续三场比赛中获得第一名，根据奖金对照表派奖，单注最高奖金限额为500000元。 格式：01|01|03
        public const int G3GFS = 31;        // 过三关复式，01,02|04|01
        public const int G3GBH = 32;        // 过三关包号，01,02|04|09,11
        public const int G3GBHDT = 33;  // 过三关胆拖包号，格式：(01,08)02,03
        public const int DXJODS = 34;   // 大小奇偶单式，对冠军进行大小奇偶投注,根据奖金对照表派奖,单注浮动奖金最高可获 8 元，小奇(01,03,05):A，小偶(02,04,06):B，大奇(07,09,11):C，大偶(08,10,12):D
        public const int DXJOFS = 35;   // 大小奇偶单式，格式：A,B
        public const int Z2DS = 36;     // 组二单式，猜中当前期比赛冠亚军即为中奖,根据奖金对照表派奖,单注浮动奖金最高可获 5000 元 ，格式：05,06
        public const int Z2FS = 37;     // 组二复式，格式：05,06,09
        public const int Z2DT = 38;     // 组二胆拖，格式：(01)02,03
        public const int Z3DS = 39;     // 组三单式，：猜中当前期比赛冠亚季军即为中奖,根据奖金对照表派奖,单注浮动奖金最高可获 27774 元，格式：01,02,03
        public const int Z3FS = 40;     // 组三复式，格式：05,06,09,11,12
        public const int Z3DT = 41;		// 组三胆拖，格式：(01)02,03,07,09

        /// <summary>
        /// 用playId作为key
        /// </summary>
        private static Dictionary<String, String> playPId2PNameDictionary = new Dictionary<String, String>()
        {
            {Q1DS.ToString(),"前一（冠军）单式" },
        {Q1FS.ToString(),"前一复式" },
        {Q2DS.ToString(),"前二（冠亚军）单式" },
        {Q2FS.ToString(),"前二复式" },
        {Q2BH.ToString(),"前二包号" },
        {Q2BHDT.ToString(),"前二胆拖包号" },
        {Q3DS.ToString(),"前三单式" },
        {Q3FS.ToString(),"前三复式" },
        {Q3BH.ToString(),"前三包号" },
        {Q3BHDT.ToString(),"前三胆拖包号" },
        {WZDCDS.ToString(),"位置，单车选号单式" },
        {WZDCFS.ToString(),"位置，单车选号复式" },
        {WZSCDS.ToString(),"位置，双车选号单式" },
        {WZSCFS.ToString(),"位置，双车选号复式" },
        {WZSCDT.ToString(),"位置，双车选号胆拖" },
        {YSQ1DS.ToString(),"颜色(6种颜色)前一单式" },
        {YSQ1FS.ToString(),"颜色前一复式" },
        {YSQ2DS.ToString(),"颜色前二单式" },
        {YSQ2FS.ToString(),"颜色前二复式" },
        {YSQ2BH.ToString(),"颜色前二包号" },
        {YSQ2BHDT.ToString(),"颜色前二包号胆拖" },
        {YSQ3DS.ToString(),"颜色前三单式" },
        {YSQ3FS.ToString(),"颜色前三复式" },
        {YSQ3BH.ToString(),"颜色前三包号" },
        {YSQ3BHDT.ToString(),"颜色前三包号胆拖" },
        {G2GDS.ToString(),"过两关单式" },
        {G2GFS.ToString(),"过两关复式" },
        {G2GBH.ToString(),"过两关包号" },
        {G2GBHDT.ToString(),"过两关胆拖包号" },
        {G3GDS.ToString(),"过三关单式" },
        {G3GFS.ToString(),"过三关复式" },
        {G3GBH.ToString(),"过三关包号" },
        {G3GBHDT.ToString(),"过三关胆拖包号" },
        {DXJODS.ToString(),"大小奇偶单式" },
        {DXJOFS.ToString(),"大小奇偶单式" },
        {Z2DS.ToString(),"组二单式" },
        {Z2FS.ToString(),"组二复式" },
        {Z2DT.ToString(),"组二胆拖" },
        {Z3DS.ToString(),"组三单式" },
        {Z3FS.ToString(),"组三复式" },
        {Z3DT.ToString(),"组三胆拖" }
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
