using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.SingleUpload
{
    public class GuessFootball:Guess
    {
        public string spfDgOdds { set; get; }	//	胜平负单关赔率,胜票赔率、平赔率、负赔率
        public string spfGgOdds { set; get; }	// 	胜平负过关赔率
        public string rqspfDgOdds { set; get; }	// 	让球胜平负单关赔率
        public string rqspfGgOdds { set; get; }	//	让球胜平负过关赔率
        public string zjqDgOdds { set; get; }	//	总进球单关赔率
        public string zjqGgOdds { set; get; }	//	总进球过关赔率
        public string bqcDgOdds { set; get; }	//	半全场单关赔率
        public string bqcGgOdds { set; get; }	//	半全场过关赔率
        public string bfGgOdds { set; get; }	//	比分过关赔率(单关于过关赔率一致)
        public string dgrq { set; get; }	//	单关让球数
        public string ggrq { set; get; }	//	过关让球
        public string backColor { set; get; }//背景色
        public string relationId { set; get; }//关联id
        public string gameStartTime { set; get; }
    }
}
