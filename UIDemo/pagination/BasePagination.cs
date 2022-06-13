using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Demo;

namespace Maticsoft.demo.pagination
{
    /// <summary>
    /// 所有带有分页的页面的一个接口，需要用到分页就必须实现了以下方法
    /// </summary>
   public abstract class BasePagination<T>
    {
        private Int64 pageNo;//当前页码
        private Int64 pageSize;//当前页面最大长度
        private Int64 totalDataCount;//记录总条数

        private ControlsList controlslist;//滚动条控件
        public ControlsList Controlslist
        {
            get { return controlslist; }
            set { controlslist = value; }
        }

        private ModulePagingNEW modulePaging;//分页控件
        public ModulePagingNEW ModulePaging
        {
            get { return modulePaging; }
            set { modulePaging = value; }
        }

        private List<T> dataList;//数据list

        protected BasePagination(Int64 pno, Int64 psize, ControlsList clist, ModulePagingNEW mPaging)
        {
            this.pageNo = pno;
            this.pageSize = psize;
            this.totalDataCount = 0;
            this.ModulePaging = mPaging;
            this.controlslist = clist;

             //注册事件
            this.ModulePaging.BtnFirstClick += this.fristPageHandler;
            this.ModulePaging.BtnPreviousClick += this.previousPageHandler;
            this.ModulePaging.BtnNextClick += this.nextPageHandler;
            this.ModulePaging.BtnLastClick += this.lastPageHandler;
            this.ModulePaging.BtnJumpClick += this.jumpHandler;
        }

       /// <summary>
       /// 获取最大页数
       /// </summary>
       /// <returns></returns>
        public Int64 getMaxPageNo() {
            return this.pageSize == 0?0:(long)Math.Ceiling(((double)this.totalDataCount) / ((double)this.pageSize));
        }

        /// <summary>
        /// 获取查询时的其实位置
        /// </summary>
        /// <returns></returns>
        public Int64 getStartPageNo()
        {
            return this.pageSize * this.pageNo;
        }

       /// <summary>
       /// 获取显示的页码
       /// </summary>
       /// <returns></returns>
        public Int64 getShowPageNO() {
            return this.totalDataCount == 0?0:this.pageNo + 1;
        }

       /// <summary>
       /// 查询指定页数的数据，并进行初始化
       /// </summary>
       /// <param name="pno"></param>
       /// <param name="psize"></param>
        public abstract void getPageNumberList();
        /// <summary>
        /// 初始化页面方法，需要各个子类自己实现
        /// </summary>
        /// <param name="state"></param>
        public abstract void initFormDataList(object state);

        /// <summary>
        /// 跳转到指定页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void jumpHandler(object sender, EventArgs e)
        {
            this.PageNo = this.ModulePaging.JumpPage-1;
            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(initFormDataList), sender);
        }

        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void fristPageHandler(object sender, EventArgs e)
        {
            this.PageNo = 0;
            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(initFormDataList), sender);
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lastPageHandler(object sender, EventArgs e)
        {
            this.PageNo = this.getMaxPageNo() - 1;
            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(initFormDataList));
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void nextPageHandler(object sender, EventArgs e)
        {
            this.PageNo += 1;
            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(initFormDataList));
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void previousPageHandler(object sender, EventArgs e)
        {
            this.PageNo -= 1;
            //往界面加载数据，只执行一次
            ThreadPool.QueueUserWorkItem(new WaitCallback(initFormDataList));
        }     
       

        public Int64 PageNo
        {
            get { return pageNo; }
            set { pageNo = value; }
        }        

        public Int64 PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public Int64 TotalDataCount
        {
            get { return totalDataCount; }
            set { totalDataCount = value; }
        }

        public List<T> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }
    }
}
