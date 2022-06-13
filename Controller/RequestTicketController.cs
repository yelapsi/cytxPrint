using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;
using Maticsoft.Common;
using Maticsoft.Common.Util;

namespace Maticsoft.Controller
{
    public class RequestTicketController
    {
        private RequestTicketServiceImpl rtimpl = new RequestTicketServiceImpl();

        public bool requestTickets(ref bool isEndOfOrder)
        {
            try
            {
                return rtimpl.requestTickets(ref isEndOfOrder);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public lottery_order GetLotteryOrderById(string id)
        {
            try
            {
                return rtimpl.GetLotteryOrderById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
