using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.httpmodel
{
    public class C006ContentReq
    {
        public List<ticket> tickets { get; set; }
    }

    public class ticket
    {
        //机头
        public String HeadNo { get; set; }

        //彩票的ID
        public String LotteryTypeId { get; set; }

        //终端机编号
        public int Nums { get; set; }
    }

    public class AckTicket : ticket
    {
        //public List<String> TicketIds { get; set; }
        public String TicketIds { get; set; }
    }

    public class C006ContentAck
    {
        //二维码字串
        public String QRCodeUrl { get; set; }
        //订单ID
        public String OrderId { get; set; }

        public List<AckTicket> tickets { get; set; }
    }
}
