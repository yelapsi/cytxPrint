using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;

namespace Maticsoft.Controller
{
    public class ManualProcessingController
    {
        private ManualProcServiceImpl mpsimpl = new ManualProcServiceImpl();

        /// <summary>
        /// 查询所有需要手工处理的订单（用于初始化界面）
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getAllManualOrders()
        {
            try
            {
                return mpsimpl.getAllManualOrders();
            }
            catch (Exception)
            {
                throw new Exception("把订单置为手工处理操作出错!");
            }
        }

        /// <summary>
        /// 获取所有含有错漏票的订单的数量
        /// </summary>
        /// <returns></returns>
        public int getManualOrderNum()
        {
            try
            {
                return mpsimpl.getManualOrderNum();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有错漏票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderId(String orderId)
        {
            try
            {
                return mpsimpl.getTicketsByOrderId(orderId);
            }
            catch (Exception)
            {
                throw new Exception("把订单置为手工处理操作出错!");
            }
        }

        /// <summary>
        /// 撤票
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="tId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public Boolean cancelTicket(String oId, String tId, String money)
        {
            try
            {
                return mpsimpl.cancelTicket(oId, tId, money);
            }
            catch (Exception)
            {
                throw new Exception("把订单置为手工处理操作出错!");
            }
        }


        /// <summary>
        /// 确认完成出票
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="tId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public Boolean sureCompeletTicket(String oId, String tId, String money)
        {
            try
            {
                return mpsimpl.sureCompeletTicket(oId, tId, money);
            }
            catch (Exception)
            {
                throw new Exception("把订单置为手工处理操作出错!");
            }
        }

        /// <summary>
        /// 确认完成出票——订单上点击
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        public Boolean sureCompeletOrder(String oId)
        {
            try
            {
                return mpsimpl.sureCompeletOrder(oId);
            }
            catch (Exception)
            {
                throw new Exception("确认整单完成出票处理操作出错!");
            }
        }

        /// <summary>
        /// 撤单——这里的撤单只是撤票的总和（也就是已经出了的票是不能被撤掉的）
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        public Boolean cancelOrder(String oId)
        {
            try
            {
                return mpsimpl.cancelOrder(oId);
            }
            catch (Exception)
            {
                throw new Exception("确认整单撤单处理操作出错!");
            }
        }

        /// <summary>
        /// 恢复订单
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        public Boolean recoveryOrder(String oId)
        {
            try
            {
                return mpsimpl.recoveryOrder(oId);
            }
            catch (Exception)
            {
                throw new Exception("恢复订单操作出错!");
            }
        }

        /// <summary>
        /// 获取指定订单下所有的票数量
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public long getTicketsNumByOrderId(string oid)
        {
            try
            {
                return mpsimpl.getTicketsNumByOrderId(oid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<lottery_ticket> getTicketsByOrderIdPagination(string oid, long sno, long size)
        {
            try
            {
                return mpsimpl.getTicketsByOrderIdPagination(oid, sno, size);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
