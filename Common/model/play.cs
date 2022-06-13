using System;
namespace Maticsoft.Model
{
	[Serializable]
	public partial class play
	{
		public play()
		{}
		#region Model
		private int _play_id;
		private string _play_name;
		private int _license_id;
		private string _license_name;
		/// <summary>
		/// 
		/// </summary>
		public int play_id
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
		public int license_id
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

