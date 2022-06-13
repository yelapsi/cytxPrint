using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.serviceinterface
{
    interface ILogService
    {
        /// <summary>
        /// 把日志写到队列中
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        void addLogDataToQueue(String msg, GlobalConstants.LOGTYPE_ENUM type);

        /// <summary>
        /// 日志队列的处理
        /// </summary>
        void logQueueDataHandler();
    }
}
