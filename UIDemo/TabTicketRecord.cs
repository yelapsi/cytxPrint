﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using Maticsoft.Common;
using Maticsoft.Common.Util;
using System.Threading;
using Demo.pagination;

namespace Demo
{
    public partial class TabTicketRecord : UserControl
    {
        private lottery_order lo = null;
        private Panel mainFormPanel = null;

        TabTicketRecord_Pagination ttrp = null;

        public TabTicketRecord(Panel plParents,lottery_order lo)
        {
            InitializeComponent();
            this.mainFormPanel = plParents;
            this.lo = lo;

            ttrp = new TabTicketRecord_Pagination(0,int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]),this.lo,this.controlsList,this.modulePagingNEW);

            //初始化
            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
            {
                this.controlsList.Add(new ItemTicketRecord(null));
            }
            this.controlsList.showPaging = this.ShowPaging;
            this.controlsList.Add(this.modulePagingNEW);
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

        private void TabTicketRecord_Load(object sender, EventArgs e)
        {
            this.picLicense.BackgroundImage = SysUtil.GetLicenseImg(this.lo.license_id.ToString());
            this.lbLicense.Text = SysUtil.licenseNameTranslation(this.lo.license_id.ToString());
            this.lbOrderId.Text = lo.id.ToString();
            this.lbOrderPrice.Text = String.Format("总{0}元（出票{1}元）", lo.total_money.ToString(), lo.ticket_money.ToString());

            this.lbTotalErrorTicketNum.Text = String.Format("总{0}张（出票{1}张）", lo.total_tickets_num.ToString(), lo.ticket_num.ToString());


            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ttrp.initFormDataList));
                        
            this.btnSearch.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.mainFormPanel.Controls)
            {
                if (c.GetType() == typeof(TabOrderRecord) || c.GetType() == typeof(TabSearch))
                {
                    if (c.Visible == false)
                    {
                        c.Visible = true;
                    }
                }
            }
            this.mainFormPanel.Controls.Remove(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ttrp.initFormDataListByTicketId), this.tbTicketId.Text.Trim());
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSearchEnter;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnSearch;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lo != null)
            {
                if (String.IsNullOrEmpty(this.textBox1.Text) || String.IsNullOrEmpty(this.textBox2.Text))
                {
                    MsgBox.getInstance().Show("'起始票号'或'结束票号'不能为空!", "提示", MsgBox.MyButtons.OK);
                }
                else
                {
                    int a = int.Parse(this.textBox1.Text);
                    int b = int.Parse(this.textBox2.Text);

                    int max = (int)this.lo.total_tickets_num;
                    if (a <= 0 || b <= 0)
                    {
                        MsgBox.getInstance().Show("'票号'应大于0!", "提示", MsgBox.MyButtons.OK);
                    }
                    else if (a > b)
                    {
                        MsgBox.getInstance().Show("'起始票号'应小于'结束票号'!", "提示", MsgBox.MyButtons.OK);
                        //this.textBox1.Text = b.ToString();
                        //this.textBox2.Text = a.ToString();
                        //pictureBox1_Click(sender, e);
                    }
                    else if (b > max)
                    {
                        MsgBox.getInstance().Show("票号超过最大上限!", "提示", MsgBox.MyButtons.OK);
                        //this.textBox2.Text = max.ToString();
                        //pictureBox1_Click(sender, e);
                    }
                    else
                    {
                        IList<lottery_ticket> loList = new List<lottery_ticket>();
                        RecordController recordController = new RecordController();

                        loList = recordController.getTicketListByIdAndStartIndexAndEndIdex((int)lo.id,a,b);

                        FrmReTicketList frmTicketNumberSearch = new FrmReTicketList(loList);
                        frmTicketNumberSearch.StartIndex = a;
                        frmTicketNumberSearch.EndIndex = b;
                        frmTicketNumberSearch.ShowDialog();
                    }
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8) || (String.IsNullOrEmpty(((TextBox)sender).Text) && e.KeyChar == (char)48))
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.qrLeave;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.qrEnter;
        }
    }
}
