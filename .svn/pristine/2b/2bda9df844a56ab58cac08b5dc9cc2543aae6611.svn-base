using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class MultipleDataBlock:ImageDataBlock
    {
        public MultipleDataBlock(int startx, int starty)
        {
            this.startPoint = new System.Drawing.Point(startx, starty);
        }

        /// <summary>
        /// 取倍数对应的点的位置
        /// </summary>
        /// <param name="pointlist"></param>
        /// <param name="data"></param>
        public override void getPointArrayByData(List<Point> pointlist, string data)
        {
            String[] datass = data.Split('-');
            int multiple = 0;
            int.TryParse(datass[1], out multiple);
            this.getMultiplePoints(pointlist, multiple, this.startPoint, datass[0]);
        }
    }
}
