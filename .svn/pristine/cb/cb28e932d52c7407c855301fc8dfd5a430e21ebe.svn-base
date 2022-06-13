using Demo.pagination;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Demo
{
    public partial class TabSearch : UserControl
    {
        private Panel plParent = null;
        private readonly RecordController trcontroller = new RecordController();
        TabSearchOrder_Pagination searchPagination = null;

        private Int64 formPendingOrderNum;
        public Int64 FormPendingOrderNum
        {
            get { return formPendingOrderNum; }
            set
            {
                Int64 i = formPendingOrderNum;
                formPendingOrderNum = value;
                if (i > 0 && value == 0)
                {
                    if (this.searchPagination.getShowPageNO() == this.searchPagination.getMaxPageNo())//当前处理的刚好是最后一页
                    {
                        if (this.searchPagination.PageNo != 0)
                        {
                            this.searchPagination.PageNo--;
                        }
                    }
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(this.searchPagination.initFormDataList));
                }
            }
        }

        public TabSearch(Panel panel)
        {
            InitializeComponent();
            plParent = panel;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.searchPagination.StrLicense = ((ComboboxItem)this.cbLicense.SelectedItem).Key.ToString();
            this.searchPagination.StrState = ((ComboboxItem)this.cBoxOrderState.SelectedItem).Key.ToString();
            this.searchPagination.StrOrderId = tbOrderId.Text;

            //往界面加载数据
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.searchPagination.getOrderByIdFuzzySearch));
        }

        private void TabSearch_Load(object sender, EventArgs e)
        {
            this.moduleTitlebar.remind = "统计查询 > 订单查询";
            this.controlsList.BackColor = Color.White;
            searchPagination = new TabSearchOrder_Pagination(0, int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]), this.controlsList, this.modulePagingNEW);
            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
            {
                ItemOrderSearch ios = new ItemOrderSearch(plParent, this.controlsList, null, this);
                this.controlsList.Add(ios);
            }
            //初始化下拉框条件
            this.cbLicense.Items.Add(new ComboboxItem(0, "-彩种-"));
            this.cbLicense.SelectedIndex = 0;

            foreach (String item in LicenseContants.licenseId2NameDictionary.Keys)
            {
                this.cbLicense.Items.Add(new ComboboxItem(item, LicenseContants.licenseId2NameDictionary[item]));
            }

            this.cBoxOrderState.Items.Add(new ComboboxItem(0, "-状态-"));
            this.cBoxOrderState.SelectedIndex = 0;

            foreach (int item in GlobalConstants.ORDER_TICKET_STATE_TEXT_DIC.Keys)
            {
                this.cBoxOrderState.Items.Add(new ComboboxItem(item, GlobalConstants.ORDER_TICKET_STATE_TEXT_DIC[item]));
            }
            //往界面加载数据
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.searchPagination.initFormDataList));
            this.controlsList.Add(this.modulePagingNEW);
            this.modulePagingNEW.Visible = true;
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = this.btnSearch.BackgroundImage = global::Demo.Properties.Resources.btnSearchEnter;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = this.btnSearch.BackgroundImage = global::Demo.Properties.Resources.btnSearch;
        }
    }
}
