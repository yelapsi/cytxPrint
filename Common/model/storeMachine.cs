using System;

namespace Maticsoft.Common.model
{
	[Serializable]
	public partial class storeMachine
	{
        public storeMachine()
		{}
		#region Model
		private string _machine_name;
		private string _machine_code;
		private string _machine_type;
		private string _com_name;
        private Int64 _com_baudrate;
        private Int64 _com_databits;
		private string _com_stopbits;
		private string _com_parity;
		private string _terminal_number;
        private Int64 _is_feed_back;
        private Int64 _speed_level;
        private Int64 _big_ticket_amount;
        private String _big_ticket_pass;
        private Int64 _is_auto_ticket;
        private Int64 _is_continuous_ticket;
        private long _is_compl_auto_stop;

        public Int64 bigTicketAmount
        {
            set { _big_ticket_amount = value; }
            get { return _big_ticket_amount; }
        }

        public String bigTicketPass
        {
            get { return _big_ticket_pass; }
            set { _big_ticket_pass = value; }
        }

        public Int64 speedLevel
        {
            get { return _speed_level; }
            set { _speed_level = value; }
        }

		public string machineName
		{
			set{ _machine_name=value;}
			get{return _machine_name;}
		}
		
		public string machineCode
		{
			set{ _machine_code=value;}
			get{return _machine_code;}
		}
		
		public string machineType
		{
			set{ _machine_type=value;}
			get{return _machine_type;}
		}
		
		public string comName
		{
			set{ _com_name=value;}
			get{return _com_name;}
		}
		
        public Int64 comBaudrate
		{
			set{ _com_baudrate=value;}
			get{return _com_baudrate;}
		}
		
        public Int64 comDatabits
		{
			set{ _com_databits=value;}
			get{return _com_databits;}
		}
		
		public string comStopbits
		{
			set{ _com_stopbits=value;}
			get{return _com_stopbits;}
		}
		
		public string comParity
		{
			set{ _com_parity=value;}
			get{return _com_parity;}
		}
		
		public string terminalNumber
		{
			set{ _terminal_number=value;}
			get{return _terminal_number;}
		}
		
        public Int64 isFeedBack
		{
			set{ _is_feed_back=value;}
			get{return _is_feed_back;}
		}

        public Int64 isAutoTicket
        {
            set { _is_auto_ticket = value; }
            get { return _is_auto_ticket; }
        }
        
        public Int64 isContinuousTicket
        {
            set { _is_continuous_ticket = value; }
            get { return _is_continuous_ticket; }
        }

        public long isComplAutoStop
        {
            get { return _is_compl_auto_stop; }
            set { _is_compl_auto_stop = value; }
        }

		#endregion Model
    }
}

