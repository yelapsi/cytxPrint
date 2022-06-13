using Maticsoft.Common.model;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    /// <summary>
    /// 14场——5注
    /// </summary>
   public class SFC_5Z_Structure: SPImageStructure
    {
       public SFC_5Z_Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 6;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 33 * SPImageGlobal.BB_HIGH;

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               this.DATA_BLOCK_LIST.Add(new SFC_5Z_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X + (2 - i%3) * SPImageGlobal.RACE_BLOCK_WIDTH,
                               SPImageGlobal.START_POINT_Y + (3+(i/3)*15) * SPImageGlobal.BB_HIGH));
           }
            //倍数块——这个单子不能打倍数
           //this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
           //                     SPImageGlobal.START_POINT_Y + 17 * SPImageGlobal.BB_HIGH));

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
            int m = 1,p =0;
            int.TryParse(lt.multiple,out m);
            int.TryParse(lt.bet_price,out p);

            if (lt.play_type.Equals(SFCPlayType.FS.ToString()))//复式
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X,
                                SPImageGlobal.START_POINT_Y + 21 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                this.DATA_BLOCK_LIST[5].getPointArrayByData(points, codes[0]);
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
                }
            }            
            return points;
        }

    }
}
