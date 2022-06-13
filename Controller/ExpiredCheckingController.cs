using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Maticsoft.Controller
{
    public class ExpiredCheckingController
    {
        private IExpiredCheckingService etc = new ExpiredCheckingServiceImpl();

        /// <summary>
        /// 1. select lottery_ticket by stop_time > now
        /// 2. update state of ticket
        /// 3. update expired_count
        /// 4. update expired_price
        /// </summary>
        public void ExpiredTicketCheckingHandler()
        {
            try
            {
                etc.ExpiredTicketCheckingHandler();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
