using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// lottery_ticket:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class lottery_ticket
	{
		public lottery_ticket()
		{}
		#region Model
		private Int64 _ticket_id;
        private Int64 _order_id;
        private Int64 _userid;
		private string _username;
        private Int64 _storeid;
        private Int64 _license_id;
		private string _play_type;
        private string _create_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		private string _ticket_date;
		private string _bet_code;
		private string _bet_num;
		private string _multiple;
		private string _bet_price;
		private string _stop_time;
		private string _ticket_state;
		private string _issue;
		private string _order_odds;
		private string _ticket_odds;
		private string _order_rqs;
		private string _ticket_rqs;
		private string _terminal_number;
		private string _exc_handling_record;
		private string _com_port;
		private string _sent_num;
		private string _exception_description;
		private string _cancel_money="0.00";
        private string _zj_flag = "0";
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

        public string zj_flag
        {
            get { return _zj_flag; }
            set { _zj_flag = value; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Int64 ticket_id
		{
			set{ _ticket_id=value;}
			get{return _ticket_id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 order_id
		{
			set{ _order_id=value;}
			get{return _order_id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 storeid
		{
			set{ _storeid=value;}
			get{return _storeid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 license_id
		{
			set{ _license_id=value;}
			get{return _license_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string play_type
		{
			set{ _play_type=value;}
			get{return _play_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string create_date
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ticket_date
		{
			set{ _ticket_date=value;}
			get{return _ticket_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bet_code
		{
			set{ _bet_code=value;}
			get{return _bet_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bet_num
		{
			set{ _bet_num=value;}
			get{return _bet_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string multiple
		{
			set{ _multiple=value;}
			get{return _multiple;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bet_price
		{
			set{ _bet_price=value;}
			get{return _bet_price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string stop_time
		{
			set{ _stop_time=value;}
			get{return _stop_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ticket_state
		{
			set{ _ticket_state=value;}
			get{return _ticket_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string issue
		{
			set{ _issue=value;}
			get{return _issue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_odds
		{
			set{ _order_odds=value;}
			get{return _order_odds;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ticket_odds
		{
			set{ _ticket_odds=value;}
			get{return _ticket_odds;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string order_rqs
		{
			set{ _order_rqs=value;}
			get{return _order_rqs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ticket_rqs
		{
			set{ _ticket_rqs=value;}
			get{return _ticket_rqs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string terminal_number
		{
			set{ _terminal_number=value;}
			get{return _terminal_number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string exc_handling_record
		{
			set{ _exc_handling_record=value;}
			get{return _exc_handling_record;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string com_port
		{
			set{ _com_port=value;}
			get{return _com_port;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sent_num
		{
			set{ _sent_num=value;}
			get{return _sent_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string exception_description
		{
			set{ _exception_description=value;}
			get{return _exception_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cancel_money
		{
			set{ _cancel_money=value;}
			get{return _cancel_money;}
		}

        private String _betCode_info;

        public String betCode_info
        {
            get { return this._bet_code; }
            set { _betCode_info = value; }
        }
		#endregion Model

	}
}

