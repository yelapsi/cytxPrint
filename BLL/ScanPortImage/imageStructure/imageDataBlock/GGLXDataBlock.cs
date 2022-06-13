using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
    /// <summary>
    /// 过关类型数据块
    /// </summary>
    public class GGLXDataBlock : ImageDataBlock
    {
        public GGLXDataBlock(int startx,int starty) {
            this.startPoint = new System.Drawing.Point(startx, starty);
        }

        /// <summary>
        /// 根据传入的数据，得到需要描的几个点的起始坐标
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override void getPointArrayByData(List<Point> pointlist, String data)
        {
            pointlist.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (data.StartsWith("6") ? 8 : (data.Contains("1c1") ? 3 : 5)) * SPImageGlobal.S2S_WIDTH,
       SPImageGlobal.START_POINT_Y + 2 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
        }
    }
}
