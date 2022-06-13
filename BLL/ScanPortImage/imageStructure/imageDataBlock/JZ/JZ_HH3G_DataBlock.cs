using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Maticsoft.BLL.ScanPortImage.imageStructure
{
   public class JZ_HH3G_DataBlock: ImageDataBlock
    {
       public static int DATA_BLOCK_HIGH = 22 * SPImageGlobal.BB_HIGH;
       private String play="";

       public JZ_HH3G_DataBlock(int startx, int starty)
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
            //记录当前的玩法
            this.play = dz [ 2 ].Split ( '*' ) [ 1 ];
            //取对阵的点
            this.getSMGRacePoints(pointlist, dz[0], this.startPoint);//对阵的点
            //取竞猜结果的点
            //0,1,2,3,4,5,6,7
            this.getGuessResultPoints(pointlist, dz[1].Split(','));
        }

        /// <summary>
        /// 取得竞猜结果的点位值
        /// </summary>
        /// <param name="resultdata"></param>
        private void getGuessResultPoints(List<Point> plist, String[] resultdata) {
            foreach (String item in resultdata)
            {
                String[] playresult = item.Split('-');//5-1,5-2,5-3,5-4
                int x = 0, y = 0;
                String thisplay="",thisresult="";
                if ( !this.play.StartsWith ( "6-" ) )//非混合过关用混合过关单子
                {
                    thisplay = this.play.Split ( '-' ) [ 0 ];
                    thisresult = playresult [ 0 ];
                }
                else
                {
                    thisplay = playresult [ 0 ];
                    thisresult = playresult [ 1 ];
                }

                switch ( thisplay )
                {
                    case "1"://胜平负
                        y = 7;
                        switch ( thisresult )
                        {
                            case "3":
                                x = 0;
                                break;
                            case "1":
                                x = 1;
                                break;
                            default:
                                x = 2;
                                break;
                        }
                        break;
                    case "2"://让球胜平负
                        y = 8;
                        switch ( thisresult )
                        {
                            case "3":
                                x = 0;
                                break;
                            case "1":
                                x = 1;
                                break;
                            default:
                                x = 2;
                                break;
                        }
                        break;
                    case "3"://总进球
                        switch ( thisresult )
                        {
                            case "0":
                                x = 0;
                                y = 20;
                                break;
                            case "1":
                                x = 1;
                                y = 20;
                                break;
                            case "2":
                                x = 2;
                                y = 20;
                                break;
                            case "3":
                                x = 3;
                                y = 20;
                                break;
                            case "4":
                                x = 0;
                                y = 21;
                                break;
                            case "5":
                                x = 1;
                                y = 21;
                                break;
                            case "6":
                                x = 2;
                                y = 21;
                                break;
                            default:
                                x = 3;
                                y = 21;
                                break;
                        }
                        break;
                    case "4"://半全场
                        String f = thisresult.Substring ( 0, 1 ), l = thisresult.Substring ( 1 );
                        x = ( l.Equals ( "3" ) ? 0 : l.Equals ( "1" ) ? 1 : 2 );
                        y = ( f.Equals ( "3" ) ? 17 : f.Equals ( "1" ) ? 18 : 19 );
                        break;
                    default://比分      
                        switch ( thisresult )
                        {
                            //JCZQ_INDEX_BF.put("1", "1:0");
                            //JCZQ_INDEX_BF.put("2", "2:0");
                            //JCZQ_INDEX_BF.put("3", "2:1");
                            //JCZQ_INDEX_BF.put("4", "3:0");
                            //JCZQ_INDEX_BF.put("5", "3:1");
                            //JCZQ_INDEX_BF.put("6", "3:2");
                            //JCZQ_INDEX_BF.put("7", "4:0");
                            //JCZQ_INDEX_BF.put("8", "4:1");
                            case "1":
                                x = 0;
                                y = 9;
                                break;
                            case "2":
                                x = 0;
                                y = 10;
                                break;
                            case "3":
                                x = 0;
                                y = 11;
                                break;
                            case "4":
                                x = 0;
                                y = 12;
                                break;
                            case "5":
                                x = 0;
                                y = 13;
                                break;
                            case "6":
                                x = 0;
                                y = 14;
                                break;
                            case "7":
                                x = 0;
                                y = 15;
                                break;
                            case "8":
                                x = 0;
                                y = 16;
                                break;
                            //JCZQ_INDEX_BF.put("9", "4:2");
                            //JCZQ_INDEX_BF.put("10", "5:0");
                            //JCZQ_INDEX_BF.put("11", "5:1");
                            //JCZQ_INDEX_BF.put("12", "5:2");
                            //JCZQ_INDEX_BF.put("0", "胜其他");
                            //JCZQ_INDEX_BF.put("14", "0:0");
                            //JCZQ_INDEX_BF.put("15", "1:1");
                            //JCZQ_INDEX_BF.put("16", "2:2");
                            case "9":
                                x = 1;
                                y = 9;
                                break;
                            case "10":
                                x = 1;
                                y = 10;
                                break;
                            case "11":
                                x = 1;
                                y = 11;
                                break;
                            case "12":
                                x = 1;
                                y = 12;
                                break;
                            case "0":
                                x = 1;
                                y = 13;
                                break;
                            case "14":
                                x = 1;
                                y = 14;
                                break;
                            case "15":
                                x = 1;
                                y = 15;
                                break;
                            case "16":
                                x = 1;
                                y = 16;
                                break;
                            //JCZQ_INDEX_BF.put("27", "2:4");
                            //JCZQ_INDEX_BF.put("28", "0:5");
                            //JCZQ_INDEX_BF.put("29", "1:5");
                            //JCZQ_INDEX_BF.put("30", "2:5");
                            //JCZQ_INDEX_BF.put("18", "负其他");
                            //JCZQ_INDEX_BF.put("17", "3:3");
                            //JCZQ_INDEX_BF.put("13", "平其他");
                            case "27":
                                x = 2;
                                y = 9;
                                break;
                            case "28":
                                x = 2;
                                y = 10;
                                break;
                            case "29":
                                x = 2;
                                y = 11;
                                break;
                            case "30":
                                x = 2;
                                y = 12;
                                break;
                            case "18":
                                x = 2;
                                y = 13;
                                break;
                            case "17":
                                x = 2;
                                y = 14;
                                break;
                            case "13":
                                x = 2;
                                y = 15;
                                break;
                            //JCZQ_INDEX_BF.put("19", "0:1");
                            //JCZQ_INDEX_BF.put("20", "0:2");
                            //JCZQ_INDEX_BF.put("21", "1:2");
                            //JCZQ_INDEX_BF.put("22", "0:3");
                            //JCZQ_INDEX_BF.put("23", "1:3");
                            //JCZQ_INDEX_BF.put("24", "2:3");
                            //JCZQ_INDEX_BF.put("25", "0:4");
                            //JCZQ_INDEX_BF.put("26", "1:4");
                            case "19":
                                x = 3;
                                y = 9;
                                break;
                            case "20":
                                x = 3;
                                y = 10;
                                break;
                            case "21":
                                x = 3;
                                y = 11;
                                break;
                            case "22":
                                x = 3;
                                y = 12;
                                break;
                            case "23":
                                x = 3;
                                y = 13;
                                break;
                            case "24":
                                x = 3;
                                y = 14;
                                break;
                            case "25":
                                x = 3;
                                y = 15;
                                break;
                            default:
                                x = 3;
                                y = 16;
                                break;
                        }
                        break;
                }

                plist.Add ( new Point ( startPoint.X + x * SPImageGlobal.S2S_WIDTH,
                this.startPoint.Y + y * SPImageGlobal.BB_HIGH + SPImageGlobal.B2S_HIGH ) );
            }
        }
    }
}