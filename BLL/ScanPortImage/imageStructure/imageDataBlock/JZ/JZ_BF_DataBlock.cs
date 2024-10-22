﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class JZ_BF_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 15 * SPImageGlobal.BB_HIGH;

       public JZ_BF_DataBlock(int startx, int starty)
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
            //1,9,27,19,2,10,28,20,3,11,29,21,4,12,30,22,5,0,18,23,6,14,17,24,7,15,13,25,8,16,26
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
                    case "1":
                        y = 7;
                        break;
                    case "2":
                        y = 8;
                        break;
                    case "3":
                        y = 9;
                        break;
                    case "4":
                        y = 10;
                        break;
                    case "5":
                        y = 11;
                        break;
                    case "6":
                        y = 12;
                        break;
                    case "7":
                        y = 13;
                        break;
                    case "8":
                        y = 14;
                        break;
                    case "9":
                        x = 1;
                        y = 7;
                        break;
                    case "10":
                        x = 1;
                        y = 8;
                        break;
                    case "11":
                        x = 1;
                        y = 9;
                        break;
                    case "12":
                        x = 1;
                        y = 10;
                        break;
                    case "0":
                        x = 1;
                        y = 11;
                        break;
                    case "14":
                        x = 1;
                        y = 12;
                        break;
                    case "15":
                        x = 1;
                        y = 13;
                        break;
                    case "16":
                        x = 1;
                        y = 14;
                        break;
                    case "27":
                        x = 2;
                        y = 7;
                        break;
                    case "28":
                        x = 2;
                        y = 8;
                        break;
                    case "29":
                        x = 2;
                        y = 9;
                        break;
                    case "30":
                        x = 2;
                        y = 10;
                        break;
                    case "18":
                        x = 2;
                        y = 11;
                        break;
                    case "17":
                        x = 2;
                        y = 12;
                        break;
                    case "13":
                        x = 2;
                        y = 13;
                        break;
                    case "19":
                        x = 3;
                        y = 7;
                        break;
                    case "20":
                        x = 3;
                        y = 8;
                        break;
                    case "21":
                        x = 3;
                        y = 9;
                        break;
                    case "22":
                        x = 3;
                        y = 10;
                        break;
                    case "23":
                        x = 3;
                        y = 11;
                        break;
                    case "24":
                        x = 3;
                        y = 12;
                        break;
                    case "25":
                        x = 3;
                        y = 13;
                        break;
                    default:
                        x = 3;
                        y = 14;
                        break;
                }
                plist.Add(new Point(startPoint.X + x * SPImageGlobal.S2S_WIDTH,
                this.startPoint.Y + y *SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
        }
    }
}