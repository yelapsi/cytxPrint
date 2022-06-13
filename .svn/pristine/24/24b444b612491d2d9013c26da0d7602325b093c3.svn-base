using System;
using System.Drawing;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemErrorTicketDetail : UserControl
    {
        private bool loaded = false;
        private lottery_ticket lticket = null;

        public ItemErrorTicketDetail()
        {
            InitializeComponent();
            this.X = this.panel1.Location.X;
        }

        public ItemErrorTicketDetail(String labIndex, lottery_ticket lt):this()
        {
            this.Lticket = lt;
            this.labIndex.Text = labIndex;
        }
        public lottery_ticket Lticket
        {
            get { return lticket; }
            set
            {
                lticket = value;
                refreshTicketInfo();
            }
        }

        public Label LbBet
        {
            get { return this.lbBet; }
        }

        public Label LbMultiple
        {
            get { return this.lbMultiple; }
        }

        public Label LbCheckDetail
        {
            get { return this.lbCheckDetail; }
        }

        public PictureBox PicRepeat
        {
            get { return this.picRepeat; }
        }

        public PictureBox PicCancel
        {
            get { return this.picCancel; }
        }

        public PictureBox PicOk
        {
            get { return this.picSure; }
        }

        /// <summary>
        /// 获取选择的结果
        /// </summary>
        /// <returns></returns>
        public int getErrorTicketSign() {
            if (this.IsRepeat) {
                return GlobalConstants.TICKET_ERR_SIGN.TICKET_AGAIN;
            }

            if (this.IsCancel)
            {
                return GlobalConstants.TICKET_ERR_SIGN.CANCEL;
            }

            if (this.IsSure)
            {
                return GlobalConstants.TICKET_ERR_SIGN.COMPLETE_TICKET;
            }

            return GlobalConstants.TICKET_ERR_SIGN.NO_OPERATION;
        }

        /// <summary>
        /// 取得票的Id
        /// </summary>
        /// <returns></returns>
        public String getTicketId() {
            return this.lticket.ticket_id.ToString();
        }

        /// <summary>
        /// 取得票的Id
        /// </summary>
        /// <returns></returns>
        public String getTicketBetMoney()
        {
            return this.lticket.bet_price.ToString();
        }

        private void refreshTicketInfo()
        {
            if (null != this.Lticket)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                        refreshTicketInfoHandler();
                    }));
                }
                else
                {
                    refreshTicketInfoHandler();
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

        private void refreshTicketInfoHandler()
        {
            this.labIndex.Text = this.Lticket.ticket_id.ToString();

            this.panel1.Width = (this.Lticket.ticket_id.ToString().Length - 1) * 9 + 14;
            this.panel1.Location = new Point((this.X - (this.Lticket.ticket_id.ToString().Length - 1) * 9), this.panel1.Location.Y);
            this.labIndex.Text = this.Lticket.ticket_id.ToString();
            string[] betCode2ShowArray = null;// BetCodeTranslationUtil.betCode2ShowArray(this.Lticket.bet_code, this.Lticket.license_id.ToString(), this.Lticket.play_type);

            if (this.Lticket.order_id > 0)
            {
                betCode2ShowArray = BetCodeTranslationUtil.betCode2ShowArray(this.Lticket.bet_code, this.Lticket.license_id.ToString(), this.Lticket.play_type);
            }
            else
            {
                betCode2ShowArray = BetCodeTranslationUtil.betCode2ShowArrayNoCrypt(this.Lticket.bet_code, this.Lticket.license_id.ToString(), this.Lticket.play_type);
            }

            this.lbDetails.Text = betCode2ShowArray[0];
            this.lbDetails2.Text = betCode2ShowArray[1];
            this.lbBet.Text = this.Lticket.bet_num + "注";
            this.lbMultiple.Text = this.Lticket.multiple + "倍";

            this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);

            //初始化上次暂存的选择结果
            if (lticket.err_ticket_sign == GlobalConstants.TICKET_ERR_SIGN.TICKET_AGAIN)
            {
                this.IsRepeat = true;
            }
            else if (lticket.err_ticket_sign == GlobalConstants.TICKET_ERR_SIGN.CANCEL)
            {
                this.IsCancel = true;
            }
            else if (lticket.err_ticket_sign == GlobalConstants.TICKET_ERR_SIGN.COMPLETE_TICKET)
            {
                this.IsSure = true;
            }

            //加戳（错、撤、逾）
            if (this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()) ||
                this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString()) ||
                this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()) ||
                this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString()) ||
                this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString()))
            {
                this.picSeal.BackgroundImage = global::Demo.Properties.Resources.sealError;
                if (this.lbDetails2.Size.Height > this.picSeal.Height)
                {
                    this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
                }
                else
                {
                    this.Size = new Size(this.Size.Width, this.picSeal.Height + 60);
                }
            }
            else if (this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString()))
            {
                this.picSeal.BackgroundImage = global::Demo.Properties.Resources.sealCancel;
                if (this.lbDetails2.Size.Height > this.picSeal.Height)
                {
                    this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
                }
                else
                {
                    this.Size = new Size(this.Size.Width, this.picSeal.Height + 60);
                }
            }
            else if (this.lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
            {
                this.picSeal.BackgroundImage = global::Demo.Properties.Resources.sealExpired;
                if (this.lbDetails2.Size.Height > this.picSeal.Height)
                {
                    this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
                }
                else
                {
                    this.Size = new Size(this.Size.Width, this.picSeal.Height + 60);
                }
            }
            else
            {
                this.picSeal.BackgroundImage = null;
                this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
            }
        }

        private void ErrorTicketItem_Load(object sender, EventArgs e)
        {
            loaded = true;
        }

        //点击了重新出票
        private void picRepeat_Click(object sender, EventArgs e)
        {
            this.IsRepeat = !this.IsRepeat;
            if (!this.IsRepeat)
            {
                Control c = this;
                while (c.GetType() != typeof(TabErrorTicketDetail))
                {
                    c = c.Parent;
                }
                if (((TabErrorTicketDetail)c).IsAllRepeat)
                    ((TabErrorTicketDetail)c).IsAllRepeat = false;
            }
        }

        //点击了撤票
        private void picCancel_Click(object sender, EventArgs e)
        {
            this.IsCancel = !this.IsCancel;
            if (!this.IsCancel)
            {
                Control c = this;
                while (c.GetType() != typeof(TabErrorTicketDetail))
                {
                    c = c.Parent;
                }
                if (((TabErrorTicketDetail)c).IsAllCancel)
                    ((TabErrorTicketDetail)c).IsAllCancel = false;
            }
        }

        //点击了确认出票
        private void picSure_Click(object sender, EventArgs e)
        {
            this.IsSure = !this.IsSure;
            if (!this.IsSure)
            {
                Control c = this;
                while (c.GetType() != typeof(TabErrorTicketDetail))
                {
                    c = c.Parent;
                }
                if (((TabErrorTicketDetail)c).IsAllSure)
                    ((TabErrorTicketDetail)c).IsAllSure = false;
            }
        }

        /// <summary>
        /// 查看票花详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbCheckDetail_Click(object sender, EventArgs e)
        {
            FrmCompareTicketInfoShow fcti = new FrmCompareTicketInfoShow(this.lticket);
            fcti.ShowDialog();
        }

        private bool isSure = false;
        private bool isCancel = false;
        private bool isRepeat = false;

        public bool IsSure
        {
            get { return isSure; }
            set
            {
                isSure = value;

                if (isSure)
                {
                    this.picSure.BackgroundImage = global::Demo.Properties.Resources.qxz;
                    this.IsRepeat = false;
                    this.IsCancel = false;
                }
                else
                {
                    if (loaded)
                    {
                        this.picSure.BackgroundImage = global::Demo.Properties.Resources.mxz;
                    }
                }
            }
        }
        public bool IsCancel
        {
            get { return isCancel; }
            set
            {
                isCancel = value;

                if (isCancel)
                {
                    this.picCancel.BackgroundImage = global::Demo.Properties.Resources.qxz;
                    this.IsSure = false;
                    this.IsRepeat = false;
                }
                else
                {
                    if(loaded)
                    {
                        this.picCancel.BackgroundImage = global::Demo.Properties.Resources.mxz;
                    }
                }
            }
        }
        public bool IsRepeat
        {
            get { return isRepeat; }
            set
            {
                isRepeat = value;

                if (isRepeat)
                {
                    this.picRepeat.BackgroundImage = global::Demo.Properties.Resources.qxz;
                    this.IsSure = false;
                    this.IsCancel = false;
                }
                else
                {
                    if (loaded)
                    {
                        this.picRepeat.BackgroundImage = global::Demo.Properties.Resources.mxz;
                    }
                }
            }
        }
    }
}
