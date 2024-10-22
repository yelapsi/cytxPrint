﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Demo.pagination;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;

namespace Demo
{
    public partial class TabFeedbackTicketDetail : UserControl
    {
        //controlList的元素个数上限
        TabFBTicketDetail_Pagination tfpagination;


        private Panel plParent = null;
        private lottery_order lorder = null;

        public TabFeedbackTicketDetail(Panel p, lottery_order lo)
        {
            InitializeComponent();
            plParent = p;
            this.lorder = lo;
            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
            {
                ItemFeedbackTicketDetail ifbtd = new ItemFeedbackTicketDetail(null);
                this.controlsList.Add(ifbtd);
            }

            //初始化分页对象
            tfpagination = new TabFBTicketDetail_Pagination(0, int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]), lo, this.controlsList, this.modulePagingNEW);

            this.controlsList.Gap = 20;
            this.controlsList.GapX = 20;
            this.controlsList.showPaging = this.ShowPaging;
        }

        private void CYTXLotteryFeedbackTicketDetailTab_Load(object sender, EventArgs e)
        {
            this.moduleTitlebar.remind = "当前位置 > 反馈 > 反馈详情";
            this.picLicense.BackgroundImage = SysUtil.GetLicenseImg(this.lorder.license_id.ToString());
            this.lbLicense.Text = SysUtil.licenseNameTranslation(this.lorder.license_id.ToString());
            this.lbOrderId.Text = lorder.id.ToString();
            this.lbOrderPrice.Text = String.Format(this.lbOrderPrice.Text, lorder.total_money.ToString(), lorder.ticket_money.ToString());
            this.lbTotalErrorTicketNum.Text = String.Format(this.lbTotalErrorTicketNum.Text, new String[] { lorder.total_tickets_num.ToString(), lorder.ticket_num.ToString() });

            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.tfpagination.initFormDataList));
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

        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.plParent.Controls.Add(new TabFeedback(this.plParent));
            this.plParent.Controls.Remove(this);
        }
    }
}