﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Demo.pagination;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.Controller.Scheduler;
using Maticsoft.BLL.log;
using System.Media;
using Maticsoft.BLL.ScanPortImage;
using Maticsoft.Common.dbUtility;
//using Maticsoft.BLL.proController;

namespace Demo
{
    public partial class TabPrint : UserControl
    {
        private PrintTicketController printController = new PrintTicketController();
        private RequestTicketController rtcontroller = new RequestTicketController();

        public Scheduler sIScheduler;//调度对象(在支持多彩机版本中,该对象应该在机器Tab中)
        public TabPrint_Pagination tabPagination = null;//分页控件操作对象

        private ItemOrder morderItem;
        public ItemOrder mOrderItem
        {
            get
            {
                return morderItem;
            }
            set
            {
                this.morderItem = value;
                this.tabPagination.IOrder = value;
                refreshTotalInfo();
            }
        }

        public ControlsList TicketItemControlsList
        {
            get { return ticketItemControlsList; }
        }
        public ControlsList OrderItemControlsList
        {
            get { return orderItemControlsList; }
        }
        public TabPrint(Scheduler sischeduler)
        {            
            InitializeComponent();
            this.sIScheduler = sischeduler;

            try
            {
                this.orderItemControlsList.IsItemOrder = true;
                //初始化票区域
                for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                {
                    this.ticketItemControlsList.Add(new ItemTicket(null));
                }


                //初始化分页操作对象
                tabPagination = new TabPrint_Pagination(0, int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]), null, this.ticketItemControlsList, this.modulePagingNEW);

                this.ticketItemControlsList.Gap = 24;
                this.ticketItemControlsList.GapX = 25;
                this.TicketItemControlsList.showPaging = this.ShowPaging;
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("初始化票区域异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        private void ShowPaging(bool isVisible)
        {
            try
            {
                if (this.modulePagingNEW.Visible != isVisible && this.modulePagingNEW.MaxPage > 1)
                {
                    if (this.modulePagingNEW.InvokeRequired)
                    {
                        this.modulePagingNEW.Invoke(new EventHandler(delegate(object o, EventArgs e)
                        {
                            this.modulePagingNEW.Visible = isVisible;
                        }));
                    }
                    else
                    {
                        this.modulePagingNEW.Visible = isVisible;
                    }
                }
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        private void alterPrinting()
        {

        }

        private void TabPrint_Load(object sender, EventArgs e)
        {
            //LocationPanel lp = new LocationPanel();
            //lp.Location = new System.Drawing.Point(500, 40);
            //lp.BringToFront();
            //this.Controls.Add(lp);

            try
            {
                // 一些首页控件的设置 和 首次启动软件需要的订单、票信息
                PreSetting();
                //启动调度线程、检查线程
                ThreadPool.QueueUserWorkItem(new WaitCallback(schedulerThread));
                ThreadPool.QueueUserWorkItem(new WaitCallback(checkScheduler));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("初始化机器信息异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                // 加载订单、票信息的线程
                ThreadPool.QueueUserWorkItem(new WaitCallback(AddToControlList));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("加载订单、票信息线程启动异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                // 订单监控线程
                ThreadPool.QueueUserWorkItem(new WaitCallback(OrdersMonitor));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("订单监控线程启动异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                // 取票线程
                ThreadPool.QueueUserWorkItem(new WaitCallback(RequestRemoteTicketsBussiness));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("取票线程启动异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                // 加载分页控件
                this.TicketItemControlsList.Add(this.modulePagingNEW);
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("加载分页控件异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /* ------ step_1 start ------ */
        private void PreSetting()
        {
            try
            {
                Maticsoft.BLL.ScanPortImage.SPImageGlobal.alterPrinting = new SPImageGlobal.AlterPrinting(delegate()
                {
                    if (Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE].Equals(Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.PRINTER) || Global.SYSTEM_CONFIG_MAP [GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE].Equals(Maticsoft.Common.Util.GlobalConstants.PRINT_TYPE.PRINTER_QRCODE))
                    {
                        this.lbJXTag.Text = "打印机型号：";
                        this.lbJX.Location = new System.Drawing.Point(this.lbJXTag.Location.X + this.lbJXTag.Width, this.lbJXTag.Location.Y);

                        this.lbPortTag.Text = "";
                        this.lbPort.Visible = false;


                        this.label4.Text = "打印机状态：";
                        this.label4.Location = new System.Drawing.Point(179, this.label4.Location.Y);
                        this.label_COM_State.Location = new System.Drawing.Point(this.label4.Location.X + this.label4.Width, this.label4.Location.Y);

                        this.lbJX.Text = this.sIScheduler.SPINFO.SLIP_PRINTER.M_NAME;//打印机名称
                        this.label_COM_State.Text = this.sIScheduler.SPINFO.SLIP_PRINTER.printerState[this.sIScheduler.SPINFO.SLIP_PRINTER.M_STATE].ToString();//打印机状态
                    }
                    else
                    {
                        this.lbJXTag.Text = "机型：";
                        this.lbJX.Location = new System.Drawing.Point(this.lbJXTag.Location.X + this.lbJXTag.Width, this.lbJXTag.Location.Y);
                        this.lbJX.Text = this.sIScheduler.SPINFO.MacInfo.machine_name;

                        this.lbPortTag.Text = "工作端口：";
                        this.lbPort.Visible = true;

                        this.label4.Text = "端口状态：";
                        this.label4.Location = new System.Drawing.Point(233, this.label4.Location.Y);
                        this.label_COM_State.Location = new System.Drawing.Point(this.label4.Location.X + this.label4.Width, this.label4.Location.Y);

                        this.lbPort.Text = this.sIScheduler.SPINFO.MacInfo.com_name;
                        this.label_COM_State.Text = GlobalConstants.COM_STATE_DICTIONARY[this.sIScheduler.SPINFO.SP_COM_STATE];
                    }
                });
                //从保留字段表里查询"IS_PRINT_SCAN_IMAGE"字段
                Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE = Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PRINT_TYPE ].Equals ( GlobalConstants.PRINT_TYPE.PRINTER );

                this.OrderItemControlsList.VScrollBar.ScrollButton.BackgroundImage = global::Demo.Properties.Resources.hh;
                this.OrderItemControlsList.VScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
                //调整ticketItemControlsList的滚动条设置
                this.ticketItemControlsList.VScrollBar.Width = 20;
                this.ticketItemControlsList.VScrollBar.ScrollButton.Width = this.ticketItemControlsList.VScrollBar.Width;
                this.ticketItemControlsList.VScrollBar.ScrollButton.Height = 78;
                this.ticketItemControlsList.VScrollBar.Location = new System.Drawing.Point(this.ticketItemControlsList.Size.Width - this.ticketItemControlsList.VScrollBar.Width, 0);
                this.ticketItemControlsList.VScrollBar.BackColor = System.Drawing.Color.Transparent;
                this.ticketItemControlsList.VScrollBar.ScrollButton.BackgroundImage = global::Demo.Properties.Resources.bsh; this.ticketItemControlsList.VScrollBar.BackgroundImage = global::Demo.Properties.Resources.scrollbarBackgroundimg;
                
                /*
                 * 1、先加载错漏票被停止的订单或是正常被停止的订单
                 * 2、加载错漏票的订单
                 * 3、加载等待出票的订单
                 */
                Queue<lottery_order> queue = printController.getAllCanInPrintFormOrders(out Global.ERROR_TICKET_NUM);
                List<lottery_order> list = new List<lottery_order>();
                if (queue.Count >= 1)
                {
                    int index = 0;
                    foreach (lottery_order lo in queue)
                    {
                        //如果彩票机出票，不支持出票的采种，直接置为手工处理 如果是打印投注单，则所有彩种都支持
                        if (Global.MachineCanPrintLicenseDic[this.sIScheduler.SPINFO.MacInfo.terminal_number].ContainsKey(lo.license_id.ToString()) || Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE)//如果是彩机不支持出票的采种，直接置为手工处理
                        {
                            if (lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()))
                            {
                                this.printController.updateOrderAndTicketState(lo.id.ToString(), GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString(), GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString());
                                lo.bet_state = GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString();
                            }
                            else if (lo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString()))
                            {
                                this.printController.updateOrderAndTicketState(lo.id.ToString(), GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString(), GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString());
                                lo.bet_state = GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString();
                            }
                            ItemOrder oi = new ItemOrder(this, this.refreshTotalInfo);
                            oi.LotteryOrder = lo;
                            if (index == 0)
                            {
                                this.mOrderItem = oi;
                                index++;
                            }
                            list.Add(lo);
                            this.orderItemControlsList.Add(oi);
                        }
                        else
                        {//如果是彩机不支持出票的采种，直接置为手工处理
                            this.printController.orderToManualProcess(lo.id.ToString());
                        }
                    }
                }
                printController.updateIsInPrintForm(list, true);
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

        }
        /* ------ step_1 end ------ */

        /* ------ step_2 start ------ */
        /// <summary>
        /// 加载订单到页面
        /// </summary>
        /// <param name="presetting">是否是第一次打开程序的预加载</param>
        private void AddToControlListMethod(int presetting)
        {
            try
            {
                //查错漏票
                List<lottery_order> listerror = printController.getLotteryOrderListByStateNotInForm2(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString());
                List<lottery_order> list = new List<lottery_order>();

                if (null != listerror && listerror.Count > 0)
                {
                    foreach (lottery_order item in listerror)
                    {
                        //如果彩票机出票，不支持出票的采种，直接置为手工处理;如果是打印投注单，则所有彩种都支持
                        if (Global.MachineCanPrintLicenseDic[this.sIScheduler.SPINFO.MacInfo.terminal_number].ContainsKey(item.license_id.ToString()) || Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE)//如果是彩机不支持出票的采种，直接置为手工处理
                        {
                            list.Add(item);
                        }
                        else
                        {
                            this.printController.orderToManualProcess(item.id.ToString());
                        }
                    }
                }
                if (null != list && list.Count > 0)
                {
                    //如果目前界面上没有错漏票,把界面上正在打印的订单暂停
                    if (Global.ERROR_TICKET_NUM <= 0)
                    {
                        this.sIScheduler.SPINFO.INTERRUPT_STATE = GlobalConstants.InterruptState.INTERRUPT_WAIT_TICKETTHREAD;

                        foreach (ItemOrder oi in this.orderItemControlsList.ControlList.Controls)
                        {
                            if (oi.LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString()))
                            {
                                //修改数据库状态
                                this.printController.updateOrderAndTicketState(oi.LotteryOrder.id.ToString(), oi.LotteryOrder.bet_state, GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString());
                                oi.securityThreadBetState(int.Parse(GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString()));
                                break;//只可能有一个，所以遇到后就可以跳出去了
                            }
                        }
                    }

                    List<Control> oiListTemp = new List<Control>();
                    foreach (lottery_order lo in list)
                    {
                        ItemOrder oi = new ItemOrder(this, this.refreshTotalInfo);
                        oi.LotteryOrder = lo;
                        oiListTemp.Add(oi);
                    }
                    //把加载到界面的订单的is_in_print_form属性改为1（'已经加载到界面'）
                    if (this.orderItemControlsList.ControlList.Controls.Count <= 0)
                    {
                        this.mOrderItem = ((ItemOrder)oiListTemp[0]);
                    }

                    this.orderItemControlsList.InsertRange(Global.ERROR_TICKET_NUM, oiListTemp);
                    printController.updateIsInPrintForm(list, true);

                    //记录错漏票数量,用作下次加载时的起始位置
                    //'监控线程'中,每处理完一条错漏票,就把Global.ERROR_TICKET_NUM减一
                    //点击'删除'按钮,Global.ERROR_TICKET_NUM减一
                    Global.ERROR_TICKET_NUM += oiListTemp.Count;
                }

                //查询lottery_order表的state为AWATTING_PRINT的记录,并且orderId大于上次查询的最大orderId （Retrieve table lottery_order,which state is AWATTING_PRINT and lottery orderId larger than the last time's searching' largest lottery orderId）


                List<lottery_order> listwait = printController.getLotteryOrderListByStateNotInForm(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString()); ;
                List<lottery_order> listn = new List<lottery_order>();
                List<Control> oiListTemp2 = new List<Control>();

                if (null != listwait && listwait.Count > 0)
                {
                    foreach (lottery_order item in listwait)
                    {
                        //如果彩票机出票，不支持出票的采种，直接置为手工处理 如果是打印投注单，则所有彩种都支持
                        if (Global.MachineCanPrintLicenseDic[this.sIScheduler.SPINFO.MacInfo.terminal_number].ContainsKey(item.license_id.ToString()) || Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE)//如果是彩机不支持出票的采种，直接置为手工处理
                        {
                            listn.Add(item);
                            ItemOrder oi = new ItemOrder(this, this.refreshTotalInfo);
                            oi.LotteryOrder = item;
                            oiListTemp2.Add(oi);
                        }
                        else
                        {
                            this.printController.orderToManualProcess(item.id.ToString());
                        }
                    }

                    if (this.orderItemControlsList.ControlList.Controls.Count == 0)
                    {
                        this.mOrderItem = ((ItemOrder)oiListTemp2[0]);
                    }
                    this.orderItemControlsList.AddRange(oiListTemp2);
                    printController.updateIsInPrintForm(listn, true);
                }

                //单式上传订单
                List<lottery_order> listwaitSingle = printController.getLotteryOrderSingleListByStateNotInForm(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString());

                List<lottery_order> listnSingle = new List<lottery_order>();

                if (null != listwaitSingle && listwaitSingle.Count > 0)
                {
                    foreach (lottery_order item in listwaitSingle)
                    {
                        //如果彩票机出票，不支持出票的采种，直接置为手工处理 如果是打印投注单，则所有彩种都支持
                        if (Global.MachineCanPrintLicenseDic[this.sIScheduler.SPINFO.MacInfo.terminal_number].ContainsKey(item.license_id.ToString()) || Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE)//如果是彩机不支持出票的采种，直接置为手工处理
                        {
                            listnSingle.Add(item);
                        }
                        else
                        {
                            this.printController.orderToManualProcessSingle(item.id.ToString());
                        }
                    }
                }

                if (listnSingle.Count > 0)
                {
                    List<Control> oiListTemp = new List<Control>();
                    foreach (lottery_order lo in listnSingle)
                    {
                        ItemOrder oi = new ItemOrder(this, this.refreshTotalInfo);
                        oi.LotteryOrder = lo;
                        oiListTemp.Add(oi);
                    }
                    if (this.orderItemControlsList.ControlList.Controls.Count <= 0)
                    {
                        this.mOrderItem = ((ItemOrder)oiListTemp[0]);
                    }
                    this.orderItemControlsList.AddRange(oiListTemp);
                    printController.updateIsInPrintFormSingle(listnSingle, true);
                }
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        private void AddToControlList(object state)
        {
            while (true)
            {
                try
                {
                    if (!GlobalConstants.SORTING)
                    {
                        AddToControlListMethod(0);
                    }                    
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("加载票线程有错:" + e.StackTrace.ToString(), GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
                finally {
                    Thread.Sleep(1000);
                }
            }
        }

        #region 监控线程
        //监控线程：监控controlList的第一个控件
        private void OrdersMonitor(object state)
        {
            int rount = 0;
            while (true)
            {
                try
                {
                    OrdersMonitorHandler(rount);
                    rount++;
                    rount = rount % 1000;
                    Thread.Sleep(10);
                }
                catch (Exception e)
                {
                    Thread.Sleep(10);
                    LogUtil.getInstance().addLogDataToQueue("监控线程有错:" + e.StackTrace.ToString(), GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
            }
        }

        private void OrdersMonitorHandler(int rount)
        {
            try
            {
                //界面中有"订单"
                if (this.orderItemControlsList.ControlList.Controls.Count > 0)
                {
                    #region 界面上有订单
                    //当前订单(选中的订单)
                    lottery_order dblo = new lottery_order();
                    if (this.mOrderItem.LotteryOrder.IsSingle)
                    {
                        dblo = this.printController.getLotteryOrderSingleById(this.mOrderItem.LotteryOrder.id.ToString());
                    }
                    else
                    {
                        dblo = this.printController.getLotteryOrderById(this.mOrderItem.LotteryOrder.id.ToString());
                    }


                    lottery_order thislo = this.mOrderItem.LotteryOrder;
                    if (dblo.ticket_num + dblo.canceled_num + dblo.errticket_num + dblo.expired_num != this.mOrderItem.COMPLETE_TICKET_NUM)
                    {
                        this.mOrderItem.COMPLETE_TICKET_NUM = dblo.ticket_num + dblo.canceled_num + dblo.errticket_num + dblo.expired_num;
                        thislo.ticket_num = dblo.ticket_num;
                        thislo.canceled_num = dblo.canceled_num;
                        thislo.expired_num = dblo.expired_num;
                        thislo.errticket_num = dblo.errticket_num;
                    }

                    //LogUtil.getInstance().addLogDataToQueue("监控首页>>>>>有订单数据" , GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION);
                    //1、先判断处理票数量是否已经达到订单数量，达到了就读取状态判断后续的处理
                    if (this.mOrderItem.COMPLETE_TICKET_NUM >= thislo.total_tickets_num)
                    {
                        LogUtil.getInstance().addLogDataToQueue("监控首页>>>>>应移除订单:总" + thislo.total_tickets_num
                            + "已出:" + thislo.ticket_num + "撤票:" + thislo.expired_num + "错票:" + thislo.errticket_num, GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION);
                        
                        if (printController.updateIsInPrintForm(new List<lottery_order>() { thislo }, false))
                        {
                            if (thislo.bet_state.ToString().Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()))
                            {
                                //错漏票 从错漏票界面恢复后 再变成错漏票后 Global.ERROR_TICKET_NUM应该减一
                                Global.ERROR_TICKET_NUM--;
                            }

                            //移除订单之前，先保证修改彩票区域的队列为空，因为移除订单之后，这些信息也就不需要处理了
                            this.sIScheduler.SPINFO.CompeletTicketIdStateQueue.Clear();

                            this.orderItemControlsList.RemoveObj(this.mOrderItem);
                            this.mOrderItem = null;//2015-11-10
                            if (this.orderItemControlsList.Count > 0)
                            {
                                //如果是不带反馈的机型，休眠0.5秒
                                if (this.sIScheduler.SPINFO.MacInfo.is_feed_back == 0)
                                {
                                    Thread.Sleep(500);
                                }
                                this.mOrderItem = (ItemOrder)this.orderItemControlsList.ControlList.Controls[0];
                            }
                            else
                            {
                                if ( this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL )
                                {
                                    if ((this.sIScheduler.SPINFO.MacInfo.is_compl_auto_stop.ToString().Equals( GlobalConstants.TrueFalseSign.TRUE)) || this.sIScheduler.SPINFO.MacInfo.is_continuous_ticket.ToString().Equals( GlobalConstants.TrueFalseSign.FALSE))//最后一个订单停止出票||是否连续出票
                                    {
                                        Global.IS_WORKING = false;
                                        this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE;
                                    }
                                }
                            }
                        }
                    }
                    else if ( ( null != this.sIScheduler ) &&  ( this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL ) && Global.IS_WORKING )
                    {
                        if (this.sIScheduler.SPINFO.INTERRUPT_STATE == GlobalConstants.InterruptState.INTERRUPT_NOT)
                        {
                            LogUtil.getInstance().addLogDataToQueue("监控首页>>>>>订单由未出票状态变为出票状态", GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION);
                            //没有中断，正常处理
                            // 界面上的订单就分两种，正在出票和不在出票的
                            // 2.(不在出票的订单) 如果bet_state为等待出票、暂停等待、错漏票(等待出票)、重打票 则相应update为出票中、出票中、错漏票(出票中)、重打票(处理中)
                            if (thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString()) ||
                                thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString()) ||
                                thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString()) ||
                                thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString()) ||
                                thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString()))
                            {
                                //先改数据库，再改本地，否则传给数据库的订单的值会是已经修改过的
                                String newState = "";

                                if (thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString()) ||
                                   thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString()))
                                {
                                    newState = GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString();
                                }
                                else if (thislo.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString()))
                                {
                                    newState = GlobalConstants.ORDER_TICKET_STATE.RE_PRINTTING.ToString();
                                }
                                else
                                {
                                    newState = GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString();
                                }


                                //修改数据库状态
                                this.printController.updateOrderAndTicketState(thislo.id.ToString(), thislo.bet_state, newState);

                                if (null == this.mOrderItem || this.mOrderItem.LotteryOrder.id != thislo.id)
                                {//如果现在界面上显示的不是该订单的信息，那么得重新赋值界面;如果是就不用管了，减少界面刷新的闪烁
                                    this.mOrderItem = (ItemOrder)this.orderItemControlsList.ControlList.Controls[0];
                                    //先保证修改彩票区域的队列为空，因为新加入订单之后，这些信息也就不需要处理了
                                    this.sIScheduler.SPINFO.CompeletTicketIdStateQueue.Clear();
                                }

                                this.mOrderItem.securityThreadBetState(int.Parse(newState));
                            }
                            // 界面上的订单就分两种，正在出票和不在出票的
                            //正在出票的订单不管
                        }
                        else if (this.sIScheduler.SPINFO.INTERRUPT_STATE == GlobalConstants.InterruptState.INTERRUPT_WAIT_ORDERTHREAD)
                        {//中断，处理中断
                            //中断，需要订单线程做订单处理   
                            lottery_order dblo2 = printController.getLotteryOrderById(thislo.id.ToString());

                            if (dblo2.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString()) ||
                               dblo2.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()))
                            {
                                // 5. '等待出票'的错漏票 8,状态改为'出票中'的错漏票 9,并且,若有正在打印的正常票，设为'暂停'状态
                                //先改数据库，再改本地，否则传给数据库的订单的值会是已经修改过的
                                String newState = dblo2.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString()) ?
                                    GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString() : GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString();
                                //修改数据库状态
                                this.printController.updateOrderAndTicketState(thislo.id.ToString(), thislo.bet_state, newState);
                                this.mOrderItem.securityThreadBetState(int.Parse(newState));
                            }
                            //中断处理结束,中断状态置回'0'
                            this.sIScheduler.SPINFO.INTERRUPT_STATE = GlobalConstants.InterruptState.INTERRUPT_NOT;
                        }
                    }
                    else
                    {
                        //有订单，不运行，提示音
                        if (rount == 0 )
                        {
                            try
                            {
                                System.Media.SoundPlayer sp = new SoundPlayer();
                                sp.SoundLocation = Global.AUDIO_FILES_BASEDIR.FullName + Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ORDER ];
                                sp.Play();
                            }
                            catch (Exception)
                            { }
                        }
                    }

                    #endregion 界面上有订单
                }
                else
                {
                    //LogUtil.getInstance().addLogDataToQueue("监控首页>>>>>无订单数据", GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION);
                    #region 界面上没有订单
                    //界面中没有"订单"，即"所有订单完成，自动停止"设为true
                    if ( ( this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL ) && this.sIScheduler.SPINFO.MacInfo.is_compl_auto_stop.ToString().Equals(GlobalConstants.TrueFalseSign.TRUE) )
                    {
                        this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE;
                    }

                    #endregion 界面上没有订单
                }
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        #endregion 监控线程

        /* ------ step_2 end ------ */

        /* ------ step_3 start ------ */
        /// <summary>
        /// 刷新界面上的统计信息
        /// </summary>
        public void refreshTotalInfo()
        {
            try
            {
                this.Invoke(new EventHandler(delegate(object o, EventArgs e)
                {
                    if (null == this.mOrderItem)
                    {
                        this.lbOrderId.Text = "";
                        this.lbLicense.Text = "";
                        this.lbOrderPrice.Text = "0元";
                        this.lbTotalTicketNum.Text = "0张";
                        this.txtPercentage.Text = " 0%";
                        this.progressBar.Value = 0;
                        this.moduleProgressMsg.refreshPosition(0, 0, 0);
                        if (null != this.sIScheduler)
                        {
                            this.sIScheduler.SPINFO.OrderId = String.Empty;
                        }
                    }
                    else
                    {
                        try
                        {
                            this.lbOrderId.Text = this.mOrderItem.LotteryOrder.id.ToString().Replace("-","(上传)");
                            this.lbLicense.Text = SysUtil.licenseNameTranslation(this.mOrderItem.LotteryOrder.license_id.ToString());
                            this.lbOrderPrice.Text = this.mOrderItem.LotteryOrder.total_money + "元";
                            this.lbTotalTicketNum.Text = this.mOrderItem.LotteryOrder.total_tickets_num + "张";
                            this.txtPercentage.Text = (this.mOrderItem.COMPLETE_TICKET_NUM * 100 / this.mOrderItem.LotteryOrder.total_tickets_num).ToString() + "%";

                            if (null != this.sIScheduler)
                            {
                                this.sIScheduler.SPINFO.OrderId = this.mOrderItem.LotteryOrder.id.ToString();
                            }

                            if (this.txtPercentage.Text.Length == 2)
                            {//保证3位长度
                                this.txtPercentage.Text = " " + this.txtPercentage.Text;
                            }
                            this.progressBar.Value = (int)Math.Floor((this.mOrderItem.COMPLETE_TICKET_NUM * 100.00 / this.mOrderItem.LotteryOrder.total_tickets_num));

                            if ( null != this.sIScheduler && this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL )
                            {
                                this.moduleProgressMsg.refreshPosition(1, (int)this.mOrderItem.LotteryOrder.total_tickets_num, (int)this.mOrderItem.COMPLETE_TICKET_NUM);
                            }
                            else
                            {
                                this.moduleProgressMsg.refreshPosition(0, (int)this.mOrderItem.LotteryOrder.total_tickets_num, (int)this.mOrderItem.COMPLETE_TICKET_NUM);
                            }
                        }
                        catch
                        {
                            this.lbOrderId.Text = "";
                            this.lbLicense.Text = "";
                            this.lbOrderPrice.Text = "0元";
                            this.lbTotalTicketNum.Text = "0张";
                            this.txtPercentage.Text = " 0%";
                            this.progressBar.Value = 0;
                            this.moduleProgressMsg.refreshPosition(0, 0, 0);
                            if (null != this.sIScheduler)
                            {
                                this.sIScheduler.SPINFO.OrderId = String.Empty;
                            }
                        }
                    }
                }));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("刷新界面上的统计信息时发生异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /* ------ step_3 end ------ */

        /* ------ step_4 start ------ */
        private void RequestRemoteTicketsBussiness(Object threadParameters)
        {
            bool isEndOfOrder = true;
            while (true)
            {
                try
                {
                    rtcontroller.requestTickets(ref isEndOfOrder);
                }
                catch (Exception ce)
                {
                    LogUtil.getInstance().addLogDataToQueue("取票线程出现异常!---" + ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
                if (isEndOfOrder)
                {
                    Thread.Sleep(5000);
                }
            }
        }
        /* ------ step_4 end ------ */
        /* ------ step_5 start ------ */

        /* ------ step_5 end ------ */
        #region 开始出票按钮
        //开始出票按钮
        private void startTicketbtn_Click(object sender, EventArgs e)
        {
            //按钮都不让点击，然后设置状态为等待打开串口。线程等待串口调度线程的处理结果
            this.Invoke ( new EventHandler ( delegate ( object o, EventArgs e1 )
            {
                this.startTicketBtn.BackgroundImage = global::Demo.Properties.Resources.kshui;
                this.startTicketBtn.Enabled = false;
                this.stopTicketBtn.BackgroundImage = global::Demo.Properties.Resources.tt;
                this.stopTicketBtn.Enabled = true;
            } ) );

            //订单对象不可点击
            foreach ( ItemOrder item in this.orderItemControlsList.ControlList.Controls )
            {
                item.fordidClick ( );
            }
            if ( this.OrderItemControlsList.ControlList.Controls.Count > 0 )
            {//点击开始出票时，界面有订单
                this.mOrderItem = ( ItemOrder ) this.OrderItemControlsList.ControlList.Controls [ 0 ];
            }

            Global.IS_WORKING = true;

            this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_OPEN;
            LogUtil.getInstance().addLogDataToQueue("点击了开始出票按钮!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
        }      

        #endregion 开始出票按钮

        #region 停止出票按钮
        //停止出票按钮
        private void stopTicketBtn_Click(object sender, EventArgs e)
        {
            //按钮都不让点击，然后设置状态为等待关闭串口。线程等待串口调度线程的处理结果
            this.Invoke ( new EventHandler ( delegate ( object o, EventArgs e1 )
            {
                this.stopTicketBtn.BackgroundImage = global::Demo.Properties.Resources.tz;
                this.stopTicketBtn.Enabled = false;
            } ) );

            Global.IS_WORKING = false;
            this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE;
            LogUtil.getInstance().addLogDataToQueue("点击了停止出票按钮!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
        }
        #endregion 停止出票按钮

        #region 调度线程
        private void schedulerThread(object obj)
        {
            if ( SPImageGlobal.IS_PRINT_SCAN_IMAGE )//只要是系统启动，就打开日志记录
            {
                SPImageGlobal.CON_StartRecord ( "./PrintLOG/" + DateUtil.getServerDateTime ( DateUtil.DATE_FMT_STR3 ) + "-log.txt" );
            }

            while (true)
            {
                    try
                    {
                        #region 刷新界面上的显示信息
                        //保证修改后实时体现
                        this.Invoke ( new EventHandler ( delegate ( object o, EventArgs e )
                        {
                            this.label_workWay.Text = this.sIScheduler.SPINFO.MacInfo.is_continuous_ticket.ToString().Equals(
                                GlobalConstants.TrueFalseSign.TRUE) ?
                                ( "连续出票" + ( this.sIScheduler.SPINFO.MacInfo.is_compl_auto_stop.ToString().Equals(
                                GlobalConstants.TrueFalseSign.TRUE) ? "，无订单时停止出票。" : "。" ) ) : "单订单出票。";
                            if ( Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE )
                            {
                                this.lbJX.Text = this.sIScheduler.SPINFO.SLIP_PRINTER.M_NAME;//打印机名称
                                this.label_COM_State.Text = this.sIScheduler.SPINFO.SLIP_PRINTER.printerState [ this.sIScheduler.SPINFO.SLIP_PRINTER.M_STATE ].ToString ( );//打印机状态
                                this.sIScheduler.SPINFO.SLIP_PRINTER.M_NAME = 
                                    GlobalConstants.PRINTER_MODEL_MAP [ Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PRINTER_MODEL ] ];
                            }
                            else
                            {
                                this.lbPort.Text = this.sIScheduler.SPINFO.MacInfo.com_name;
                                this.label_COM_State.Text = GlobalConstants.COM_STATE_DICTIONARY [ this.sIScheduler.SPINFO.SP_COM_STATE ];
                            }
                        } ) );

                        #endregion 刷新界面上的显示信息

                        /*1、如果是打印机，那么直接使用长连接即可——无论什么时候都保证连接状态
                         *2、如果是彩票机，也可保证长连接——只是在重打和键盘测试的时候直接使用已经连接的对象(保证在没有点击开始按钮的时候使用)
                         */
                        if ( SPImageGlobal.IS_PRINT_SCAN_IMAGE  )//出扫描单
                        {
                            //检查打印机状态
                            if ( this.sIScheduler.SPINFO.SLIP_PRINTER.M_OBJID == 0 || this.sIScheduler.SPINFO.SLIP_PRINTER.M_STATE == 3)
                            {
                                //打开打印机
                                this.sIScheduler.SPINFO.SLIP_PRINTER.M_OBJID =
                                        SPImageGlobal.CON_ConnectDevices ( this.sIScheduler.SPINFO.SLIP_PRINTER.M_NAME,
                                        this.sIScheduler.SPINFO.SLIP_PRINTER.M_CONNECTION_WAY, 1000 );

                                if ( this.sIScheduler.SPINFO.SLIP_PRINTER.M_OBJID != 0 )
                                {
                                    this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL;
                                    this.sIScheduler.SPINFO.SLIP_PRINTER.M_STATE = 
                                        SPImageGlobal.CON_QueryStatus ( this.sIScheduler.SPINFO.SLIP_PRINTER.M_OBJID );

                                    LogUtil.getInstance ( ).addLogDataToQueue ( "尝试打开打印机成功!" + this.sIScheduler.SPINFO.SLIP_PRINTER.M_STATE, 
                                        GlobalConstants.LOGTYPE_ENUM.TICKET_LOG );
                                }
                                else
                                {
                                    LogUtil.getInstance ( ).addLogDataToQueue ("次尝试打开打印机失败!" + 
                                        this.sIScheduler.SPINFO.SLIP_PRINTER.M_STATE, GlobalConstants.LOGTYPE_ENUM.TICKET_LOG );
                                }
                            }
                            else//如果现在打印机已经是连接的，那么判断调度器的状态
                            {
                                if ( this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_OPEN )
                                {
                                    this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL;
                                }
                            }
                        }
                        else//彩票机
                        {
                            try
                            {
                                if ( !this.sIScheduler.SPINFO.Sp.IsOpen )
                                {
                                    //每次打开时重新赋值，有可能在设置中修改过对应的值了
                                    this.sIScheduler.SPINFO.Sp.BaudRate = ( int ) this.sIScheduler.SPINFO.MacInfo.com_baudrate;
                                    this.sIScheduler.SPINFO.Sp.PortName = this.sIScheduler.SPINFO.MacInfo.com_name;
                                    this.sIScheduler.SPINFO.Sp.DataBits = ( int ) this.sIScheduler.SPINFO.MacInfo.com_databits;
                                    this.sIScheduler.SPINFO.Sp.StopBits = GlobalConstants.StopBitsDic [ this.sIScheduler.SPINFO.MacInfo.com_stopbits ];
                                    this.sIScheduler.SPINFO.Sp.Parity = GlobalConstants.ParityDic [ this.sIScheduler.SPINFO.MacInfo.com_parity ];

                                    this.sIScheduler.SPINFO.Sp.Open ( );
                                    if ( this.sIScheduler.SPINFO.Sp.IsOpen )//打开成功了
                                    {
                                        //初始化彩机//1、初始化数字间隔
                                        initMachine ( this.sIScheduler );
                                        this.sIScheduler.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.OPEN_SUCC;
                                    }
                                    else
                                    {
                                        this.sIScheduler.SPINFO.SP_COM_STATE = GlobalConstants.COM_STATE.OPEN_FAIL;
                                    }                                    
                                }
                                else//如果现在彩票机已经是连接的，那么判断调度器的状态
                                {
                                    if ( this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_OPEN )
                                    {
                                        this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.NORMAL;
                                    }
                                }
                            }
                            catch ( Exception e)
                            {                                
                                LogUtil.getInstance ( ).addLogDataToQueue ( e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION );
                            }
                        }
                    }
                    catch ( Exception)
                    { }
                    finally
                    {
                        Thread.Sleep ( 1000 );
                    }
            }
        }

        /// <summary>
        /// 初始化彩机
        /// </summary>
        /// <param name="s"></param>
        private void initMachine(Scheduler s)
        {
            try
            {
                bool result = true;
                if (Global.SLC_DICTIONARY.ContainsKey(s.SPINFO.MacInfo.speed_level.ToString()))
                {
                    byte[] sendcmdF0 = new byte[256], sendcmdF1 = new byte[256];
                    int sendcmdlength = 0;
                    String Intervals = Global.SLC_DICTIONARY[s.SPINFO.MacInfo.speed_level.ToString()].digital_interval.ToString("X2");

                    byte[] startCommandF0 = CommandProcessor.HexDataToCommand(new String[] { "F0", Intervals });
                    Array.Copy(startCommandF0, 0, sendcmdF0, sendcmdlength, startCommandF0.Length);

                    sendcmdlength += 2;
                    sendcmdF0 = CommandProcessor.packCommand(sendcmdF0, GlobalConstants.cmdSign_KV[GlobalConstants.BASE_CMD.KEYBOARD], sendcmdlength);

                    String cmd = CommandProcessor.bytesToHexString(sendcmdF0);
                    result = SerialPortUtil.writeData(s.SPINFO.Sp, sendcmdF0, sendcmdlength + 10);
                    if (result)
                    {
                        sendcmdlength = 0;
                        byte[] startCommandF1 = CommandProcessor.HexDataToCommand(new String[] { "F1", "200"});
                        Array.Copy(startCommandF1, 0, sendcmdF1, sendcmdlength, startCommandF1.Length);

                        sendcmdlength += 2;
                        sendcmdF1 = CommandProcessor.packCommand(sendcmdF1, GlobalConstants.cmdSign_KV[GlobalConstants.BASE_CMD.KEYBOARD], sendcmdlength);
                        cmd = CommandProcessor.bytesToHexString(sendcmdF1);
                        result = SerialPortUtil.writeData(s.SPINFO.Sp, sendcmdF1, sendcmdlength + 10);
                    }
                }
                else
                {
                    result = false;
                }

                if (!result)
                {//初始化系统失败
                    s.SPINFO.IsError = true;
                    s.SPINFO.ErrorCode = GlobalConstants.ERROR_CODE.DIGITALINTERVAL_INIT_FAIL;
                    s.SPINFO.ErrorState = GlobalConstants.ErrorState.UNTREATED;
                    s.SPINFO.ErrorMsg = String.Format(GlobalConstants.ErrorCodeDictionary[s.SPINFO.ErrorCode], s.SPINFO.Sp.PortName);
                    s.SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK; ;
                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue(e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }
        #endregion

        #region 检查线程
        /// <summary>
        /// 检查调度器
        /// </summary>
        private void checkScheduler(object state)
        {
            while (true)
            {
                try
                {
                    if ( Global.IS_WORKING )//点击了开始出票
                    {
                        if ( SPImageGlobal.IS_PRINT_SCAN_IMAGE )//打印机
                        {
                            switch ( this.sIScheduler.SPINFO.PRINT_STATE )
                            {
                                case GlobalConstants.PRINT_STATE_ENUM.INIT:
                                    this.sIScheduler.SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET;
                                    break;
                                case GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK://暂时不做错误处理，直接出票
                                    this.sIScheduler.SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET;
                                    break;
                                default://
                                    break;
                            }
                        }
                        else//彩票机
                        {
                            switch ( this.sIScheduler.SPINFO.PRINT_STATE )
                            {
                                case GlobalConstants.PRINT_STATE_ENUM.INIT:
                                    this.sIScheduler.SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET;
                                    break;
                                case GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK://暂时不做错误处理，直接出票
                                    this.sIScheduler.SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET;
                                    break;
                                default://
                                    break;
                            }
                        }                        
                    }
                    else//点击了停止出票
                    {
                        if ( this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE )//只关注等待停止的
                        {
                            //1、如果有错误，先处理错误
                            if ( this.sIScheduler.SPINFO.IsError && this.sIScheduler.SPINFO.ErrorState.Equals ( GlobalConstants.ErrorState.UNTREATED ) )
                            {//有错，需要处理错误
                                errorHandler ( this.sIScheduler.SPINFO.ErrorCode );
                                this.sIScheduler.SPINFO.IsError = false;
                                this.sIScheduler.SPINFO.ErrorState = GlobalConstants.ErrorState.PROCESSED;
                            }

                            //如果有等待停止标识，那么做停止处理
                            if ( ( this.sIScheduler.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.INIT
                                 || this.sIScheduler.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET
                                 || this.sIScheduler.SPINFO.PRINT_STATE == GlobalConstants.PRINT_STATE_ENUM.WAIT_CHECK) //只有在这两个状态下才能做停止操作
                                && this.sIScheduler.SPINFO.CompeletTicketIdStateQueue.Count == 0 )
                            {
                                //说明首页更新状态也完成了
                                this.sIScheduler.SPINFO.refresh ( );
                                this.updatePauseItem ( );

                                foreach ( ItemOrder item in this.orderItemControlsList.ControlList.Controls )
                                {
                                    item.allowClick ( );
                                }

                                this.Invoke ( new EventHandler ( delegate ( object o, EventArgs e )
                                {
                                    this.startTicketBtn.BackgroundImage = global::Demo.Properties.Resources.ks;
                                    this.startTicketBtn.Enabled = true;
                                    this.stopTicketBtn.BackgroundImage = global::Demo.Properties.Resources.tz;
                                    this.stopTicketBtn.Enabled = false;
                                } ) );                    
                            }

                            if ( this.sIScheduler.SPINFO.INTERRUPT_STATE ==
                                       GlobalConstants.InterruptState.INTERRUPT_WAIT_TICKETTHREAD
                                && this.sIScheduler.SPINFO.CompeletTicketIdStateQueue.Count == 0 )
                            {
                                this.sIScheduler.SPINFO.INTERRUPT_STATE =
                                    GlobalConstants.InterruptState.INTERRUPT_WAIT_ORDERTHREAD;
                            }
                        }                          
                    }
                }
                catch (Exception e)
                {
                    Thread.Sleep(10);
                    LogUtil.getInstance().addLogDataToQueue("检查线程异常!" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }

            }
        }

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="errorCode"></param>
        private void errorHandler(String errorCode)
        {
            try
            {
                //如果是对比失败,则需要判断系统的设置是什么，然后处理
                if (this.sIScheduler.SPINFO.ErrorCode.Equals(GlobalConstants.ERROR_CODE.PARSER_LOAD_FAIL) ||
                    this.sIScheduler.SPINFO.ErrorCode.Equals(GlobalConstants.ERROR_CODE.FEEDBACK_DATA_INCOMPLETE) ||
                    this.sIScheduler.SPINFO.ErrorCode.Equals(GlobalConstants.ERROR_CODE.ANALYTICAL_DATA_ANOMALIES) ||
                    this.sIScheduler.SPINFO.ErrorCode.Equals(GlobalConstants.ERROR_CODE.COMPARISON_DATA_FAIL))
                {
                    //Global.errorhandlist[0].handle_code
                    //如果现在已经点击了出票按钮，则不再继续读票
                    this.sIScheduler.SPINFO.PRINT_STATE = this.sIScheduler.SPINFO.SCHEDULER_STATE == SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE ?
                        GlobalConstants.PRINT_STATE_ENUM.INIT : GlobalConstants.PRINT_STATE_ENUM.WAIT_TICKET;
                }
                else
                {
                    //其他错误都要停止出票，因为打票机有问题，继续出票依然会出不来
                    this.sIScheduler.SPINFO.SCHEDULER_STATE = SerialPortInfo.SCHEDULER_STATE_ENUM.WAIT_CLOSE;
                    this.sIScheduler.SPINFO.PRINT_STATE = GlobalConstants.PRINT_STATE_ENUM.INIT;
                    MsgBox.getInstance().Show(String.Format(GlobalConstants.ErrorCodeDictionary[errorCode], this.sIScheduler.SPINFO.MacInfo.com_name), "错误", MsgBox.MyButtons.OK);
                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue(e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        #endregion 检查线程

        /// <summary>
        /// 暂停出票，修改正在打印的ItemOrder状态（3变为4,9变为16）
        /// </summary>
        private void updatePauseItem()
        {
            try
            {
                if (this.OrderItemControlsList.ControlList.Controls.Count != 0)
                {
                    if (((ItemOrder)this.OrderItemControlsList.ControlList.Controls[0]).LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()))
                    {
                        this.printController.updateOrderAndTicketState(((ItemOrder)this.OrderItemControlsList.ControlList.Controls[0]).LotteryOrder.id.ToString(), GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString(), GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString());
                        ((ItemOrder)this.OrderItemControlsList.ControlList.Controls[0]).securityThreadBetState(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE);
                    }
                    else if (((ItemOrder)this.OrderItemControlsList.ControlList.Controls[0]).LotteryOrder.bet_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString()))
                    {
                        this.printController.updateOrderAndTicketState(((ItemOrder)this.OrderItemControlsList.ControlList.Controls[0]).LotteryOrder.id.ToString(), GlobalConstants.ORDER_TICKET_STATE.PRINTTING.ToString(), GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString());
                        ((ItemOrder)this.OrderItemControlsList.ControlList.Controls[0]).securityThreadBetState(GlobalConstants.ORDER_TICKET_STATE.PAUSE);
                    }

                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue(e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

        }

        /// <summary>
        /// 票数排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortByTicketNum_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalConstants.SORTING = true;
                this.btnSortByTicketNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(172)))), ((int)(((byte)(82)))));
                this.btnSortByTicketNum.ForeColor = System.Drawing.Color.White;
                this.btnSortByTime.BackColor = System.Drawing.Color.White;
                this.btnSortByTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
                RemoveAwaitingTickets();
                Sort(0);
                GlobalConstants.SORTING = false;
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /// <summary>
        /// 按时间排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSortByTime_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalConstants.SORTING = true;
                this.btnSortByTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(172)))), ((int)(((byte)(82)))));
                this.btnSortByTime.ForeColor = System.Drawing.Color.White;
                this.btnSortByTicketNum.BackColor = System.Drawing.Color.White;
                this.btnSortByTicketNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
                RemoveAwaitingTickets();
                Sort(1);
                GlobalConstants.SORTING = false;
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /// <summary>
        /// 移除界面中所有等待出票的ItemOrder
        /// </summary>
        private void RemoveAwaitingTickets()
        {
            try
            {
                int len = this.OrderItemControlsList.ControlList.Controls.Count;
                if (len <= 0)
                {
                    return;
                }

                for (int i = len - 1; i >= 0; i--)
                {
                    ItemOrder oi = this.OrderItemControlsList.ControlList.Controls[i] as ItemOrder;
                    if (oi.LotteryOrder.bet_state == GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString())
                    {
                        this.OrderItemControlsList.RemoveObj(oi);
                    }
                }
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sortBy">排序条件</param>
        public void Sort(int sortBy)
        {
            try
            {
                IList<lottery_order> list = new List<lottery_order>();

                list = printController.getLotteryOrderListForSort(sortBy);

                if (list.Count > 0)
                {
                    IList<Control> oiListTemp = new List<Control>();
                    foreach (lottery_order lo in list)
                    {
                        ItemOrder oi = new ItemOrder(this, this.refreshTotalInfo);
                        oi.LotteryOrder = lo;
                        this.orderItemControlsList.Add(oi);
                    }
                    printController.updateIsInPrintForm((List<lottery_order>)list, true);
                }
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        private void FreshTheOrderOfItemsInControlsList(ItemOrder c)
        {
            try
            {
                //找链表头部
                while (c.Previous != null)
                {
                    c = c.Previous;
                }

                int i = 0;
                while (c != null)
                {
                    this.OrderItemControlsList.ControlList.Controls.SetChildIndex(c, i++);
                    string str = c.LotteryOrder.id.ToString();
                    c = c.Next;
                }
            }
            catch (Exception e1)
            {
                
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //LocationPanel lp = new LocationPanel();
            //lp.Location = new System.Drawing.Point(500,40);
            //lp.BringToFront();
            //this.Controls.Add(lp);
        }
    }
}