using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class JZ_BQC_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 10 * SPImageGlobal.BB_HIGH;

       public JZ_BQC_DataBlock(int startx, int starty)
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
            //33,31,30,13,11,10,03,01,00
            this.getGuessResultPoints(pointlist, dz[1].Split(','));
        }

        /// <summary>
        /// 取得竞猜结果的点位值
        /// </summary>
        /// <param name="resultdata"></param>
        private void getGuessResultPoints(List<Point> plist, String[] resultdata) {
            foreach (String item in resultdata)
            {
                String f = item.Substring(0, 1), l = item.Substring(1);
                plist.Add(new Point(startPoint.X + (l.Equals("3") ? 0 : l.Equals("1") ? 1 : 2) * SPImageGlobal.S2S_WIDTH,
                this.startPoint.Y + (f.Equals("3") ? 7 : f.Equals("1") ? 8 :9) *SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
        }
    }
}