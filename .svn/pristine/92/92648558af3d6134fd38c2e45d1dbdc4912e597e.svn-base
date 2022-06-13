using Maticsoft.Common.model;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class BD_BF_DataBlock: ImageDataBlock
    {
        public static int DATA_BLOCK_HIGH = 5 * SPImageGlobal.BD_BB_HIGH_SHORT;

        public BD_BF_DataBlock(int startx, int starty)
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
            this.getBDRacePoints(pointlist, data, BJDCPlayType.BF, this.startPoint);//取赛事的点
            String[] dz = qqhq[1].Split(',');//10,20,21,30,31,32,40,41,42,9A,00,11,22,33,99,01,02,12,03,13,23,04,14,24,0A
            for (int j = 0; j < dz.Length; j++)
            {
                int x =0,y=0;
                switch (dz[j])
                {
                    case "10":
                        x = 4;
                        y = 0;
                        break;
                    case "20":
                        x = 3;
                        y = 0;
                        break;
                    case "21":
                        x = 2;
                        y = 0;
                        break;
                    case "30":
                        x = 1;
                        y = 0;
                        break;
                    case "31":
                        x = 0;
                        y = 0;
                        break;
                    case "32":
                        x = 4;
                        y = 1;
                        break;
                    case "40":
                        x = 3;
                        y = 1;
                        break;
                    case "41":
                        x = 2;
                        y = 1;
                        break;
                    case "42":
                        x = 1;
                        y = 1;
                        break;
                    case "9A":
                        x = 0;
                        y = 1;
                        break;
                    case "00":
                        x = 4;
                        y = 2;
                        break;
                    case "11":
                        x = 3;
                        y = 2;
                        break;
                    case "22":
                        x = 2;
                        y = 2;
                        break;
                    case "33":
                        x = 1;
                        y = 2;
                        break;
                    case "99":
                        x = 0;
                        y = 2;
                        break;
                    case "01":
                        x = 4;
                        y = 3;
                        break;
                    case "02":
                        x = 3;
                        y = 3;
                        break;
                    case "12":
                        x = 2;
                        y = 3;
                        break;
                    case "03":
                        x = 1;
                        y = 3;
                        break;
                    case "13":
                        x = 0;
                        y = 3;
                        break;
                    case "23":
                        x = 4;
                        y = 4;
                        break;
                    case "04":
                        x = 3;
                        y = 4;
                        break;
                    case "14":
                        x = 2;
                        y = 4;
                        break;
                    case "24":
                        x = 1;
                        y = 4;
                        break;
                    default:
                        x = 0;
                        y = 4;
                        break;
                }
                pointlist.Add(new Point(this.startPoint.X + x * SPImageGlobal.BDBF_HEAD_BB_WIDTH, this.startPoint.Y + y * SPImageGlobal.BD_BB_HIGH_SHORT));
            }            
        }
    }
}
