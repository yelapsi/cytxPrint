using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class BD_BQC_DataBlock: ImageDataBlock
    {
        public static int DATA_BLOCK_HIGH = 3 * SPImageGlobal.BD_BB_HIGH_SHORT;

        public BD_BQC_DataBlock(int startx, int starty)
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
            String[] qqhq = data.Split(':');
            this.getBDRacePoints(pointlist, data, BJDCPlayType.BQC, this.startPoint);//取赛事的点
            String[] dz = qqhq[1].Split(',');
            for (int j = 0; j < dz.Length; j++)
            {
                int x =0,y=0;
                switch (dz[j])
                {
                    case "33":
                        x = 2;
                        y = 0;
                        break;
                    case "31":
                        x = 2;
                        y = 1;
                        break;
                    case "30":
                        x = 2;
                        y = 2;
                        break;
                    case "13":
                        x = 1;
                        y = 0;
                        break;
                    case "11":
                        x = 1;
                        y = 1;
                        break;
                    case "10":
                        x = 1;
                        y = 2;
                        break;
                    case "03":
                        x = 0;
                        y = 0;
                        break;
                    case "01":
                        x = 0;
                        y = 1;
                        break;
                    default:
                        x = 0;
                        y = 2;
                        break;
                }
                pointlist.Add(new Point(this.startPoint.X + x * SPImageGlobal.BD_HEAD_BB_WIDTH, this.startPoint.Y + y * SPImageGlobal.BD_BB_HIGH_SHORT));
            }            
        }
    }
}
