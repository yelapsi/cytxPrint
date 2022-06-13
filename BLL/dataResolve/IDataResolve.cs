using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    interface IDataResolve
    {
        /// <summary>
        /// 投注数据转换为命令数据
        /// </summary>
        /// <param name="data">投注数据</param>
        /// <param name="playType">玩法</param>
        /// <returns></returns>
        String ticketDataToCommand(String data,int playType);
    }
}
