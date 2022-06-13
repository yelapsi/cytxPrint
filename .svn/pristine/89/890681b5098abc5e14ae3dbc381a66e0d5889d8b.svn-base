using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using Maticsoft.demo.pagination;
using Maticsoft.Common.Util;

namespace Demo.pagination
{
    public class TabFBTicketDetail_Pagination : BasePagination<lottery_ticket>
    {
        public FeedbackController fbc = new FeedbackController();
        public TabFBTicketDetail_Pagination(Int64 pno, Int64 psize, lottery_order lo, ControlsList clist, ModulePagingNEW mPaging)
            : base(pno, psize, clist, mPaging)
        {
            this.Lorder = lo;
        }

        public override void getPageNumberList()
        {
            try
            {
                //加载反馈失败的订单
                this.TotalDataCount = fbc.getTicketsNumByOrderId(Lorder.id.ToString());
                this.DataList = fbc.getTicketsByOrderIdPagination(Lorder.id.ToString(), this.getStartPageNo(), this.PageSize);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="o"></param>
        public override void initFormDataList(object o)
        {
            try
            {
                this.getPageNumberList();
                if (null != this.DataList && this.DataList.Count > 0)
                {
                    for (int index = 0; index < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); index++)
                    {
                        ItemFeedbackTicketDetail item = (ItemFeedbackTicketDetail)this.Controlslist.ControlList.Controls[index];
                        if (index < this.DataList.Count)
                        {
                            item.Lticket = this.DataList[index];
                        }
                        else
                        {
                            item.Lticket = null;
                        }
                    }
                    this.Controlslist.refreshLocation();
                }

                this.ModulePaging.InitItem(this.getMaxPageNo(), this.getShowPageNO());
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private lottery_order lorder;
        public lottery_order Lorder
        {
            get { return lorder; }
            set { lorder = value; }
        }
    }
}
