using Maticsoft.Common.model;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class LCBQCStructure: SPImageStructure
    {
        public LCBQCStructure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 3;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 16 * SPImageGlobal.BB_HIGH;

           for (int i = 0; i < 3; i++)
           {
               this.DATA_BLOCK_LIST.Add(new LCBQC_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X + (2 - i) * SPImageGlobal.RACE_BLOCK_WIDTH,
                               SPImageGlobal.START_POINT_Y + 1 * SPImageGlobal.BB_HIGH));
           }
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                                SPImageGlobal.START_POINT_Y + 14 * SPImageGlobal.BB_HIGH));

        }

        /// <summary>
        /// 根据票面数据，获取所有要描绘的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public override List<Point> getDrawPoints(lottery_ticket lt)
        {
            List<Point> points = new List<Point>();

            String[] codes = lt.bet_code.Split(';');
            if (lt.play_type.Equals(BQCPlayType.FS.ToString()))//复式
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 8 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 4 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                this.DATA_BLOCK_LIST[3].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            }
            else
            {
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
