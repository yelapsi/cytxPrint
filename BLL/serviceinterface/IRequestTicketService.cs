using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common.model;

namespace Maticsoft.BLL.serviceinterface
{
   public interface IRequestTicketService
    {
        bool requestTickets(ref bool isEndOfOrder);
        lottery_order GetLotteryOrderById(string id);
    }
}
