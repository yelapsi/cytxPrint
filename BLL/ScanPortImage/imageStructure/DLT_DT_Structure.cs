using Maticsoft.BLL.ScanPortImage.imageStructure;
using Maticsoft.Common.model;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
   public class DLT_DT_Structure: SPImageStructure
    {
       public DLT_DT_Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 2;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 16 * SPImageGlobal.BB_HIGH;

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               this.DATA_BLOCK_LIST.Add(new DLT_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                               SPImageGlobal.START_POINT_Y + (i*5+2) * SPImageGlobal.BB_HIGH));
           }
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                                SPImageGlobal.START_POINT_Y + 12 * SPImageGlobal.BB_HIGH));

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
                                SPImageGlobal.START_POINT_Y + 15 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
            String[] codes = lt.bet_code.Split('+');
            this.DATA_BLOCK_LIST[0].getPointArrayByData(points, (codes[0].Contains(")") ? codes[0].Split(')')[0].Replace("(", "") : "") + "+" + (codes[1].Contains(")") ? codes[1].Split(')')[0].Replace("(", "") : ""));//胆码
            this.DATA_BLOCK_LIST[1].getPointArrayByData(points, (codes[0].Contains(")") ? codes[0].Split(')')[1].Replace("(", "") : codes[0]) + "+" + (codes[1].Contains(")") ? codes[1].Split(')')[1] : codes[1]));//拖码
            this.DATA_BLOCK_LIST[2].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
                        
            return points;
        }

    }
}
