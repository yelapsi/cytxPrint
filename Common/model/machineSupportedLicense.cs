using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model
{
    [Serializable]
    public class machineSupportedLicense
    {
		#region Model
		private string _terminal_number= "00000";
        private Int64 _license_id;
		private string _license_name;

        public string terminalNumber
		{
			set{ _terminal_number=value;}
			get{return _terminal_number;}
		}
        public Int64 licenseId
		{
			set{ _license_id=value;}
			get{return _license_id;}
		}
		public string licenseName
		{
			set{ _license_name=value;}
			get{return _license_name;}
		}
		#endregion Model
	}
}
