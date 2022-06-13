using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    /// <summary>
    /// 14场——5注
    /// </summary>
   public class SFC_5Z_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 15 * SPImageGlobal.BB_HIGH;

       public SFC_5Z_DataBlock(int startx, int starty)
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
            String[] dz = data.Contains("|")?data.Split('|'):data.Split(',');
            for (int i = 0; i < dz.Length; i++)
            {
                char[] results = dz[i].ToCharArray();
                foreach (char item in results)
                {
                    if (item !='#')
                    {
                        pointlist.Add(
                        new Point(this.startPoint.X + (item == '0' ? 1 : (item == '1' ? 2 : 3)) * SPImageGlobal.S2S_WIDTH,
                        this.startPoint.Y + (1+i) * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH)); 
                    }                       
                }
            }
        }           
    }
}
