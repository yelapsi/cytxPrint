using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
   public class ECUP_GJ_GYJ_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 7 * SPImageGlobal.BB_HIGH;

       public ECUP_GJ_GYJ_DataBlock(int startx, int starty)
       {
            this.startPoint = new System.Drawing.Point(startx, starty);
        }

        /// <summary>
        /// 根据传入的数据，得到需要描的几个点的起始坐标
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
       public override void getPointArrayByData(List<Point> pointlist, String data)
        {
            String[] dz = data.Split(',');
            for (int i = 0; i < dz.Length; i++)
            {
                int x = 0;
                int.TryParse(dz[i], out x);
                pointlist.Add(
                    new Point(SPImageGlobal.LEFT_SMALL_BB_X + ((x - 1) % 12) * SPImageGlobal.S2S_WIDTH,
                    this.startPoint.Y + (int)Math.Floor(((x - 1) / 12d)+1) * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
        }
    }
}
