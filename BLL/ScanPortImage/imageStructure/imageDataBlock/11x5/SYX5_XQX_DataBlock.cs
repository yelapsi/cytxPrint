﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class SYX5_XQX_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 5 * SPImageGlobal.BB_HIGH;

       public SYX5_XQX_DataBlock(int startx, int starty)
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
            String[] qqhq = data.Split('|');//分开各个位数
            for (int i = 0; i < qqhq.Length; i++)
            {
                String[] dz = qqhq[i].Split(',');
                for (int j = 0; j < dz.Length; j++)
                {
                    int x = 0;
                    int.TryParse(dz[j].ToString(), out x);
                    pointlist.Add(
                        new Point(this.startPoint.X + (x + 1)* SPImageGlobal.S2S_WIDTH,
                        this.startPoint.Y + i * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
                } 
            }           
        }
    }
}
