using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common.model;

namespace Maticsoft.BLL.serviceinterface
{
   public interface IFeedbackService
    {
       /// <summary>
       /// 查询所有需要反馈的订单
       /// </summary>
       /// <returns></returns>
       List<lottery_order> getAllFeedbackOrderList();

       /// <summary>
       /// 查询所有需要手动反馈的订单
       /// </summary>
       /// <returns></returns>
       List<lottery_order> getAllNeedManualFeedBackOrders(Boolean isAutoFeedBack);

       /// <summary>
       /// 查询所有需要手动反馈的订单——分页
       /// </summary>
       /// <returns></returns>
       List<lottery_order> getAllNeedManualFeedBackOrdersPagination(long sno, long psize, Boolean isAutoFeedBack, Boolean isIncludeJL);

       /// <summary>
        /// 查询所有反馈失败的订单
        /// </summary>
        /// <returns></returns>
       List<lottery_order> getAllFeedBackErrorOrders();

        /// <summary>
        /// 获取所有需要手动处理反馈的订单的数量
        /// </summary>
        /// <param name="isAutoFeedBack">是否自动反馈</param>
        /// <param name="isIncludeJL">是否反馈篮球</param>
        /// <returns></returns>
        int getAllNeedManualFeedBackOrderNum(Boolean isAutoFeedBack,Boolean isIncludeJL);

       /// <summary>
        /// 查询所有反馈失败但是未加载到界面上的订单
        /// </summary>
        /// <returns></returns>
       List<lottery_order> getFeedBackErrorNoInFormOrders();

       /// <summary>
       /// 查询所有需要反馈，且已经显示在界面上的订单
       /// </summary>
       /// <returns></returns>
       List<lottery_order> getFeedbackOrderListInForm();

       /// <summary>
       /// 查询所有需要反馈，但未显示在界面上的订单
       /// </summary>
       /// <returns></returns>
       List<lottery_order> getFeedbackOrderListNotInForm();

       /// <summary>
       /// 修改对应订单是否在反馈界面状态
       /// </summary>
       /// <param name="lol"></param>
       /// <returns></returns>
       Boolean updateIsInFeedbackForm(List<lottery_order> lol);

       /// <summary>
        /// 反馈（一条）
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
       Boolean ManualFeedbackSingle(lottery_order lo);

       /// <summary>
       /// 处理出票反馈结果
       /// </summary>
       /// <param name="orderId"></param>
       /// <returns></returns>
       bool updateOrderAndTicketStateFeedback(string orderId,int isFeedback);
    }
}
