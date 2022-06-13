using Maticsoft.Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
   public class BD_SPF_Structure: SPImageStructure
    {
       public BD_SPF_Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 15;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = 28 * SPImageGlobal.BD_BB_HIGH;

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               this.DATA_BLOCK_LIST.Add(new BD_SPF_DataBlock(SPImageGlobal.START_POINT_X_BD + (i < 7 ? 6 * SPImageGlobal.BD_HEAD_BB_WIDTH : 0),
                               SPImageGlobal.START_POINT_Y + ((i<7?i:i-7)*3+1) * SPImageGlobal.BD_BB_HIGH));
           }

           //过关方式
           this.DATA_BLOCK_LIST.Add(new BD_GGFS_DataBlock(SPImageGlobal.START_POINT_X_BD + 6 * SPImageGlobal.BD_HEAD_BB_WIDTH,
                               SPImageGlobal.START_POINT_Y + 22 * SPImageGlobal.BD_BB_HIGH, lNameStr));
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.START_POINT_X_BD,
                                SPImageGlobal.START_POINT_Y + 25 * SPImageGlobal.BD_BB_HIGH));

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
