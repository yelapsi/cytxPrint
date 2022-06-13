using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
    public class ScanPortImageUtil
    {
        public static Bitmap creatScanPortImage(lottery_ticket lt,String times)
        {
            SPImageStructure spis = SPImageGlobal.SPISTRUCTURE_DICTIONARY[getSPIKey(lt)];
            //第一步：计算整个图片的高度(头上高度——文字内容加部分空白预留、扫描部分、尾部高度)
            Bitmap imgTemp = new Bitmap(640, spis.getStructureHigh()+300);
            Graphics g = Graphics.FromImage(imgTemp); //创建画板
            g.Clear(Color.White);

            //第二步：写入订单信息
            g.DrawString(lt.multiple+"倍"+lt.bet_price+"元", new Font("宋体", 40, FontStyle.Bold, GraphicsUnit.Pixel), SystemBrushes.ControlText, new Point(300, 2));
            g.DrawString("订单:" + lt.order_id.ToString().Replace("-","(上传)") + "(" + lt.ticket_id + "-" + times + ")\n<" + getShowName(lt.username)+">", new Font("宋体", 25, FontStyle.Bold, GraphicsUnit.Pixel), SystemBrushes.ControlText, new Point(10, 2));
            //第三步：绘制一张未填入打印内容的图片
            if (lt.license_id == 11)//双色球
            {
                ////普通双色球
                //creatBlankScanPortImage02(imgTemp, g, spis);
                ////第四步：填入打印内容
                //drawBetContent02(imgTemp, g, spis.getDrawPoints(lt));

                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.JIANGXI))
                {
                    //江西双色球
                    creatBlankScanPortImageJiangXi(imgTemp, g, spis);
                    //第四步：填入打印内容
                    drawBetContentJiangXi(imgTemp, g, spis.getDrawPoints(lt));
                }
                else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.GUANGXI))
                {
                    //广西双色球
                    creatBlankScanPortImageGuangXi(imgTemp, g, spis);
                    //第四步：填入打印内容
                    drawBetContentGuangXi(imgTemp, g, spis.getDrawPoints(lt));
                }
            }
            else if (lt.license_id == 21)
            {
                creatBlankScanPortImage_BD(imgTemp, g, spis, lt.play_type);
                drawBetContent_BD(imgTemp, g, spis.getDrawPoints(lt), lt.play_type);
                //在最后画点东西，不然投注单会被截断
                g.DrawString("[北京单场]", new Font("宋体", 25, FontStyle.Bold, GraphicsUnit.Pixel), SystemBrushes.ControlText, new Point(10, imgTemp.Height - 50));
            }
            else
            {
                creatBlankScanPortImage(imgTemp, g, spis);
                //第四步：填入打印内容
                drawBetContent(imgTemp, g, spis.getDrawPoints(lt));
            }           
            return FaqCopyTo1bpp(imgTemp);
        }

        public static Bitmap creatScanPortImage02(lottery_ticket lt)
        {
            //第一步：计算整个图片的高度(头上高度——文字内容加部分空白预留、扫描部分、尾部高度)
            Bitmap imgTemp = new Bitmap(640, 800);
            Graphics g = Graphics.FromImage(imgTemp); //创建画板
            g.Clear(Color.White);

            //第二步：写入订单信息
            g.DrawString(lt.multiple + "倍" + lt.bet_price + "元", new Font("宋体", 40, FontStyle.Bold, GraphicsUnit.Pixel), SystemBrushes.ControlText, new Point(300, 2));
            g.DrawString("订单:" + lt.order_id.ToString().Replace("-", "(上传)") + "(" + lt.ticket_id  + ")\n<" + getShowName(lt.username) + ">", new Font("宋体", 25, FontStyle.Bold, GraphicsUnit.Pixel), SystemBrushes.ControlText, new Point(10, 2));

            String[] betCode2ShowArray = BetCodeTranslationUtil.betCode2ShowArrayNoCrypt(lt.bet_code, lt.license_id.ToString(), lt.play_type);

            StringBuilder sb = new StringBuilder ( );
            String bCodeArrays = betCode2ShowArray [ 1 ].Replace ( " , ", "," ).Replace(Environment.NewLine,"^");
            int count =0;
            foreach ( char c in bCodeArrays )
            {
                sb.Append ( c );
                if ( c==0x5E )//碰到字符串自带的换行符，那就重新计算
                {
                    count = 0;
                }
                else
                {
                    count += ( int ) c >= 0x4E00 && ( int ) c <= 0x9FA5 ? 2 : 1; //中文占两个字节
                    if ( count >= 34 )
                    {
                        sb.Append ( "^" );
                        count = 0;
                    }
                }                
            }
            g.DrawString ( betCode2ShowArray [ 0 ] + "\n" + sb.ToString ( ).Replace ( "^", Environment.NewLine ) + "\n" + lt.bet_num + "注  " + lt.multiple + "倍  " + lt.bet_price + "元", new Font ( "宋体", 30, FontStyle.Bold, GraphicsUnit.Pixel ), SystemBrushes.ControlText, new Point ( 30, 100 ) );
            
            return FaqCopyTo1bpp(imgTemp);
        }



        /// <summary>
        /// 绘制一张空白图——通用方法
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="g"></param>
        /// <param name="bigp"></param>
        /// <param name="smallp"></param>
        private static void creatBlankScanPortImage(Bitmap bmp, Graphics g, SPImageStructure spis)
        {
            Pen bigp = new Pen(Color.Black, 11.7f);//大黑块画笔
            Pen smallp = new Pen(Color.Black, SPImageGlobal.PLAY_SMALL_BB_HIGH);//小黑块画笔

            String[] playCode = spis.getPTypeHeadDesc();
            //第一步：开始标识、左边黑线、结束标识
            int endy = 0;
            g.DrawLine(bigp, SPImageGlobal.START_POINT_X, SPImageGlobal.START_POINT_Y, SPImageGlobal.START_POINT_X + SPImageGlobal.BB_WIDTH, SPImageGlobal.START_POINT_Y);
            for (int i = 1; i <= spis.getStructureHigh() / SPImageGlobal.BB_HIGH; i++)
            {
                endy = SPImageGlobal.START_POINT_Y + i * SPImageGlobal.BB_HIGH + (int)Math.Floor(i / 10d);
                g.DrawLine(bigp, SPImageGlobal.START_POINT_X, endy, SPImageGlobal.START_POINT_X + SPImageGlobal.BB_WIDTH, endy);
            }

            bigp.Width += 4;
            g.DrawLine(bigp, 640 - 35, endy + SPImageGlobal.BB_WIDTH, 640, endy + SPImageGlobal.BB_WIDTH);
            //第二步：绘制玩法
            for (int i = 0; i < playCode.Length; i++)
            {
                for (int j = 0; j < playCode[i].Length; j++)
                {
                    if (playCode[i][j] == '1')
                    {
                        g.DrawLine(smallp,
                                   SPImageGlobal.LEFT_SMALL_BB_X + j * SPImageGlobal.S2S_WIDTH + (int)Math.Floor(j / 3d),
                                   SPImageGlobal.START_POINT_Y + i * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH,
                                   SPImageGlobal.LEFT_SMALL_BB_X + j * SPImageGlobal.S2S_WIDTH + SPImageGlobal.BB_WIDTH + (int)Math.Floor(j / 3d),
                                   SPImageGlobal.START_POINT_Y + i * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH);
                    }
                }
            }
        }
        /// <summary>
        /// 绘制投注内容的点
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="smallp"></param>
        /// <param name="list"></param>
        private static void drawBetContent(Bitmap imgTemp, Graphics g, List<Point> list)
        {
            Pen smallp = new Pen(Color.Black, SPImageGlobal.SMALL_BB_HIGH);//小黑块画笔
            foreach (Point item in list)
            {
                int newx = item.X + (int)Math.Floor((item.X - SPImageGlobal.LEFT_SMALL_BB_X) / SPImageGlobal.BB_WIDTH / 3d);
                g.DrawLine(smallp, newx,item.Y,newx + SPImageGlobal.BB_WIDTH - 4,item.Y);
            }
        }

        /// <summary>
        /// 绘制投注内容的点(双色球专用)
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="smallp"></param>
        /// <param name="list"></param>
        private static void drawBetContent02(Bitmap imgTemp, Graphics g, List<Point> list)
        {
            Pen smallp = new Pen(Color.Black, 24f);//小黑块画笔
            foreach (Point item in list)
            {
                int newx = item.X + (int)Math.Floor((item.X - SPImageGlobal.LEFT_SMALL_BB_X) / SPImageGlobal.BB_WIDTH / 3d);
                g.DrawLine(smallp, newx,
                item.Y + 2 + (int)Math.Floor((item.Y - SPImageGlobal.START_POINT_Y) / (3d * SPImageGlobal.BB_HIGH)),
                    newx + SPImageGlobal.BB_WIDTH - 4,
                    item.Y + 2 + (int)Math.Floor((item.Y - SPImageGlobal.START_POINT_Y) / (3d * SPImageGlobal.BB_HIGH)));
            }
        }

        /// <summary>
        /// 绘制投注内容的点(江西双色球专用)
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="smallp"></param>
        /// <param name="list"></param>
        private static void drawBetContentJiangXi(Bitmap imgTemp, Graphics g, List<Point> list)
        {
            Pen pen = new Pen(Color.Black, 29f);//画笔
            foreach (Point item in list)
            {
                g.DrawLine(pen,
                           item.X, 
                           item.Y,
                           item.X + 19,//19是黑块的宽度
                           item.Y);
            }
        }

        /// <summary>
        /// 绘制投注内容的点(广西双色球专用)
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="smallp"></param>
        /// <param name="list"></param>
        private static void drawBetContentGuangXi(Bitmap imgTemp, Graphics g, List<Point> list)
        {
            Pen pen = new Pen(Color.Black, 30f);//画笔
            foreach (Point item in list)
            {
                g.DrawLine(pen,
                           item.X, 
                           item.Y,
                           item.X + 30,//19是黑块的宽度
                           item.Y);
            }
        }

        /// <summary>
        /// 绘制投注内容的点——北单
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="smallp"></param>
        /// <param name="list"></param>
        private static void drawBetContent_BD(Bitmap imgTemp, Graphics g, List<Point> list,String play)
        {
            Pen bigp = new Pen(Color.Black, 15f);//大黑块画笔
            bool isshort = play.StartsWith("2-");//除了胜平负。短票向右修正
            foreach (Point item in list)
            {
                g.DrawLine(bigp, item.X + (isshort ? 0 : 4), item.Y, item.X + (isshort ? 0 : 4), item.Y + 25);
            }
        }

        /// <summary>
        /// 双色球投注单初始票面
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="spis"></param>
        private static void creatBlankScanPortImage02(Bitmap imgTemp, Graphics g, SPImageStructure spis)
        {
            Pen bigp = new Pen(Color.Black, 17.1f);//大黑块画笔
            Pen smallp = new Pen(Color.Black, 11.7f);//小黑块画笔

            //String[] playCode = spis.getPTypeHeadDesc();
            ////第一步：开始标识、左边黑线、结束标识
            int endy = 1544;
            g.DrawLine(bigp, 22, SPImageGlobal.START_POINT_Y, 22 + 20, SPImageGlobal.START_POINT_Y);
            g.DrawLine(bigp, 22, endy - 2, 22 + 20, endy - 2);
            g.DrawLine(smallp, 315, endy, SPImageGlobal.BB_WIDTH + 315, endy);
            g.DrawLine(smallp, 463, endy, SPImageGlobal.BB_WIDTH + 463, endy);
        }


        // 1. 江西双色球红球横坐标
        public static int[] ssqRedCoordinateX = new int[8];

        // 2. 江西双色球蓝球横坐标
        public static int[] ssqBlueCoordinateX = new int[4];

        // 3. 江西双色球 纵坐标 共5注 每注5个坐标
        public static int[] ssqCoordinateY = new int[27];

        // 4. 江西双色球 复式横坐标
        public static int ssqMultipleCoordinateX = 0;

        /// <summary>
        /// 01.江西双色球投注单初始票面
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="spis"></param>
        private static void creatBlankScanPortImageJiangXi(Bitmap imgTemp, Graphics g, SPImageStructure spis)
        {
            int blockWidth = 19;
            int blockHigh = 29;

            Pen pen = new Pen(Color.Black, (float)blockHigh);//画笔

            ////第一步：开始标识、左边黑线、结束标识
            int startPointX = 7;
            int startPointY = 100;

            int offsetH = 19 + blockWidth;
            int offsetV = 28 + blockWidth;

            int pointXH = startPointX + 62 + blockWidth;
            int pointYV = startPointY + 91;

            // 基本点
            g.DrawLine(pen, startPointX, startPointY, startPointX + blockWidth, startPointY);

            int indexH = 0;
            int indexV = 0;

            int[] pointXTempArr = new int[13];
            // 横向点
            for (int i = 0; i < 13; i++)
            {
                int coordinateX = 0;
                indexH++;
                if (indexH ==2)
                {
                    indexH = 0;
                    pointXH++;
                }
                coordinateX = pointXH + i * offsetH;
                g.DrawLine(pen, coordinateX, startPointY, coordinateX + blockWidth, startPointY);
                pointXTempArr[12 - i] = coordinateX;
            }

            int[] pointYTempArr = new int[27];
            // 竖向点
            for (int i = 0; i < 27; i++)
            {
                int coordinateY = 0;
                indexV++;
                if (indexV == 10)
                {
                    indexV = 0;
                    pointYV++;
                }
                coordinateY = pointYV +i * offsetV;
                g.DrawLine(pen, startPointX, coordinateY, startPointX + blockWidth, coordinateY);
                pointYTempArr[i] = coordinateY;
            }

            //获取复式，红球，蓝球的横坐标
            for (int i = 0; i < pointXTempArr.Length; i++)
            {
                if (i == 0)
                {
                    ssqMultipleCoordinateX = pointXTempArr[i];
                }
                else if (i > 0 && i < 9)
                {
                    ssqRedCoordinateX[i - 1] = pointXTempArr[i];
                }
                else
                {
                    ssqBlueCoordinateX[i - 9] = pointXTempArr[i];
                }
            }

            //获取纵坐标坐标数组
            for (int i = 0; i < pointYTempArr.Length; i++)
            {
                ssqCoordinateY[i] = pointYTempArr[i];
            }
        }

        /// <summary>
        /// 02.广西双色球投注单初始票面
        /// </summary>
        /// <param name="imgTemp"></param>
        /// <param name="g"></param>
        /// <param name="spis"></param>
        private static void creatBlankScanPortImageGuangXi(Bitmap imgTemp, Graphics g, SPImageStructure spis)
        {
            //数据点和右侧标记点（小）
            int blockWidth = 25;
            int blockHigh = 25;

            //尾部的两个点（大）
            int blockWidthRear = 36;
            int blockHighRear = 33;

            Pen pen = new Pen(Color.Black, (float)blockHigh);//画笔 数据点和右侧标记点（小）

            ////第一步：开始标识、左边黑线、结束标识
            int startPointX = 610;
            int startPointY = 100;

            //两个点之间空隙的距离
            int offsetH = 20;
            int offsetV = 18;
            
            // 竖向点
            int pointGroupHigh = 277;//每组点的高度 每组6个点
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 6; i++)
                {
                    g.DrawLine(pen, startPointX, i * (offsetV + blockWidth) + 100 + j * pointGroupHigh, startPointX + blockWidth, i * (offsetV + blockWidth) + 100 + j * pointGroupHigh);
                }
            }

            g.DrawLine(pen, startPointX, 100 + 5 * pointGroupHigh, startPointX + blockWidth, 100 + 5 * pointGroupHigh);
            g.DrawLine(pen, startPointX, 100 + 5 * pointGroupHigh + 35 + blockHigh, startPointX + blockWidth, 100 + 5 * pointGroupHigh + 35 + blockHigh);
            g.DrawLine(pen, startPointX, 100 + 5 * pointGroupHigh + (35 + blockHigh) * 2, startPointX + blockWidth, 100 + 5 * pointGroupHigh + (35 + blockHigh) * 2);

            //尾部的两个点（大）
            g.DrawLine(pen, 110, 100 + 5 * pointGroupHigh + (35 + blockHigh) * 2, 110 + blockWidthRear, 100 + 5 * pointGroupHigh + (35 + blockHigh) * 2);
            g.DrawLine(pen, 415, 100 + 5 * pointGroupHigh + (35 + blockHigh) * 2, 415 + blockWidthRear, 100 + 5 * pointGroupHigh + (35 + blockHigh) * 2);
        }

        /// <summary>
        /// 绘制一张空白图——北单专用
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="g"></param>
        /// <param name="bigp"></param>
        /// <param name="smallp"></param>
        private static void creatBlankScanPortImage_BD(Bitmap bmp, Graphics g, SPImageStructure spis,String play)
        {
            Pen bigp = new Pen(Color.Black, 15f);//大黑块画笔
            Pen smallp = new Pen(Color.Black, 1f);//大黑块画笔

            bool isshort = play.StartsWith("2-");
            int THIS_BB_HIGH = isshort ? SPImageGlobal.BD_BB_HIGH : SPImageGlobal.BD_BB_HIGH_SHORT;
            int head_line_num = play.StartsWith("3-") ? 11 : 13;
            int this_head_bb_width = play.StartsWith("3-") ? SPImageGlobal.BDBF_HEAD_BB_WIDTH : SPImageGlobal.BD_HEAD_BB_WIDTH;

            String[] playCode = spis.getPTypeHeadDesc();
            //第一步：绘制头上的13条线
            for (int i = 0; i < head_line_num; i++)
            {
                g.DrawLine(bigp, SPImageGlobal.START_POINT_X_BD + i * this_head_bb_width + (isshort ? 0 : 4),
                    SPImageGlobal.START_POINT_Y,
                 SPImageGlobal.START_POINT_X_BD + i * this_head_bb_width + (isshort ? 0 : 4), 
                 SPImageGlobal.START_POINT_Y + 25);
            }

            //第二步：绘制玩法
            for (int i = 0; i < playCode.Length; i++)
            {
                for (int j = 0; j < playCode[i].Length; j++)
                {
                    if (playCode[i][j] == '1')
                    {
                        g.DrawLine(bigp, SPImageGlobal.START_POINT_X_BD + (head_line_num-1) * this_head_bb_width,
                            SPImageGlobal.START_POINT_Y + (j + 1) * THIS_BB_HIGH + (isshort ? 0 : -6),
                        SPImageGlobal.START_POINT_X_BD + (head_line_num - 1) * this_head_bb_width,
                        SPImageGlobal.START_POINT_Y + (j + 1) * THIS_BB_HIGH + 25 + (isshort ? 0 : -6));
                    }
                    else
                    {
                        g.DrawLine(bigp, SPImageGlobal.START_POINT_X_BD + (head_line_num - 1) * this_head_bb_width,
                            SPImageGlobal.START_POINT_Y + (j + 1) * THIS_BB_HIGH + (isshort ? 0 : -6),
                        SPImageGlobal.START_POINT_X_BD + (head_line_num - 1) * this_head_bb_width,
                        SPImageGlobal.START_POINT_Y + (j + 1) * THIS_BB_HIGH + 25 + (isshort ? 0 : -6));
                        //g.DrawLine(smallp, SPImageGlobal.START_POINT_X_BD + (head_line_num - 1) * this_head_bb_width,
                        //    SPImageGlobal.START_POINT_Y + (j + 1) * THIS_BB_HIGH + (isshort ? 0 : -6),
                        //SPImageGlobal.START_POINT_X_BD + (head_line_num - 1) * this_head_bb_width,
                        //SPImageGlobal.START_POINT_Y + (j + 1) * THIS_BB_HIGH + 1 + (isshort ? 0 : -6));
                    }
                }
            }           
        }

        /// <summary>
        /// 把图片转换成1位深度的黑白图
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private static System.Drawing.Bitmap FaqCopyTo1bpp(System.Drawing.Bitmap b)
        {
            int w = b.Width, h = b.Height;
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, w, h);
            if (b.PixelFormat != System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
            {
                System.Drawing.Bitmap temp = new System.Drawing.Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(temp);
                g.DrawImage(b, r, 0, 0, w, h, System.Drawing.GraphicsUnit.Pixel);
                g.Dispose();
                b = temp;
            }
            System.Drawing.Imaging.BitmapData bdat = b.LockBits(r, System.Drawing.Imaging.ImageLockMode.ReadOnly, b.PixelFormat);
            System.Drawing.Bitmap b0 = new System.Drawing.Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            System.Drawing.Imaging.BitmapData b0dat = b0.LockBits(r, System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int index = y * bdat.Stride + (x * 4);
                    if (System.Drawing.Color.FromArgb(System.Runtime.InteropServices.Marshal.ReadByte(bdat.Scan0, index + 2), System.Runtime.InteropServices.Marshal.ReadByte(bdat.Scan0, index + 1), System.Runtime.InteropServices.Marshal.ReadByte(bdat.Scan0, index)).GetBrightness() > 0.5f)
                    {
                        int index0 = y * b0dat.Stride + (x >> 3);
                        byte p = System.Runtime.InteropServices.Marshal.ReadByte(b0dat.Scan0, index0);
                        byte mask = (byte)(0x80 >> (x & 0x7));
                        System.Runtime.InteropServices.Marshal.WriteByte(b0dat.Scan0, index0, (byte)(p | mask));
                    }
                }
            }
            b0.UnlockBits(b0dat);
            b.UnlockBits(bdat);
            return b0;
        }

        /// <summary>
        /// 取可显示的用户名
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static string getShowName(string p)
        {
            return p.Substring(0, 1) + "****" + (p.Length > 4 ? p.Substring(p.Length - 5, 5) : p.Substring(1));
        }

        /// <summary>
        /// 通过彩票对象取得对应的票面结构字典的key值
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        private static string getSPIKey(lottery_ticket lt)
        {
            if (lt.play_type.Contains("-"))//竞彩
            {
                String[] p = lt.play_type.Split('-');
                if (lt.license_id == 9 && (p[0].Equals("10") || p[0].Equals("11")))//冠军和冠亚军
                {
                    return "9_10_11";
                }

                int m = 3;
                int.TryParse(p[1].Replace("null", "1c1").Split('c')[0], out m);
                if (m == 1)//有可能是单关选了多场
                {
                    m = lt.bet_code.Split('|').Length;
                }

                if (lt.license_id == 9)
                {
                    if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE ]
                .Equals ( PCodeConstant.CODE.PEKING ) )//北京地区
                    {
                        return lt.license_id + "_6_" + ( m <= 3 ? 3 : ( m <= 6 ? 6 : 8 ) );
                    }
                    else
                    {
                        return lt.license_id + "_" + ( p [ 0 ].Equals ( "2" ) ? "6" : p [ 0 ] ) + "_" + ( m <= 3 ? 3 : ( m <= 6 ? 6 : 8 ) );
                    }                    
                }
                else if (lt.license_id == 21)
                {
                    return lt.license_id + "_" + p[0] + "_" + "1";
                }
                else if (lt.license_id == 11)
                {
                    return "11_1_2";
                }
                else
                {
                    return lt.license_id + "_" + p[0] + "_" + (m <= 3 ? 3 : (m <= 6 ? 6 : 8));
                }
            }
            else
            {
                if (lt.license_id == 5 || lt.license_id == 6)
                {
                    if (lt.license_id == 5 && lt.play_type.Equals("1"))
                    {
                        int bet_num = 0;
                        int.TryParse(lt.bet_num, out bet_num);
                        if (bet_num > 3)
                        {
                            return "5_14c_5";
                        }
                    }
                    return "5_6_1";
                }
                else if (lt.license_id == 3 || lt.license_id == 7 || lt.license_id == 8)
                {
                    return lt.license_id + "_1_2";
                }
                else if (lt.license_id == 4)
                {
                    return lt.license_id + (lt.play_type.Equals("3") ? "_0_3" : "_1_2");
                }
                else if (lt.license_id == 2 || lt.license_id == 1)
                {
                    return "2_1_2";
                }
                else if (lt.license_id >= 100 && lt.license_id <= 200)
                {
                    int ltp = 0;
                    int.TryParse(lt.play_type, out ltp);
                    if (ltp == 5 || ltp == 55 || ltp == 6 || ltp == 7 || ltp == 8 || ltp == 12 || ltp == 1212 || ltp == 13 || ltp == 14 || ltp == 15)
                    {
                        return "100_QX";
                    }
                    else
                    {
                        return "100_RX";
                    }
                }
                else if (lt.license_id == 11)
                {
                    return "11_1_2";
                }
                return lt.license_id + "_" + lt.play_type;
            }
        }

        /// <summary>
        /// 检查投注单是否支持
        /// </summary>
        /// <param name="lottery_ticket"></param>
        /// <returns></returns>
        public static bool slipIsSupport(lottery_ticket lt)
        {
            if ( Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE]
                .Equals(PCodeConstant.CODE.PEKING))//北京地区
            {
                if ( lt.license_id != 9 && lt.license_id < 100 )//北京地区专用——目前只支持竞彩足球和11选5
                {
                    return false;
                }
                else
                {
                    if ( lt.license_id == 9 && lt.play_type.StartsWith ( "6-" ) )//竞彩足球
                    {
                        String[] betcodes = lt.bet_code.Split ( '|' );
                        if ( betcodes.Length > 6 )//大于6关只能是胜平负和让球胜平负
                        {
                            for ( int i = 0; i < betcodes.Length; i++ )
                            {
                                String m = betcodes [ i ].Split ( ':' ) [ 1 ].Split ( '-' ) [ 0 ];
                                if ( !m.Equals ( "1" ) && !m.Equals ( "2" ) )
                                {
                                    return false;
                                }
                            }
                        }
                        else if ( betcodes.Length > 3 )
                        {
                            for ( int i = 0; i < betcodes.Length; i++ )
                            {
                                String m = betcodes [ i ].Split ( ':' ) [ 1 ].Split ( '-' ) [ 0 ];
                                if ( !m.Equals ( "1" ) && !m.Equals ( "2" ) && !m.Equals ( "3" ) )
                                {
                                    return false;
                                }
                            }
                        }                        
                    }
                }

                return true;
            }
            else//北京以外的地区
            {
                if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE ]
                .Equals ( PCodeConstant.CODE.JIANGXI ) )//江西支持双色球
                {
                    if ( lt.license_id == 11 && !lt.play_type.Equals ( SSQPlayType.DT ) )
                    {
                        return true;
                    }
                }
                else if(Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.GUANGXI))//广西支持双色球
                {
                    if (lt.license_id == 11 && !lt.play_type.Equals(SSQPlayType.DT))
                    {
                        return true;
                    }
                }
                else if ( lt.license_id == 11){//其它地区不支持双色球
                    return false;
                }

                if ( lt.license_id == 9 && lt.play_type.StartsWith ( "6-" ) )//竞彩足球
                {
                    String[] betcodes = lt.bet_code.Split ( '|' );
                    if ( betcodes.Length > 6 )//大于6关只能是胜平负和让球胜平负
                    {
                        for ( int i = 0; i < betcodes.Length; i++ )
                        {
                            String m = betcodes [ i ].Split ( ':' ) [ 1 ].Split ( '-' ) [ 0 ];
                            if ( !m.Equals ( "1" ) && !m.Equals ( "2" ) )
                            {
                                return false;
                            }
                        }
                    }
                    else if ( betcodes.Length > 3 )
                    {
                        for ( int i = 0; i < betcodes.Length; i++ )
                        {
                            String m = betcodes [ i ].Split ( ':' ) [ 1 ].Split ( '-' ) [ 0 ];
                            if ( !m.Equals ( "1" ) && !m.Equals ( "2" ) && !m.Equals ( "3" ) )
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
                else if ( lt.license_id == 10 )//竞彩篮球
                {
                    if ( lt.play_type.StartsWith ( "3-" ) )//胜分差只能3关
                    {
                        int m = 0;
                        int.TryParse ( lt.play_type.Split ( '-' ) [ 1 ].Split ( 'c' ) [ 0 ], out m );
                        if ( m > 3 )
                        {
                            return false;
                        }
                    }
                    else if ( lt.play_type.StartsWith ( "6-" ) )//混合过关6关8关，只支持大小分、让分胜负、胜负
                    {
                        String[] betcodes = lt.bet_code.Split ( '|' );
                        if ( betcodes.Length > 3 )//混合过关6关8关，只支持大小分、让分胜负、胜负，不支持胜分差
                        {
                            for ( int i = 0; i < betcodes.Length; i++ )
                            {
                                String m = betcodes [ i ].Split ( ':' ) [ 1 ].Split ( '-' ) [ 0 ];
                                if ( m.Equals ( "3" ) )
                                {
                                    return false;
                                }
                            }
                        }
                    }

                    return true;
                }
                else if ( lt.license_id == 8 && lt.play_type.StartsWith ( "6-" ) )
                {
                    String[] betcodes = lt.bet_code.Split ( '|' );
                    if ( betcodes.Length > 3 )
                    {
                        for ( int i = 0; i < betcodes.Length; i++ )
                        {
                            String m = betcodes [ i ].Split ( ':' ) [ 1 ].Split ( '-' ) [ 0 ];
                            if ( m.Equals ( "3" ) )
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
                else if ( lt.license_id == 1 )
                {
                    if ( ( lt.play_type.Equals ( PL3PlayType.PLSZHXDS.ToString ( ) ) ||
                        lt.play_type.Equals ( PL3PlayType.PLSZHXFS.ToString ( ) ) ||
                        lt.play_type.Equals ( PL3PlayType.PLSZXDS.ToString ( ) ) ||
                        lt.play_type.Equals ( PL3PlayType.PLSZLDS.ToString ( ) ) ) )//直选和值不支持
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ( lt.license_id == 21 )//北单，编号大于99的不能出
                {
                    bool issupport = true;
                    String[] codes = lt.bet_code.Split ( '|' );
                    for ( int i = 0; i < codes.Length; i++ )
                    {
                        String[] qqhq = codes [ i ].Split ( ':' );
                        int rnum = 1;
                        int.TryParse ( qqhq [ 0 ].Substring ( 8, qqhq [ 0 ].Length - 8 ), out rnum );
                        if ( rnum > 195 )
                        {
                            issupport = false;
                            break;
                        }
                    }

                    //暂时没有胜负过关的投注单
                    if ( lt.play_type.StartsWith ( "1-" ) )
                    {
                        issupport = false;
                    }

                    return issupport;
                }
                else if ( lt.license_id == 13 || lt.license_id == 12 || lt.license_id == 20 || lt.license_id == 22 ||
                    lt.license_id == 23 || lt.license_id > 200 )
                {
                    return false;
                }

                return true;
            }
        }


        /// <summary>
        /// 拆分票
        /// </summary>
        /// <param name="lottery_ticket"></param>
        /// <returns></returns>
        public static List<lottery_ticket> splitLotteryTicket(lottery_ticket lt)
        {
            List<lottery_ticket> ltlist = new List<lottery_ticket>();
            if ((lt.license_id == 6 || lt.license_id == 7 || lt.license_id == 8) && lt.play_type.Equals("1"))//只能打3注
            {
                ltlist = TicketSplitUtil.splitByBetNum(lt, 3);
            }
            else if (lt.license_id == 2 && lt.play_type.Equals("1"))//只能打4注
            {
                //先拆倍数
                List<lottery_ticket> templist = TicketSplitUtil.splitByMuliplt(lt);

                foreach (lottery_ticket item in templist)
                {
                    List<lottery_ticket> templist2 = TicketSplitUtil.splitByBetNum(item, 4);
                    foreach (lottery_ticket item2 in templist2)
                    {
                        ltlist.Add(item2);
                    }
                }
            }
            else if (lt.license_id == 1)
            {
                //先拆倍数
                List<lottery_ticket> templist = TicketSplitUtil.splitByMuliplt(lt);

                foreach (lottery_ticket item in templist)
                {
                    List<lottery_ticket> templist2 = TicketSplitUtil.splitByBetNum(item, 4);
                    foreach (lottery_ticket item2 in templist2)
                    {
                        List<lottery_ticket> templist3 = TicketSplitUtil.pl3TicketSplit(item2);
                        foreach (lottery_ticket item3 in templist3)
                        {
                            ltlist.Add(item3);
                        }
                    }
                }
            }
            else if (lt.license_id >= 100 && lt.license_id <= 200)
            {
                List<lottery_ticket> templist = TicketSplitUtil.syx5TicketSplit(lt);
                foreach (lottery_ticket item in templist)
                {
                    ltlist.Add(item);
                }
            }
            else if (lt.license_id == 11)//双色球
            {
                //List<lottery_ticket> templist = TicketSplitUtil.ssqTicketSplit(lt);
                //foreach (lottery_ticket item in templist)
                //{
                //    ltlist.Add(item);
                //}

                ltlist.Add(lt);
            }
            else
            {
                ltlist.Add(lt);
            }

            return ltlist;
        }
    }
}
