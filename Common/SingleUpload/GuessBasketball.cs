using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.SingleUpload
{
    public class GuessBasketball:Guess
    {
        public string sfDgOdds { set; get; }	// 胜负单关赔率
        public string sfGgOdds { set; get; }	// 胜负过关赔率
        public string rfsfDgOdds { set; get; }	// 让分胜负单关赔率
        public string rfsfGgOdds { set; get; }	// 让分胜负过关赔率
        public string sfcGgOdds { set; get; }	// 胜分差过关赔率（单关/过关一致）
        public string dxfDgOdds { set; get; }	// 大小分单关赔率
        public string dxfGgOdds { set; get; }	// 大小分过关赔率
        public string dgrf { set; get; }	//	让分
        public string ggrf { set; get; }	// 	过关让分
        public string dgyszf { set; get; }	//	预设总分
        public string ggyszf { set; get; }	//  过关总分
        public string backColor { set; get; }//背景色
        public string gameStartTime { set; get; }
        public string relationId { set; get; }//关联id
    }
}
