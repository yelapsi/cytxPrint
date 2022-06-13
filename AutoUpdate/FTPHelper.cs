using System;
using System.Collections;
using Tamir.SharpSsh;

namespace AutoUpdate
{
    public class SFTPHelper
    {
        private SshTransferProtocolBase m_sshCp;
 
        public SFTPHelper()
        {
            m_sshCp = new Sftp(SFTPGlobal.Host, SFTPGlobal.User);

            if (!String.IsNullOrEmpty(SFTPGlobal.Pass))
            {
                m_sshCp.Password = SFTPGlobal.Pass;
            }else if (!String.IsNullOrEmpty(SFTPGlobal.IdentityFile))
            {
                m_sshCp.AddIdentityFile(SFTPGlobal.IdentityFile);
            }
        }

        public bool Connected
        {
            get
            {
                return m_sshCp.Connected;
            }
        }
        public void Connect()
        {
            if (!m_sshCp.Connected)
            {
                m_sshCp.Connect();
            }
        }
        public void Close()
        {
            if (m_sshCp.Connected)
            {
                m_sshCp.Close();
            }
        }
        public bool Upload(string localPath, string remotePath)
        {
            try
            {
                if (!m_sshCp.Connected)
                {
                    m_sshCp.Connect();
                }
                m_sshCp.Put(localPath, remotePath);

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool Download(string remotePath, string localPath)
        {
            try
            {
                if (!m_sshCp.Connected)
                {
                    m_sshCp.Connect();
                }

                m_sshCp.Get(remotePath, localPath);

                return true;
            }
            catch
            {
                return false;
            }
        }
        //public bool Delete(string remotePath)
        //{
        //    try
        //    {
        //        if (!m_sshCp.Connected)
        //        {
        //            m_sshCp.Connect();
        //        }
        //        ((Sftp)m_sshCp).Delete(remotePath);//刚刚新增的Delete方法

        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public ArrayList GetFileList(string path)
        {
            try
            {
                if (!m_sshCp.Connected)
                {
                    m_sshCp.Connect();
                }

                ArrayList alist = ((Sftp)m_sshCp).GetFileList(path);
                ArrayList returnalist = new ArrayList();
                foreach (var item in alist)
                {
                    if (!((String)item).EndsWith("."))
                    {
                        returnalist.Add(item);
                    }
                }

                return returnalist;
            }
            catch
            {
                return null;
            }
        }
    }
}
