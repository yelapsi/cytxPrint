using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// machine_license:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class machine_license
	{
		public machine_license()
		{}
		#region Model
        private Int64 _machine_id;
		private string _model_name;
		private string _model_code;
		private string _type;
        private Int64 _license_id;
		private string _license_name;
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
        public Int64 machine_id
        {
            set { _machine_id = value; }
            get { return _machine_id; }
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
        public Int64 license_id
		{
			set{ _license_id=value;}
			get{return _license_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string license_name
		{
			set{ _license_name=value;}
			get{return _license_name;}
		}
		#endregion Model

	}
}

