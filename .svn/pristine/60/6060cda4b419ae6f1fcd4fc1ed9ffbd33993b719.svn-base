using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Threading;
using Maticsoft.Model;

namespace Maticsoft.Model
{
    public class SerialPortInfo
    {
        public static object spInfoLockObj = new object();
        private SerialPort sp;//串口
        private Boolean isWaitTicket;//等待分配票(需要从数据库中读取一张票)

        private Dictionary<String, procedure_configuration> proconfigDictionary;//控制流程列表

        private Boolean isDynamicInterval;//是否处于动态间隔内(出完一张票后，需要进入动态间隔时间)

        private Boolean isCanRead;//当前串口是否可读票(如果正在出票则值为false)
        private Boolean isCanWrite;//当前串口是否可读票(如果正在出票则值为false)
        private Boolean isCanCheck;//是否可启动检查(出票，读取票面数据完成后此状态为true)
        private Boolean isCanSendCMD;//是否可发送命令
        private Boolean isWorking;//是否打开了开始出票按钮
        private String orderId;//当前处理的订单号
        private lottery_ticket ticket;//要处理的彩票数据
        private Dictionary<String, String> compeletTicketIdState;//已完成的彩票id和完成结果

        private Boolean isError;//是否有错误
        private String errorCode;//错误代码 
        private String errorState;//错误状态，UNTREATED:未处理；PROCESSED:已处理;
        private String errorMsg;//错误信息描述
        private store_machine macInfo;//出票机器信息

        private Boolean hasMachineInit;//机器是否已经初始化

        private int interruptState;//中断状态
        private Boolean isWaitStop;//等待停止


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="sp">串口</param>
        /// <param name="isAvailable">串口目前是否可用(未打开或是被占用均为“N)</param>
        /// <param name="canNextStep">是否可进行下一步</param>
        /// <param name="macInfo">出票机器信息</param>
        /// <param name="ticket">要处理的彩票数据</param>
        public SerialPortInfo(SerialPort sp, store_machine macInfo)
        {
            this.sp = sp;
            this.IsWorking = false;
            this.isError = false;
            this.macInfo = macInfo;
            this.isCanRead = true;
            this.isCanWrite = false;
            this.orderId = String.Empty;
            this.isWaitTicket = false;
            this.HasMachineInit = false;
            this.isDynamicInterval = false;
            this.IsCanSendCMD = true;
            this.ProconfigDictionary = new Dictionary<string, procedure_configuration>();
            this.CompeletTicketIdState = new Dictionary<string, string>();

            this.InterruptState = 0;
            this.IsWaitStop = false;
        }


        public void refresh() {
            this.IsWorking = false;
            this.isError = false;
            this.isCanRead = true;
            this.isCanWrite = false;
            this.orderId = String.Empty;
            this.Ticket = null;
            this.isWaitTicket = false;
            this.IsDynamicInterval = false;
            this.IsCanSendCMD = true;

            this.InterruptState = 0;
            this.IsWaitStop = false;

            this.CompeletTicketIdState = new Dictionary<string, string>();

            //关闭串口
            if (this.Sp.IsOpen) {
                try
                {
                    this.Sp.Close();
                }
                catch (Exception)
                {
                    this.IsError = true;
                    this.ErrorCode = "100002";
                    this.ErrorState = "UNTREATED";
                    this.ErrorMsg = String.Format("关闭串口{0}失败!",this.Sp.PortName);
                    this.IsCanCheck = true;
                }
            }

        }


        public Boolean IsDynamicInterval{get { return isDynamicInterval; }set { isDynamicInterval = value; }}
        public String OrderId{get { return orderId; }set { orderId = value; }}
        public SerialPort Sp{get { return sp; }set { sp = value; }}
        public Boolean IsError { get { return isError; } set { isError = value; } }
        public String ErrorMsg{get { return errorMsg; }set { errorMsg = value; }}
        public store_machine MacInfo { get { return macInfo; } set { macInfo = value; } }
        public lottery_ticket Ticket{get { return ticket; }set { ticket = value; }}
        public Boolean IsCanRead { get { return isCanRead; } set { isCanRead = value; } }
        public Boolean IsCanWrite { get { return isCanWrite; } set { isCanWrite = value; } }
        public Boolean IsCanCheck { get { return isCanCheck; } set { isCanCheck = value; } }
        public Boolean IsWorking { get { return isWorking; } set { isWorking = value; } }
        public Boolean IsWaitTicket { get { return isWaitTicket; } set { isWaitTicket = value; } }
        public Boolean HasMachineInit { get { return hasMachineInit; } set { hasMachineInit = value; } }
        public String ErrorCode{get { return errorCode; }set { errorCode = value; }}
        public String ErrorState{get { return errorState; }set { errorState = value; }}
        public Dictionary<String, String> CompeletTicketIdState
        {
            get { return compeletTicketIdState; }
            set { compeletTicketIdState = value; }
        }

        public Dictionary<String, procedure_configuration> ProconfigDictionary
        {
            get { return proconfigDictionary; }
            set { proconfigDictionary = value; }
        }
        public Boolean IsCanSendCMD
        {
            get { return isCanSendCMD; }
            set { isCanSendCMD = value; }
        }
        public int InterruptState
        {
            get { return interruptState; }
            set { interruptState = value; }
        }

        public Boolean IsWaitStop
        {
            get { return isWaitStop; }
            set { isWaitStop = value; }
        }
    }
}
