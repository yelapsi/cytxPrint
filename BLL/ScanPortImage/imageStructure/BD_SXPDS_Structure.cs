using Maticsoft.Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
   public class BD_SXPDS_Structure: SPImageStructure
    {
       public BD_SXPDS_Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 6;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 18 * SPImageGlobal.BD_BB_HIGH_SHORT;

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               this.DATA_BLOCK_LIST.Add(new BD_SXP_DS_DataBlock(SPImageGlobal.START_POINT_X_BD + 3 * SPImageGlobal.BD_HEAD_BB_WIDTH,
                               SPImageGlobal.START_POINT_Y + (i * 3+1) * SPImageGlobal.BD_BB_HIGH_SHORT));
           }

           //过关方式
           this.DATA_BLOCK_LIST.Add(new BD_GGFS_DataBlock(SPImageGlobal.START_POINT_X_BD,
                               SPImageGlobal.START_POINT_Y + 10 * SPImageGlobal.BD_BB_HIGH_SHORT, lNameStr));
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.START_POINT_X_BD,
                                SPImageGlobal.START_POINT_Y + SPImageGlobal.BD_BB_HIGH_SHORT));

        }

        /// <summary>
        /// 根据票面数据，获取所有要描绘的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public override List<Point> getDrawPoints(lottery_ticket lt)
        {
            List<Point> points = new List<Point>();
            String[] codes = lt.bet_code.Split('|');
                for (int i = 0; i < this.DATA_BLOCK_LIST.Count; i++)
                {
                    if (i < this.SLIP_EVENT_NUMBER)
                    {
                        if (i < codes.Length)//codes.Length
                        {
                            this.DATA_BLOCK_LIST[i].getPointArrayByData(points, codes[i]);
                        }
                    }
                    else if (i == this.DATA_BLOCK_LIST.Count - 2)//过关方式
                    {
                        this.DATA_BLOCK_LIST[i].getPointArrayByData(points, lt.play_type.Replace("null", "1c1").Split('-')[1]);
                    }
                    else if (i == this.DATA_BLOCK_LIST.Count - 1)//倍数
                    {
                        this.DATA_BLOCK_LIST[i].getPointArrayByData(points, lt.license_id.ToString() + "@" + lt.play_type.Replace("null", "1c1").Split('-')[0] + "-" + lt.multiple);
                    }
                }          
            return points;
        }

    }
}
