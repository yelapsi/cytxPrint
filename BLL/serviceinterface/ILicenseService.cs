using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.serviceinterface
{
    public interface ILicenseService:IBaseService
    {
        void UpdateLicense(List<Model.license> licenseList, List<Model.play> playList);

        void ClearLicense();
    }
}
