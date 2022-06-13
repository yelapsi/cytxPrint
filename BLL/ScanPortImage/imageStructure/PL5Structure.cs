using Maticsoft.BLL.ScanPortImage.imageStructure;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
    public class PL5Structure: SPImageStructure
    {
        public PL5Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 4;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 26 * SPImageGlobal.BB_HIGH;

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               this.DATA_BLOCK_LIST.Add(new PL3_PL5_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                               SPImageGlobal.START_POINT_Y + (i*6+2) * SPImageGlobal.BB_HIGH));
           }
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X+11*SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 9 * SPImageGlobal.BB_HIGH));
        }

        /// <summary>
        /// 根据票面数据，获取所有要描绘的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public override List<Point> getDrawPoints(lottery_ticket lt)
        {
            List<Point> points = new List<Point>();

            //彩种标识
            points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (lt.license_id == LicenseContants.License.GAMEIDPLW?3:2) * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

            String[] codes = lt.bet_code.Split(';');
            if (lt.license_id == LicenseContants.License.GAMEIDPLW && lt.play_type.Equals(PL5PlayType.ZHX_FS.ToString()))//排列5复式
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 4 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 7 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                this.DATA_BLOCK_LIST[4].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            }
            else if ((lt.license_id == LicenseContants.License.GAMEIDPLS) && lt.play_type.Equals(PL3PlayType.PLSZHXFS.ToString()))//排列三直选复式
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 4 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 7 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                this.DATA_BLOCK_LIST[4].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            }
            else if ((lt.license_id == LicenseContants.License.GAMEIDPLS) && lt.play_type.Equals(PL3PlayType.PLSZHXZHFS.ToString()))//排列三直选组合复式
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 4 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 7 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                this.DATA_BLOCK_LIST[4].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);

                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 12 * SPImageGlobal.S2S_WIDTH,
                                    SPImageGlobal.START_POINT_Y + 23 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
            else
            {
                if ((lt.license_id == LicenseContants.License.GAMEIDPLS) && (lt.play_type.Equals(PL3PlayType.PLSZXDS.ToString())
                    || lt.play_type.Equals(PL3PlayType.PLSZLDS.ToString())))//排列三组选单式
                {
                    points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 12 * SPImageGlobal.S2S_WIDTH,
                                    SPImageGlobal.START_POINT_Y + 23*SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
                }
                for (int i = 0; i < this.DATA_BLOCK_LIST.Count; i++)
                {
                    if (i < this.SLIP_EVENT_NUMBER)
                    {
                        if (i < codes.Length)//codes.Length
                        {
                            this.DATA_BLOCK_LIST[i].getPointArrayByData(points, codes[i]);
                        }
                    }
                    else if (i == this.DATA_BLOCK_LIST.Count - 1)//倍数
                    {
                        this.DATA_BLOCK_LIST[i].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
                    }
                }
            }            
            return points;
        }

    }
}
