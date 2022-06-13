using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.httpmodel
{
    public class BodyLoginResponse
    {
        private int _storeId;
        private Int64 _date;

        private IList<Machine> _machineList = new List<Machine>();

        public class Machine
        {
            private storeMachine _storeMachine;
            private List<machineSupportedLicense> _machineLicenseList;

            public storeMachine storeMachine
            {
                get { return _storeMachine; }
                set { _storeMachine = value; }
            }
            public List<machineSupportedLicense> machineLicenseList
            {
                get { return _machineLicenseList; }
                set { _machineLicenseList = value; }
            }
        }

        public int storeId
        {
            get { return _storeId; }
            set { _storeId = value; }
        }
        public Int64 date
        {
            get { return _date; }
            set { _date = value; }
        }
        public IList<Machine> machineList
        {
            get { return _machineList; }
            set { _machineList = value; }
        }
    }
}
