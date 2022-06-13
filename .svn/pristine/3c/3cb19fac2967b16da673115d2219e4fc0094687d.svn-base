using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public interface GuessSingleUploadParser : SingleUploadParser
    {
        /// <summary>
        /// 解析单式上传文件
        /// </summary>
        /// <param name="playId">玩法</param>
        /// <param name="line"></param>
        /// <param name="schNum"></param>
        /// <param name="passLen">竞彩N串1，其他彩种填0即可</param>
        /// <param name="withSch"></param>
        /// <returns></returns>
        string parseSingleFileLine(int playId, string line, int schNum, int passLen, bool withSch); 
    }
}
