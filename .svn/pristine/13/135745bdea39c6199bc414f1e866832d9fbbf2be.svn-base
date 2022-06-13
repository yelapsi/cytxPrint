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
    public class TabTicketRecord_Pagination : BasePagination<lottery_ticket>
    {
        public RecordController recordc = new RecordController();

        public TabTicketRecord_Pagination(Int64 pno, Int64 psize, lottery_order lo, ControlsList clist, ModulePagingNEW mPaging)
            : base(pno, psize, clist, mPaging)
        {
            this.LotteryOrder = lo;
        }

        public override void getPageNumberList()
        {
            try
            {
                //加载对应的票
                this.TotalDataCount = recordc.getTicketsNumByOrderId(this.LotteryOrder.id);
                this.DataList = recordc.getTicketsByOrderIdPagination(this.LotteryOrder.id, this.getStartPageNo(), this.PageSize);
            }
            catch (Exception e)
            {                
                throw e;
            }            
        }

        public void getPageNumberListByTicketId(string ticketId)
        {
            try
            {
                //加载对应的票
                this.TotalDataCount = recordc.getTicketsNumByOrderIdAndTicketId(this.LotteryOrder.id, ticketId);
                this.DataList = recordc.getTicketsByOrderIdAndTicketIdPagination(this.LotteryOrder.id, ticketId, this.getStartPageNo(), this.PageSize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="state"></param>
        public override void initFormDataList(object state)
        {
            try
            {
                this.getPageNumberList();
                if (null != this.DataList && this.DataList.Count > 0)
                {
                    for ( int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++ )
                    {
                        ItemTicketRecord rItem = (ItemTicketRecord)this.Controlslist.ControlList.Controls[i];
                        if (i < this.DataList.Count)
                        {
                            rItem.Lticket = this.DataList[i];
                        }
                        else
                        {
                            rItem.Lticket = null;
                        }
                    }
                }
                this.Controlslist.refreshLocation();
                this.ModulePaging.InitItem(this.getMaxPageNo(), this.getShowPageNO());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 查票
        /// </summary>
        /// <param name="state"></param>
        public void initFormDataListByTicketId(object state)
        {
            try
            {
                string orderId = state.ToString();
                if (String.IsNullOrEmpty(orderId))
                {
                    this.initFormDataList(null);
                }
                else
                {
                    this.getPageNumberListByTicketId(orderId);
                    if (null != this.DataList && this.DataList.Count > 0)
                    {
                        for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                        {
                            ItemTicketRecord rItem = (ItemTicketRecord)this.Controlslist.ControlList.Controls[i];
                            if (i < this.DataList.Count)
                            {
                                rItem.Lticket = this.DataList[i];
                            }
                            else
                            {
                                rItem.Lticket = null;
                            }
                        }
                    }
                    else if (this.DataList.Count <= 0)
                    {
                        for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                        {
                            ItemTicketRecord rItem = (ItemTicketRecord)this.Controlslist.ControlList.Controls[i];
                            if (rItem.Lticket != null)
                            {
                                rItem.Lticket = null;
                            }
                        }
                    }
                    this.Controlslist.refreshLocation();
                    this.ModulePaging.InitItem(this.getMaxPageNo(), this.getShowPageNO());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public lottery_order LotteryOrder { get; set; }

    }
}
