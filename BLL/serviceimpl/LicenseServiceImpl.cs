using Maticsoft.BLL.serviceinterface;
using System.Collections.Generic;
using Maticsoft.Model;
using System.Collections;
using Maticsoft.Common.dbUtility;
using System.Data.SQLite;
using System;

namespace Maticsoft.BLL.serviceimpl
{
    public class LicenseServiceImpl : BaseServiceImpl, ILicenseService
    {
        public void UpdateLicense(List<license> licenseList, List<play> playList)
        {
            try
            {
                string sqlLicense = string.Format("insert into license({0}) values({1})", licenseColumns, licenseParameters);
                List<SQLiteParameter[]> sqlLicenseParasList = new List<SQLiteParameter[]>();
                foreach (license li in licenseList)
                {
                    sqlLicenseParasList.Add(GetLiceseParameterArr(li));
                }
                SQLiteHelper.getBLLInstance().ExecuteSqlParasTran(sqlLicense, sqlLicenseParasList);

                string sqlPlay = string.Format("insert into license({0}) values({1})", licenseColumns, licenseParameters);
                IList<SQLiteParameter[]> sqlPlayParasList = new List<SQLiteParameter[]>();
                foreach (play pl in playList)
                {
                    sqlPlayParasList.Add(GetPlayParameterArr(pl));
                }
                SQLiteHelper.getBLLInstance().ExecuteSqlParasTran(sqlLicense, sqlLicenseParasList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ClearLicense()
        {
            ArrayList sqllist = new ArrayList();
            //sqllist.Add("DELETE FROM license;");
            sqllist.Add("DELETE FROM play;");
            try
            {
                SQLiteHelper.getBLLInstance().ExecuteSqlTran(sqllist);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
