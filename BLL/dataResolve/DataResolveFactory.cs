using Maticsoft.BLL.dataResolve;
using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.dataResolve
{
    class DataResolveFactory
    {
        /// <summary>
        /// 把所有的数据转换对象放到字典中进行调度
        /// </summary>
        private static Dictionary<int, IDataResolve> dataResolveMap = new Dictionary<int, IDataResolve> { 
        {LicenseContants.License.GAMEIDPLS,new PL3DataResolve()},
        {LicenseContants.License.GAMEIDPLW,new PL5DataResolve()},
        {LicenseContants.License.GAMEIDQXC,new QXCDataResolve()},
        {LicenseContants.License.GAMEIDDLT,new DLTDataResolve()},
        {LicenseContants.License.GAMEIDSFC,new SFCDataResolve()},
        {LicenseContants.License.GAMEIDRXJ,new RX9DataResolve()},
        {LicenseContants.License.GAMEIDBQC,new BQCDataResolve()},
        {LicenseContants.License.GAMEIDJQC,new JQCDataResolve()},
        {LicenseContants.License.GAMEIDJCZQ,new JCZQDataResolve()},
        {LicenseContants.License.GAMEIDJCLQ,new JCLQDataResolve()},
        {LicenseContants.License.GAMEIDSSQ,new SSQDataResolve()},
        {LicenseContants.License.GAMEIDF3D,new F3DDataResolve()},
        {LicenseContants.License.GAMEIDQLC,new QLCDataResolve()},
        {100,new SD11x5DataResolve()}//十一选五统一用100
        };

        /// <summary>
        /// 获取对应的转换处理对象
        /// </summary>
        /// <param name="lId"></param>
        /// <returns></returns>
        public static IDataResolve getInstance(int lId)
        {
            return DataResolveFactory.dataResolveMap[lId];
        }
    }
}
