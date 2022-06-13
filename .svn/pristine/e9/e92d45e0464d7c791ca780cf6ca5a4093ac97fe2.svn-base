using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.httpmodel
{
    public class Body1001
    {
        public Body1001() { }
        public Body1001(lottery_order lo) {
            this.orderId = lo.id.ToString();
            this.betState = lo.bet_state;
            this.ticketNum = lo.ticket_num.ToString();
            this.ticketMoney = lo.ticket_money.ToString();
            this.cancelTicketNum = lo.canceled_num.ToString();
            this.cancelMoney = lo.canceled_money.ToString();
            this.ticketsInfo = new List<Body1001.FeedBackTicket>();
        }

        //order informaion
        public string orderId { get; set; }
        public string betState { get; set; }
        //public string betPrice {get;set;}
        //public string ticketDate {get;set;}
        public string ticketNum { get; set; }
        public string ticketMoney { get; set; }
        public string cancelTicketNum { get; set; }
        public string cancelMoney { get; set; }
        //error tickets informaion
        public IList<FeedBackTicket> ticketsInfo { get; set; }

        public class FeedBackTicket
        {
            public FeedBackTicket(lottery_ticket lt) {
                this.orderId = lt.order_id.ToString();
                this.ticketId = lt.ticket_id.ToString();
                this.errNum = "0";//错误注数
                this.printCode = "无数据";
                this.ticketState = lt.ticket_state;
                this.ticketMoney = (lt.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString())||
                    lt.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString()))?"0": lt.bet_price.ToString();
                this.betMoney = lt.bet_price;
                this.ticketOdds = lt.ticket_odds; // 赔率
                this.ticketDate = lt.ticket_date;
                this.ticketRqs = lt.ticket_rqs;
            }
            public string orderId { get; set; }
            public string ticketId { get; set; }
            public string errNum { get; set; }
            public string printCode { get; set; }
            public string ticketState { get; set; }
            public string ticketMoney { get; set; }//正常出票金额
            public string betMoney { get; set; }//票的总投注金额
            public string ticketOdds { get; set; }
            public string ticketRqs { get; set; }
            public string ticketDate { get; set; }
        }
    }
}
