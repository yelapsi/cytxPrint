using System;
using System.Threading;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using System.Collections.Generic;
using Maticsoft.Common.Util;
using System.Drawing;

namespace Demo
{
    public partial class TabRecord : UserControl
    {
        Control oc = new Control();//当前选中的订单Panel
        String endDateStr = "dateTime('now','start of day','+{0} day')";
        private RecordController trcontroller = new RecordController();
        private Panel mainFormPanel = null;
        public TabRecord(Panel plParent)
        {
            InitializeComponent();
            this.mainFormPanel = plParent;
            this.endDateStr = String.Format(this.endDateStr, "1");
        }

        /// <summary>
        /// 加载页面时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabTicketRecord_Load(object sender, EventArgs e)
        {
            //往界面加载数据
            ThreadPool.QueueUserWorkItem(new WaitCallback(initStatistics),"1");
            DateTime dt = DateUtil.getServerDateTime();
            
            if (dt.Month.ToString().Length == 1)
            {
                this.lbMonth.Location = new System.Drawing.Point(18,10);
            }
            else if (dt.Month.ToString().Length > 1)
            {
                this.lbMonth.Location = new System.Drawing.Point(10,10);
            }

            this.lbMonth.Text = dt.Month.ToString();
            this.lbDay.Text = dt.Day.ToString();
        }

        private void initStatistics(object state)
        {
            String startDateStr = "dateTime('now','start of day')";
            
            while (true)
            {
               TicketRecordStatistics trs =  trcontroller.getAllTicketedRecordStatistics(startDateStr, endDateStr);
               TicketRecordStatistics trfs = trcontroller.getAllFeedBackTicketedRecordStatistics(startDateStr, endDateStr);
               TicketRecordStatistics trnfs = trcontroller.getAllNotFeedBackTicketedRecordStatistics(startDateStr, endDateStr);
               TicketRecordStatistics trcs = trcontroller.getAllCancelTicketedRecordStatistics(startDateStr, endDateStr);
               TicketRecordStatistics tros = trcontroller.getAllOverdueTicketedRecordStatistics(startDateStr, endDateStr);

               if (this.labTRSOrderNum.InvokeRequired)
               {
                   this.Invoke(new EventHandler(delegate(object o3, EventArgs e)
                   {
                       this.labTRSOrderNum.Text = trs.orderNum.ToString();
                       this.labTRSTicketNum.Text = trs.ticketNum.ToString();
                       this.labTRSOrderMoney.Text = trs.ticketMoney.ToString();

                       this.labTRFeedbackSOrderNum.Text = trfs.orderNum.ToString();
                       this.labTRFeedbackSTicketNum.Text = trfs.ticketNum.ToString();
                       this.labTRFeedbackSOrderMoney.Text = trfs.ticketMoney.ToString();

                       this.labTRNotFeedbackSOrderNum.Text = trnfs.orderNum.ToString();
                       this.labTRNotFeedbackSTicketNum.Text = trnfs.ticketNum.ToString();
                       this.labTRNotFeedbackSOrderMoney.Text = trnfs.ticketMoney.ToString();

                       this.labTRCancelSOrderNum.Text = trcs.orderNum.ToString();
                       this.labTRCancelSTicketNum.Text = trcs.ticketNum.ToString();
                       this.labTRCancelSOrderMoney.Text = trcs.ticketMoney.ToString();

                       this.labTROverdueSOrderNum.Text = tros.orderNum.ToString();
                       this.labTROverdueSTicketNum.Text = tros.ticketNum.ToString();
                       this.labTROverdueSOrderMoney.Text = tros.ticketMoney.ToString();
                   }));
               }
               else
               {
                   this.labTRSOrderNum.Text = trs.orderNum.ToString();
                   this.labTRSTicketNum.Text = trs.ticketNum.ToString();
                   this.labTRSOrderMoney.Text = trs.ticketMoney.ToString();

                   this.labTRFeedbackSOrderNum.Text = trfs.orderNum.ToString();
                   this.labTRFeedbackSTicketNum.Text = trfs.ticketNum.ToString();
                   this.labTRFeedbackSOrderMoney.Text = trfs.ticketMoney.ToString();

                   this.labTRNotFeedbackSOrderNum.Text = trnfs.orderNum.ToString();
                   this.labTRNotFeedbackSTicketNum.Text = trnfs.ticketNum.ToString();
                   this.labTRNotFeedbackSOrderMoney.Text = trnfs.ticketMoney.ToString();

                   this.labTRCancelSOrderNum.Text = trcs.orderNum.ToString();
                   this.labTRCancelSTicketNum.Text = trcs.ticketNum.ToString();
                   this.labTRCancelSOrderMoney.Text = trcs.ticketMoney.ToString();

                   this.labTROverdueSOrderNum.Text = tros.orderNum.ToString();
                   this.labTROverdueSTicketNum.Text = tros.ticketNum.ToString();
                   this.labTROverdueSOrderMoney.Text = tros.ticketMoney.ToString();
               }
               Thread.Sleep(1000*5);
            }
        }        

        private void plFeedbacked_Click(object sender, EventArgs e)
        {
            if (this.mainFormPanel == null)
            {
                MessageBox.Show("mainFormPanel is NULL!");
            }
            this.mainFormPanel.Controls.Add(new TabOrderRecord(this.mainFormPanel, 1));
            this.Visible = false;
        }

        private void plUnfeedback_Click(object sender, EventArgs e)
        {
            if (this.mainFormPanel == null)
            {
                MessageBox.Show("mainFormPanel is NULL!");
            }
            this.mainFormPanel.Controls.Add(new TabOrderRecord(this.mainFormPanel, 2));
            this.Visible = false;
        }

        private void plCancel_Click(object sender, EventArgs e)
        {
            if (this.mainFormPanel == null)
            {
                MessageBox.Show("mainFormPanel is NULL!");
            }
            this.mainFormPanel.Controls.Add(new TabOrderRecord(this.mainFormPanel, 3));
            this.Visible = false;
        }

        private void plExpired_Click(object sender, EventArgs e)
        {
            if (this.mainFormPanel == null)
            {
                MessageBox.Show("mainFormPanel is NULL!");
            }
            this.mainFormPanel.Controls.Add(new TabOrderRecord(this.mainFormPanel, 4));
            this.Visible = false;
        }

        private void pl_MouseLeave(object sender, EventArgs e)
        {
            AttachImg(sender, null);
        }

        private void plUnfeedback_MouseHover(object sender, EventArgs e)
        {
            AttachImg(sender, global::Demo.Properties.Resources.cover);
        }

        private void plFeedbacked_MouseHover(object sender, EventArgs e)
        {
            AttachImg(sender, global::Demo.Properties.Resources.cover);
        }

        private void plCancel_MouseHover(object sender, EventArgs e)
        {
            AttachImg(sender, global::Demo.Properties.Resources.cover);
        }

        private void plExpired_MouseHover(object sender, EventArgs e)
        {
            AttachImg(sender, global::Demo.Properties.Resources.cover);
        }

        private void AttachImg(object sender, Bitmap bitmap)
        {
            if (!sender.Equals(oc) || oc.BackgroundImage == null)
            {
                oc.BackgroundImage = null;
                Control c = sender as Control;
                while (c.GetType() != typeof(Panel))
                {
                    c = c.Parent;
                }
                c.BackgroundImage = bitmap;
                oc = c;
            }
        }

        private void labTRSOrderNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRSOrderNumUnit);
        }

        private void labTRSTicketNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRSTicketNumUnit);
        }

        private void labTRNotFeedbackSOrderNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRNotFeedbackSOrderNumUnit);
        }

        private void labTRNotFeedbackSTicketNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRNotFeedbackSTicketNumUnit);
        }

        private void labTRNotFeedbackSOrderMoney_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRNotFeedbackSOrderMoneyUnit);
        }

        private void labTRFeedbackSOrderNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRFeedbackSOrderNumUnit);
        }

        private void labTRFeedbackSTicketNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRFeedbackSTicketNumUnit);
        }

        private void labTRFeedbackSOrderMoney_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRFeedbackSOrderMoneyUnit);
        }

        private void labTRCancelSOrderNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRCancelSOrderNumUnit);
        }

        private void labTRCancelSTicketNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRCancelSTicketNumUnit);
        }

        private void labTRCancelSOrderMoney_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRCancelSOrderMoneyUnit);
        }

        private void labTROverdueSOrderNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTROverdueSOrderNumUnit);
        }

        private void labTROverdueSTicketNum_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTROverdueSTicketNumUnit);
        }

        private void labTROverdueSOrderMoney_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTROverdueSOrderMoneyUnit);
        }

        private void labTRSOrderMoney_TextChanged(object sender, EventArgs e)
        {
            this.fun((Control)sender, this.labTRSOrderMoneyUnit);
        }

        /// <summary>
        /// 自动调整标签距离
        /// </summary>
        private void fun(Control c1, Control c2)
        {
            if (c2.InvokeRequired)
            {
                c2.Invoke(new EventHandler(delegate(object o, EventArgs e2)
                {
                    c2.Location = new Point((c1.Location.X + c1.Text.Length * 18), c2.Location.Y);
                }));
            }
            else
            {
                c2.Location = new Point((c1.Location.X + c1.Text.Length * 18), c2.Location.Y);
            }
        }

        private void picOneDay_MouseHover(object sender, EventArgs e)
        {
            this.picOneDay.BackgroundImage = global::Demo.Properties.Resources.oneDayFocused;
        }

        private void picOneDay_MouseLeave(object sender, EventArgs e)
        {
            this.picOneDay.BackgroundImage = global::Demo.Properties.Resources.oneDay;
        }

        private void picThreeDays_MouseHover(object sender, EventArgs e)
        {
            this.picThreeDays.BackgroundImage = global::Demo.Properties.Resources.threeDaysFocused;
        }

        private void picThreeDays_MouseLeave(object sender, EventArgs e)
        {
            this.picThreeDays.BackgroundImage = global::Demo.Properties.Resources.threeDays;
        }

        private void picSevenDays_MouseHover(object sender, EventArgs e)
        {
            this.picSevenDays.BackgroundImage = global::Demo.Properties.Resources.sevenDaysFocused;
        }

        private void picSevenDays_MouseLeave(object sender, EventArgs e)
        {
            this.picSevenDays.BackgroundImage = global::Demo.Properties.Resources.sevenDays;
        }

        private void picOneDay_Click(object sender, EventArgs e)
        {
            this.endDateStr = "dateTime('now','start of day','+1 day')";
        }

        private void picThreeDays_Click(object sender, EventArgs e)
        {
            this.endDateStr = "dateTime('now','start of day','+3 day')";
        }

        private void picSevenDays_Click(object sender, EventArgs e)
        {
            this.endDateStr = "dateTime('now','start of day','+7 day')";
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            this.mainFormPanel.Controls.Clear();
            this.mainFormPanel.Controls.Add(new TabSearch(this.mainFormPanel));
            //this.Visible = false;
        }

        private void btnSearchOrder_MouseHover(object sender, EventArgs e)
        {
            this.btnSearchOrder.BackgroundImage = global::Demo.Properties.Resources.btnSearchFocused;
        }

        private void btnSearchOrder_MouseLeave(object sender, EventArgs e)
        {
            this.btnSearchOrder.BackgroundImage = global::Demo.Properties.Resources.btnSearchUnfocused;
        }

        private void TabRecord_MouseEnter(object sender, EventArgs e)
        {
            oc.BackgroundImage = null;
        }
    }
}
