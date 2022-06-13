using System;
using System.Collections.Generic;
using Maticsoft.Common.model;
namespace Maticsoft.BLL.serviceinterface
{
    interface IManualProcService
    {

        /// <summary>
        /// 撤单——这里的撤单只是撤票的总和（也就是已经出了的票是不能被撤掉的）
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        bool cancelOrder(string oId);

        /// <summary>
        /// 撤票
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="tId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        bool cancelTicket(string oId, string tId, string money);

        /// <summary>
        /// 查询所有需要手工处理的订单（用于初始化界面）
        /// </summary>
        /// <returns></returns>
        List<lottery_order> getAllManualOrders();

        /// <summary>
        /// 获取所有含有错漏票的订单的数量
        /// </summary>
        /// <returns></returns>
        int getManualOrderNum();

        /// <summary>
        /// 恢复订单
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        bool recoveryOrder(string oId);

        /// <summary>
        /// 确认完成出票——订单上点击
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        bool sureCompeletOrder(string oId);

        /// <summary>
        /// 确认完成出票——票上点击
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="tId"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        bool sureCompeletTicket(string oId, string tId, string money);
    }
}
