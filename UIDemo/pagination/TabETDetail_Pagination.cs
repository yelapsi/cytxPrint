﻿using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.demo.pagination;

namespace Demo.pagination
{
   public class TabETDetail_Pagination: BasePagination<lottery_ticket>
    {
       public ErrorTicketController etc = new ErrorTicketController();
       public TabETDetail_Pagination(Int64 pno, Int64 psize, lottery_order lo, ControlsList clist, ModulePagingNEW mPaging)
            : base(pno, psize, clist, mPaging)
        {
            this.Lorder = lo;
        }

        public override void getPageNumberList()
        {
            try
            {
                //加载反馈失败的订单
                this.TotalDataCount = etc.getTicketsNumByOrderIdAndStates(Lorder.id.ToString(), new List<string>() { GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString() });
                this.DataList = etc.getTicketsByOrderIdAndStatesPagination(Lorder.id.ToString(), new List<string>() { GlobalConstants.ORDER_TICKET_STATE.ERROR.ToString() }, this.getStartPageNo(), this.PageSize);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

       /// <summary>
       /// 初始化
       /// </summary>
       /// <param name="obj"></param>
        public override void initFormDataList(object obj)
        {
            try
            {
                this.getPageNumberList();//获取数据
                if (null != this.DataList && this.DataList.Count != 0)
                {
                    for (int index = 0; index < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); index++)
                    {
                        ItemErrorTicketDetail item = (ItemErrorTicketDetail)this.Controlslist.ControlList.Controls[index];
                        if (index < this.DataList.Count)
                        {
                            item.Lticket = this.DataList[index];
                        }
                        else
                        {
                            item.Lticket = null;
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



        private lottery_order lorder;
        public lottery_order Lorder
        {
            get { return lorder; }
            set { lorder = value; }
        }
    }
}
