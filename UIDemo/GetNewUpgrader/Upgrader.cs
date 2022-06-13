using System.Threading;
using Upgrade;

namespace Demo.GetNewUpgrader
{
    public class Upgrader
    {
        //下载服务器上的relealist文件
        public void UpdateStart()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.GetNewUpgrader));
        }

        private void GetNewUpgrader(object state)
        {
            try
            {
                //ftp操作工具
                SFTPHelper objSFTPHelper = new SFTPHelper();
                objSFTPHelper.Connect();
                
                if (objSFTPHelper.Connected)
                {
                    objSFTPHelper.Download(SFTPGlobal.FtpPath + SFTPGlobal.CYTXPRINT_EXE, SFTPGlobal.CYTXPRINT_EXE);
                    objSFTPHelper.Download(SFTPGlobal.FtpPath + SFTPGlobal.CYTXPRINT_EXE_CONFIG, SFTPGlobal.CYTXPRINT_EXE_CONFIG);
                    objSFTPHelper.Close();
                }
            }
            catch
            {

            }
        }
    }
}
