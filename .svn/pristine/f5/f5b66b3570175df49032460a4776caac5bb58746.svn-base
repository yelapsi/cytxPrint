using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// lottery_ticket:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class lotteryTicket
	{
		public lottery_ticket lotteriTicket(lottery_ticket lt)
		{
            lt.bet_code = this.betCode;
            lt.bet_num = this.betNum;
            lt.bet_price = this.betPrice;
            lt.cancel_money = this.cancelMoney;
            lt.com_port = this.comPort;
            lt.create_date = this.createDate;
            lt.exc_handling_record = this.excHandlingRecord;
            lt.exception_description = this.exceptionDescription;
            lt.issue = this.issue;
            lt.license_id = this.licenseId;
            lt.multiple = this.multiple;
            lt.order_id = this.orderId;
            lt.order_odds = this.orderOdds;
            lt.order_rqs = this.orderRqs;
            lt.play_type = this.playType;
            lt.sent_num = this.sentNum;
            lt.stop_time = this.stopTime;
            lt.storeid = this.storeid;
            lt.terminal_number = this.terminalNumber;
            lt.ticket_date = this.ticketDate;
            lt.ticket_id = this.ticketId;
            lt.ticket_odds = this.ticketOdds;
            lt.ticket_rqs = this.ticketRqs;
            lt.ticket_state = this.ticketState;
            lt.userid = this.userid;
            lt.username = this.username;
            lt.zj_flag = this.zj_flag;
            lt.err_ticket_sign = this.err_ticket_sign;
            lt.betCode_info = this.betCode_info;
            lt.ticket_info = this.ticket_info;
            return lt;
        }
		#region Model
		public Int64 ticketId {get;set;}
        public Int64 orderId {get;set;}
        public Int64 userid {get;set;}
		public string username {get;set;}
        public Int64 storeid {get;set;}
        public Int64 licenseId {get;set;}
		public string playType {get;set;}
        private string _createDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string createDate
        {
          get { return _createDate; }
          set { _createDate = value; }
        }
		public string ticketDate {get;set;}
		public string betCode {get;set;}
		public string betNum {get;set;}
		public string multiple {get;set;}
		public string betPrice {get;set;}
		public string stopTime {get;set;}
		public string ticketState {get;set;}
		public string issue {get;set;}
		public string orderOdds {get;set;}
		public string ticketOdds {get;set;}
		public string orderRqs {get;set;}
		public string ticketRqs {get;set;}
		public string terminalNumber {get;set;}
		public string excHandlingRecord {get;set;}
		public string comPort {get;set;}
		public string sentNum {get;set;}
		public string exceptionDescription {get;set;}
        private string _cancelMoney = "0.00";
        private Int64 _err_ticket_sign = 0;

        private string _ticket_info;//出票信息——票花信息

        public string ticket_info
        {
            get { return _ticket_info; }
            set { _ticket_info = value; }
        }

        public Int64 err_ticket_sign
        {
            get { return _err_ticket_sign; }
            set { _err_ticket_sign = value; }
        }
        public string cancelMoney
        {
            get { return _cancelMoney; }
            set { _cancelMoney = value; }
        }

        private string _zj_flag = "0";

        public string zj_flag
        {
            get { return _zj_flag; }
            set { _zj_flag = value; }
        }

        private String _betCode_info;

        public String betCode_info
        {
            get { return this.betCode; }
            set { _betCode_info = value; }
        }
		
		#endregion Model

	}
}

