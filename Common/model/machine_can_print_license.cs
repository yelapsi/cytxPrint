using System;
namespace Maticsoft.Common.model
{
    [Serializable]
    public partial class machine_can_print_license
    {
        public machine_can_print_license()
        {
        }

        public machine_can_print_license(machineSupportedLicense m)
        {
            this.terminal_number = m.terminalNumber;
            this.license_id = m.licenseId;
            this.license_name = m.licenseName;
        }

        public machine_can_print_license(String tnum, Int64 lid, String lname)
        {
            this.terminal_number = tnum;
            this.license_id = lid;
            this.license_name = lname;
        }
        #region Model
        private string _terminal_number;
        private Int64 _license_id;
        private string _license_name;
        
        public string terminal_number
        {
            set { _terminal_number = value; }
            get { return _terminal_number; }
        }
        
        public Int64 license_id
        {
            set { _license_id = value; }
            get { return _license_id; }
        }
        
        public string license_name
        {
            set { _license_name = value; }
            get { return _license_name; }
        }
        #endregion Model

    }
}

