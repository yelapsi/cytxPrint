using Maticsoft.BLL.cmdResolve;
using Maticsoft.BLL.comparison;
using Maticsoft.BLL.log;
using Maticsoft.BLL.proController;
using Maticsoft.BLL.ScanPortImage;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common;
using Maticsoft.Common.dencrypt;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace Maticsoft.Controller.Scheduler
{
    public class Scheduler
    {
        public static List<Scheduler> SerialInteriorSchedulerList = new List<Scheduler>();//调度器列表，全局公用

        private BaseProController bpc = null;
        private PrintTicketServiceImpl printbll = new PrintTicketServiceImpl();

        private static String lockcomcmdobj = "lockcomcmdobj";
        private static String lockinfoobj = "lockinfoobj";
        private StringBuilder resultCMDSB = new StringBuilder();//串口读取数据存储
        private StringBuilder threadCMDSB = new StringBuilder();//线程处理数据临时存储
        private StringBuilder threadInfoSB = new StringBuilder();//线程处理票花数据临时存储

        public SerialPortInfo SPINFO { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="sp">串口</param>
        /// <param name="isAvailable">串口目前是否可用(未打开或是被占用均为“N)</param>
        /// <param name="canNextStep">是否可进行下一步</param>
        /// <param name="macInfo">出票机器信息</param>
        /// <param name="ticket">要处理的彩票数据</param>
        public Scheduler(SerialPort sp, store_machine macInfo)
        {
            SPINFO = new SerialPortInfo(sp, macInfo);
            bpc = new BaseProController(SPINFO);

            //spinfo.Sp.DataReceived +=Sp_DataReceived;//读取串口数据
            //初始化所有的线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(readTicketScheduler));//读需要出的票的线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(ticketPrintScheduler));//打票线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(readResultCMDScheduler));//处理出票结果命令的线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(opResultCMDScheduler));//处理出票结果命令的线程
            ThreadPool.QueueUserWorkItem(new WaitCallback(opResultInfoScheduler));//处理出票票花结果的线程
        }

        private void readResultCMDScheduler(object state)
        {
            while (true)//出扫描单该线程直接失效
            {
                try
                {
                    if (!SPImageGlobal.IS_PRINT_SCAN_IMAGE)
                    {
                        if (this.SPINFO.Sp.IsOpen)
                        {
                            int combyteslength = this.SPINFO.Sp.BytesToRead;
                            if (combyteslength > 0)
                            {
                                byte[] bytes = new byte[combyteslength];//接收数据缓冲区
                                this.SPINFO.Sp.Read(bytes, 0, bytes.Length);

                                if (this.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT ||
                                    this.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT_RESULT)
                                {
                                    lock (lockcomcmdobj)
                                    {
                                        resultCMDSB.Append(BitConverter.ToString(bytes) + "-");
                                        LogUtil.getInstance().addLogDataToQueue("当前缓冲区命令>>>>>" + resultCMDSB.ToString(), GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("读取串口数据异常>>>>>" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                }
                finally
                {
                    Thread.Sleep(100);
                }

            }
        }

        #region 读票调度

        /// <summary>
        /// 读票调度
        /// </summary>
        private void readTicketScheduler(object obj)
        {
            while (true)
            {
                try
                {
                    if (Global.IS_WORKING && SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL
                             && (SPINFO.INTERRUPT_STATE == GlobalConstants.InterruptState.INTERRUPT_NOT))
                    { //串口可用
                        if (SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET)
                        {
                            //LogUtil.addDataToQueue("可读票，开始读票", LogUtil.runTimeType);
                            //查询当前需要出的票
                            if (!String.IsNullOrEmpty(SPINFO.OrderId))
                            {
                                //读一张票
                                String[] stateList = new String[] {
                             GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString(),
                             GlobalConstants.ORDER_TICKET_STATE.RE_PRINTTING.ToString(),
                             GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString()};
                                SPINFO.Ticket = printbll.getTopOneTicket(SPINFO.OrderId, stateList);
                                if (null != SPINFO.Ticket)
                                {
                                    if (SPINFO.Ticket.order_id > 0)
                                    {
                                        SPINFO.Ticket.bet_code = DESEncrypt.Decrypt(SPINFO.Ticket.bet_code, GlobalConstants.KEY);
                                    }

                                    SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT;
                                    SPINFO.IsGetCMD = false;
                                    SPINFO.IsSendCMD = false;
                                }
                            }
                        }
                    }
                    else if (SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE &&
                       SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET)
                    {
                        SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.INIT;
                    }
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("读票线程异常>>>订单号:" + e.StackTrace.ToString(), GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
                finally
                {
                    //默认时间间隔
                    Thread.Sleep(10);
                }

            }
        }
        #endregion

        #region 出票调度器
        /// <summary>
        /// 出票调度器
        /// </summary>
        /// <param name="obj"></param>
        private void ticketPrintScheduler(object obj)
        {
            while (true)
            {
                if (SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT)
                {
                    //准备好票数据
                    LogUtil.getInstance().addLogDataToQueue("准备出票>>>订单号:" + SPINFO.OrderId + ",票ID:" + SPINFO.Ticket.ticket_id
                        + ",彩种:" + SPINFO.Ticket.license_id + ",玩法:" + SPINFO.Ticket.play_type, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                    List<Bitmap> bmplist = new List<Bitmap>();
                    if (SPImageGlobal.IS_PRINT_SCAN_IMAGE)//出扫描单
                    {
                        //先判断单子是否能出
                        if (ScanPortImageUtil.slipIsSupport(SPINFO.Ticket))
                        {
                            List<lottery_ticket> ltlist = ScanPortImageUtil.splitLotteryTicket(SPINFO.Ticket);
                            for (int i = 1; i <= ltlist.Count; i++)
                            {
                                bmplist.Add(ScanPortImageUtil.creatScanPortImage(ltlist[i - 1], i.ToString() + "/" + ltlist.Count));
                            }
                        }
                        else
                        {
                            //打印出投注内容，方便店主直接手敲
                            bmplist.Add(ScanPortImageUtil.creatScanPortImage02(SPINFO.Ticket));
                        }

                        SPINFO.SLIP_PRINTER.M_STATE = 0;
                        bool issucc = true;
                        String errorcode = String.Empty;
                        foreach (Bitmap item in bmplist)
                        {
                            if (SPINFO.SLIP_PRINTER.M_OBJID == 0)
                            {//打开失败
                                issucc = false;
                                errorcode = GlobalConstants.ERROR_CODE.PRINTER_OPEN_FAILED;
                                break;
                            }
                            else
                            {
                                //检查打印机状态
                                SPINFO.SLIP_PRINTER.M_STATE = SPImageGlobal.CON_QueryStatus(SPINFO.SLIP_PRINTER.M_OBJID);
                                if (SPINFO.SLIP_PRINTER.M_STATE != 0)
                                {
                                    LogUtil.getInstance().addLogDataToQueue("错误打印机状态为:" + SPINFO.SLIP_PRINTER.M_STATE, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                    if (SPINFO.SLIP_PRINTER.M_STATE == 3)
                                    {
                                        issucc = false;
                                        errorcode = GlobalConstants.ERROR_CODE.PRINTER_OPEN_FAILED;
                                        break;
                                    }
                                    else if (SPINFO.SLIP_PRINTER.M_STATE == 1)
                                    {
                                        issucc = false;
                                        errorcode = GlobalConstants.ERROR_CODE.PRINTER_IS_OUT_OF_PAPER;
                                        break;
                                    }
                                    else//其它异常
                                    {
                                        issucc = false;
                                        errorcode = GlobalConstants.ERROR_CODE.PRINTER_CONNECTION_EXCEPTION;
                                        break;
                                    }
                                }
                                else
                                {
                                    item.Save("testprint02.bmp", ImageFormat.Bmp);
                                    int i = SPImageGlobal.CON_PrintFile(SPINFO.SLIP_PRINTER.M_OBJID, "testprint02.bmp");
                                    int ii = SPImageGlobal.ASCII_CtrlCutPaper(SPINFO.SLIP_PRINTER.M_OBJID, 66, 50);
                                    //CON_PrintBMPBuffer(Spinfo.SLIP_PRINTER.M_OBJID, bt.Width, bt.Height, imgData);
                                    int tryCnt = 3;//最多试3次
                                    while (tryCnt > 0)
                                    {
                                        if (SPImageGlobal.CON_PageSend(SPINFO.SLIP_PRINTER.M_OBJID) != 0)
                                        {
                                            LogUtil.getInstance().addLogDataToQueue("第" + (4 - tryCnt) + "次尝试成功!" + SPINFO.SLIP_PRINTER.M_STATE, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                            break;
                                        }
                                        else
                                        {
                                            LogUtil.getInstance().addLogDataToQueue("第" + (4 - tryCnt) + "次尝试失败!" + SPINFO.SLIP_PRINTER.M_STATE, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                        }
                                        tryCnt--;
                                        issucc = tryCnt != 0;
                                    }

                                    //关闭打印机
                                    //SPImageGlobal.CON_CloseDevices(Spinfo.SLIP_PRINTER.M_OBJID);
                                    //Spinfo.SLIP_PRINTER.M_OBJID = 0;

                                    if (!issucc)
                                    {
                                        errorcode = GlobalConstants.ERROR_CODE.PRINTER_WORK_FAILED;
                                        break;
                                    }
                                }
                            }

                            Thread.Sleep(10);
                        }

                        //无返馈出票结果
                        LogUtil.getInstance().addLogDataToQueue("打印投注单" + (issucc ? "成功" : "失败"), GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                        if (issucc)
                        {
                            succOperationMethod("", "打印投注单成功");
                        }
                        else
                        {
                            if (errorcode.Equals(GlobalConstants.ERROR_CODE.PRINTER_WORK_FAILED))
                            {
                                errorOperationMethod(errorcode, errorcode, "打印投注单失败");
                            }
                            else
                            {
                                SPINFO.IsError = true;
                                SPINFO.ErrorCode = errorcode;
                                SPINFO.ErrorMsg = GlobalConstants.ErrorCodeDictionary[SPINFO.ErrorCode];
                                SPINFO.ErrorState = GlobalConstants.ErrorState.UNTREATED;
                                SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK;
                                //记录日志
                                LogUtil.getInstance().addLogDataToQueue(String.Format(SPINFO.ErrorMsg, SPINFO.MacInfo.com_name)
                                    + ">>>>" + errorcode, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            //第一步:如果是有反馈的，打开反馈通道
                            if (this.SPINFO.MacInfo.is_feed_back.ToString().Equals(GlobalConstants.TrueFalseSign.TRUE) &&
                                  (Global.SysDateMillisecond - this.SPINFO.FBDATACHANNELINIT_MILLIS > 15000 ||
                                  this.SPINFO.CONTINUOUS_TICKET_NUM >= 15))
                            {
                                feedbackDataChannelInit();
                                this.SPINFO.CONTINUOUS_TICKET_NUM = 0;
                            }

                            bpc.ticketProcessHandler();
                            this.SPINFO.CompeletTicketIdStateQueue.Enqueue(new KeyValuePair<string, string>(SPINFO.Ticket.ticket_id.ToString(), "100"));//100标识等待结果
                            Global.REVIOUSLT = SPINFO.Ticket;
                            this.SPINFO.CONTINUOUS_TICKET_NUM++;
                        }
                        catch (Exception e)
                        {
                            LogUtil.getInstance().addLogDataToQueue("出票线程异常>>>订单号:" + SPINFO.OrderId + ",票ID:" + SPINFO.Ticket.ticket_id + e.StackTrace.ToString(), GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                        }
                        finally
                        {
                            Int64 dycms = this.dynamicTimeCalculator((int)Global.SLC_DICTIONARY[this.SPINFO.MacInfo.speed_level.ToString()].dynamic_interval_max,
                                    (int)Global.SLC_DICTIONARY[this.SPINFO.MacInfo.speed_level.ToString()].dynamic_interval_min)
                                    + (int)Global.SLC_DICTIONARY[this.SPINFO.MacInfo.speed_level.ToString()].ticket_interval;

                            if (this.SPINFO.MacInfo.is_feed_back == 1)
                            {
                                if (Global.SysDateMillisecond - this.SPINFO.SEND_DATA_MILLIS < dycms)
                                {
                                    //动态时间间隔+票间隔
                                    Thread.Sleep((int)(dycms - (Global.SysDateMillisecond - this.SPINFO.SEND_DATA_MILLIS)));
                                }
                            }
                            else
                            {
                                Thread.Sleep((int)dycms);
                            }
                        }
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }


        /// <summary>
        /// 初始化数据反馈通道
        /// </summary>
        private void feedbackDataChannelInit()
        {
            int count = 0;
            this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.FBDATACHANNELINIT_WAIT;
            try
            {
                byte[] feedbackDataChannelClose = { 0xFF, 0x11, 0xFF, 0x13, 0x4B, 0x01, 0xA2, 0xFF, 0x0D, 0xFF, 0x0A };//关闭反馈通道
                String cmd = CommandProcessor.bytesToHexString(feedbackDataChannelClose);
                bool b = SerialPortUtil.writeData(this.SPINFO.Sp, feedbackDataChannelClose, 11);
                while (count < 10)
                {
                    if (this.SPINFO.SP_COM_STATE != GlobalConstants.COM_STATE.FBDATACHANNELINIT_WAIT)
                    {
                        Thread.Sleep(500); //提示收到数据后，延时0.5s让盒子关闭通道
                        break;
                    }
                    else
                    {
                        count++;
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue(e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.FBDATACHANNELINIT_WAIT;
            try
            {
                byte[] feedbackDataChannelClose = { 0xFF, 0x11, 0xFF, 0x13, 0x4B, 0x01, 0xA4, 0xFF, 0x0D, 0xFF, 0x0A };//关闭反馈通道
                String cmd = CommandProcessor.bytesToHexString(feedbackDataChannelClose);
                bool b = SerialPortUtil.writeData(this.SPINFO.Sp, feedbackDataChannelClose, 11);
                while (count < 20)
                {
                    if (this.SPINFO.SP_COM_STATE != GlobalConstants.COM_STATE.FBDATACHANNELINIT_WAIT)
                    {
                        Thread.Sleep(1000); //提示收到数据后，延时1s让盒子打开通道
                        break;
                    }
                    else
                    {
                        count++;
                        if (count == 19)
                        {
                            this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.FBDATACHANNELINIT_FAIL;
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue(e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /// <summary>
        /// 动态时间计算器
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        private int dynamicTimeCalculator(int max, int min)
        {
            if (max == min)
            {
                return max;
            }

            int diff = max - min;
            Random r = new Random(DateTime.Now.Millisecond);
            return min + r.Next(1000000) % diff;
        }
        #endregion

        #region 处理出票结果调度器
        /// <summary>
        /// 处里回收的命令
        /// </summary>
        /// <param name="state"></param>
        private void opResultCMDScheduler(object state)
        {
            while (true)//出扫描单该线程直接失效
            {
                try
                {
                    if (!SPImageGlobal.IS_PRINT_SCAN_IMAGE)
                    {
                        if (resultCMDSB.Length > 0)
                        {
                            lock (lockcomcmdobj)
                            {
                                threadCMDSB.Append(resultCMDSB.ToString()).Replace(GlobalConstants.BASE_CMD.KEYBOARD_DELAY_ING, "");
                                resultCMDSB.Remove(0, resultCMDSB.Length);
                            }
                        }

                        if (threadCMDSB.Length > 0)
                        {
                            List<String> cmdarray = CommandProcessor.getAllCompeleteCMD(ref threadCMDSB);
                            foreach (String item in cmdarray)
                            {
                                LogUtil.getInstance().addLogDataToQueue("当前命令>>>>>" + item, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                if (item.Contains(GlobalConstants.BASE_CMD.RECEIVE_START_PRINT))//这条命令是打印数据
                                {
                                    //记录取到回馈数据的时间
                                    this.SPINFO.FBDATACHANNELINIT_MILLIS = Global.SysDateMillisecond;
                                    this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.COMMUNICATIONS_NORMAL;
                                    lock (lockinfoobj)
                                    {
                                        threadInfoSB.Append(item.Replace(GlobalConstants.BASE_CMD.RECEIVE_START_PRINT, "").Replace(GlobalConstants.BASE_CMD.CMD_END, "") + "-");//尾巴要加上一个"-"
                                    }
                                }
                                else
                                {
                                    //检查是否包含错误命令
                                    if (item.StartsWith(GlobalConstants.ERROR_CMD.ERROR_CMD_HEAD))
                                    {
                                        //包含错误命令
                                        errorOperationMethod(CmdResovleUtil.errorCmd2ErrorCode(item), "", "");
                                    }//是否包含彩机已发送数据命令(作为继续发送下次数据的依据)
                                    else if (item.Contains(GlobalConstants.BASE_CMD.KEYBOARD_SENDDATA.ToUpper()))
                                    {
                                        if (this.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT)//打开反馈通道
                                        {
                                            if (this.SPINFO.MacInfo.is_feed_back == 1 && this.SPINFO.SP_COM_STATE == GlobalConstants.COM_STATE.FBDATACHANNELINIT_WAIT)//现在需要验证的是数据接收通道
                                            {
                                                this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.FBDATACHANNELINIT_SUCC;
                                                LogUtil.getInstance().addLogDataToQueue("初始化数据通道,已发送键盘数据!", GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                            }
                                        }
                                        else if (this.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT_RESULT)
                                        {
                                            if (!this.SPINFO.IsSendCMD)
                                            {
                                                this.SPINFO.IsSendCMD = true;
                                                LogUtil.getInstance().addLogDataToQueue("已发送键盘数据!", GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                            }
                                            else if (null != this.SPINFO.Ticket && item.Contains(
                                          GlobalConstants.BASE_CMD.KEYBOARD_RECEVICEDATA.ToUpper())
                                           && !this.SPINFO.IsGetCMD)
                                            {
                                                this.SPINFO.IsGetCMD = true;
                                                LogUtil.getInstance().addLogDataToQueue("已接收键盘数据!", GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("解析回馈命令出现了异常!" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                }
                finally
                {
                    Thread.Sleep(100);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void opResultInfoScheduler(object state)
        {
            Int64 count = 1;
            while (true)
            {
                try
                {
                    if (!SPImageGlobal.IS_PRINT_SCAN_IMAGE)//出扫描单该线程直接失效
                    {
                        //1、先看当前有没有正在出的票；2、是否发送错误；3、
                        if (this.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_PRINT_RESULT)
                        {
                            count++;
                            if (this.SPINFO.IsError && this.SPINFO.ErrorCode.Equals(GlobalConstants.ERROR_CODE.SEND_DATA_FAIL))
                            {//发送的时候就已经错误了
                                errorOperationMethod(GlobalConstants.ERROR_CODE.SEND_DATA_FAIL, "", "");
                            }
                            else if (count >= 350)//已经过了45秒还没搞定
                            {
                                if (!this.SPINFO.IsGetCMD && !this.SPINFO.IsSendCMD)
                                {//未接收到键盘数据
                                    if (!this.SPINFO.IsGetCMD)
                                    {//未接收到键盘数据
                                        errorOperationMethod(GlobalConstants.ERROR_CODE.KEYBOARD_NOT_RECEIVED_DATA, "", "");
                                    }
                                    else if (!this.SPINFO.IsSendCMD)
                                    {//键盘未发送数据
                                        errorOperationMethod(GlobalConstants.ERROR_CODE.KEYBOARD_NOT_SEND_DATA, "", "");
                                    }

                                    this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.COMMUNICATION_ABNORMAL;
                                }
                                else
                                {//未收到反馈信息
                                    errorOperationMethod(GlobalConstants.ERROR_CODE.COMPARISON_DATA_FAIL, "", "");
                                }

                                //简单比对失败
                                LogUtil.getInstance().addLogDataToQueue("票花命令为>>>>>" + threadInfoSB.ToString()
                                    , GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                count = 0;
                            }
                            else//发送时是正常的
                            {
                                if (this.SPINFO.MacInfo.is_feed_back == 1)//带反馈的机型
                                {
                                    if (threadInfoSB.Length > 0)
                                    {
                                        String print_data = String.Empty;
                                        String ticketInfo = String.Empty;
                                        String serialPort_Str = String.Empty;

                                        lock (lockinfoobj)
                                        {
                                            serialPort_Str = threadInfoSB.ToString();
                                            threadInfoSB.Remove(0, threadInfoSB.Length);
                                            //取出完整的票花数据
                                            if (CmdResovleUtil.getCompleteTicketData(ref serialPort_Str, ref print_data))
                                            {
                                                count = 0;
                                                //如果已经取到了完整的票花，那么此时还收不到已发送数据的指令也没关系，不需要了
                                                if (!this.SPINFO.IsSendCMD)
                                                {
                                                    this.SPINFO.IsSendCMD = true;
                                                }
                                                LogUtil.getInstance().addLogDataToQueue("取票花数据,有反馈，取到完整票花>>>>>" + print_data, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);

                                                ticketInfo = CmdResovleUtil.CMD2TicketInfo(print_data);
                                                //记录日志
                                                LogUtil.getInstance().addLogDataToQueue("解析票花>>>>" + ticketInfo, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                                String resultStr = String.Empty;

                                                //从解析的票面数据中得到所有要比对的节点的值
                                                if (ComparisonUtil.comparisonFunction(this.SPINFO.Ticket, ticketInfo, out resultStr))
                                                {
                                                    //比对成功
                                                    LogUtil.getInstance().addLogDataToQueue(this.SPINFO.Ticket.order_id + ";" + this.SPINFO.Ticket.ticket_id + ":" + resultStr + "取出出票赔率为:" + this.SPINFO.Ticket.ticket_odds
                                                       , GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                                    succOperationMethod(ticketInfo, "有返馈出票成功");
                                                }
                                                else
                                                {
                                                    //简单比对失败
                                                    LogUtil.getInstance().addLogDataToQueue(this.SPINFO.Ticket.order_id + ";" + this.SPINFO.Ticket.ticket_id + ":" + "比对失败>>>>>" + threadInfoSB.ToString()
                                                        , GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                                    errorOperationMethod(GlobalConstants.ERROR_CODE.COMPARISON_DATA_FAIL, resultStr, ticketInfo);
                                                    print_data = String.Empty;//清空打印数据
                                                }
                                            }//取出完整的票花数据

                                            //回复数据
                                            threadInfoSB.Append(serialPort_Str);
                                        }
                                    }
                                }
                                else//不带反馈机型——只要判断其已发送数据即认为成功
                                {
                                    if (this.SPINFO.IsSendCMD)
                                    {
                                        this.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.COMMUNICATIONS_NORMAL;
                                        //无返馈出票成功
                                        LogUtil.getInstance().addLogDataToQueue("无返馈出票成功", GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                                        succOperationMethod("", "无返馈出票成功");
                                        count = 0;
                                    }
                                }
                            }
                        }
                        else//当前不在打票
                        {
                            count = 0;
                            lock (lockinfoobj)//回复数据
                            {
                                threadInfoSB.Remove(0, threadInfoSB.Length);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("处理票花命令出现了异常!" + e.StackTrace + threadInfoSB.ToString(), GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
                }
                finally
                {
                    Thread.Sleep(100);
                }
            }
        }
        #endregion 处理出票结果调度器

        /// <summary>
        /// 错误时处理方法
        /// </summary>
        private void errorOperationMethod(String errorCode, String exceptionmsg, String ticketInfo)
        {
            try
            {
                //做错漏票处理
                this.SPINFO.Ticket.ticket_state = GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString();
                this.SPINFO.Ticket.ticket_info = ticketInfo;
                this.SPINFO.Ticket.exception_description = exceptionmsg;

                bool r = printbll.ticketResultHandler(this.SPINFO.Ticket);
                //记录该票的出票结果，用着界面展示依据
                this.SPINFO.CompeletTicketIdStateQueue.Enqueue(new KeyValuePair<string, string>(this.SPINFO.Ticket.ticket_id.ToString(), GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()));

                SPINFO.IsError = true;
                SPINFO.ErrorCode = errorCode;
                SPINFO.ErrorMsg = GlobalConstants.ErrorCodeDictionary[SPINFO.ErrorCode];
                SPINFO.ErrorState = GlobalConstants.ErrorState.UNTREATED;

                //记录日志
                LogUtil.getInstance().addLogDataToQueue(String.Format(SPINFO.ErrorMsg, SPINFO.MacInfo.com_name)
                    + ">>>>" + exceptionmsg, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK;
            }
        }

        /// <summary>
        /// 成功时处理方法
        /// </summary>
        /// <param name="ticketResultStr"></param>
        /// <param name="description"></param>
        private void succOperationMethod(String ticketInfo, String ticketResultStr)
        {
            try
            {
                ticketInfo = SysUtil.ticketInfoToDBStr(ticketInfo);
                if (this.SPINFO.Ticket.ticket_state == GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString())
                {
                    this.SPINFO.Ticket.ticket_state = GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString();
                }
                else if (this.SPINFO.Ticket.ticket_state == GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString())
                {
                    this.SPINFO.Ticket.ticket_state = GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString();
                }
                else
                {
                    this.SPINFO.Ticket.ticket_state = GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString();
                }

                this.SPINFO.Ticket.ticket_info = ticketInfo;
                this.SPINFO.Ticket.exception_description = ticketResultStr;

                bool r = printbll.ticketResultHandler(this.SPINFO.Ticket);

                //记录该票的出票结果，用着界面展示依据
                this.SPINFO.CompeletTicketIdStateQueue.Enqueue(new KeyValuePair<string, string>(this.SPINFO.Ticket.ticket_id.ToString(),
                    GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK;
            }
        }
    }
}