using Maticsoft.Common.model;
using Maticsoft.Common.Util.playType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
    public class SYX5Structure: SPImageStructure
    {
        private Boolean IS_QX;//用来区分是前选还是任选
        public SYX5Structure(String lNameStr)
       {
           this.SLIP_EVENT_NUMBER = 5;
           this.ISHAS_CLEARANCE_TYPE = false;
           this.PTYPE_HEAD_DESC = SPImageGlobal.PTYPE_HEAD_DESC_DICTIONARY[lNameStr];
           this.HIGHLY_EFFECTIVE_CONTENT = (lNameStr.Equals("11X5_RX")? 16:31) * SPImageGlobal.BB_HIGH;

           this.IS_QX = lNameStr.Equals("11X5_QX");//用来区分是前选还是任选

           for (int i = 0; i < this.SLIP_EVENT_NUMBER; i++)
           {
               if (lNameStr.Equals("11X5_RX"))
               {
                   this.DATA_BLOCK_LIST.Add(new SYX5_RXX_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                               SPImageGlobal.START_POINT_Y + (2 + i * 2) * SPImageGlobal.BB_HIGH));
               }
               else
               {
                   this.DATA_BLOCK_LIST.Add(new SYX5_XQX_DataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                               SPImageGlobal.START_POINT_Y + (2 + i * 5) * SPImageGlobal.BB_HIGH));
               }
           }
            //倍数块
           this.DATA_BLOCK_LIST.Add(new MultipleDataBlock(SPImageGlobal.LEFT_SMALL_BB_X,
                                SPImageGlobal.START_POINT_Y + (2 + 5 * (lNameStr.Equals("11X5_RX") ? 2 : 5)) * SPImageGlobal.BB_HIGH));

        }

        /// <summary>
        /// 根据票面数据，获取所有要描绘的点
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        public override List<Point> getDrawPoints(lottery_ticket lt)
        {
            List<Point> points = new List<Point>();

            String[] codes = lt.bet_code.Split(';');
            if (IS_QX)//前选
            {
                //先判断是否是组选
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + ((lt.play_type.Equals(SD11X5PlayType.Q2ZX_DS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q2ZX_FS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q3ZX_DS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q3ZX_FS.ToString()))?7:6) * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
                //判断是选前几
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + ((lt.play_type.Equals(SD11X5PlayType.Q2ZX.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q2ZXFS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q2ZX_DS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q2ZX_FS.ToString())) ? 3 : 4) * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));
                //判断是否为复式
                if (lt.play_type.Equals(SD11X5PlayType.Q2ZXFS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q2ZX_FS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q3ZXFS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q3ZX_FS.ToString()))
                {
                    points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 10 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 6 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                    this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                    this.DATA_BLOCK_LIST[5].getPointArrayByData(points,"100-" + lt.multiple);
                }
                else
                {                    
                    for (int i = 0; i < this.DATA_BLOCK_LIST.Count; i++)
                    {
                        if ((lt.play_type.Equals(SD11X5PlayType.Q2ZX_DS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.Q3ZX_DS.ToString())) && i < codes.Length)//如果是前三组选单式和前二组选单式，号码格式得修正一下
                        {
                            codes[i] = codes[i].Replace(",", "|");
                        }
                        if (i < this.SLIP_EVENT_NUMBER)
                        {
                            if (i < codes.Length)//codes.Length
                            {
                                this.DATA_BLOCK_LIST[i].getPointArrayByData(points, codes[i]);
                            }
                        }
                        else if (i == this.DATA_BLOCK_LIST.Count - 1)//倍数
                        {
                            this.DATA_BLOCK_LIST[i].getPointArrayByData(points,"100-" + lt.multiple);
                        }
                    }
                }
            }
            else
            {
                //先判断是任几
                int X = 0,ltp=0;
                int.TryParse(lt.play_type, out ltp);
                if (ltp == 1 || ltp == 101)
                {
                    X = 0;
                }
                else if (ltp>=2&&ltp<=4)
                {
                    X = 1;
                }else if (ltp>=9&&ltp<=11)
                {
                    X = 2;
                }
                else if (ltp >= 16 && ltp <= 18)
                {
                    X = 3;
                }
                else if (ltp >= 19 && ltp <= 21)
                {
                    X = 4;
                }
                else if (ltp >= 22 && ltp <= 24)
                {
                    X = 5;
                }
                else if (ltp >= 25 && ltp <= 27)
                {
                    X = 6;
                }
                else if (ltp >= 28 && ltp <= 30)
                {
                    X = 7;
                }
                points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + X * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                //判断是否为复式
                if (lt.play_type.Equals(SD11X5PlayType.Q1FS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.R2FS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.R3FS.ToString()) ||
                    lt.play_type.Equals(SD11X5PlayType.R4FS.ToString())||
                    lt.play_type.Equals(SD11X5PlayType.R5FS.ToString())||
                    lt.play_type.Equals(SD11X5PlayType.R6FS.ToString())||
                    lt.play_type.Equals(SD11X5PlayType.R7FS.ToString())||
                    lt.play_type.Equals(SD11X5PlayType.R8FS.ToString()))
                {
                    points.Add(new Point(SPImageGlobal.LEFT_SMALL_BB_X + 9 * SPImageGlobal.S2S_WIDTH,
                                SPImageGlobal.START_POINT_Y + 3 * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH));

                    this.DATA_BLOCK_LIST[0].getPointArrayByData(points, codes[0]);
                    this.DATA_BLOCK_LIST[5].getPointArrayByData(points, "100-" + lt.multiple);
                }
                else
                {
                    for (int i = 0; i < this.DATA_BLOCK_LIST.Count; i++)
                    {
                        if (i < this.SLIP_EVENT_NUMBER)
                        {
                            if (i < codes.Length)//codes.Length
                            {
                                this.DATA_BLOCK_LIST[i].getPointArrayByData(points, codes[i]);
                            }
                        }
                        else if (i == this.DATA_BLOCK_LIST.Count - 1)//倍数
                        {
                            this.DATA_BLOCK_LIST[i].getPointArrayByData(points,"100-" + lt.multiple);
                        }
                    }
                }
            }
                        
            return points;
        }

    }
}
