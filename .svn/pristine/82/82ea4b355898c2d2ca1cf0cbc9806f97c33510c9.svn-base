using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using Maticsoft.demo.pagination;
using Maticsoft.Common.Util;

namespace Demo.pagination
{
   public class TabManual_Pagination : BasePagination<lottery_ticket>
    {
       ManualProcessingController mpc = new ManualProcessingController();

       public TabManual_Pagination(Int64 pno, Int64 psize, lottery_order lo, ControlsList clist, ModulePagingNEW mPaging)
            : base(pno, psize, clist, mPaging)
        {
            this.Lorder = lo;
        }

        public override void getPageNumberList()
        {
            try
            {
                //加载反馈失败的订单
                this.TotalDataCount = mpc.getTicketsNumByOrderId(Lorder.id.ToString());
                this.DataList = mpc.getTicketsByOrderIdPagination(Lorder.id.ToString(), this.getStartPageNo(), this.PageSize);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 初始化彩票显示区域
        /// </summary>
        /// <param name="orderId"></param>
        public override void initFormDataList(object o)
        {
            try
            {
                this.getPageNumberList();
                for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                {
                    ItemManualTicket mti = (ItemManualTicket)this.Controlslist.ControlList.Controls[i];
                    if (i < this.DataList.Count)
                    {
                        mti.LotteryTicket = this.DataList[i];
                    }
                    else
                    {
                        mti.LotteryTicket = null;
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
            set {
                try
                {
                    if (null == lorder && null == value)
                    {//初始化生成的时候会执行
                        return;
                    }
                    else
                    {
                        this.lorder = value;
                        if (null != value)
                        {
                            this.PageNo = 0;
                            this.TotalDataCount = lorder.total_tickets_num;
                            //订单状态为'打印完成' 和 '未添加到界面'
                            ThreadPool.QueueUserWorkItem(new WaitCallback(initFormDataList));
                        }
                        else
                        {
                            for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                            {
                                ((ItemManualTicket)this.Controlslist.ControlList.Controls[i]).LotteryTicket = null;
                            }

                            this.TotalDataCount = 0;
                            this.PageNo = 0;
                            this.ModulePaging.InitItem(this.getMaxPageNo(), this.getShowPageNO());
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }                                
            }
        }
    }
}
