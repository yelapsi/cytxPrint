using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Demo.pagination;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using Maticsoft.Common.Util;

namespace Demo
{
    public partial class TabOrderRecord : UserControl
    {
        private int orderType = 1;
        private Panel mainFormPanel = null;
        private TabOrderRecord_Pagination tabRecordP = null;
        
        public TabOrderRecord(Panel plParents,int orderType)
        {
            InitializeComponent();
            this.mainFormPanel = plParents;
            this.orderType = orderType;

            tabRecordP = new TabOrderRecord_Pagination(0,int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]),this.orderType,this.controlsList,this.modulePagingNEW);
            this.controlsList.showPaging = this.ShowPaging;
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

        private void TabOrderRecord_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
            {
                this.controlsList.Add(new ItemOrderRecord(this.mainFormPanel,null));
            }

            //初始化线程，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.tabRecordP.initFormDataList));
            this.controlsList.Add(modulePagingNEW);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.mainFormPanel.Controls)
            {
                if (c.GetType() == typeof(TabRecord))
                {
                    if (c.Visible == false)
                    {
                        c.Visible = true;
                    }
                }
            }
            this.mainFormPanel.Controls.Remove(this);
        }
    }
}
