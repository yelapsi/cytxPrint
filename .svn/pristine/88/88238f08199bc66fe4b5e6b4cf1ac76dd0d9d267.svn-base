using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
   public class JL_SFC_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 11 * SPImageGlobal.BB_HIGH;

       public JL_SFC_DataBlock(int startx, int starty)
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
            String[] dz = data.Split(':');
            //取对阵的点
            this.getSMGRacePoints(pointlist, dz[0], this.startPoint);//对阵的点
            //取竞猜结果的点
            this.getGuessResultPoints(pointlist, new String[] { dz[1] });
        }

        /// <summary>
        /// 取得竞猜结果的点位值
        /// </summary>
        /// <param name="resultdata"></param>
        private void getGuessResultPoints(List<Point> plist, String[] resultdata) {
            int result = 0;
            foreach (String items in resultdata)
            {
                foreach (String item in items.Split(','))
                {
                    int.TryParse(item, out result);
                    plist.Add(new Point(startPoint.X + (result % 2 + (result > 5 ? 2 : 0)) * SPImageGlobal.S2S_WIDTH,
                        this.startPoint.Y + (8 + (result > 5 ? result-6 : result) / 2) * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
                }                
            }
        }
    }
}
