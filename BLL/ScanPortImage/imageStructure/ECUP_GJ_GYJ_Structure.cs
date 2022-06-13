using Maticsoft.Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class ECUP_GJ_GYJ_Structure: SPImageStructure
    {
        public ECUP_GJ_GYJ_Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 1;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 15 * SPImageGlobal.BB_HIGH;

           this.DATA_BLOCK_LIST.Add(new ECUP_GJ_GYJ_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                               SPImageGlobal.START_POINT_Y + 3 * SPImageGlobal.BB_HIGH));
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X + 8 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 10 * SPImageGlobal.BB_HIGH));

        }

        /// <summary>
        /// 根据票面数据，获取所有要描绘的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public override List<Point> getDrawPoints(lottery_ticket lt)
        {
            List<Point> points = new List<Point>();
            //判断是冠军还是冠亚军
            points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (lt.play_type.StartsWith("10-")?4:10) * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 2 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            
            String[] codes = lt.bet_code.Split(',');
            String code = String.Empty;
            for (int i = 0; i < codes.Length; i++)
            {
                code += codes[i].Split('_')[0] + (i < codes.Length-1 ? "," : "");
            }

            this.DATA_BLOCK_LIST[0].getPointArrayByData(points, code);
            this.DATA_BLOCK_LIST[1].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            return points;
        }

    }
}
