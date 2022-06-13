using System;
using Maticsoft.Common.model;
namespace Maticsoft.Common.model
{
	/// <summary>
	/// lottery_ticket:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class lotteryTicket
	{
        public lotteryTicket() {
            
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
        private Int64 _is_feedback;

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

        public Int64 is_feedback
        {
            get { return _is_feedback; }
            set { _is_feedback = value; }
        }
		
		#endregion Model

        public string return_pass_type { get; set; }

        public Int64 return_license_id { get; set; }

        public string return_license_name { get; set; }

        public string return_issue { get; set; }

        public Int64 return_issue_num { get; set; }

        public string return_play_name { get; set; }

        public Int64 return_multiple { get; set; }

        public Int64 return_money { get; set; }

        public string return_bet_info { get; set; }
    }
}

