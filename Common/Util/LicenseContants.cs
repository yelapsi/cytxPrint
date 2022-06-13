using System;
using System.Collections.Generic;

namespace Maticsoft.Common.Util
{
    public class LicenseContants
    {
        /// <summary>
        /// 彩种类别
        /// </summary>
        public static class LicenseType
        {
            public const int SPORT_LOTTERY = 1;//体彩
            public const int WELFARE_LOTTERY = 2;//福彩
            public const int HIGH_FREQUENCY = 3;//高频彩
        }

        public static Dictionary<String, String> licenseTypeDictionary = new Dictionary<string, string>()
        {
            { LicenseContants.LicenseType.SPORT_LOTTERY.ToString(),"体彩"},
            { LicenseContants.LicenseType.WELFARE_LOTTERY.ToString(),"福彩"},
            { LicenseContants.LicenseType.HIGH_FREQUENCY.ToString(),"高频彩"}
        };

        /// <summary>
        /// 采种
        /// </summary>
        public static class License
        {
            /** 游戏类别与名称*/
            /** 排列三*/
            public const int GAMEIDPLS = 1;
            /** 排列五*/
            public const int GAMEIDPLW = 2;
            /** 七星彩*/
            public const int GAMEIDQXC = 3;
            /** 大乐透*/
            public const int GAMEIDDLT = 4;
            /** 胜负彩*/
            public const int GAMEIDSFC = 5;
            /** 任选9*/
            public const int GAMEIDRXJ = 6;
            /** 半全场*/
            public const int GAMEIDBQC = 7;
            /** 进球彩*/
            public const int GAMEIDJQC = 8;
            /** 竞彩足球*/
            public const int GAMEIDJCZQ = 9;
            /** 竞彩篮球*/
            public const int GAMEIDJCLQ = 10;
            /** 双色球*/
            public const int GAMEIDSSQ = 11;
            /** 福彩3D*/
            public const int GAMEIDF3D = 12;
            /** 七乐彩*/
            public const int GAMEIDQLC = 13;
            /** 体彩6+1*/
            public const int GAMEIDLJY = 20;
            /** 北京单场*/
            public const int GAMEIDBJDC = 21;
            /** 20选5*/
            public const int GAMEID20X5 = 23;
            /** 胜负过关*/
            public const int GAMEIDSFGG = 22;

            public const int FREQ_SD11X5 = 101;  // 11运夺金
            public const int FREQ_ZHJ11X5 = 102; // 浙江11选5
            public const int FREQ_JX11X5 = 103;  // 江西11选5
            public const int FREQ_GD11X5 = 104;  // 广东11选5
            public const int FREQ_CQ11X5 = 105;  // 重庆11选5
            public const int FREQ_GZ11X5 = 106;  // 贵州11选5
            public const int FREQ_LN11X5 = 107;  // 辽宁11选5
            public const int FREQ_SHX11X5 = 108; // 陕西11选5
            public const int FREQ_HLJ11X5 = 109; // 黑龙江11选5
            public const int FREQ_FJ11X5 = 110;  // 福建11选5
            public const int FREQ_TJ11X5 = 111;  // 天津11选5
            public const int FREQ_SH11X5 = 112;  // 上海11选5
            public const int FREQ_GX11X5 = 113;  // 广西11选5
            public const int FREQ_BJ11X5 = 114;  // 北京11选5
            public const int FREQ_SX11X5 = 115;  // 山西11选5
            public const int FREQ_JS11X5 = 116;  // 江苏11选5
            public const int FREQ_NMG11X5 = 117; // 内蒙11选5
            public const int FREQ_GS11X5 = 118;  // 甘肃11选5
            public const int FREQ_AH11X5 = 119;  // 安徽11选5
            public const int FREQ_HB11X5 = 120;  // 河北11选5
            public const int FREQ_SC11X5 = 121;  // 四川11选5
            public const int FREQ_YN11X5 = 122;  // 云南11选5
            public const int FREQ_HN11X5 = 123;  // 河南11选5
            public const int FREQ_HUB11X5 = 124; // 湖北11选5
            public const int FREQ_JL11X5 = 125;  // 吉林11选5
            public const int FREQ_XJ11X5 = 126;  // 新疆11选5
            public const int FREQ_XZ11X5 = 127;  // 西藏11选5
            public const int FREQ_NX11X5 = 128;  // 宁夏11选5

            public const int FREQ_HNXYSC = 201;  // 湖南幸运赛车
            public const int FREQ_SHSSL = 202;   // 上海时时乐
            public const int FREQ_KLPK3 = 203;   // 快乐扑克3

            public const int FREQ_JXSSC = 301;   //	江西时时彩
            public const int FREQ_CQSSC = 302;   //	重庆时时彩
            public const int FREQ_TJSSC = 303;   //	天津时时彩
            public const int FREQ_XJSSC = 304;   //	新疆时时彩
            public const int FREQ_YNSSC = 305;   //	云南时时彩
            public const int FREQ_HLJSSC = 306;  //	黑龙江时时彩

            public const int FREQ_SHK3 = 401;    //	上海快3
            public const int FREQ_GXK3 = 402;    //	广西快3
            public const int FREQ_GZK3 = 403;    //	贵州快3
            public const int FREQ_JSK3 = 404;    //	江苏快3
            public const int FREQ_HUBK3 = 405;   //	湖北快3
            public const int FREQ_NMGK3 = 406;   //	内蒙快3
            public const int FREQ_HBK3 = 407;    //	河北快3
            public const int FREQ_JLK3 = 408;    //	吉林快3
            public const int FREQ_FJK3 = 409;    //	福建快3
            public const int FREQ_QHK3 = 410;    //	青海快3
            public const int FREQ_AHK3 = 411;    //	安徽快3
            public const int FREQ_GSK3 = 412;    //	甘肃快3
            public const int FREQ_XZK3 = 413;    //	西藏快3

            public const int FREQ_CQKL10 = 501;  //	重庆快乐10分
            public const int FREQ_HNKL10 = 502;  //	湖南快乐10分
            public const int FREQ_TJKL10 = 503;  //	天津快乐10分
            public const int FREQ_YNKL10 = 504;  //	云南快乐10分
            public const int FREQ_GXKL10 = 505;  //	广西快乐10分
            public const int FREQ_GDKL10 = 506;  //	广东快乐10分
            public const int FREQ_HLJKL10 = 507; //	黑龙江快乐10分

            public const int FREQ_LNKL12 = 601;  //	辽宁快乐12
            public const int FREQ_ZHJKL12 = 602; //	浙江快乐12
            public const int FREQ_SCKL12 = 603;	//	四川快乐12
        }

        public static Dictionary<String, String> licenseId2NameDictionary = new Dictionary<string, string>() { 
        {LicenseContants.License.GAMEIDPLS.ToString(),"排列三"},
        {LicenseContants.License.GAMEIDPLW.ToString(),"排列五"},
        {LicenseContants.License.GAMEIDQXC.ToString(),"七星彩"},
        {LicenseContants.License.GAMEIDDLT.ToString(),"大乐透"},
        {LicenseContants.License.GAMEIDSFC.ToString(),"胜负彩"},
        {LicenseContants.License.GAMEIDRXJ.ToString(),"任选9"},
        {LicenseContants.License.GAMEIDBQC.ToString(),"半全场"},
        {LicenseContants.License.GAMEIDJQC.ToString(),"进球彩"},
        {LicenseContants.License.GAMEIDJCZQ.ToString(),"竞彩足球"},
        {LicenseContants.License.GAMEIDJCLQ.ToString(),"竞彩篮球"},
        {LicenseContants.License.GAMEIDSSQ.ToString(),"双色球"},
        {LicenseContants.License.GAMEIDF3D.ToString(),"福彩3D"},
        {LicenseContants.License.GAMEIDQLC.ToString(),"七乐彩"},
        {LicenseContants.License.GAMEIDLJY.ToString(),"体彩6+1"},
        {LicenseContants.License.GAMEIDBJDC.ToString(),"北京单场"},
        {LicenseContants.License.GAMEID20X5.ToString(),"20选5"},
        {LicenseContants.License.GAMEIDSFGG.ToString(),"胜负过关"},

         {LicenseContants.License.FREQ_SD11X5.ToString(),"11运夺金"},
        {LicenseContants.License.FREQ_ZHJ11X5.ToString(),"浙江11选5"},
        {LicenseContants.License.FREQ_JX11X5.ToString(),"江西11选5"},
        {LicenseContants.License.FREQ_GD11X5.ToString(),"广东11选5"},
        {LicenseContants.License.FREQ_CQ11X5.ToString(),"重庆11选5"},
        {LicenseContants.License.FREQ_GZ11X5.ToString(),"贵州11选5"},
        {LicenseContants.License.FREQ_LN11X5.ToString(),"辽宁11选5"},
        {LicenseContants.License.FREQ_SHX11X5.ToString(),"陕西11选5"},
        {LicenseContants.License.FREQ_HLJ11X5.ToString(),"黑龙江11选5"},
        {LicenseContants.License.FREQ_FJ11X5.ToString(),"福建11选5"},
        {LicenseContants.License.FREQ_TJ11X5.ToString(),"天津11选5"},
        {LicenseContants.License.FREQ_SH11X5.ToString(),"上海11选5"},
        {LicenseContants.License.FREQ_GX11X5.ToString(),"广西11选5"},
        {LicenseContants.License.FREQ_BJ11X5.ToString(),"北京11选5"},
        {LicenseContants.License.FREQ_SX11X5.ToString(),"山西11选5"},
        {LicenseContants.License.FREQ_JS11X5.ToString(),"江苏11选5"},
        {LicenseContants.License.FREQ_NMG11X5.ToString(),"内蒙11选5"},
        {LicenseContants.License.FREQ_GS11X5.ToString(),"甘肃11选5"},
        {LicenseContants.License.FREQ_AH11X5.ToString(),"安徽11选5"},
        {LicenseContants.License.FREQ_HB11X5.ToString(),"河北11选5"},
        {LicenseContants.License.FREQ_SC11X5.ToString(),"四川11选5"},
        {LicenseContants.License.FREQ_YN11X5.ToString(),"云南11选5"},
        {LicenseContants.License.FREQ_HN11X5.ToString(),"河南11选5"},
        {LicenseContants.License.FREQ_HUB11X5.ToString(),"湖北11选5"},
        {LicenseContants.License.FREQ_JL11X5.ToString(),"吉林11选5"},
        {LicenseContants.License.FREQ_XJ11X5.ToString(),"新疆11选5"},
        {LicenseContants.License.FREQ_XZ11X5.ToString(),"西藏11选5"},
        {LicenseContants.License.FREQ_NX11X5.ToString(),"宁夏11选5"},

        {LicenseContants.License.FREQ_HNXYSC.ToString(),"湖南幸运赛车"},
        {LicenseContants.License.FREQ_SHSSL.ToString(),"上海时时乐"},
        {LicenseContants.License.FREQ_KLPK3.ToString(),"快乐扑克3"},

        {LicenseContants.License.FREQ_JXSSC.ToString(),"江西时时彩"},
        {LicenseContants.License.FREQ_CQSSC.ToString(),"重庆时时彩"},
        {LicenseContants.License.FREQ_TJSSC.ToString(),"天津时时彩"},
        {LicenseContants.License.FREQ_XJSSC.ToString(),"新疆时时彩"},
        {LicenseContants.License.FREQ_YNSSC.ToString(),"云南时时彩"},
        {LicenseContants.License.FREQ_HLJSSC.ToString(),"黑龙江时时彩"},

        {LicenseContants.License.FREQ_SHK3.ToString(),"上海快3"},
        {LicenseContants.License.FREQ_GXK3.ToString(),"广西快3"},
        {LicenseContants.License.FREQ_GZK3.ToString(),"贵州快3"},
        {LicenseContants.License.FREQ_JSK3.ToString(),"江苏快3"},
        {LicenseContants.License.FREQ_HUBK3.ToString(),"湖北快3"},
        {LicenseContants.License.FREQ_NMGK3.ToString(),"内蒙快3"},
        {LicenseContants.License.FREQ_HBK3.ToString(),"河北快3"},
        {LicenseContants.License.FREQ_JLK3.ToString(),"吉林快3"},
        {LicenseContants.License.FREQ_FJK3.ToString(),"福建快3"},
        {LicenseContants.License.FREQ_QHK3.ToString(),"青海快3"},
        {LicenseContants.License.FREQ_AHK3.ToString(),"安徽快3"},
        {LicenseContants.License.FREQ_GSK3.ToString(),"甘肃快3"},
        {LicenseContants.License.FREQ_XZK3.ToString(),"西藏快3"},

        {LicenseContants.License.FREQ_CQKL10.ToString(),"重庆快乐10分"},
        {LicenseContants.License.FREQ_HNKL10.ToString(),"湖南快乐10分"},
        {LicenseContants.License.FREQ_TJKL10.ToString(),"天津快乐10分"},
        {LicenseContants.License.FREQ_YNKL10.ToString(),"云南快乐10分"},
        {LicenseContants.License.FREQ_GXKL10.ToString(),"广西快乐10分"},
        {LicenseContants.License.FREQ_GDKL10.ToString(),"广东快乐10分"},
        {LicenseContants.License.FREQ_HLJKL10.ToString(),"	黑龙江快乐10分"},

        {LicenseContants.License.FREQ_LNKL12.ToString(),"辽宁快乐12"},
        {LicenseContants.License.FREQ_ZHJKL12.ToString(),"浙江快乐12"},
        {LicenseContants.License.FREQ_SCKL12.ToString(),"四川快乐12"}
    };
    }
}
