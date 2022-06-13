using System;
using System.Threading;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common.Util;

namespace Maticsoft.BLL.log
{
    public class LogUtil
    {
        private LogUtil()
        {
        }
        private static LogUtil instance = null;
        public static LogUtil getInstance()
        {
            if (null == LogUtil.instance)
            {
                LogUtil.instance = new LogUtil();
            }
            return LogUtil.instance;
        }

        //日志操作业务对象
        private ILogService ls = new LogServiceImpl();
        private Boolean isInit = false;


        private static Boolean IsSwitchOpen { get; set; }

        /// <summary>
        /// 打开日志记录开关
        /// </summary>
        public static void switchOpen()
        {
            IsSwitchOpen = true;
        }

        /// <summary>
        /// 关闭日志记录开关
        /// </summary>
        public static void switchClise()
        {
            IsSwitchOpen = false;
        }

        public void init()
        {
            if (!isInit)//只能初始化一次
            {
                this.isInit = true;
                ThreadPool.QueueUserWorkItem(new WaitCallback(Tasks));
            }
        }

        private void Tasks(object state)
        {
            while (true)
            {
                try
                {
                    ls.logQueueDataHandler();
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("写日志异常:" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                    Thread.Sleep(100);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        public void addLogDataToQueue(string msg, GlobalConstants.LOGTYPE_ENUM type)
        {
            try
            {
                this.ls.addLogDataToQueue(msg, type);
            }
            catch (Exception)
            {
            }

        }
    }
}
