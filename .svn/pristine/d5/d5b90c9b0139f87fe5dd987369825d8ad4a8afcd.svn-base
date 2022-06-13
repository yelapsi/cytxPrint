using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;
using System;
using System.Collections.Generic;

namespace Maticsoft.Controller
{
    public class FeedbackController
    {
        private readonly FeedbackServiceImpl fbsImpl = new FeedbackServiceImpl();
        private readonly PrintTicketServiceImpl printImpl = new PrintTicketServiceImpl();
        //MessageTemplet mt = new MessageTemplet(GlobalConstants.TRANSCODE.FEEDBACK);//消息对象
        #region 重构
        /// <summary>
        /// 查询所有需要反馈的订单
        /// </summary>
        /// <returns></returns>
       public List<lottery_order> getAllFeedbackOrderList() {
            try
            {
                return fbsImpl.getAllFeedbackOrderList();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

       /// <summary>
       /// 查询所有需要手动反馈的订单
       /// </summary>
       /// <returns></returns>
       public List<lottery_order> getAllNeedManualFeedBackOrders(Boolean isAutoFeedBack)
       {
            try
            {
                return fbsImpl.getAllNeedManualFeedBackOrders(isAutoFeedBack);
            }
            catch (Exception e)
            {
                throw e;
            }           
       }
       /// <summary>
       /// 查询所有需要手动反馈的订单——分页
       /// </summary>
       /// <returns></returns>
       public List<lottery_order> getAllNeedManualFeedBackOrdersPagination(long pno, long psize, Boolean isAutoFeedBack, Boolean isIncludeJL)
       {
            try
            {
                return fbsImpl.getAllNeedManualFeedBackOrdersPagination(pno, psize, isAutoFeedBack, isIncludeJL);
            }
            catch (Exception e)
            {
                throw e;
            }           
       }

       /// <summary>
       /// 获取所有需要手动处理反馈的订单的数量
       /// </summary>
       /// <param name="isAutoFeedBack">是否自动反馈</param>
       /// <returns></returns>
       public int getAllNeedManualFeedBackOrderNum(Boolean isAutoFeedBack, Boolean isIncludeJL)
       {
            try
            {
                return fbsImpl.getAllNeedManualFeedBackOrderNum(isAutoFeedBack,isIncludeJL);
            }
            catch (Exception e)
            {
                throw e;
            }           
       }

        /// <summary>
        /// 查询所有反馈失败的订单
        /// </summary>
        /// <returns></returns>
       public List<lottery_order> getAllFeedBackErrorOrders() {
           try
           {
               return fbsImpl.getAllFeedBackErrorOrders();
           }
           catch (Exception)
           {
               throw;
           }
       }


        /// <summary>
        /// 查询所有反馈失败但是未加载到界面上的订单
        /// </summary>
        /// <returns></returns>
       public List<lottery_order> getFeedBackErrorNoInFormOrders()
       {
           try
           {
               return fbsImpl.getFeedBackErrorNoInFormOrders();
           }
           catch (Exception)
           {
               throw;
           }
       }


        /// <summary>
        /// 查询所有需要反馈，且已经显示在界面上的订单
        /// </summary>
        /// <returns></returns>
       public List<lottery_order> getFeedbackOrderListInForm() {
            try
            {
                return fbsImpl.getFeedbackOrderListInForm();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        /// <summary>
        /// 查询所有需要反馈，但未显示在界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getFeedbackOrderListNotInForm() {
            try
            {
                return fbsImpl.getFeedbackOrderListNotInForm();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        

        /// <summary>
        /// 修改对应订单是否在反馈界面状态
        /// </summary>
        /// <param name="lol"></param>
        /// <returns></returns>
        public Boolean updateIsInFeedbackForm(List<lottery_order> lol)
        {
            try
            {
                return fbsImpl.updateIsInFeedbackForm(lol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 反馈（一条）
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        public Boolean ManualFeedbackSingle(lottery_order lo)
        {
            try
            {
                return fbsImpl.ManualFeedbackSingle(lo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool updateOrderAndTicketStateFeedback(string orderId, int feedBackResult)
        {
            try
            {
                return fbsImpl.updateOrderAndTicketStateFeedback(orderId, feedBackResult);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<lottery_ticket> getFeedbackTicketsByOrderId(string orderId)
        {
            try
            {
                return fbsImpl.getTicketsByOrderId(orderId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 获取指定订单下所有的票数量
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public long getTicketsNumByOrderId(string oid)
        {
            try
            {
                return fbsImpl.getTicketsNumByOrderId(oid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<lottery_ticket> getTicketsByOrderIdPagination(string oid, long sno, long size)
        {
            try
            {
                return fbsImpl.getTicketsByOrderIdPagination(oid, sno, size);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
