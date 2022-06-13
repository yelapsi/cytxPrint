using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    /// <summary>
    /// 竞彩篮球大小分赛事数据块
    /// </summary>
   public class JL_DXF_SF_RFSF_DataBlock : ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 8 * SPImageGlobal.BB_HIGH;

       public JL_DXF_SF_RFSF_DataBlock(int startx, int starty)
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
            foreach (String items in resultdata)
            {
                foreach (String item in items.Split(','))
                {
                    plist.Add(new Point(startPoint.X + (item.Equals("0") ? 0 : 1) * SPImageGlobal.S2S_WIDTH,
                     this.startPoint.Y + 7 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH)); 
                }                
            }
        }
    }
}
