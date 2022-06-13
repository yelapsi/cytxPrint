using System;
using System.Drawing;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemFeedbackTicketDetail : UserControl
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息  
                return;
            base.WndProc(ref m);
        }

        private lottery_ticket lticket = null;

        public ItemFeedbackTicketDetail()
        {
            InitializeComponent();
            this.X = this.panel1.Location.X;
        }

        public ItemFeedbackTicketDetail(lottery_ticket lt)
            : this()
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
            get { return lbResult; }
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
                        this.labIndex.Text = this.Lticket.ticket_id.ToString();
                        this.panel1.Width = (this.Lticket.ticket_id.ToString().Length - 1) * 9 + 14;
                        this.panel1.Location = new Point((this.X - (this.Lticket.ticket_id.ToString().Length - 1) * 9), this.panel1.Location.Y);
                        this.labIndex.Text = this.Lticket.ticket_id.ToString();
                        string[] betCode2ShowArray = BetCodeTranslationUtil.betCode2ShowArray(this.Lticket.bet_code, this.Lticket.license_id.ToString(), this.Lticket.play_type);
                        this.lbDetails.Text = betCode2ShowArray[0];
                        this.lbDetails2.Text = betCode2ShowArray[1];
                        this.lbBet.Text = this.Lticket.bet_num + "注";
                        this.lbMultiple.Text = this.Lticket.multiple + "倍";

                        this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
                    }));
                }
                else
                {
                    this.labIndex.Text = this.Lticket.ticket_id.ToString();
                    this.panel1.Width = (this.Lticket.ticket_id.ToString().Length - 1) * 9 + 14;
                    this.panel1.Location = new Point((this.X - (this.Lticket.ticket_id.ToString().Length - 1) * 9), this.panel1.Location.Y);
                    this.labIndex.Text = this.Lticket.ticket_id.ToString();
                    string[] betCode2ShowArray = BetCodeTranslationUtil.betCode2ShowArray(this.Lticket.bet_code, this.Lticket.license_id.ToString(), this.Lticket.play_type);
                    this.lbDetails.Text = betCode2ShowArray[0];
                    this.lbDetails2.Text = betCode2ShowArray[1];
                    this.lbBet.Text = this.Lticket.bet_num + "注";
                    this.lbMultiple.Text = this.Lticket.multiple + "倍";

                    this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
                }

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
                else
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new EventHandler(delegate(object o, EventArgs e)
                        {
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
                        }));
                    }
                    else
                    {
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
            }
            else
            {
                this.Height = 0;
            }
        }

        private void FeedbackTicketItem_Load(object sender, EventArgs e)
        {
            this.X = this.panel1.Location.X;
            refreshTicketInfo();
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
    }
}
