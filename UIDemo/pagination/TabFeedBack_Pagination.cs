﻿using System;
using System.Collections.Generic;
using System.Text;
using Demo;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Controller;
using System.Windows.Forms;
using Maticsoft.Common.Util;

namespace Maticsoft.demo.pagination
{
    public class TabFeedBack_Pagination : BasePagination<lottery_order>
    {
        public FeedbackController fbc = new FeedbackController();

        public TabFeedBack_Pagination(Int64 pno, Int64 psize, ControlsList clist, ModulePagingNEW mPaging) : base(pno, psize, clist, mPaging) { }

        public override void getPageNumberList()
        {
            try
            {
                //加载反馈失败的订单
                this.TotalDataCount = fbc.getAllNeedManualFeedBackOrderNum(false, false);
                this.DataList = fbc.getAllNeedManualFeedBackOrdersPagination(this.getStartPageNo(), this.PageSize, false, false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public override void initFormDataList(object state)
        {
            try
            {
                this.getPageNumberList();
                if (null != this.DataList && this.DataList.Count > 0)
                {
                    for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                    {
                        ItemFeedback item = (ItemFeedback)this.Controlslist.ControlList.Controls[i];

                        if (item.InvokeRequired)
                        {
                            item.Invoke(new EventHandler(delegate(object obj, EventArgs e)
                            {
                                if (i < this.DataList.Count)
                                {
                                    item.LotteryOrder = this.DataList[i];
                                }
                                else
                                {
                                    item.LotteryOrder = null;
                                }
                            }));
                        }
                        else
                        {
                            if (i < this.DataList.Count)
                            {
                                item.LotteryOrder = this.DataList[i];
                            }
                            else
                            {
                                item.LotteryOrder = null;
                            }
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
            finally
            {
                if (null != state)
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
}
