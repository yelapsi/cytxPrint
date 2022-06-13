using System;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemOrderRecord : UserControl
    {
        private Panel mainFormPanel = null;
        private lottery_order lo = null;
        public ItemOrderRecord(Panel mainFormPanel, lottery_order lo)
        {
            InitializeComponent();
            this.mainFormPanel = mainFormPanel;
            this.LotteryOrder = lo;
        }

        /// <summary>
        /// 查看错漏票订单详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetail_Click(object sender, EventArgs e)
        {            
            TabTicketRecord tRecord = new TabTicketRecord(this.mainFormPanel, this.lo);
            this.mainFormPanel.Controls.Add(tRecord);

            foreach (Control c in this.mainFormPanel.Controls)
            {
                if (c.GetType() == typeof(TabOrderRecord))
                {
                    c.Visible = false;
                }
            }
        }

        public lottery_order LotteryOrder
        {
            get { return lo; }
            set
            {
                lo = value;
                init();
            }
        }

        private void init()
        {
            if (null !=this.LotteryOrder)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                        initHandler();
                    }));                    
                }
                else
                {
                    initHandler();
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

        private void initHandler(){
            this.Height = 62;
            this.picLicense.BackgroundImage = SysUtil.GetLicenseImg((lo.license_id >= 100 && lo.license_id < 200) ? "101" : lo.license_id.ToString());

            this.lbLicense.Text = SysUtil.licenseNameTranslation(lo.license_id.ToString());
            this.lbOrderId.Text = lo.id.ToString();

            this.lbTotalTicketNum.Text = lo.total_tickets_num.ToString();
            this.lbOrderPrice.Text = lo.total_money.ToString();

            this.lbPrintedTicketsNum.Text = lo.ticket_num.ToString();
            this.lbPrintedTicketsPrice.Text = lo.ticket_money.ToString();

            this.lbCancelNum.Text = this.lo.canceled_num.ToString();
            this.lbCancelPrice.Text = this.lo.canceled_money.ToString();

            this.lbExpiredNum.Text = this.lo.expired_num.ToString();
            this.lbExpiredPrice.Text = this.lo.expired_money.ToString();

            this.lbState.Text = GlobalConstants.ORDER_TICKET_STATE_TEXT_DIC[int.Parse(this.lo.bet_state)];

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
