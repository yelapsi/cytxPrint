using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.SingleUpload
{
    public class Guess : IComparable
    {
        public string id { set; get; }	// 编号：20140317001
        public string leageId { set; get; }	// 联赛编号(可不用)
        public string leageName { set; get; }	// 联赛名称
        public string hostName { set; get; }	// 主队名称
        public string guestName { set; get; }	// 客队名称
        public string averageOdds { set; get; }	// 平均赔率
        public string startTime { set; get; }	// 比赛开始时间
        public string stopTime { set; get; }	// 比赛截止时间
        public string schudlesNO { set; get; }//对阵号，用于显示亚欧析，修改者：PENGYR
        public string bgcolor { set; get; }//联赛背景色
        public string srcLeaguageName { set; get; }
        public string srcHostName { set; get; }
        public string srcGuestName { set; get; }

        public int CompareTo(object obj)
        {
            int result;
            try
            {
                Guess info = obj as Guess;
                if (long.Parse(this.id) > long.Parse(info.id))
                {
                    result = 0;
                }
                else
                    result = 1;
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
