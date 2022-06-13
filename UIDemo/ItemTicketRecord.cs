using System;
using System.Drawing;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Common;

namespace Demo
{
    public partial class ItemTicketRecord : UserControl
    {
        private lottery_ticket lticket = null;

        public ItemTicketRecord()
        {
            InitializeComponent();
            this.X = this.panel1.Location.X;
        }

        public ItemTicketRecord(lottery_ticket lt):this()
        {
            this.Lticket = lt;            
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

        public Label LbResult
        {
            get { return this.lbResult; }
        }

        /// <summary>
        /// 取得票的Id
        /// </summary>
        /// <returns></returns>
        public String getTicketId()
        {
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
                    this.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        refreshHandler();
                    }));
                }
                else
                {
                    refreshHandler();
                } 
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                        this.Height = 0;
                    }));
                }
                else
                {
                    this.Height = 0;
                }                
            }      

        }

        private void refreshHandler()
        {
            this.panel1.Width = (this.Lticket.ticket_id.ToString().Length - 1) * 9 + 14;

            this.labIndex.Text = this.Lticket.ticket_id.ToString();

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

            if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString())
            || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString())
            || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString())
            || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString()))
            {
                //已出票
                //显示'已出票'文字描述
                if (this.LbResult.InvokeRequired)
                {
                    this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.LbResult.Text = "已出票";
                        this.LbResult.ForeColor = System.Drawing.Color.Green;
                        this.lbDetails2.ForeColor = System.Drawing.Color.Green;
                    }));
                }
                else
                {
                    this.LbResult.Text = "已出票";
                    this.LbResult.ForeColor = System.Drawing.Color.Green;
                    this.lbDetails2.ForeColor = System.Drawing.Color.Green;
                }

            }
            //else if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString())
            //     || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()))
            //{
            //    //已撤单
            //    //显示'已撤票'文字描述
            //    if (this.LbResult.InvokeRequired)
            //    {
            //        this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
            //        {
            //            this.LbResult.Text = "已撤票";
            //            this.LbResult.ForeColor = System.Drawing.Color.Red;
            //            this.lbDetails2.ForeColor = System.Drawing.Color.Red;
            //        }));
            //    }
            //    else
            //    {
            //        this.LbResult.Text = "已撤票";
            //        this.LbResult.ForeColor = System.Drawing.Color.Red;
            //        this.lbDetails2.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            //else if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
            //{
            //    //逾期
            //    //显示'逾期'文字描述
            //    if (this.LbResult.InvokeRequired)
            //    {
            //        this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
            //        {
            //            this.LbResult.Text = "逾期";
            //            this.LbResult.ForeColor = System.Drawing.Color.Red;
            //            this.lbDetails2.ForeColor = System.Drawing.Color.Red;
            //        }));
            //    }
            //    else
            //    {
            //        this.LbResult.Text = "逾期";
            //        this.LbResult.ForeColor = System.Drawing.Color.Red;
            //        this.lbDetails2.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            else if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.AWAITING_PRINT.ToString())
             || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString())
             || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.MANUAL_WAITING_PRINT.ToString())
             || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_WAITING_PRINT.ToString()))
            {
                //等待出票
                //显示'等待出票'文字描述
                if (this.LbResult.InvokeRequired)
                {
                    this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.LbResult.Text = "等待出票";
                        this.LbResult.ForeColor = System.Drawing.Color.Blue;
                        this.lbDetails2.ForeColor = System.Drawing.Color.Blue;
                    }));
                }
                else
                {
                    this.LbResult.Text = "等待出票";
                    this.LbResult.ForeColor = System.Drawing.Color.Blue;
                    this.lbDetails2.ForeColor = System.Drawing.Color.Blue;
                }

            }
            else if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString())
             || this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString()))
            {
                //暂停
                //显示'暂停'文字描述
                if (this.LbResult.InvokeRequired)
                {
                    this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.LbResult.Text = "暂停";
                        this.LbResult.ForeColor = System.Drawing.Color.Blue;
                        this.lbDetails2.ForeColor = System.Drawing.Color.Blue;
                    }));
                }
                else
                {
                    this.LbResult.Text = "暂停";
                    this.LbResult.ForeColor = System.Drawing.Color.Blue;
                    this.lbDetails2.ForeColor = System.Drawing.Color.Blue;
                }

            }
            else
            {
                if (this.LbResult.InvokeRequired)
                {
                    this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.LbResult.Text = "暂停";
                        this.LbResult.ForeColor = System.Drawing.Color.Blue;
                        this.lbDetails2.ForeColor = System.Drawing.Color.Blue;
                    }));
                }
                else
                {
                    this.LbResult.Text = "";
                    this.LbResult.ForeColor = System.Drawing.Color.Black;
                    this.lbDetails2.ForeColor = System.Drawing.Color.Black;
                }
            }
            
            //加戳（错、撤、逾）
            if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()) ||
                this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString()) ||
                this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()) ||
                this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString()) ||
                this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString()))
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
            else if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString()))
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
            else if (this.Lticket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
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

        private void FeedbackTicketItem_Load(object sender, EventArgs e)
        {
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

        private void btnReprint_MouseEnter(object sender, EventArgs e)
        {
            this.btnReprint.BackgroundImage = global::Demo.Properties.Resources.btnReprintEnter;
        }

        private void btnReprint_MouseLeave(object sender, EventArgs e)
        {
            this.btnReprint.BackgroundImage = global::Demo.Properties.Resources.btnReprint;
        }

        /// <summary>
        /// 重打彩票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReprint_Click(object sender, EventArgs e)
        {
            FrmReTicket frm = new FrmReTicket(this.Lticket);
            frm.ShowDialog();
        }
    }
}
