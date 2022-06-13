using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// store_machine:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class store_machine
	{
		public store_machine()
		{}
		#region Model
		private Int64  _id;
        private Int64 _model_id;
		private string _model_name;
		private string _model_code;
		private string _model_type;
		private string _com_name;
        private Int64 _com_baudrate;
        private Int64 _com_databits;
		private string _com_stopbits;
		private string _com_parity;
		private string _terminal_number;
        private Int64 _is_feed_back;
        private Int64 _speed_sign;

        private Int64 _big_ticket_amount;
        private String _big_ticket_pass;

        private Int64 _is_auto_ticket;
        private Int64 _is_continuous_ticket;

        private String _print_receivedata_end;
        private String _receive_start_contrl_key;
        private String _receive_start_print_key;
        

        /// <summary>
        /// 
        /// </summary>
        public Int64 big_ticket_amount
        {
            set { _big_ticket_amount = value; }
            get { return _big_ticket_amount; }
        }

        public String big_ticket_pass
        {
            get { return _big_ticket_pass; }
            set { _big_ticket_pass = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 model_id
        {
            get { return _model_id; }
            set { _model_id = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int64 speed_sign
        {
            get { return _speed_sign; }
            set { _speed_sign = value; }
        }
		/// <summary>
		/// 
		/// </summary>
        public Int64 id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string model_name
		{
			set{ _model_name=value;}
			get{return _model_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string model_code
		{
			set{ _model_code=value;}
			get{return _model_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string model_type
		{
			set{ _model_type=value;}
			get{return _model_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string com_name
		{
			set{ _com_name=value;}
			get{return _com_name;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 com_baudrate
		{
			set{ _com_baudrate=value;}
			get{return _com_baudrate;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 com_databits
		{
			set{ _com_databits=value;}
			get{return _com_databits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string com_stopbits
		{
			set{ _com_stopbits=value;}
			get{return _com_stopbits;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string com_parity
		{
			set{ _com_parity=value;}
			get{return _com_parity;}
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
        public Int64 is_feed_back
		{
			set{ _is_feed_back=value;}
			get{return _is_feed_back;}
		}

        /// <summary>
        /// 
        /// </summary>
        public Int64 is_auto_ticket
        {
            set { _is_auto_ticket = value; }
            get { return _is_auto_ticket; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int64 is_continuous_ticket
        {
            set { _is_continuous_ticket = value; }
            get { return _is_continuous_ticket; }
        }

        public String receive_start_contrl_key
        {
            get { return _receive_start_contrl_key; }
            set { _receive_start_contrl_key = value; }
        }


        public String receive_start_print_key
        {
            get { return _receive_start_print_key; }
            set { _receive_start_print_key = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String print_receivedata_end
        {
            get { return _print_receivedata_end; }
            set { _print_receivedata_end = value; }
        }
		#endregion Model

	}
}

