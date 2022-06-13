using System;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.BLL.log;
using System.Drawing;

namespace Demo
{
    public partial class ItemFeedback : UserControl
    {
        private Panel plParent = null;
        //父容器的FeedbackController
        FeedbackController feedbackController = new FeedbackController();

        /// <summary>
        /// 父控件中的滚动条控件
        /// </summary>
        private ControlsList parentclist;
        public ControlsList Parentclist
        {
            get { return parentclist; }
            set { parentclist = value; }
        }

        private lottery_order _lotteryOrder;
        public lottery_order LotteryOrder
        {
            get { return _lotteryOrder; }
            set
            {
                //这样写主要是要先处理订单再刷新界面
                if (null == _lotteryOrder && null != value)
                {
                    _lotteryOrder = value;
                    setLottery();
                    this.ParentCnotrol.FormPendingOrderNum++;
                }
                else if (null != _lotteryOrder && null == value)
                {
                    _lotteryOrder = value;
                    setLottery();
                    this.ParentCnotrol.FormPendingOrderNum--;
                }
                else
                {
                    _lotteryOrder = value;
                    setLottery();
                }
            }
        }

        public PictureBox CheckBox
        {
            get { return this.checkBox; }
        }
        public PictureBox PicLicense
        {
            get { return this.picLicense; }
        }
        public Label LbLicense
        {
            get { return this.lbLicense; }
        }
        public Label LbOrderPrice
        {
            get { return this.lbOrderPrice; }
        }
        public Label LbPrintedTicketsPrice
        {
            get { return this.lbPrintedTicketsPrice; }
        }
        public Label LbTotalTicketNum
        {
            get { return this.lbTotalTicketNum; }
        }
        public Label LbPrintedTicketsNum
        {
            get { return this.lbPrintedTicketsNum; }
        }
        public Label LbCompleteTime
        {
            get { return this.lbCompleteTime; }
        }

        public ItemFeedback()
        {
            InitializeComponent();
        }

        public ItemFeedback(Panel panel, ControlsList cl, lottery_order lo, TabFeedback parent)
            : this()
        {
            this.plParent = panel;
            this.Parentclist = cl;
            this.LotteryOrder = lo;

            this.ParentCnotrol = parent;
        }
        private void btnFeedback_Click(object sender, EventArgs e)
        {
            //反馈
            if (null != this.LotteryOrder)
            {

                //1、如果是等待反馈则反馈;2、如果是反馈错误则直接改为反馈失败已处理即可
                if (feedBackResult == GlobalConstants.FeedbackState.NOT_FEEDBACK)
                {
                    try
                    {
                        LogUtil.getInstance().addLogDataToQueue("手动反馈订单>>>" + this.LotteryOrder.id, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                        if (this.feedbackController.ManualFeedbackSingle(this.LotteryOrder))
                        {
                            LogUtil.getInstance().addLogDataToQueue("手动反馈订单>>>" + this.LotteryOrder.id + "成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                            this.LotteryOrder = null;
                            Parentclist.refreshLocation();
                            MsgBox.getInstance().Show("订单反馈成功!", "提示", MsgBox.MyButtons.OK);
                        }
                        else
                        {
                            LogUtil.getInstance().addLogDataToQueue("手动反馈订单>>>" + this.LotteryOrder.id + "失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                            this.LotteryOrder.is_feedback = GlobalConstants.FeedbackState.FAILED;
                            this.FeedBackResult = GlobalConstants.FeedbackState.FAILED;
                            MsgBox.getInstance().Show("订单反馈时出错!", "提示", MsgBox.MyButtons.OK);
                        }
                    }
                    catch (Exception ce)
                    {
                        LogUtil.getInstance().addLogDataToQueue("手动反馈订单>>>" + this.LotteryOrder.id + "异常!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                        MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
                    }

                }
                else
                {
                    try
                    {
                        MsgBox.MsgDialogResult result = MsgBox.getInstance().Show("是否确定该订单已在店主后台处理完成?", "提示", MsgBox.MyButtons.OKCancel);
                        if (result == MsgBox.MsgDialogResult.OK)
                        {
                            if (this.feedbackController.updateOrderAndTicketStateFeedback(this.LotteryOrder.id.ToString(), GlobalConstants.FeedbackState.FAILED_PROCESSED))
                            {
                                LogUtil.getInstance().addLogDataToQueue("确认订单" + this.LotteryOrder.id + "后台处理,成功!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                                this.LotteryOrder = null;
                                Parentclist.refreshLocation();
                                MsgBox.getInstance().Show("订单确认处理成功!", "提示", MsgBox.MyButtons.OK);
                            }
                            else
                            {
                                LogUtil.getInstance().addLogDataToQueue("确认订单" + this.LotteryOrder.id + "后台处理,失败!", GlobalConstants.LOGTYPE_ENUM.OWNER_OPERATOR);
                                MsgBox.getInstance().Show("订单确认处理时出错!", "提示", MsgBox.MyButtons.OK);
                            }
                        }
                    }
                    catch (Exception ce)
                    {
                        LogUtil.getInstance().addLogDataToQueue("确认订单" + this.LotteryOrder.id + "后台处理,异常!" + ce.Message, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                        MsgBox.getInstance().Show(ce.Message, "提示", MsgBox.MyButtons.OK);
                    }
                }

            }
        }

        private void setLottery()
        {
            if (null != this.LotteryOrder)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate (object o, EventArgs e)
                    {
                        setLotteryOrderHandler();
                    }));
                }
                else
                {
                    setLotteryOrderHandler();
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate (object o, EventArgs e)
                    {
                        this.Height = 0;
                    }));

                }
                else
                {
                    this.Height = 0;
                }
            }

        }

        private void setLotteryOrderHandler()
        {

            this.Height = 62;
            this.IsChecked = false;
            this.LbLicense.Text = SysUtil.licenseNameTranslation(this.LotteryOrder.license_id.ToString());
            this.lbOrderId.Text = this.LotteryOrder.id.ToString();
            SetLicenseImg(this.LotteryOrder.license_id);

            this.lbTotalTicketNum.Text = this.LotteryOrder.total_tickets_num.ToString();
            this.lbOrderPrice.Text = this.LotteryOrder.total_money.ToString();

            this.lbPrintedTicketsNum.Text = this.LotteryOrder.ticket_num.ToString();
            this.lbPrintedTicketsPrice.Text = this.LotteryOrder.ticket_money.ToString();

            this.lbCancelNum.Text = this.LotteryOrder.canceled_num.ToString();
            this.lbCancelPrice.Text = this.LotteryOrder.canceled_money.ToString();

            this.lbExpiredNum.Text = this.LotteryOrder.expired_num.ToString();
            this.lbExpiredPrice.Text = this.LotteryOrder.expired_money.ToString();

            this.lbState.Text = GlobalConstants.ORDER_TICKET_STATE_TEXT_DIC[int.Parse(this.LotteryOrder.bet_state)];
            if (this.LotteryOrder.bet_state != "13")//出了'出票成功' 其他状态都设为红色
            {
                if (this.lbState.InvokeRequired)
                {
                    this.lbState.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.lbState.ForeColor = Color.Red;
                    }));

                }
                else
                {
                    this.lbState.ForeColor = Color.Red;
                }
            }

            DateTime dt = new DateTime();
            if (DateTime.TryParse(this.LotteryOrder.ticket_date, out dt))
            {
                this.LbCompleteTime.Text = dt.ToString("MM月dd日hh时mm分");
            }
            else
            {
                this.LbCompleteTime.Text = "--月--日--时--分";
            }

            this.FeedBackResult = (int)this.LotteryOrder.is_feedback;
        }

        private void SetLicenseImg(long licenseId)
        {
            this.PicLicense.Image = SysUtil.GetLicenseImg(licenseId.ToString());
        }

        private int feedBackResult;
        public int FeedBackResult
        {
            get { return feedBackResult; }
            set
            {
                feedBackResult = value;
                if (feedBackResult == GlobalConstants.FeedbackState.NOT_FEEDBACK)
                {
                    this.BackColor = System.Drawing.Color.Transparent;
                    this.btnFeedback.BackgroundImage = global::Demo.Properties.Resources.btnManualFeedback;
                    this.checkBox.Visible = true;

                    this.btnFeedback.MouseEnter += new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.btnFeedback.BackgroundImage = global::Demo.Properties.Resources.btnManualFeedbackEnter;
                    });

                    this.btnFeedback.MouseLeave += new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.btnFeedback.BackgroundImage = global::Demo.Properties.Resources.btnManualFeedback;
                    });
                }
                else
                {
                    this.BackgroundImage = global::Demo.Properties.Resources.itemFeedbackErrorImg;
                    this.btnFeedback.BackgroundImage = global::Demo.Properties.Resources.btnOK;
                    this.checkBox.Visible = false;

                    this.btnFeedback.MouseEnter += new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.btnFeedback.BackgroundImage = global::Demo.Properties.Resources.btnOKEnter;
                    });

                    this.btnFeedback.MouseLeave += new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.btnFeedback.BackgroundImage = global::Demo.Properties.Resources.btnOK;
                    });
                }
            }
        }

        private bool isChecked = false;
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (isChecked)
                {
                    this.checkBox.BackgroundImage = global::Demo.Properties.Resources.qxz;
                }
                else
                {
                    this.checkBox.BackgroundImage = global::Demo.Properties.Resources.mxz;
                }
            }
        }
        private void checkBox_Click(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }

        private void lbDetails_Click(object sender, EventArgs e)
        {

            this.plParent.Controls.Clear();
            TabFeedbackTicketDetail cdTab = new TabFeedbackTicketDetail(this.plParent, this.LotteryOrder);
            cdTab.BringToFront();
            this.plParent.Controls.Add(cdTab);
            cdTab.Show();
        }

        public TabFeedback ParentCnotrol { get; set; }
    }
}
