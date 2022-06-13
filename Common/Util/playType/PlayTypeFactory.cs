using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.Util.playType
{
   public class PlayTypeFactory
    {
        /// <summary>
        ///  获取对应玩法
        /// </summary>
        /// <param name="LID"></param>
        /// <returns></returns>
        public static IPlayType getInstance(String LID) {
            return LID2PlayTypeDic[LID];
        }

        private static Dictionary<String, IPlayType> LID2PlayTypeDic =  new Dictionary<string, IPlayType> {
          {LicenseContants.License.GAMEIDPLS.ToString(), PL3PlayType.getInstance()},
        {LicenseContants.License.GAMEIDPLW.ToString(), PL5PlayType.getInstance()},
        {LicenseContants.License.GAMEIDQXC.ToString(), QXCPlayType.getInstance()},
        {LicenseContants.License.GAMEIDDLT.ToString(), DLTPlayType.getInstance()},
        {LicenseContants.License.GAMEIDSFC.ToString(), SFCPlayType.getInstance()},
        {LicenseContants.License.GAMEIDRXJ.ToString(), R9PlayType.getInstance()},
        {LicenseContants.License.GAMEIDBQC.ToString(), BQCPlayType.getInstance()},
        {LicenseContants.License.GAMEIDJQC.ToString(), JQCPlayType.getInstance()},
        {LicenseContants.License.GAMEIDJCZQ.ToString(), JCZQPlayType.getInstance()},
        {LicenseContants.License.GAMEIDJCLQ.ToString(), JCLQPlayType.getInstance()},
        {LicenseContants.License.GAMEIDSSQ.ToString(), SSQPlayType.getInstance()},
        {LicenseContants.License.GAMEIDF3D.ToString(), F3DPlayType.getInstance()},
        {LicenseContants.License.GAMEIDQLC.ToString(), QLCPlayType.getInstance()},
        {LicenseContants.License.GAMEIDLJY.ToString(), LJYPlayType.getInstance()},
        {LicenseContants.License.GAMEIDBJDC.ToString(), BJDCPlayType.getInstance()},
        {LicenseContants.License.GAMEID20X5.ToString(), L20x5PlayType.getInstance()},
        {LicenseContants.License.GAMEIDSFGG.ToString(), SFGGPlayType.getInstance()},

         {LicenseContants.License.FREQ_SD11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_ZHJ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_JX11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_GD11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_CQ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_GZ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_LN11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_SHX11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_HLJ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_FJ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_TJ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_SH11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_GX11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_BJ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_SX11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_JS11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_NMG11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_GS11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_AH11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_HB11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_SC11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_YN11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_HN11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_HUB11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_JL11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_XJ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_XZ11X5.ToString(), SD11X5PlayType.getInstance()},
        {LicenseContants.License.FREQ_NX11X5.ToString(), SD11X5PlayType.getInstance()},

        {LicenseContants.License.FREQ_HNXYSC.ToString(), HNXYSCPlayType.getInstance()},
        {LicenseContants.License.FREQ_SHSSL.ToString(), SHSSLPlayType.getInstance()},
        {LicenseContants.License.FREQ_KLPK3.ToString(), KLPK3PlayType.getInstance()},

        {LicenseContants.License.FREQ_JXSSC.ToString(), JXSSCPlayType.getInstance()},
        {LicenseContants.License.FREQ_CQSSC.ToString(), JXSSCPlayType.getInstance()},
        {LicenseContants.License.FREQ_TJSSC.ToString(), JXSSCPlayType.getInstance()},
        {LicenseContants.License.FREQ_XJSSC.ToString(), JXSSCPlayType.getInstance()},
        {LicenseContants.License.FREQ_YNSSC.ToString(), JXSSCPlayType.getInstance()},
        {LicenseContants.License.FREQ_HLJSSC.ToString(), JXSSCPlayType.getInstance()},

        {LicenseContants.License.FREQ_SHK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_GXK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_GZK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_JSK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_HUBK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_NMGK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_HBK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_JLK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_FJK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_QHK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_AHK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_GSK3.ToString(), SHK3PlayType.getInstance()},
        {LicenseContants.License.FREQ_XZK3.ToString(), SHK3PlayType.getInstance()},

        {LicenseContants.License.FREQ_CQKL10.ToString(), CQKL10PalyType.getInstance()},
        {LicenseContants.License.FREQ_HNKL10.ToString(), CQKL10PalyType.getInstance()},
        {LicenseContants.License.FREQ_TJKL10.ToString(), CQKL10PalyType.getInstance()},
        {LicenseContants.License.FREQ_YNKL10.ToString(), CQKL10PalyType.getInstance()},
        {LicenseContants.License.FREQ_GXKL10.ToString(), CQKL10PalyType.getInstance()},
        {LicenseContants.License.FREQ_GDKL10.ToString(), CQKL10PalyType.getInstance()},
        {LicenseContants.License.FREQ_HLJKL10.ToString(), CQKL10PalyType.getInstance()},

        {LicenseContants.License.FREQ_LNKL12.ToString(), LNKL12PlayType.getInstance()},
        {LicenseContants.License.FREQ_ZHJKL12.ToString(), LNKL12PlayType.getInstance()},
        {LicenseContants.License.FREQ_SCKL12.ToString(), LNKL12PlayType.getInstance()}
        };



    }
}
