/**  版本信息模板在安装目录下，可自行修改。
* license.cs
*
* 功 能： N/A
* 类 名： license
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/8/22 17:21:03   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// license:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class license
	{
		public license()
		{}

        public license(Int64 license_id,String license_name)
        {
            this.license_id = license_id;
            this.license_name = license_name;
        }
		#region Model
        private Int64 _license_id;
		private string _license_name;
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

