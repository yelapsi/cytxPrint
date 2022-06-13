using Maticsoft.BLL.serviceimpl;
using Maticsoft.BLL.serviceinterface;
using System.Collections.Generic;
using Maticsoft.Model;

namespace Maticsoft.Controller
{
    public class LicenseController
    {
        ILicenseService licenseService = new LicenseServiceImpl();

        /// <summary>
        /// 更新彩种
        /// </summary>
        /// <param name="licenseList"></param>
        /// <param name="playList"></param>
        public void UpdateLicense(List<license> licenseList, List<play> playList)
        {
            try
            {
                //licenseService.ClearLicense();
                licenseService.UpdateLicense(licenseList, playList);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
