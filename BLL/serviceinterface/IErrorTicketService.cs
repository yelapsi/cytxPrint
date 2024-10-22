﻿using System;
using System.Collections.Generic;
using Maticsoft.Common.model;
namespace Maticsoft.BLL.serviceinterface
{
    interface IErrorTicketService
    {
        /// <summary>
        /// 读取所有的错漏票订单——用于初始化
        /// </summary>
        /// <param name="terminalNumber"></param>
        /// <returns></returns>
        List<lottery_order> getAllErrorTicketOrder(string terminalNumber);

        /// <summary>
        /// 获取所有含有错漏票的订单的数量
        /// </summary>
        /// <returns></returns>
        int getAllErrorTicketOrderNum();

        /// <summary>
        /// 读取所有的错漏票订单——分页
        /// </summary>
        /// <param name="terminalNumber"></param>
        /// <returns></returns>
        List<lottery_order> getAllErrorTicketOrderPagination(Int64 sno,Int64 psize);

        /// <summary>
        /// 根据订单Id获取订单下的所有错漏票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<lottery_ticket> getErrorTicketsByOrderId(string orderId);

        /// <summary>
        /// 读取所有未放置于界面上的错漏票订单——用于追加
        /// </summary>
        /// <param name="terminalNumber"></param>
        /// <returns></returns>
        List<lottery_order> getNotInFormErrorTicketOrder(string terminalNumber);

        /// <summary>
        /// 确定错漏票的选择
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool saveOperatingResult(lottery_order order, Dictionary<string, string[]> param,ref bool finished);

        /// <summary>
        /// 暂存错漏票的选择
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        bool stagingOperatingResult(string orderId, Dictionary<string, string> param);
    }
}
