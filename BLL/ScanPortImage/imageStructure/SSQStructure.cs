using Maticsoft.BLL.ScanPortImage.imageStructure.imageDataBlock;
using Maticsoft.Common;
using Maticsoft.Common.Util;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class SSQStructure : SPImageStructure
    {
        public SSQStructure(String lNameStr)
        {
            this.SLIP_EVENT_NUMBER = 3;
            this.ISHAS_CLEARANCE_TYPE = false;
            this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
            this.HIGHLY_EFFECTIVE_CONTENT = 1400;//2500;//18 * SPImageGlobal.BB_HIGH;

            if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.NATIONWIDE))
            {
                //for (int i = 0; i < 5; i++)
                //{
                //双色球 红色球数据块起始坐标 蓝色球数据块起始坐标
                //this.DATA_BLOCK_LIST.Add(new SSQ_DataBlock(
                //    SPImageGlobal.LEFT_SMALL_BB_X + (2 - i) * SPImageGlobal.RACE_BLOCK_WIDTH + 100 - 23
                //    , SPImageGlobal.START_POINT_Y + 221
                //    , 100 + 102
                //    , SPImageGlobal.START_POINT_Y + 221
                //    ));
                //}

                //倍数块 普通双色球
                //this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X - 2, SPImageGlobal.START_POINT_Y + 17 * SPImageGlobal.BB_HIGH - 2));
            }
            else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.PEKING))
            {
                
            }
            else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.JIANGXI))
            {
                this.DATA_BLOCK_LIST.Add(new SSQ_DataBlock(
                SPImageGlobal.LEFT_SMALL_BB_X + 2 * SPImageGlobal.RACE_BLOCK_WIDTH + 100 - 21
                , SPImageGlobal.START_POINT_Y + 227
                , 100 + 104
                , SPImageGlobal.START_POINT_Y + 227
                ));

                //倍数块 江西双色球
                this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[25]));
            }
            else if (Global.SYSTEM_CONFIG_MAP[GlobalConstants.SYSTEM_CONFIG_KEYS.PROVINCES_CODE].Equals(PCodeConstant.CODE.GUANGXI))
            {
                this.DATA_BLOCK_LIST.Add(new SSQ_DataBlock(
                SPImageGlobal.LEFT_SMALL_BB_X + 2 * SPImageGlobal.RACE_BLOCK_WIDTH + 100 - 21
                , SPImageGlobal.START_POINT_Y + 227
                , 100 + 104
                , SPImageGlobal.START_POINT_Y + 227
                ));

                //倍数块 广西双色球
                this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(ScanPortImageUtil.ssqMultipleCoordinateX, ScanPortImageUtil.ssqCoordinateY[25]));
            }
        }

        public override List<System.Drawing.Point> getDrawPoints(Common.model.lottery_ticket lt)
        {
            List<Point> points = new List<Point>();



            //彩种
            //points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + (lt.license_id == LicenseContants.License.GAMEIDRXJ ? 11 : 10) * SPImageGlobal.S2S_WIDTH,SPImageGlobal.START_POINT_Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
            String betCode = lt.bet_code.Replace(" ", "");
            //int m = 1, p = 0;
            //int.TryParse(lt.multiple, out m);
            //int.TryParse(lt.bet_price, out p);

            //if (lt.play_type.Equals(SSQPlayType.FS.ToString()))//复式
            //{
            //    //points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X,
            //    //                SPImageGlobal.START_POINT_Y + 5 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

            //    //this.DATA_BLOCK_LIST[2].getPointArrayByData(points, codes[0]);
            //    //this.DATA_BLOCK_LIST[3].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            //}
            //else
            //{
            //    //for (int i = 0; i < this.DATA_BLOCK_LIST.Count; i++)
            //    //{
            //    //    if (i < this.SLIP_EVENT_NUMBER)
            //    //    {
            //    //        if (i < codes.Length)
            //    //        {
            //    //            this.DATA_BLOCK_LIST[i].getPointArrayByData(points, codes[i]);
            //    //        }
            //    //    }
            //    //    else if (i == this.DATA_BLOCK_LIST.Count - 1)//倍数
            //    //    {
            //    //        this.DATA_BLOCK_LIST[i].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            //    //    }
            //    //}


            //    //for (int i = 0; i < codes.Length; i++)
            //    //{

            try
            {
                this.DATA_BLOCK_LIST[0].getPointArrayByData(points, betCode);
            }
            catch
            {
            }

            try
            {
                this.DATA_BLOCK_LIST[1].getPointArrayByData(points, lt.license_id.ToString() + "-" + lt.multiple);
            }
            catch
            {
            }
                    
            //    //}
            //}
            return points;
        }
    }
}
