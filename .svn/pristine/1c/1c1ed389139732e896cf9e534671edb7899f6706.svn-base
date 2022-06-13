using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// sys_config:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sys_config
	{
		public sys_config()
		{}
		#region Model
		private Int64 _ticket_interval=0;
        private Int64 _digital_interval = 0;
        private Int64 _enter_interval = 0;
        private Int64 _dynamic_interval_min = 0;
        private Int64 _dynamic_interval_max;        
		private string _sys_pass;
        private Int64 _is_automatic_feedback;


        /// <summary>
        /// 取动态间隔时间
        /// </summary>
        /// <returns></returns>
        public Int64 getDynamicInterval() {
            if (this.dynamic_interval_min >= this.dynamic_interval_max)
            {
                return 0;
            }
            else {
                Random r = new Random(DateTime.Now.Millisecond);
                Int64 i = r.Next() % (this.dynamic_interval_max - this.dynamic_interval_min);
                return i + this.dynamic_interval_min;
            }
        }


		/// <summary>
		/// 
		/// </summary>
        public Int64 ticket_interval
		{
			set{ _ticket_interval=value;}
			get{return _ticket_interval;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 digital_interval
		{
			set{ _digital_interval=value;}
			get{return _digital_interval;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 enter_interval
		{
			set{ _enter_interval=value;}
			get{return _enter_interval;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 dynamic_interval_min
		{
			set{ _dynamic_interval_min=value;}
			get{return _dynamic_interval_min;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Int64 dynamic_interval_max
		{
			set{ _dynamic_interval_max=value;}
			get{return _dynamic_interval_max;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public string sys_pass
		{
			set{ _sys_pass=value;}
			get{return _sys_pass;}
		}

        /// <summary>
        /// 
        /// </summary>
        public Int64 is_automatic_feedback
        {
            set { _is_automatic_feedback = value; }
            get { return _is_automatic_feedback; }
        }
		#endregion Model

	}
}

