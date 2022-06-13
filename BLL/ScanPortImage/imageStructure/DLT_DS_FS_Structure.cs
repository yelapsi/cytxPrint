using Maticsoft.BLL.ScanPortImage.imageStructure;
using Maticsoft.Common.model;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
   public class DLT_DS_FS_Structure: SPImageStructure
    {
       public DLT_DS_FS_Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 5;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 32 * SPImageGlobal.BB_HIGH;

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               this.DATA_BLOCK_LIST.Add(new DLT_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                               SPImageGlobal.START_POINT_Y + (i*5+3) * SPImageGlobal.BB_HIGH));
           }
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                                SPImageGlobal.START_POINT_Y + 28 * SPImageGlobal.BB_HIGH));

        }

        /// <summary>
        /// 根据票面数据，获取所有要描绘的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public override List<Point> getDrawPoints(lottery_ticket lt)
        {
            List<Point> points = new List<Point>();
            if (int.Parse(lt.bet_price) / int.Parse(lt.bet_num) / int.Parse(lt.multiple) == 3)//追加
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 12 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 31 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
            String[] codes = lt.bet_code.Split(';');
            if (lt.play_type.Equals(DLTPlayType.FS.ToString()))//复式
            {
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 12 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 6 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                this.DATA_BLOCK_LIST[5].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
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
