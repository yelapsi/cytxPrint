using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.demo.pagination;
using System;

namespace Demo.pagination
{
    public class TabSearchOrder_Pagination : BasePagination<lottery_order>
    {
        private RecordController trcontroller = new RecordController();
        String startDateStr = DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR4);
        String endDateStr = DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR4);
        String strLicense = "", strOrderId = "", strState = "";

        public TabSearchOrder_Pagination(Int64 pno, Int64 psize, ControlsList clist, ModulePagingNEW mPaging)
            : base(pno, psize, clist, mPaging)
        {
            this.ModulePaging = mPaging;

        }

        public override void getPageNumberList()
        {
            try
            {
                //加载订单
                this.TotalDataCount = trcontroller.getRecordStatisticsNumBy(strLicense, strState, strOrderId);
                this.DataList = trcontroller.getRecordStatisticsBy(strLicense, strState, strOrderId, this.getStartPageNo().ToString(), this.PageSize.ToString());
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
                for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                {
                    ItemOrderSearch etItem = (ItemOrderSearch)this.Controlslist.ControlList.Controls[i];
                    if (null != this.DataList && i < this.DataList.Count)
                    {
                        etItem.LotteryOrder = this.DataList[i];
                    }
                    else
                    {
                        etItem.LotteryOrder = null;
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

        public void getOrderByIdFuzzySearch(object state)
        {
            try
            {
                this.getPageNumberList();
                for (int i = 0; i < int.Parse(Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.PAGE_SIZE]); i++)
                {
                    ItemOrderSearch etItem = (ItemOrderSearch)this.Controlslist.ControlList.Controls[i];
                    if (null != this.DataList && i < this.DataList.Count)
                    {
                        etItem.LotteryOrder = this.DataList[i];
                    }
                    else
                    {
                        etItem.LotteryOrder = null;
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

        public string StrLicense
        {
            get
            {
                return strLicense;
            }

            set
            {
                strLicense = (string.IsNullOrEmpty(value) || value.Equals("0")) ? "" : value;
            }
        }

        public string StrOrderId
        {
            get
            {
                return strOrderId;
            }

            set
            {
                strOrderId = (string.IsNullOrEmpty(value) || value.Equals("0")) ? "" : value;
            }
        }

        public string StrState
        {
            get
            {
                return strState;
            }

            set
            {
                strState = (string.IsNullOrEmpty(value) || value.Equals("0")) ? "" : value;
            }
        }

        public string StartDateStr
        {
            get
            {
                return startDateStr;
            }

            set
            {
                startDateStr = value;
            }
        }

        public string EndDateStr
        {
            get
            {
                return endDateStr;
            }

            set
            {
                endDateStr = value;
            }
        }
    }
}
