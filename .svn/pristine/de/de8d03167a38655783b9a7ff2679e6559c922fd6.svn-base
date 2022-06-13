using System;
using Maticsoft.Common.dencrypt;
namespace Maticsoft.Common.model
{
	/// <summary>
	/// speed_level_cmd:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class speed_level_cmd
	{
		public speed_level_cmd()
		{}

        public speed_level_cmd(SpeedLevelCmd slc)
		{
        this.speed_level = slc.speedLevel;
		this.cmd_code = slc.cmdCode;
		this.cmd_type = slc.cmdType;
        this.license_id = slc.licenseId;
		this.license_name = slc.licenseName;
        this.play_id = slc.playId;
		this.play_name = slc.playName;
		this.ggfs_dfs = slc.ggfsDfs;
		this.description = slc.description;
		this.start_flow = slc.startFlow;
		this.first_flow = slc.firstFlow;
		this.second_flow = slc.secondFlow;
		this.third_flow = slc.thirdFlow;
		this.fourth_flow = slc.fourthFlow;
		this.fifth_flow = slc.fifthFlow;
		this.large_pass_flow = slc.largePassFlow;
        }

        /// <summary>
        /// 把关键字段加密——用于入库
        /// </summary>
        /// <param name="key"></param>
        public void Encrypt(String key)
        {
            this.start_flow = DESEncrypt.Encrypt(this.start_flow, key);
            this.first_flow = DESEncrypt.Encrypt(this.first_flow, key);
            this.second_flow = DESEncrypt.Encrypt(this.second_flow, key);
            this.third_flow = DESEncrypt.Encrypt(this.third_flow, key);
            this.fourth_flow = DESEncrypt.Encrypt(this.fourth_flow, key);
            this.fifth_flow = DESEncrypt.Encrypt(this.fifth_flow, key);
            this.large_pass_flow = DESEncrypt.Encrypt(this.large_pass_flow, key);
        }

        /// <summary>
        /// 把关键字段解密——用于出库使用
        /// </summary>
        /// <param name="key"></param>
        public void Decrypt(String key)
        {
            this.start_flow = DESEncrypt.Decrypt(this.start_flow, key);
            this.first_flow = DESEncrypt.Decrypt(this.first_flow, key);
            this.second_flow = DESEncrypt.Decrypt(this.second_flow, key);
            this.third_flow = DESEncrypt.Decrypt(this.third_flow, key);
            this.fourth_flow = DESEncrypt.Decrypt(this.fourth_flow, key);
            this.fifth_flow = DESEncrypt.Decrypt(this.fifth_flow, key);
            this.large_pass_flow = DESEncrypt.Decrypt(this.large_pass_flow, key);
        }
        
		#region Model
		private string _speed_level;
		private string _cmd_code;
		private string _cmd_type;
        private Int64 _license_id;
		private string _license_name;
        private Int64 _play_id;
		private string _play_name;
		private string _ggfs_dfs;
		private string _description;
		private string _start_flow;
		private string _first_flow;
		private string _second_flow;
		private string _third_flow;
		private string _fourth_flow;
		private string _fifth_flow;
		private string _large_pass_flow;
		/// <summary>
		/// 
		/// </summary>
		public string speed_level
		{
			set{ _speed_level=value;}
			get{return _speed_level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cmd_code
		{
			set{ _cmd_code=value;}
			get{return _cmd_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cmd_type
		{
			set{ _cmd_type=value;}
			get{return _cmd_type;}
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
		/// <summary>
		/// 
		/// </summary>
        public Int64 play_id
		{
			set{ _play_id=value;}
			get{return _play_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string play_name
		{
			set{ _play_name=value;}
			get{return _play_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ggfs_dfs
		{
			set{ _ggfs_dfs=value;}
			get{return _ggfs_dfs;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string start_flow
		{
			set{ _start_flow=value;}
			get{return _start_flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string first_flow
		{
			set{ _first_flow=value;}
			get{return _first_flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string second_flow
		{
			set{ _second_flow=value;}
			get{return _second_flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string third_flow
		{
			set{ _third_flow=value;}
			get{return _third_flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fourth_flow
		{
			set{ _fourth_flow=value;}
			get{return _fourth_flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fifth_flow
		{
			set{ _fifth_flow=value;}
			get{return _fifth_flow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string large_pass_flow
		{
			set{ _large_pass_flow=value;}
			get{return _large_pass_flow;}
		}
		#endregion Model

	}
}

