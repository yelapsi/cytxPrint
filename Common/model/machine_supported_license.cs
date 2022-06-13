using System;
namespace Maticsoft.Common.model
{
	[Serializable]
	public partial class machine_supported_license
	{
        public machine_supported_license(){ }

        public machine_supported_license(machineSupportedLicense msl)
		{
            this._terminal_number = msl.terminalNumber;
            this._license_id = msl.licenseId;
		    this._license_name = msl.licenseName;
        }
		#region Model
		private string _terminal_number= "00000";
        private Int64 _license_id;
		private string _license_name;

        public string terminal_number
		{
			set{ _terminal_number=value;}
			get{return _terminal_number;}
		}
        public Int64 license_id
		{
			set{ _license_id=value;}
			get{return _license_id;}
		}
        public string license_name
		{
			set{ _license_name=value;}
			get{return _license_name;}
		}
		#endregion Model
	}
}

