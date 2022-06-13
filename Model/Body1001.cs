using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    public class Body1001
    {
        //order informaion
        public string orderId {get;set;}
        //public string betPrice {get;set;}
        //public string totalTicketNum {get;set;}
        //public string ticketDate {get;set;}
        //public string errTicketsNum {get;set;}
        //error tickets informaion
        public IList<ErrorTicket> errTickets { get; set; }
        public class ErrorTicket
        {
            public string ticketId { get; set; }
            public string errNum { get; set; }
            public string printCode { get; set; }
        }
    }
}
