/**  版本信息模板在安装目录下，可自行修改。
* speed_level_config.cs
*
* 功 能： N/A
* 类 名： speed_level_config
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/10/16 15:23:33   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using Maticsoft.Common.dencrypt;
namespace Maticsoft.Common.model
{
	/// <summary>
	/// speed_level_config:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class speed_level_config
	{
		public speed_level_config()
		{}

        public speed_level_config(SpeedLevelConfig slc)
		{
        this.speed_level = slc.speedLevel;
        this.ticket_interval = slc.ticketInterval;
        this.digital_interval = slc.digitalInterval;
        this.enter_interval = slc.enterInterval;
        this.dynamic_interval_min = slc.dynamicIntervalMin;
        this.dynamic_interval_max = slc.dynamicIntervalMax;
        this.state =slc.state;
        }
        

        /// <summary>
        /// 取动态间隔时间
        /// </summary>
        /// <returns></returns>
        public Int64 getDynamicinterval()
        {
            if (this.dynamic_interval_min >= this.dynamic_interval_max)
            {
                return 0;
            }
            else
            {
                Random r = new Random(DateTime.Now.Millisecond);
                Int64 i = r.Next() % (this.dynamic_interval_max - this.dynamic_interval_min);
                return i + this.dynamic_interval_min;
            }
        }

		#region Model
		private string _speed_level;
		private Int64 _ticket_interval;
        private Int64 _digital_interval;
        private Int64 _enter_interval;
        private Int64 _dynamic_interval_min;
        private Int64 _dynamic_interval_max;
        private Int64 _state = 1;
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
        public Int64 state
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

