using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class ModulePaging : UserControl
    {
        public delegate void initItemDelegate(int pageIndex, int page);
        private initItemDelegate initItem;
        private int currentPageIndex;
        private int pageRange;
        private int totalItemCount;
        private int totalPageNumber;
        private ControlsList controlsList;

        public ModulePaging()
        {
            //需要初始化的参数
            // 1. this.pageRange 页面容量
            // 2. this.loadPage 加载页面的方法
            // 3. this.totalItemCount 页面元素总数
            InitializeComponent();
        }

        private void ModulePaging_Load(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            this.Visible = false;
        }

        public void firstPage(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
        }

        public void lastPage(object sender, EventArgs e)
        {
            this.CurrentPageIndex = this.getPageIndex(this.totalItemCount);
        }

        public void previousPage(object sender, EventArgs e)
        {
            if ((this.CurrentPageIndex) > 1)
                this.CurrentPageIndex--;
        }

        public void nextPage(object sender, EventArgs e)
        {
            if ((this.CurrentPageIndex) < this.TotalPageNumber)
                this.CurrentPageIndex++;
        }

        private void loadPage(int pageIndex)
        {
            int startIndex = (pageIndex < 1) ? 0 : (pageIndex - 1) * this.PageRange;
            int endIndex = startIndex + this.PageRange > this.TotalItemCount ? this.TotalItemCount : startIndex + this.PageRange;

            for (int i = 0; i < this.PageRange; i++)
            {
                if (startIndex+i < endIndex)
                {
                    this.InitItem(i, i+startIndex);
                    this.controlsList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        try
                        {
                            this.controlsList.ControlList.Controls[i].Visible = true;
                        }
                        catch (Exception e2)
                        {
                            MessageBox.Show(e2.ToString());
                        }
                    }));
                }
                else if (this.controlsList.ControlList.Controls.Count > i)
                {
                    this.controlsList.Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        try
                        {
                            this.controlsList.ControlList.Controls[i].Visible = false;
                        }
                        catch (Exception e2)
                        {
                            MessageBox.Show(e2.ToString());
                        }
                    }));
                }
            }
        }

        private void locatePageByIndex(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.cbIndex.Text))
            {
                this.CurrentPageIndex = int.Parse(this.cbIndex.Text);
            }
        }

        public int getPageIndex(int itemIndex)
        {
            int pageIndex = 0;
            if ((itemIndex % this.PageRange) > 0)
            {
                pageIndex = (itemIndex / this.PageRange) + 1;
            }
            else
            {
                pageIndex = (itemIndex / this.PageRange);
            }
            return pageIndex;
        }

        public void getTotalPageNumber()
        {
            int totalPageNumber = 0;
            if (this.PageRange > 0 && this.TotalItemCount > 0)
            {
                if ((this.TotalItemCount % this.PageRange) > 0)
                {
                    totalPageNumber = (this.TotalItemCount / this.PageRange) + 1;
                }
                else
                {
                    totalPageNumber = (this.TotalItemCount / this.PageRange);
                }
            }
            this.TotalPageNumber = totalPageNumber;
        }

        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set
            {
                currentPageIndex = value;
                if (this.cbIndex.InvokeRequired)
                {
                    this.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                        try
                        {
                            this.cbIndex.Text = currentPageIndex.ToString();
                        }
                        catch (Exception e2)
                        {
                            MessageBox.Show(e2.ToString());
                        }
                    }));
                }
                else
                {
                    this.cbIndex.Text = currentPageIndex.ToString();
                }

                if (this.InitItem != null)
                {
                    this.loadPage(currentPageIndex);
                }
            }
        }
        public int PageRange
        {
            get { return pageRange; }
            set
            {
                pageRange = value;
                getTotalPageNumber();
            }
        }
        public int TotalItemCount
        {
            get { return totalItemCount; }
            set
            {
                totalItemCount = value;
                getTotalPageNumber();
            }
        }
        public initItemDelegate InitItem
        {
            get { return initItem; }
            set { initItem = value; }
        }
        public int TotalPageNumber
        {
            get { return totalPageNumber; }
            set
            {
                totalPageNumber = value;

                //如果页数小于等于1，隐藏分页控件
                if (totalPageNumber <= 1)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                            this.Visible = false;
                        }));
                    }
                    else
                    {
                        this.Visible = false;
                    }

                    return;
                }

                if (this.lbTotalPageNumber.InvokeRequired)
                {
                    this.lbTotalPageNumber.Invoke(new EventHandler(delegate(object o,EventArgs e) {
                        this.lbTotalPageNumber.Text = String.Format("共 {0} 页", totalPageNumber);

                        if (this.cbIndex.Items.Count < totalPageNumber)
                        {
                            this.cbIndex.Items.Clear();
                            for (int i = 1; i <= totalPageNumber; i++)
                            {
                                if (this.cbIndex.InvokeRequired)
                                {
                                    this.cbIndex.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                                    {
                                        this.cbIndex.Items.Add(i.ToString());
                                    }));
                                }
                                else
                                {
                                    this.cbIndex.Items.Add(i.ToString());
                                }
                            }
                        }
                    }));
                }
                else
                {
                    this.lbTotalPageNumber.Text = String.Format("共 {0} 页", totalPageNumber);

                    if (this.cbIndex.Items.Count < totalPageNumber)
                    {
                        this.cbIndex.Items.Clear();
                        for (int i = 1; i <= totalPageNumber; i++)
                        {
                            if (this.cbIndex.InvokeRequired)
                            {
                                this.cbIndex.Invoke(new EventHandler(delegate(object o2, EventArgs e2)
                                {
                                    this.cbIndex.Items.Add(i.ToString());
                                }));
                            }
                            else
                            {
                                this.cbIndex.Items.Add(i.ToString());
                            }
                        }
                    }
                }
            }
        }
        public ControlsList ControlsList
        {
            get { return controlsList; }
            set { controlsList = value; }
        }

        private void btnFirst_MouseHover(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.firstPageHover;
            }
        }
        private void btnPrevious_MouseHover(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.previousPageHover;
            }
        }
        private void btnNext_MouseHover(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPageNumber)
            {
                ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.nextPageHover;
            }
        }
        private void btnLast_MouseHover(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPageNumber)
            {
                ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.lastPageHover;
            }
        }
        private void btnFirst_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.firstPage;
        }
        private void btnPrevious_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.previousPage;
        }
        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.nextPage;
        }
        private void btnLast_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.lastPage;
        }

        private void cbIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentPageIndex = int.Parse(((ComboBox)sender).Text);
        }

        internal void Reload()
        {
            this.CurrentPageIndex = this.CurrentPageIndex;
        }
    }
}
