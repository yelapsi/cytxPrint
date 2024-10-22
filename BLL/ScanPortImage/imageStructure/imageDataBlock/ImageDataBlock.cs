﻿using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage
{
    public abstract class ImageDataBlock
    {
        /// <summary>
        /// 赛事编号
        /// </summary>
        protected int[] raceNO = {1,2,4,5,10,20,40,50,100,200,400,500};

        /// <summary>
        /// 赛事编号——北单
        /// </summary>
        protected int[] raceNO_BD = { 1, 2,3, 4, 5,6,7,8,9, 10, 20,30, 40, 50};

        /// <summary>
        /// 倍数编号
        /// </summary>
        protected int[] multipleNO = {1,2,3,4,5,6,7,8,9,10,20,30,40,50};

        /// <summary>
        /// 倍数编号R9
        /// </summary>
        protected int[] multipleNOR9 = { 20, 15, 10, 9, 8, 7, 6, 5, 4, 3, 2};

        /// <summary>
        /// 倍数编号北单
        /// </summary>
        protected int[] multipleNOBD = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,20, 30, 40, 50, 60, 70, 80, 90};

        /// <summary>
        /// 该数据块的起始位置
        /// </summary>
        protected Point startPoint;

        /// <summary>
        /// 根据传入的数据，得到需要描的几个点的起始坐标
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract void getPointArrayByData(List<Point>pointlist,String data);

        /// <summary>
        /// 获取倍数的点——适用于所有采种
        /// </summary>
        /// <param name="plist"></param>
        /// <param name="multiple"></param>
        /// <param name="startPoint"></param>
        public void getMultiplePoints(List<Point> plist, int multiple, Point startPoint,String linceseId)
        {
            if (linceseId.Equals(LicenseContants.License.GAMEIDJCLQ.ToString()) || linceseId.Equals(LicenseContants.License.GAMEIDJCZQ.ToString()))
            {
                while (multiple > 0)
                {
                    for (int i = multipleNO.Length - 1; i >= 0; i--)
                    {
                        if (multipleNO[i] <= multiple)
                        {
                            plist.Add(new Point(startPoint.X + (i % 4) * SPImageGlobal.S2S_WIDTH,
                    startPoint.Y + (int)((Math.Floor(i / 4d) + 1) * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH)));
                            multiple -= multipleNO[i];
                            break;
                        }
                    }
                }
            }
            else if (linceseId.Equals(LicenseContants.License.GAMEIDRXJ.ToString()) || linceseId.Equals(LicenseContants.License.GAMEIDSFC.ToString()))
            {//multipleNOR9
                while (multiple > 1)
                {
                    for (int i = 0; i < multipleNOR9.Length; i++)
                    {
                        if (multipleNOR9[i] == multiple)
                        {
                            plist.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (i + 1) * SPImageGlobal.S2S_WIDTH,
                    startPoint.Y + SPImageGlobal.B2S_HIGH));
                            multiple = 0;
                            break;
                        }
                    }
                }
            }
            else if (linceseId.Equals(LicenseContants.License.GAMEIDDLT.ToString()) || linceseId.Equals("100"))//大乐透
            {
                String mstr = multiple.ToString("00");
                int sw = 0, gw = 0;
                int.TryParse(mstr.Substring(0,1),out sw);
                int.TryParse(mstr.Substring(1, 1), out gw);

                if (sw >0)
                {
                    plist.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (sw + 1) * SPImageGlobal.S2S_WIDTH,
                startPoint.Y + SPImageGlobal.B2S_HIGH));
                }

                plist.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + ((gw > 0 ? gw : 10) + 1) * SPImageGlobal.S2S_WIDTH,
                    startPoint.Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
            else if (linceseId.Equals(LicenseContants.License.GAMEIDBQC.ToString()) || linceseId.Equals(LicenseContants.License.GAMEIDJQC.ToString()))
            {//六场半全场、四场进球
                String mstr = multiple.ToString("00");
                int sw = 0, gw = 0;
                int.TryParse(mstr.Substring(0, 1), out sw);
                int.TryParse(mstr.Substring(1, 1), out gw);

                if (sw > 0)
                {
                    plist.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (9 - sw + 3) * SPImageGlobal.S2S_WIDTH,
                startPoint.Y + SPImageGlobal.B2S_HIGH));
                }

                plist.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (9 - (gw > 0 ? gw : 10) + 3) * SPImageGlobal.S2S_WIDTH,
                    startPoint.Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            }
            else if (linceseId.Equals(LicenseContants.License.GAMEIDPLS.ToString()) || linceseId.Equals(LicenseContants.License.GAMEIDPLW.ToString())
                || linceseId.Equals(LicenseContants.License.GAMEIDQXC.ToString()))
            {
                if (multiple==1)//1倍不图点位
                {
                    return;
                }
                int x = SPImageGlobal.LEFT_SMALL_BB_X + 12 * SPImageGlobal.S2S_WIDTH, y = SPImageGlobal.START_POINT_Y+SPImageGlobal.B2S_HIGH;
                if (multiple ==20)
                {
                    y += 19 * SPImageGlobal.BB_HIGH;
                }
                else if (multiple ==15)
                {
                    y += 18 * SPImageGlobal.BB_HIGH;
                }
                else
                {
                    y += (7 + multiple) * SPImageGlobal.BB_HIGH;
                }

                plist.Add(new Point(x,y));
            }
            else if (linceseId.StartsWith("21@"))//北京单场
            {
                String[] lp = linceseId.Split('@');
                if (lp[1].Equals(BJDCPlayType.SPF.ToString()) || lp[1].Equals(BJDCPlayType.BF.ToString()))
                {
                    while (multiple > 0)
                    {
                        for (int i = multipleNOBD.Length-1; i >= 0; i--)
                        {
                            if (multipleNOBD[i] <= multiple)
                            {
                                plist.Add(new Point(this.startPoint.X + (5 - i / 3) * (lp[1].Equals(BJDCPlayType.BF.ToString()) ? SPImageGlobal.BDBF_HEAD_BB_WIDTH : SPImageGlobal.BD_HEAD_BB_WIDTH),
                        startPoint.Y + (i % 3) * (lp[1].Equals(BJDCPlayType.BF.ToString()) ? SPImageGlobal.BD_BB_HIGH_SHORT : SPImageGlobal.BD_BB_HIGH)));
                                multiple -= multipleNOBD[i];
                            }
                        }
                    }
                }
                else if (lp[1].Equals(BJDCPlayType.SXDS.ToString()) || lp[1].Equals(BJDCPlayType.ZJQ.ToString()) 
                    || lp[1].Equals(BJDCPlayType.BQC.ToString()))
                {
                    while (multiple > 0)
                    {
                        for (int i = multipleNOBD.Length - 1; i >= 0; i--)
                        {
                            if (multipleNOBD[i] <= multiple)
                            {
                                plist.Add(new Point(this.startPoint.X + (1 - i / 9) * SPImageGlobal.BD_HEAD_BB_WIDTH,
                        startPoint.Y + (i % 9) * SPImageGlobal.BD_BB_HIGH_SHORT));
                                multiple -= multipleNOBD[i];
                            }
                        }
                    }
                }
                else//下半场比分
                {

                }
            }
            else if (linceseId.Equals(LicenseContants.License.GAMEIDSSQ.ToString()))
            {
                if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.NATIONWIDE))
                {
                    //普通双色球
                    //switch (multiple)
                    //{
                    //    case 2:
                    //        plist.Add(new Point(100 - 3, 140 - 3));
                    //        break;
                    //    case 3:
                    //        plist.Add(new Point(100 - 3, 180 - 1 - 3));
                    //        break;
                    //    case 5:
                    //        plist.Add(new Point(100 - 3, 220 - 2 - 3));
                    //        break;
                    //    case 10:
                    //        plist.Add(new Point(100 - 3, 260 - 4 - 3));
                    //        break;
                    //}

                    //plist.Add(new Point(100 - 3, 140 - 3));
                    //plist.Add(new Point(100 - 3, 180 - 1 - 3));
                    //plist.Add(new Point(100 - 3, 220 - 2 - 3));
                    //plist.Add(new Point(100 - 3, 260 - 4 - 3));
                }
                else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.PEKING))
                {
                    //普通双色球
                    //switch (multiple)
                    //{
                    //    case 2:
                    //        plist.Add(new Point(100 - 3, 140 - 3));
                    //        break;
                    //    case 3:
                    //        plist.Add(new Point(100 - 3, 180 - 1 - 3));
                    //        break;
                    //    case 5:
                    //        plist.Add(new Point(100 - 3, 220 - 2 - 3));
                    //        break;
                    //    case 10:
                    //        plist.Add(new Point(100 - 3, 260 - 4 - 3));
                    //        break;
                    //}

                    //plist.Add(new Point(100 - 3, 140 - 3));
                    //plist.Add(new Point(100 - 3, 180 - 1 - 3));
                    //plist.Add(new Point(100 - 3, 220 - 2 - 3));
                    //plist.Add(new Point(100 - 3, 260 - 4 - 3));
                }
                else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.JIANGXI))
                {
                    //江西双色球
                    if (multiple > 1)
                    {
                        plist.Add(new Point(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[25]));
                    }

                    switch (multiple)
                    {
                        case 2:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[0], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 3:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[1], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 4:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[2], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 5:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[3], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 6:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[4], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 7:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[5], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 8:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[6], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 9:
                            plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[7], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 10:
                            plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[0], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 20:
                            plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[1], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 30:
                            plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[2], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                        case 50:
                            plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[3], ScanPortImageUtil.ssqCoordinateY[25]));
                            break;
                    }


                    //plist.Add(new Point(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[0], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[1], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[2], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[3], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[4], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[5], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[6], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqRedCoordinateX[7], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[0], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[1], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[2], ScanPortImageUtil.ssqCoordinateY[25]));
                    //plist.Add(new Point(ScanPortImageUtil.ssqBlueCoordinateX[3], ScanPortImageUtil.ssqCoordinateY[25]));
                }
                else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.GUANGXI))
                {
                    int[] multipleNO = {2, 3, 4, 5, 10, 20, 30, 50, 80};

                    //江西双色球
                    if (multiple > 1)
                    {
                        int mulTemp = multiple;
                        for (int i = 0; i < multipleNO.Length; i++)
                        {
                            //if ((mulTemp / multipleNO[multipleNO.Length - 1 - i]) == 1 && mulTemp > 0)
                            if ((mulTemp / multipleNO[multipleNO.Length - 1 - i]) >= 1 && mulTemp > 0)
                            {
                                if ((mulTemp - multipleNO[multipleNO.Length - 1 - i]) != 1)
                                {
                                    plist.Add(new Point(570 - 51 * (multipleNO.Length - 1 - i), 44 * 0 + 277 * 5 + 100));
                                    mulTemp -= multipleNO[multipleNO.Length - 1 - i];
                                }
                            }
                        }
                        plist.Add(new Point(570 - 51 * 10, 44 * 0 + 277 * 5 + 100));
                    }
                }
            }
        }
        /// <summary>
        /// 取竞彩赛事的点
        /// </summary>
        /// <param name="race"></param>
        /// <param name="startPoint"></param>
        /// <returns></returns>
        public void getSMGRacePoints(List<Point> plist, String race, Point startPoint)
        {            
            //第一步：取字符串前8位，算出是周几（20160506）
            int week = 7;
            int.TryParse(data2weekDayTranslation(race.Substring(0, 8)),out week);
            
            //第二步：取周几的点
            plist.Add(new Point(startPoint.X + ((week-1) % 4) * SPImageGlobal.S2S_WIDTH,
                startPoint.Y + (int)(Math.Ceiling(week/4d)*SPImageGlobal.BB_HIGH+SPImageGlobal.B2S_HIGH)));
            //第三步：取对阵的点
            int racenum = 301;
            int.TryParse(race.Substring(8, 3),out racenum);
            while (racenum>0)
            {
                for (int i = raceNO.Length-1; i >= 0; i--)
                {
                    if (raceNO[i] <= racenum)
                    {
                        plist.Add(new Point(startPoint.X + (i % 4) * SPImageGlobal.S2S_WIDTH,
                startPoint.Y + (int)((Math.Ceiling((i+1)/4d)+2)*SPImageGlobal.BB_HIGH)+SPImageGlobal.B2S_HIGH));
                        racenum -= raceNO[i];
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 取竞彩赛事的点——北单
        /// </summary>
        /// <param name="race"></param>
        /// <param name="startPoint"></param>
        /// <returns></returns>
        protected void getBDRacePoints(List<Point> plist, String race,int play, Point startPoint)
        {
            //第一步：取字符串后3位，算出赛事的点（20160523270）
            int rnum = 1, x = 0,rownum = 3, this_high = SPImageGlobal.BD_BB_HIGH_SHORT;
            int.TryParse(race.Substring(8, race.IndexOf(":")-8), out rnum);
            switch (play)
            {
                case 1:
                    break;
                case 2:                    
                    this_high = SPImageGlobal.BD_BB_HIGH;
                    x = 5;
                    break;
                case 3:
                    rownum = 5;
                    x = 8;
                    break;
                case 4:
                    rownum = 5;
                    x = 7;
                    break;
                case 5:
                    x = 7;
                    break;
                default:
                    x = 6;
                    break;
            }
            while (rnum>0)
            {
                for (int i = raceNO_BD.Length -1; i >=0 ; i--)
                {
                    if (raceNO_BD[i] <= rnum)
                    {
                        plist.Add(new Point(startPoint.X + (int)(x - Math.Floor(i / rownum + 0d)) * (play == 3 ? SPImageGlobal .BDBF_HEAD_BB_WIDTH: SPImageGlobal.BD_HEAD_BB_WIDTH),
                startPoint.Y + (i % rownum) * this_high));
                        rnum -= raceNO_BD[i];
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">20150831->1</param>
        /// <returns></returns>
        private String data2weekDayTranslation(String data)
        {
            return DateUtil.data2weekDayTranslation(data);
            //return "7";
        }
    }
}
