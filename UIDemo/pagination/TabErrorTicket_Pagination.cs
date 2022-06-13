using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using Maticsoft.demo.pagination;
using System.Windows.Forms;
using Maticsoft.Common.Util;

namespace Demo.pagination
{
   public class TabErrorTicket_Pagination:BasePagination<lottery_order>
    {
       public ErrorTicketController etc = new ErrorTicketController();

       public TabErrorTicket_Pagination(Int64 pno, Int64 psize, ControlsList clist, ModulePagingNEW mPaging) : base(pno, psize, clist, mPaging) { }

        public override void getPageNumberList()
        {
            try
            {
                //加载反馈失败的订单
                this.TotalDataCount = etc.getAllErrorTicketOrderNum();
                this.DataList = etc.getAllErrorTicketOrderPagination(this.getStartPageNo(), this.PageSize);
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
                    for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                    {
                        ItemErrorTicket etItem = (ItemErrorTicket)this.Controlslist.ControlList.Controls[i];
                        if (i < this.DataList.Count)
                        {
                            etItem.LotteryOrder = this.DataList[i];
                        }
                        else
                        {
                            etItem.LotteryOrder = null;
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
            finally
            {
                if (((Control)state).InvokeRequired)
                {
                    ((Control)state).Invoke(new EventHandler(delegate(object o, EventArgs e)
                    {
                        if (((Control)state).Visible == true)
                        {
                            ((Control)state).Visible = false;
                        }
                    }));
                }
                else
                {
                    if (((Control)state).Visible == true)
                    {
                        ((Control)state).Visible = false;
                    }
                }
            }
        }
    }
}
