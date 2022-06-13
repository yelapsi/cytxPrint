using log4net;
using Maticsoft.BLL.log;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common;
using Maticsoft.Common.dbUtility;
using Maticsoft.Common.model.logmodel;
using Maticsoft.Common.Util;
using System;
using System.Reflection;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Demo.exe.config", ConfigFileExtension = "xml", Watch = true)]
namespace Maticsoft.BLL.serviceimpl
{
    public class LogServiceImpl : ILogService
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void addLogDataToQueue(string msg, GlobalConstants.LOGTYPE_ENUM type)
        {
            try
            {
                Global.debugCMDInfoQueue.Enqueue(new LogQueueItem(type, msg));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void logQueueDataHandler()
        {
            try
            {
                while (Global.debugCMDInfoQueue.Count > 0)
                {
                    LogQueueItem lqitem = Global.debugCMDInfoQueue.Dequeue();
                    if (null == lqitem)
                    {
                        break;
                    }
                    switch (lqitem.Logtype)
                    {
                        case GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION:
                            log.Info(lqitem.Msg);//用info级别来表示系统运行
                            break;
                        case GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR:
                            //log.Warn(lqitem.Msg); //用Warn级别来表示店主操作
                            this.insertOwnerOpLog(lqitem.Msg);
                            break;
                        case GlobalConstants.LOGTYPE_ENUM.EXCEOTION:
                            log.Error(lqitem.Msg);//用error级别来表示系统异常
                            break;
                        case GlobalConstants.LOGTYPE_ENUM.TICKET_LOG:
                            log.Fatal(lqitem.Msg);//出票日志
                            break;
                        case GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG:
                            log.Debug(lqitem.Msg);//通讯日志
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 插入店主操作日志
        /// </summary>
        /// <param name="msg"></param>
        private void insertOwnerOpLog(string msg)
        {
            try
            {
                String sql = String.Format("INSERT INTO Log (Date,Message) VALUES ('{0}', '{1}');", DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR1), msg);
                SQLiteHelper.getLogInstance().ExecuteSql(sql);
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue("记录店主操作日志出错!"+e.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }
    }
}
