using System;
using System.Collections.Generic;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common.model;
namespace Maticsoft.BLL.serviceimpl
{
    public interface IExpiredCheckingService:IBaseService
    {
        /// <summary>
        /// 处理逾期票
        /// </summary>
       void ExpiredTicketCheckingHandler();
    }
}
