using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Controller;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemOrderSearch : UserControl
    {
        private Panel plParent = null;
        RecordController RecordController = new RecordController();

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
                    this.ParentControl.FormPendingOrderNum++;
                }
                else if (null != _lotteryOrder && null == value)
                {
                    _lotteryOrder = value;
                    setLottery();
                    this.ParentControl.FormPendingOrderNum--;
                }
                else
                {
                    _lotteryOrder = value;
                    setLottery();
                }
            }
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

        public ItemOrderSearch()
        {
            InitializeComponent();
        }

        public ItemOrderSearch(Panel panel, ControlsList cl, lottery_order lo, TabSearch parent)
            : this()
        {
            this.plParent = panel;
            this.Parentclist = cl;
            this.LotteryOrder = lo;
            this.ParentControl = parent;
        }

        private void setLotteryOrderHandler()
        {

            this.Height = 62;
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

            DateTime dt = new DateTime();
            if (DateTime.TryParse(this.LotteryOrder.ticket_date, out dt))
            {
                this.LbCompleteTime.Text = dt.ToString("MM月dd日hh时mm分");
            }
            else
            {
                this.LbCompleteTime.Text = "--月--日--时--分";
            }
        }

        private void SetLicenseImg(long licenseId)
        {
            this.PicLicense.Image = SysUtil.GetLicenseImg((licenseId >= 100 && licenseId < 200) ? "101" : licenseId.ToString());
        }

        private void setLottery()
        {
            if (null != this.LotteryOrder)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o, EventArgs e)
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
                    this.Invoke(new EventHandler(delegate(object o, EventArgs e)
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

        public TabSearch ParentControl { get; set; }

        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            TabTicketRecord tRecord = new TabTicketRecord(this.plParent, this.LotteryOrder);
            this.plParent.Controls.Add(tRecord);

            foreach (Control c in this.plParent.Controls)
            {
                if (c.GetType() == typeof(TabSearch))
                {
                    c.Visible = false;
                }
            }
        }

        private void btnDetail_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = this.btnDetail.BackgroundImage = global::Demo.Properties.Resources.btnDetailsEnter;
        }

        private void btnDetail_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = this.btnDetail.BackgroundImage = global::Demo.Properties.Resources.btnDetails;
        }
    }
}
