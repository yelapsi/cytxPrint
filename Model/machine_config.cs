using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// machine_config:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class machine_config
	{
		public machine_config()
		{}
		#region Model
        private Int64 _id;
		private string _model_name;
		private string _model_code;
		private string _type= "1";
		private string _k_ps2= "1";
		private string _k_usb;
		private string _k_touchscreen= "1";
		private string _r_serialport= "1";
		private string _r_usbimage= "1";
		private string _r_usbdata= "1";
		private string _p_serialport;
		private string _p_usb;
		private string _p_parallelport;

		private string _product_number;


        private String _print_receivedata_end;              
        private String _receive_start_contrl_key;
        private String _receive_start_print_key;

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

        /// <summary>
        /// 
        /// </summary>
        public Int64 id
        {
            get { return _id; }
            set { _id = value; }
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
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string k_ps2
		{
			set{ _k_ps2=value;}
			get{return _k_ps2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string k_usb
		{
			set{ _k_usb=value;}
			get{return _k_usb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string k_touchscreen
		{
			set{ _k_touchscreen=value;}
			get{return _k_touchscreen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string r_serialport
		{
			set{ _r_serialport=value;}
			get{return _r_serialport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string r_usbimage
		{
			set{ _r_usbimage=value;}
			get{return _r_usbimage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string r_usbdata
		{
			set{ _r_usbdata=value;}
			get{return _r_usbdata;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_serialport
		{
			set{ _p_serialport=value;}
			get{return _p_serialport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string p_usb
		{
			set{ _p_usb=value;}
			get{return _p_usb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 
p_parallelport
		{
			set{ _p_parallelport=value;}
			get{return _p_parallelport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string product_number
		{
			set{ _product_number=value;}
			get{return _product_number;}
		}

		#endregion Model

	}
}

