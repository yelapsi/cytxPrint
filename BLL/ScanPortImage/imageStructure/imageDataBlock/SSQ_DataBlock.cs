﻿using Maticsoft.Common;
using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure.imageDataBlock
{
    public class SSQ_DataBlock : ImageDataBlock
    {
        /// <summary>
        /// （双色球蓝色球）数据块的起始位置
        /// </summary>
        protected Point startPointB;

        public static int DATA_BLOCK_HIGH = 15 * SPImageGlobal.BB_HIGH;

        public SSQ_DataBlock(int startx, int starty, int startBx, int startBy)
        {
            this.startPoint = new System.Drawing.Point(startx, starty);//红球
            this.startPointB = new System.Drawing.Point(startBx, starty);//蓝球(红球和蓝球纵坐标是一样的)
        }

        /// <summary>
        /// 双色球
        /// </summary>
        /// <param name="pointlist"></param>
        /// <param name="betCode"></param>
        public override void getPointArrayByData(List<System.Drawing.Point> pointlist, string betCode)
        {
            if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.NATIONWIDE))
            {
            }
            else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.PEKING))
            {
                SSQ_PEKING(pointlist, betCode);
            }
            else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.JIANGXI))
            {
                SSQ_JIANGXI(pointlist, betCode);
            }
            else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.GUANGXI))
            {
                SSQ_GUANGXI(pointlist, betCode);
            }
        }

        /// <summary>
        /// 普通双色球
        /// </summary>
        /// <param name="pointlist"></param>
        /// <param name="betCode"></param>
        public void SSQ_PEKING(List<System.Drawing.Point> pointlist, string betCode)
        {
            //betCode = @"01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;";
            //betCode = "01,28,29,30,31,32,33+01,02;";

            int fsr = 1;//红球复式
            int fsb = 1;//蓝球复式

            string[] codes = betCode.Split(';');

            for (int i = 0; i < codes.Length; i++)
            {
                if (codes[i].Length > 0)
                {
                    string data = codes[i];

                    string red = null;// data.Split('+')[0];
                    string blue = null;// data.Split('+')[1];

                    if (data.Contains("+"))
                    {
                        red = data.Split('+')[0];
                        blue = data.Split('+')[1];
                    }
                    else
                    {
                        red = data.Split('|')[0];
                        blue = data.Split('|')[1];
                    }

                    //红球
                    string[] redNums = red.Split(',');
                    for (int j = 0; j < redNums.Length; j++)
                    {
                        int a = (int.Parse(redNums[j]) - 1) / 6;
                        int b = (int.Parse(redNums[j]) - 1) % 6;

                        switch (i)
                        {
                            case 0:
                                pointlist.Add(new Point(this.startPoint.X - a * 37, this.startPoint.Y + b * 38 + i * 228));
                                break;
                            case 1:
                                pointlist.Add(new Point(this.startPoint.X - a * 37, this.startPoint.Y + b * 38 + i * 228 + 1));
                                break;
                            case 2:
                                pointlist.Add(new Point(this.startPoint.X - a * 37, this.startPoint.Y + b * 38 + i * 228 + 2));
                                break;
                            case 3:
                                pointlist.Add(new Point(this.startPoint.X - a * 37, this.startPoint.Y + b * 38 + i * 228 + 3));
                                break;
                            case 4:
                                pointlist.Add(new Point(this.startPoint.X - a * 37, this.startPoint.Y + b * 38 + i * 228 + 4));
                                break;
                        }
                    }

                    //蓝球
                    string[] blueNums = blue.Split(',');
                    for (int j = 0; j < blueNums.Length; j++)
                    {
                        int a = (int.Parse(blueNums[j]) - 1) / 6;
                        int b = (int.Parse(blueNums[j]) - 1) % 6;

                        switch (i)
                        {
                            case 0:
                                pointlist.Add(new Point(this.startPointB.X - a * 37, this.startPointB.Y + b * 38 + i * 228));
                                break;
                            case 1:
                                pointlist.Add(new Point(this.startPointB.X - a * 37, this.startPointB.Y + b * 38 + i * 228 + 1));
                                break;
                            case 2:
                                pointlist.Add(new Point(this.startPointB.X - a * 37, this.startPointB.Y + b * 38 + i * 228 + 2));
                                break;
                            case 3:
                                pointlist.Add(new Point(this.startPointB.X - a * 37, this.startPointB.Y + b * 38 + i * 228 + 3));
                                break;
                            case 4:
                                pointlist.Add(new Point(this.startPointB.X - a * 37, this.startPointB.Y + b * 38 + i * 228 + 4));
                                break;
                        }
                    }

                    fsr = Maticsoft.Common.MathHelper.combinations(6, redNums.Length);
                    fsb = blueNums.Length;
                }
            }

            if (fsr > 1)
            {
                pointlist.Add(new Point(this.startPoint.X - (fsr - 7) % 4 * 37, 140 - 4 + (fsr - 7) / 4 * 38));
            }
            if (fsb > 1)
            {
                pointlist.Add(new Point(277 - (fsb - 2) % 4 * 37, 140 - 4 + (fsb - 2) / 4 * 38));
            }

            //for (int i = 7; i <= 20; i++)
            //{
            //    pointlist.Add(new Point(this.startPoint.X - (i - 7) % 4 * 37 + 2, 140-4 + (i - 7) / 4 * 38));
            //}
            //for (int i = 2; i <= 16; i++)
            //{
            //    pointlist.Add(new Point(277 - (i - 2) % 4 * 37 + 2, 140 - 4 + (i - 2) / 4 * 38));
            //}
        }

        public void SSQ_JIANGXI(List<System.Drawing.Point> pointlist, string betCode)
        {
            //betCode = @"01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;";
            //betCode = "01,28,29,30,31,32,33+01,02;";

            if (betCode.Contains("(") && betCode.Contains(")"))//胆拖票
            {
                if (betCode.Split(';').Length > 1)//胆拖票只有一注
                {
                    return;
                }

                //处理前区胆码
                string red = null;// 前区胆码只有红球
                string dataD = betCode.Replace("(", "").Split(')')[0];

                if (dataD.Contains("+"))
                {
                    red = dataD.Split('+')[0];
                }
                else
                {
                    red = dataD.Split('|')[0];
                }

                //胆码红球
                string[] redNums = red.Split(',');
                for (int j = 0; j < redNums.Length; j++)
                {
                    int a = (int.Parse(redNums[j]) - 1) / 8;
                    int b = (int.Parse(redNums[j]) - 1) % 8;
                    //i表示票面上的第几注，共5注，每注5个坐标
                    pointlist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[b], ScanPortImageUtil.ssqCoordinateY[a + 3 * 5]));//胆拖票打在票面第三列，2表示第三列坐标
                }
                //胆码块
                pointlist.Add(new Point(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[15]));

                //处理拖码
                string redT = null;
                string blueT = null;
                string dataT = betCode.Replace("(", "").Split(')')[1];

                if (dataT.Contains("+"))
                {
                    redT = dataT.Split('+')[0];
                    blueT = dataT.Split('+')[1];
                }
                else
                {
                    redT = dataT.Split('|')[0];
                    blueT = dataT.Split('|')[1];
                }

                //拖码红球
                string[] redNumsT = redT.Split(',');
                for (int j = 0; j < redNumsT.Length; j++)
                {
                    int a = (int.Parse(redNumsT[j]) - 1) / 8;
                    int b = (int.Parse(redNumsT[j]) - 1) % 8;
                    //i表示票面上的第几注，共5注，每注5个坐标
                    pointlist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[b], ScanPortImageUtil.ssqCoordinateY[a + 4 * 5]));//胆拖票打在票面第三列，2表示第三列坐标
                }

                //拖码蓝球
                string[] blueNumsT = blueT.Split(',');
                for (int j = 0; j < blueNumsT.Length; j++)
                {
                    int a = (int.Parse(blueNumsT[j]) - 1) / 4;
                    int b = (int.Parse(blueNumsT[j]) - 1) % 4;
                    //i表示票面上的第几注，共5注，每注5个坐标
                    pointlist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[b], ScanPortImageUtil.ssqCoordinateY[a + 4 * 5]));
                }
                //拖码块
                pointlist.Add(new Point(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[20]));
            }
            else
            {
                int fsr = 1;//红球复式
                int fsb = 1;//蓝球复式

                string[] codes = betCode.Split(';');
                int len = codes.Length <= 5 ? codes.Length : 5;
                for (int i = 0; i < len; i++)
                {
                    if (codes[i].Length > 0)
                    {
                        string data = codes[i];

                        string red = null;// data.Split('+')[0];
                        string blue = null;// data.Split('+')[1];

                        if (data.Contains("+"))
                        {
                            red = data.Split('+')[0];
                            blue = data.Split('+')[1];
                        }
                        else
                        {
                            red = data.Split('|')[0];
                            blue = data.Split('|')[1];
                        }

                        //红球
                        string[] redNums = red.Split(',');
                        for (int j = 0; j < redNums.Length; j++)
                        {
                            int a = (int.Parse(redNums[j]) - 1) / 8;
                            int b = (int.Parse(redNums[j]) - 1) % 8;
                            //i表示票面上的第几注，共5注，每注5个坐标
                            pointlist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[b], ScanPortImageUtil.ssqCoordinateY[a + i * 5]));
                        }

                        //蓝球
                        string[] blueNums = blue.Split(',');
                        for (int j = 0; j < blueNums.Length; j++)
                        {
                            int a = (int.Parse(blueNums[j]) - 1) / 4;
                            int b = (int.Parse(blueNums[j]) - 1) % 4;
                            //i表示票面上的第几注，共5注，每注5个坐标
                            pointlist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[b], ScanPortImageUtil.ssqCoordinateY[a + i * 5]));
                        }

                        fsr = Maticsoft.Common.MathHelper.combinations(6, redNums.Length);
                        fsb = blueNums.Length;
                    }

                    if (fsr > 1 || fsb > 1)
                    {
                        pointlist.Add(new Point(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[i * 5]));
                    }
                }
            }

            //for (int i = 7; i <= 20; i++)
            //{
            //    pointlist.Add(new Point(this.startPoint.X - (i - 7) % 4 * 37 + 2, 140-4 + (i - 7) / 4 * 38));
            //}
            //for (int i = 2; i <= 16; i++)
            //{
            //    pointlist.Add(new Point(277 - (i - 2) % 4 * 37 + 2, 140 - 4 + (i - 2) / 4 * 38));
            //}
        }

        public void SSQ_GUANGXI(List<System.Drawing.Point> pointlist, string betCode)
        {

            //betCode = @"01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33+01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16;";
            //betCode = "01,28,29,30,31,32,33+01,02;";

            if (betCode.Contains("(") && betCode.Contains(")"))//胆拖票
            {
                if (betCode.Split(';').Length > 1)//胆拖票只有一注
                {
                    return;
                }

                //处理前区胆码
                string red = null;// 前区胆码只有红球
                string dataD = betCode.Replace("(", "").Split(')')[0];

                if (dataD.Contains("+"))
                {
                    red = dataD.Split('+')[0];
                }
                else
                {
                    red = dataD.Split('|')[0];
                }

                //胆码红球
                string[] redNums = red.Split(',');
                for (int j = 0; j < redNums.Length; j++)
                {
                    int a = (int.Parse(redNums[j]) - 1) / 8;
                    int b = (int.Parse(redNums[j]) - 1) % 8;
                    //i表示票面上的第几注，共5注，每注5个坐标
                    pointlist.Add(new Point(570 - 51 * b, 44 * a + 277 * 0 + 100));//胆拖票打在票面第三列，2表示第三列坐标
                }
                //胆码块
                pointlist.Add(new Point(570 - 51 * 10, 44 * 2 + 277 * 0 + 100));

                //处理拖码
                string redT = null;
                string blueT = null;
                string dataT = betCode.Replace("(", "").Split(')')[1];

                if (dataT.Contains("+"))
                {
                    redT = dataT.Split('+')[0];
                    blueT = dataT.Split('+')[1];
                }
                else
                {
                    redT = dataT.Split('|')[0];
                    blueT = dataT.Split('|')[1];
                }

                //拖码红球
                string[] redNumsT = redT.Split(',');
                for (int j = 0; j < redNumsT.Length; j++)
                {
                    int a = (int.Parse(redNumsT[j]) - 1) / 10;
                    int b = (int.Parse(redNumsT[j]) - 1) % 10;
                    //i表示票面上的第几注，共5注，每注5个坐标
                    pointlist.Add(new Point(570 - 51 * b, 44 * a + 277 * 1 + 100));//胆拖票打在票面第三列，2表示第三列坐标
                }

                //拖码蓝球
                string[] blueNumsT = blueT.Split(',');
                for (int j = 0; j < blueNumsT.Length; j++)
                {
                    int a = (int.Parse(blueNumsT[j]) - 1) / 10;
                    int b = (int.Parse(blueNumsT[j]) - 1) % 10;
                    //i表示票面上的第几注，共5注，每注5个坐标
                    pointlist.Add(new Point(570 - 51 * b, 45 * a + 173 + 277 * 1 + 100));
                }
                //拖码块
                pointlist.Add(new Point(570 - 51 * 10, 44 * 2 + 277 * 1 + 100));
            }
            else
            {
                int fsr = 1;//红球复式
                int fsb = 1;//蓝球复式

                string[] codes = betCode.Split(';');
                int len = codes.Length <= 5 ? codes.Length : 5;
                for (int i = 0; i < len; i++)
                {
                    if (codes[i].Length > 0)
                    {
                        string data = codes[i];

                        string red = null;
                        string blue = null;

                        if (data.Contains("+"))
                        {
                            red = data.Split('+')[0];
                            blue = data.Split('+')[1];
                        }
                        else
                        {
                            red = data.Split('|')[0];
                            blue = data.Split('|')[1];
                        }

                        //红球
                        string[] redNums = red.Split(',');
                        for (int j = 0; j < redNums.Length; j++)
                        {
                            int a = (int.Parse(redNums[j]) - 1) / 10;
                            int b = (int.Parse(redNums[j]) - 1) % 10;
                            //i表示票面上的第几注，共5注，每注5个坐标
                            pointlist.Add(new Point(570 - 51 * b, 44 * a + 277 * i + 100));
                        }

                        //蓝球
                        string[] blueNums = blue.Split(',');
                        for (int j = 0; j < blueNums.Length; j++)
                        {
                            int a = (int.Parse(blueNums[j]) - 1) / 10;
                            int b = (int.Parse(blueNums[j]) - 1) % 10;
                            //i表示票面上的第几注，共5注，每注5个坐标
                            pointlist.Add(new Point(570 - 51 * b, 45 * a + 173 + 277 * i + 100));
                        }

                        fsr = Maticsoft.Common.MathHelper.combinations(6, redNums.Length);
                        fsb = blueNums.Length;
                    }

                    if (fsr > 1)
                    {
                        pointlist.Add(new Point(570 - 51 * 10, 44 * 1 + 277 * i + 100));
                    }

                    if (fsb > 1)
                    {
                        pointlist.Add(new Point(570 - 51 * 10, 45 * 1 + 173 + 277 * i + 100));
                    }
                }
            }
        }
    }
}
