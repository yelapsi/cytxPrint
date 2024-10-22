﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class ItemManualTicket : UserControl
    {
        private lottery_ticket lotteryTicket;
        public lottery_ticket LotteryTicket
        {
            get { return lotteryTicket; }
            set
            {
                lotteryTicket = value;
                refreshTicketInfo();
            }
        }

        public PictureBox PicStatus
        {
            get { return this.picStatus; }
        }

        public Button BtnOk
        {
            get { return this.btnOk; }
        }

        public Button BtnCancel
        {
            get { return this.btnCancel; }
        }

        public Label LbResult
        {
            get { return this.lbResult; }
        }

        public ItemManualTicket()
        {
            InitializeComponent();
            this.X = this.panel1.Location.X;
        }
        public ItemManualTicket(lottery_ticket lt)
            : this()
        {
            this.LotteryTicket = lt;
        }

        private void refreshTicketInfo()
        {
            if (null != this.LotteryTicket)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
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

        public void refreshTicketInfoHandler()
        {
            this.panel1.Width = (this.LotteryTicket.ticket_id.ToString().Length - 1) * 9 + 14;
            this.Invoke(new EventHandler(delegate(object o, EventArgs e)
            {
                this.panel1.Location = new Point((this.X - (this.LotteryTicket.ticket_id.ToString().Length - 1) * 9), this.panel1.Location.Y);
            }));
            this.lbIndex.Text = this.LotteryTicket.ticket_id.ToString();


            String[] details = null;// BetCodeTranslationUtil.betCode2ShowArray(this.LotteryTicket.bet_code, this.LotteryTicket.license_id.ToString(), this.LotteryTicket.play_type);

            if (this.LotteryTicket.order_id > 0)
            {
                details = BetCodeTranslationUtil.betCode2ShowArray(this.LotteryTicket.bet_code, this.LotteryTicket.license_id.ToString(), this.LotteryTicket.play_type);
            }
            else
            {
                details = BetCodeTranslationUtil.betCode2ShowArrayNoCrypt(this.LotteryTicket.bet_code, this.LotteryTicket.license_id.ToString(), this.LotteryTicket.play_type);
            }

            this.lbDetails.Text = details[0];
            this.lbDetails2.Text = details[1];
            this.lbBet.Text = this.LotteryTicket.bet_num + "注";
            this.lbMultiple.Text = this.LotteryTicket.multiple + "倍";
            if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.PRINTTING_COMPLETE.ToString())
                 || this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString())
                 || this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.MANUAL_COMPLETE.ToString())
                 || this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.RE_COMPLETE.ToString()))
            {//已出票
                this.picStatus.BackgroundImage = global::Demo.Properties.Resources.wc;
                this.BtnOk.Visible = false;
                this.BtnCancel.Visible = false;
                
                //已出票
                //显示'已出票'文字描述
                if (this.LbResult.InvokeRequired)
                {
                    this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.LbResult.Visible = true;
                        this.LbResult.Text = "已出票";
                        this.LbResult.ForeColor = System.Drawing.Color.Green;
                        this.lbDetails2.ForeColor = System.Drawing.Color.Green;
                    }));
                }
                else
                {
                    this.LbResult.Visible = true;
                    this.LbResult.Text = "已出票";
                    this.LbResult.ForeColor = System.Drawing.Color.Green;
                    this.lbDetails2.ForeColor = System.Drawing.Color.Green;
                }
            }
            //else if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString())
            //     || this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString())
            //     || this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
            //{//已撤单
            //    this.picStatus.BackgroundImage = global::Demo.Properties.Resources.xxx;
            //    this.BtnOk.Visible = false;
            //    this.BtnCancel.Visible = false;
            //    String text = "已撤票";
            //    if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()))
            //    {
            //        text = "错漏票";
            //    }
            //    else if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
            //    {
            //        text = "逾期票";
            //    }

            //    //已撤单
            //    //显示'已撤票'文字描述
            //    if (this.LbResult.InvokeRequired)
            //    {
            //        this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
            //        {
            //            this.LbResult.Visible = true;
            //            this.LbResult.Text = text;
            //            this.LbResult.ForeColor = System.Drawing.Color.Red;
            //            this.lbDetails2.ForeColor = System.Drawing.Color.Red;
            //        }));
            //    }
            //    else
            //    {
            //        this.LbResult.Visible = true;
            //        this.LbResult.Text = text;
            //        this.LbResult.ForeColor = System.Drawing.Color.Red;
            //        this.lbDetails2.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            else
            {
                //已出票
                //显示'已出票'文字描述
                if (this.LbResult.InvokeRequired)
                {
                    this.LbResult.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        this.LbResult.Visible = false;
                        this.lbDetails2.ForeColor = System.Drawing.Color.Black;
                        this.BtnOk.Visible = true;
                        this.BtnCancel.Visible = true;
                    }));
                }
                else
                {
                    this.LbResult.Visible = false;
                    this.lbDetails2.ForeColor = System.Drawing.Color.Black;
                    this.BtnOk.Visible = true;
                    this.BtnCancel.Visible = true;
                }
                this.picStatus.BackgroundImage = global::Demo.Properties.Resources.wwc;

                //加戳（错、撤、逾）
                this.seal();
            }

            //this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
        }

        //加戳（错、撤、逾）
        public void seal()
        {
            if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString()) ||
                    this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_WAITING_PRINT.ToString()) ||
                    this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PRINTTING.ToString()) ||
                    this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_PAUSE.ToString()) ||
                    this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.ERROR_COMPLETE.ToString()))
            {
                this.BtnOk.Visible = false;
                this.BtnCancel.Visible = false;
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
            else if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.CANCEL.ToString()))
            {
                this.BtnOk.Visible = false;
                this.BtnCancel.Visible = false;
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
            else if (this.LotteryTicket.ticket_state.Equals(GlobalConstants.ORDER_TICKET_STATE.EXPIRED.ToString()))
            {
                this.BtnOk.Visible = false;
                this.BtnCancel.Visible = false;
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
                this.BtnOk.Visible = true;
                this.BtnCancel.Visible = true;
                this.picSeal.BackgroundImage = null;
                this.Size = new Size(this.Size.Width, this.lbDetails2.Size.Height + 60);
            }
        }

        private void ItemManualTicket_Load(object sender, EventArgs e)
        {
        }

        private void btnOk_MouseHover(object sender, EventArgs e)
        {
            this.btnOk.BackgroundImage = global::Demo.Properties.Resources.btnOKPrintEnter60X22;
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.btnCancelTicketEnter;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            this.btnOk.BackgroundImage = global::Demo.Properties.Resources.btnOKPrint60X22;
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancel.BackgroundImage = global::Demo.Properties.Resources.btnCancelTicket;
        }
    }
}
