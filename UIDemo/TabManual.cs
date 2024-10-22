﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Demo.pagination;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.BLL.log;

namespace Demo
{
    public partial class TabManual : UserControl
    {
        private readonly ManualProcessingController manualProcessingController = new ManualProcessingController();
        private ItemManualOrder mOrderItem = null;
        private long allOrderNum = 0, allTicketNum = 0;
        private TabManual_Pagination tmpagination;

        public ItemManualOrder MOrderItem
        {
            get { return mOrderItem; }
            set { 
                mOrderItem = value;
                tmpagination.Lorder = null == mOrderItem?null:mOrderItem.LotteryOrder;
            }
        }
        

        public TabManual()
        {
            InitializeComponent();

            //双缓冲
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                     //  | ControlStyles.ResizeRedraw
                     //  | ControlStyles.Selectable
                     //  | ControlStyles.AllPaintingInWmPaint
                     //  | ControlStyles.UserPaint
                     //  | ControlStyles.SupportsTransparentBackColor,
                     //true);
            this.ticketControlsList.showPaging = this.ShowPaging;
        }

        private void ShowPaging(bool isVisible)
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

        private void CYTXLotteryManualTab_Load(object sender, EventArgs e)
        {
            this.orderItemControlsList.VScrollBar.ScrollButton.BackgroundImage = global::Demo.Properties.Resources.hh;
            this.orderItemControlsList.VScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));

            tmpagination = new TabManual_Pagination(0, int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]), null, this.ticketControlsList,this.modulePagingNEW);

            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
            {
                ItemManualTicket mti = new ItemManualTicket(null);
                mti.BtnOk.Click += new EventHandler(ticketOkClick);
                mti.BtnCancel.Click += new EventHandler(TicketCancelClick);
                this.ticketControlsList.Add(mti);
            }

            Presetting();

            //自动读取数据库并将数据添加到界面的线程
            //获取反馈订单列表 并添加到界面
            //订单状态为'打印完成' 和 '未添加到界面'
            ThreadPool.QueueUserWorkItem(new WaitCallback(AddOrders));

            //初始化分页控件
            this.ticketControlsList.Add(this.modulePagingNEW);
        }

        private void Presetting()
        {
            //调整ticketItemControlsList的滚动条设置
            this.ticketControlsList.VScrollBar.Width = 20;
            this.ticketControlsList.VScrollBar.ScrollButton.Width = this.ticketControlsList.VScrollBar.Width;
            this.ticketControlsList.VScrollBar.ScrollButton.Height = 78;
            this.ticketControlsList.VScrollBar.Location = new System.Drawing.Point(this.ticketControlsList.Size.Width - this.ticketControlsList.VScrollBar.Width, 0);
            this.ticketControlsList.VScrollBar.BackColor = System.Drawing.Color.Transparent;
            this.ticketControlsList.VScrollBar.ScrollButton.BackgroundImage = global::Demo.Properties.Resources.bsh; this.ticketControlsList.VScrollBar.BackgroundImage = global::Demo.Properties.Resources.scrollbarBackgroundimg;

            this.ticketControlsList.Gap = 25;
            this.ticketControlsList.GapX = 20;
        }

        /// <summary>
        /// 加载订单
        /// </summary>
        /// <param name="o"></param>
        private void AddOrders(object o)
        {
            long ticket_num = 0, index = 0;
            IList<lottery_order> loList = manualProcessingController.getAllManualOrders();
            if (null == loList || loList.Count == 0)
            {
                this.totalOrderNum.Text = "0单";
                this.totalTicketNum.Text = "0张";
                return;
            }

            foreach (lottery_order lo in loList)
            {
                ItemManualOrder moi = new ItemManualOrder(lo);
                if (index == 0)
                {
                    this.MOrderItem = moi;
                    index++;
                }

                ticket_num += lo.total_tickets_num;
                moi.Clicked += new System.EventHandler(this.ManualOrderItemClick);
                this.orderItemControlsList.Add(moi);
            }

            this.allOrderNum = loList.Count;
            this.allTicketNum = ticket_num;

            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(delegate(object sender, EventArgs e)
                {
                    refreshTotalInfo();
                }));
            }
            else
            {
                refreshTotalInfo();
            }
            
        }
        

        /// <summary>
        /// 刷新界面上的统计信息
        /// </summary>
        private void refreshTotalInfo()
        {
            this.totalOrderNum.Text = this.allOrderNum + "单";
            this.totalTicketNum.Text = this.allTicketNum + "张";
            if (null == this.MOrderItem)
            {
                this.lbOrderId.Text = "";
                this.lbLicense.Text = "";
                this.lbOrderPrice.Text = "0元";
                this.lbTotalTicketNum.Text = "0张";
                this.txtTotalTicketsNumber.Text = "0%";
                this.lbSured.Text = "";
                this.lbCancel.Text = "";
            }
            else
            {
                this.lbOrderId.Text = this.MOrderItem.LotteryOrder.id.ToString();
                this.lbLicense.Text = SysUtil.licenseNameTranslation(this.MOrderItem.LotteryOrder.license_id.ToString());
                this.lbOrderPrice.Text = this.MOrderItem.LotteryOrder.total_money + "元";
                this.lbTotalTicketNum.Text = this.MOrderItem.LotteryOrder.total_tickets_num + "张";
                this.txtTotalTicketsNumber.Text = (this.MOrderItem.COMPLETE_TICKET_NUM * 100 / this.MOrderItem.LotteryOrder.total_tickets_num).ToString() + "%";
                this.lbSured.Text = this.MOrderItem.LotteryOrder.ticket_num.ToString();
                this.lbCancel.Text = this.MOrderItem.LotteryOrder.canceled_num.ToString();
                if (this.txtTotalTicketsNumber.Text.Length == 2)
                {//保证3位长度
                    this.txtTotalTicketsNumber.Text = " " + this.txtTotalTicketsNumber.Text;
                }
            }
        }
        //确认出票（所有剩下的票）
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (null == this.MOrderItem)
            {
                MsgBox.getInstance().Show("找不到订单!", "提示", MsgBox.MyButtons.OK);
                return;
            }
            try
            {
                if (manualProcessingController.sureCompeletOrder(this.MOrderItem.LotteryOrder.id.ToString()))
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单确认出票成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                    this.allOrderNum--;
                    this.allTicketNum -= this.MOrderItem.LotteryOrder.total_tickets_num;
                    this.orderItemControlsList.RemoveObj(this.MOrderItem);
                    this.MOrderItem = this.orderItemControlsList.ControlList.Controls.Count == 0 ? null : (ItemManualOrder)this.orderItemControlsList.ControlList.Controls[0];
                    refreshTotalInfo();

                    MsgBox.getInstance().Show("整单确认出票成功!", "提示", MsgBox.MyButtons.OK);
                }
                else
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单确认出票失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                    MsgBox.getInstance().Show("整单确认出票失败!", "提示", MsgBox.MyButtons.OK);
                }
            }
            catch (Exception ce)
            {
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单确认出票异常!>>>"+ce.Message, GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单确认出票异常!>>>" + ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
            }
        }

        //确认出票(一张)
        public void ticketOkClick(object sender, EventArgs e)
        {
            Control s = (Control)sender;
            while (s.GetType() != typeof(ItemManualTicket))
            {
                s = s.Parent;
                if (null == s) { MsgBox.getInstance().Show("找不到控件的父容器!", "提示", MsgBox.MyButtons.OK); return; }
            }

            if (null == this.MOrderItem)
            {
                MsgBox.getInstance().Show("找不到订单!", "提示", MsgBox.MyButtons.OK);
                return;
            }

            try
            {
                if (manualProcessingController.sureCompeletTicket(this.MOrderItem.LotteryOrder.id.ToString(), ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString(), ((ItemManualTicket)s).LotteryTicket.bet_price) && this.ticketControlsList.ControlList.Controls.Count > 0)
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() +">"+ ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "确认出票成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                    //票处理成功，计数器加一
                    this.MOrderItem.COMPLETE_TICKET_NUM++;
                    this.MOrderItem.LotteryOrder.ticket_num++;

                    //设置状态图片
                    ((ItemManualTicket)s).PicStatus.BackgroundImage = global::Demo.Properties.Resources.wc;

                    //隐藏出票按钮
                    ((ItemManualTicket)s).BtnOk.Visible = false;
                    ((ItemManualTicket)s).BtnCancel.Visible = false;

                    //显示'已出票'文字描述
                    ((ItemManualTicket)s).LbResult.Visible = true;
                    ((ItemManualTicket)s).LbResult.Text = "已出票";
                    ((ItemManualTicket)s).LbResult.ForeColor = System.Drawing.Color.Green;

                    //全部票处理完
                    if (this.MOrderItem.COMPLETE_TICKET_NUM == this.MOrderItem.LotteryOrder.total_tickets_num)
                    {
                        this.allOrderNum--;
                        this.allTicketNum -= this.MOrderItem.LotteryOrder.total_tickets_num;
                        this.orderItemControlsList.RemoveObj(this.MOrderItem);
                        this.MOrderItem = this.orderItemControlsList.ControlList.Controls.Count == 0 ? null : (ItemManualOrder)this.orderItemControlsList.ControlList.Controls[0];

                        MsgBox.getInstance().Show("订单处理完成!", "提示", MsgBox.MyButtons.OK);
                    }
                }
                else
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "确认出票失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                }
                refreshTotalInfo();
            }
            catch (Exception ce)
            {
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "确认出票异常!"+ce.Message, GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "确认出票异常!" + ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
            }
        }

        //撤票
        private void TicketCancelClick(object sender, EventArgs e)
        {
            Control s = (Control)sender;
            while (s.GetType() != typeof(ItemManualTicket))
            {
                s = s.Parent;
                if (null == s) { MsgBox.getInstance().Show("找不到控件的父容器!", "提示", MsgBox.MyButtons.OK); return; }
            }

            if (null == this.MOrderItem)
            {
                MsgBox.getInstance().Show("找不到订单!", "提示", MsgBox.MyButtons.OK);
                return;
            }

            try
            {
                if (manualProcessingController.cancelTicket(this.MOrderItem.LotteryOrder.id.ToString(), ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString(), ((ItemManualTicket)s).LotteryTicket.bet_price) && this.ticketControlsList.ControlList.Controls.Count > 0)
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString()+ ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString()+"撤票成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                    //票处理成功，计数器加一
                    this.MOrderItem.COMPLETE_TICKET_NUM++;
                    this.MOrderItem.LotteryOrder.canceled_num++;

                    //票处理成功，隐藏按钮
                    //((ItemManualTicket)s).BtnOk.Visible = false;
                    //((ItemManualTicket)s).BtnCancel.Visible = false;

                    //显示'已撤票'文字描述
                    //((ItemManualTicket)s).LbResult.Visible = true;
                    //((ItemManualTicket)s).LbResult.Text = "已撤票";
                    //((ItemManualTicket)s).LbResult.ForeColor = System.Drawing.Color.Red;

                    //((ItemManualTicket)s).PicStatus.BackgroundImage = global::Demo.Properties.Resources.xxx;
                    ((ItemManualTicket)s).LotteryTicket.ticket_state = GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString();
                    ((ItemManualTicket)s).refreshTicketInfoHandler();

                    //全部票处理完
                    if (this.MOrderItem.COMPLETE_TICKET_NUM == this.MOrderItem.LotteryOrder.total_tickets_num)
                    {
                        this.allOrderNum--;
                        this.allTicketNum -= this.MOrderItem.LotteryOrder.total_tickets_num;
                        this.orderItemControlsList.RemoveObj(this.MOrderItem);
                        this.MOrderItem = this.orderItemControlsList.ControlList.Controls.Count == 0 ? null : (ItemManualOrder)this.orderItemControlsList.ControlList.Controls[0];

                        MsgBox.getInstance().Show("订单处理完成!", "提示", MsgBox.MyButtons.OK);
                    }
                }
                else
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "撤票失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                }
                refreshTotalInfo();
            }
            catch (Exception ce)
            {
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "撤票异常!"+ce.Message, GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + ">" + ((ItemManualTicket)s).LotteryTicket.ticket_id.ToString() + "撤票异常!"+ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
            }
        }

        public void ManualOrderItemClick(object sender, EventArgs e)
        {
            this.MOrderItem.Selected = false;
            Control c = (Control)sender;
            while (c.GetType() != typeof(ItemManualOrder))
            {
                c = c.Parent;
                if (null == c) { return; }
            }

            this.MOrderItem = ((ItemManualOrder)c);
            this.MOrderItem.Selected = true;
            refreshTotalInfo();
        }

        /// <summary>
        /// 订单撤单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (null == this.MOrderItem)
            {
                MsgBox.getInstance().Show("找不到订单!", "提示", MsgBox.MyButtons.OK);
                return;
            }
            try
            {
                if (manualProcessingController.cancelOrder(this.MOrderItem.LotteryOrder.id.ToString()))
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString()+ "整单撤单成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                    this.allOrderNum--;
                    this.allTicketNum -= this.MOrderItem.LotteryOrder.total_tickets_num;
                    this.orderItemControlsList.RemoveObj(this.MOrderItem);
                    this.MOrderItem = this.orderItemControlsList.ControlList.Controls.Count == 0 ? null : (ItemManualOrder)this.orderItemControlsList.ControlList.Controls[0];
                    refreshTotalInfo();
                    MsgBox.getInstance().Show("整单撤单成功!", "提示", MsgBox.MyButtons.OK);
                }
                else
                {
                    LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单撤单失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                    MsgBox.getInstance().Show("整单撤单失败!", "提示", MsgBox.MyButtons.OK);
                }
            }
            catch (Exception ce)
            {
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单撤单异常!>>>"+ ce.Message, GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "整单撤单异常!>>>" + ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
            }
        }

        /// <summary>
        /// 订单恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRevert_Click(object sender, EventArgs e)
        {
            if (null == this.MOrderItem)
            {
                MsgBox.getInstance().Show("找不到订单!", "提示", MsgBox.MyButtons.OK);
                return;
            }
            try
            {
                Boolean ishas = false;
                foreach (Dictionary<String,machine_can_print_license> item in Global.MachineCanPrintLicenseDic.Values)
                {
                    foreach (machine_can_print_license license in item.Values)
                    {
                        if (this.MOrderItem.LotteryOrder.license_id == license.license_id)
                        {
                            ishas = true;
                            break;
                        }
                    }
                }
                //如果彩票机出票，不支持出票的采种，直接置为手工处理 如果是打印投注单，则所有彩种都支持
                if (ishas || Maticsoft.BLL.ScanPortImage.SPImageGlobal.IS_PRINT_SCAN_IMAGE)//如果是彩机支持出票的采种
                {
                    if (manualProcessingController.recoveryOrder(this.MOrderItem.LotteryOrder.id.ToString()))
                    {
                        LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "恢复订单成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                        this.allOrderNum--;
                        this.allTicketNum -= this.MOrderItem.LotteryOrder.total_tickets_num;
                        this.orderItemControlsList.RemoveObj(this.MOrderItem);
                        this.MOrderItem = this.orderItemControlsList.ControlList.Controls.Count == 0 ? null : (ItemManualOrder)this.orderItemControlsList.ControlList.Controls[0];
                        refreshTotalInfo();

                        MsgBox.getInstance().Show("恢复订单成功!", "提示", MsgBox.MyButtons.OK);
                    }
                    else
                    {
                        LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "恢复订单失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                        MsgBox.getInstance().Show("恢复订单失败!", "提示", MsgBox.MyButtons.OK);
                    }
                }
                else
                {
                    MsgBox.getInstance().Show("系统管理的彩机不支持改彩种,无法恢复订单!", "提示", MsgBox.MyButtons.OK);
                }
            }
            catch (Exception ce)
            {
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "恢复订单异常!>>>" + ce.Message, GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                LogUtil.getInstance().addLogDataToQueue(this.MOrderItem.LotteryOrder.id.ToString() + "恢复订单异常!>>>" + ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
            }
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.btnCancelOrderEnter;
        }

        private void btnRevert_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.btnRecoverEnter;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.scxz;
        }

        private void btnOk_MouseHover(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.btnOKPrintEnter73X25;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.btnCancelOrder;
        }

        private void btnRevert_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.btnRecover;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.sc;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = global::Demo.Properties.Resources.btnOKPrint73X25;
        }
    }
}
