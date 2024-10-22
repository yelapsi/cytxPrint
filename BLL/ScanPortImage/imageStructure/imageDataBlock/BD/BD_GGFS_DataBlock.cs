﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
   public class BD_GGFS_DataBlock: ImageDataBlock
    {
       public BD_GGFS_DataBlock(int startx, int starty,String key)
        {
            this.startPoint = new System.Drawing.Point(startx, starty);
            this.DIC_KEY = key;
        }


        public override void getPointArrayByData(List<Point> pointlist, String data)
        {
            String[][] thisggfs = SPImageGlobal.GGFS_STR_ARRAY_BD[this.DIC_KEY];
            for (int i = 0; i < thisggfs.Length; i++)
            {
                for (int j = 0; j < thisggfs[i].Length; j++)
                {
                    if (thisggfs[i][j].Equals(data, StringComparison.CurrentCultureIgnoreCase))
                    {
                        pointlist.Add(new Point(this.startPoint.X + (thisggfs.Length - (i+1)) * (this.DIC_KEY.Equals("BD_BF") ?SPImageGlobal.BDBF_HEAD_BB_WIDTH:SPImageGlobal.BD_HEAD_BB_WIDTH),
                            this.startPoint.Y + j * (this.DIC_KEY.Equals("BD_DC_SPF") ? SPImageGlobal.BD_BB_HIGH : SPImageGlobal.BD_BB_HIGH_SHORT)));
                        i = 1000;//外层也不需要循环
                        break;
                    }
                }
            }
        }

        public string DIC_KEY { get; set; }
    }
}
