using System;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemErrorTicket : UserControl
    {
        private Panel plParent = null;
        private lottery_order lo = null;

        public ItemErrorTicket()
        {
            InitializeComponent();
        }

        public ItemErrorTicket(Panel panel,lottery_order lo):this()
        {
            this.plParent = panel;
            this.LotteryOrder = lo;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                       | ControlStyles.ResizeRedraw
                       | ControlStyles.Selectable
                       | ControlStyles.AllPaintingInWmPaint
                       | ControlStyles.UserPaint
                       | ControlStyles.SupportsTransparentBackColor,
                     true);
        }

        /// <summary>
        /// 查看错漏票订单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, EventArgs e)
        {
            this.plParent.Controls.Clear();
            TabErrorTicketDetail cdTab = new TabErrorTicketDetail(this.plParent,this.lo);
            cdTab.BringToFront();
            this.plParent.Controls.Add(cdTab);
            cdTab.Show();
        }

        public lottery_order LotteryOrder
        {
            get { return lo; }
            set
            {
                lo = value;
                if (null != lo)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                            initLotteryHandler();
                        }));
                    }
                    else
                    {
                        initLotteryHandler();
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
        }

        private void initLotteryHandler()
        {
            this.Height = 62;
            this.lbLicense.Text = SysUtil.licenseNameTranslation(lo.license_id.ToString());
            this.picLicense.BackgroundImage = SysUtil.GetLicenseImg(lo.license_id.ToString());
            this.lbOrderId.Text = lo.id.ToString();

            this.lbTotalTicketNum.Text = lo.total_tickets_num.ToString();
            this.lbOrderPrice.Text = lo.total_money.ToString();

            this.lbPrintedTicketsNum.Text = lo.ticket_num.ToString();
            this.lbPrintedTicketsPrice.Text = lo.ticket_money.ToString();

            this.lbCancelNum.Text = this.lo.canceled_num.ToString();
            this.lbCancelPrice.Text = this.lo.canceled_money.ToString();

            this.lbExpiredNum.Text = this.lo.expired_num.ToString();
            this.lbExpiredPrice.Text = this.lo.expired_money.ToString();

            this.lbCompletePercentage.Text = this.lo.err_ticket_sign_num + "/" + this.lo.errticket_num;

            DateTime dt = new DateTime();
            if (DateTime.TryParse(lo.ticket_date, out dt))
            {
                this.lbCompleteTime.Text = dt.ToString("MM月dd日hh时mm分");
            }
            else
            {
                this.lbCompleteTime.Text = "--月--日--时--分";
            }
        }

        private void btnDetail_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnDetailsEnter;
        }

        private void btnDetail_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnDetails;
        }
    }
}
