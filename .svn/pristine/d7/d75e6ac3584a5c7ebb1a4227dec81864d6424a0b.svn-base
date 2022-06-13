using Maticsoft.BLL.log;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.demo.pagination;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Demo
{
    public partial class TabFeedback : UserControl
    {
        private bool isChecked = false;
        private Panel plParent = null;
        private readonly FeedbackController feedbackController = new FeedbackController();
        TabFeedBack_Pagination tfpagination = null;

        private Int64 formPendingOrderNum;
        public Int64 FormPendingOrderNum
        {
            get { return formPendingOrderNum; }
            set {
                Int64 i = formPendingOrderNum;
                formPendingOrderNum = value; 
                if (i>0 && value == 0)
                {
                    if (this.tfpagination.getShowPageNO() == this.tfpagination.getMaxPageNo())//当前处理的刚好是最后一页
                    {
                        if (this.tfpagination.PageNo != 0)
                        {
                            this.tfpagination.PageNo--;
                        }                        
                    }
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.tfpagination.initFormDataList));
                }                
            }
        }

        public TabFeedback(Panel panel)
        {
            InitializeComponent();
            plParent = panel;

            //双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                       | ControlStyles.ResizeRedraw
                       | ControlStyles.Selectable
                       | ControlStyles.AllPaintingInWmPaint
                       | ControlStyles.UserPaint
                       | ControlStyles.SupportsTransparentBackColor,
                     true);
            this.feedbackList.showPaging = this.ShowPaging;
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

        private void CYTXLotteryFeedbackTab_Load(object sender, EventArgs e)
        {
            this.moduleTitlebar.remind = "当前位置 > 反馈";
            this.feedbackList.BackColor = Color.White;
            tfpagination = new TabFeedBack_Pagination(0, int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]), this.feedbackList, this.modulePagingNEW);
            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
            {
                ItemFeedback ifb = new ItemFeedback(plParent, this.feedbackList,null,this);
                this.feedbackList.Add(ifb);
            }
            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.tfpagination.initFormDataList),this.picBoxWaiting);

            //自动读取数据库并将数据添加到界面的线程
            //获取反馈订单列表 并添加到界面
            //订单状态为'打印完成' 和 '未添加到界面'
            //ThreadPool.QueueUserWorkItem(new WaitCallback(AutoAddFeedbackItemsOperation));
            
            this.feedbackList.Add(this.modulePagingNEW);
            this.modulePagingNEW.Visible = true;
        }

        //一键反馈
        private void btnFeedback_Click(object sender, EventArgs e)
        {
                int errorNum = 0;
                this.btnFeedbackAll.Enabled = false;
                StringBuilder logsb = new StringBuilder("一键反馈>>>");
                for (int i = (int)int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]) - 1; i >= 0; i--)
                {
                    ItemFeedback item = (ItemFeedback)this.feedbackList.ControlList.Controls[i];
                    if (null != item.LotteryOrder && item.IsChecked)
                    {
                        try
                        {
                            LogUtil.getInstance().addLogDataToQueue("手动反馈订单>>>" + item.LotteryOrder.id, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                            logsb.Append(item.LotteryOrder.id.ToString());
                            if (this.feedbackController.ManualFeedbackSingle(((ItemFeedback)(this.feedbackList.ControlList.Controls[i])).LotteryOrder))
                            {
                                logsb.Append("-成功;");
                                item.LotteryOrder = null;
                            }
                            else
                            {
                                logsb.Append("-失败;");
                                ((ItemFeedback)(this.feedbackList.ControlList.Controls[i])).LotteryOrder.is_feedback = GlobalConstants.FeedbackState.FAILED;
                                ((ItemFeedback)(this.feedbackList.ControlList.Controls[i])).FeedBackResult = GlobalConstants.FeedbackState.FAILED;
                                errorNum++;                                
                            }
                        }
                        catch (Exception ce)
                        {
                            logsb.Append("-异常;");
                            LogUtil.getInstance().addLogDataToQueue("手动反馈订单" + item.LotteryOrder.id + "异常>>>" + ce.Message, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                        }
                    }
                }

                //记录店主操作日志
                LogUtil.getInstance().addLogDataToQueue(logsb.ToString(), GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                if (errorNum >0)
                {
                    MsgBox.getInstance().Show(errorNum + "个订单反馈失败!","提示", MsgBox.MyButtons.OK);
                }
                else
                {
                    MsgBox.getInstance().Show("一键反馈处理成功!", "提示", MsgBox.MyButtons.OK);
                }                
                this.btnFeedbackAll.Enabled = true;
                this.feedbackList.refreshLocation();
        }

        private void checkBox_Click(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (isChecked)
                {
                    this.checkBoxAll.BackgroundImage = global::Demo.Properties.Resources.qxz;
                    for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                    {
                        ItemFeedback fi = (ItemFeedback)this.feedbackList.ControlList.Controls[i];
                        if (null != fi.LotteryOrder)
                        {
                            fi.IsChecked = true;
                        }
                        else
                        {
                            fi.IsChecked = false;
                        }
                    }
                }
                else
                {
                    this.checkBoxAll.BackgroundImage = global::Demo.Properties.Resources.mxz;
                    for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                    {
                        ItemFeedback fi = (ItemFeedback)this.feedbackList.ControlList.Controls[i];
                        fi.IsChecked = false;
                    }
                }
            }
        }

        private void feedbackList_Load(object sender, EventArgs e)
        {

        }

        bool sort = false;
        private void btnSort_Click(object sender, EventArgs e)
        {
            IList<lottery_order> itemFeedbackList1 = new List<lottery_order>();
            IList<lottery_order> itemFeedbackList2 = new List<lottery_order>();

            foreach (var item in this.feedbackList.ControlList.Controls)
            {
                ItemFeedback itemFeedback = null;
                if (item.GetType() == typeof(ItemFeedback))
                {
                    itemFeedback = item as ItemFeedback;
                    if (itemFeedback.LotteryOrder != null)
                    {
                        if (itemFeedback.LotteryOrder.is_feedback == GlobalConstants.FeedbackState.NOT_FEEDBACK)
                        {
                            itemFeedbackList1.Add(itemFeedback.LotteryOrder);
                        }
                        else
                        {
                            itemFeedbackList2.Add(itemFeedback.LotteryOrder);
                        }
                    }
                }
            }

            if (itemFeedbackList1.Count > 0 && itemFeedbackList2.Count > 0)
            {
                if (sort)
                {
                    foreach (lottery_order lo in itemFeedbackList2)
                    {
                        itemFeedbackList1.Add(lo);
                    }

                    for (int i = 0; i < itemFeedbackList1.Count; i++)
                    {
                        ((ItemFeedback)this.feedbackList.ControlList.Controls[i]).LotteryOrder = itemFeedbackList1[i];
                    }
                }
                else
                {
                    foreach (lottery_order lo in itemFeedbackList1)
                    {
                        itemFeedbackList2.Add(lo);
                    }

                    for (int i = 0; i < itemFeedbackList2.Count; i++)
                    {
                        ((ItemFeedback)this.feedbackList.ControlList.Controls[i]).LotteryOrder = itemFeedbackList2[i];
                    }
                }
            }

            sort = !sort;
        }
    }
}
