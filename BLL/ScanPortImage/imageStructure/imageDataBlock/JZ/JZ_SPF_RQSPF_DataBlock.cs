using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class JZ_SPF_RQSPF_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 8 * SPImageGlobal.BB_HIGH;

       public JZ_SPF_RQSPF_DataBlock(int startx, int starty)
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
            //0,1,2,3,4,5,6,7
            this.getGuessResultPoints(pointlist, dz[1].Split(','));
        }

        /// <summary>
        /// 取得竞猜结果的点位值
        /// </summary>
        /// <param name="resultdata"></param>
        private void getGuessResultPoints(List<Point> plist, String[] resultdata) {
            foreach (String item in resultdata)
            {
                int x = 0,y = 0;
                switch (item)
                {
                    case "3":
                        x = 0;
                        y = 7;
                        break;
                    case "1":
                        x = 1;
                        y = 7;
                        break;
                    default:
                        x = 2;
                        y = 7;
                        break;                    
                }
                plist.Add(new Point(startPoint.X + x * SPImageGlobal.S2S_WIDTH,
                this.startPoint.Y + y *SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
        }
    }
}