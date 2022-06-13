using System;
using System.Collections.Generic;
using Maticsoft.Common.model;
namespace Maticsoft.BLL.serviceinterface
{
    public interface IBaseService
    {
        /// <summary>
        /// 根据条件查询订单列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<lottery_order> getLotteryOrderListByParam(Dictionary<string, string> param);

        /// <summary>
        /// 根据状态查询订单列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        List<lottery_order> getLotteryOrderListByState(String state);

        /// <summary>
        /// 根据订单id查询订单
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        lottery_order getLotteryOrderById(string oId);

        /// <summary>
        /// 根据订单Id获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<lottery_ticket> getTicketsByOrderId(string orderId);

        /// <summary>
        /// 根据订单Id获取订单下的所有票——分页
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<lottery_ticket> getTicketsByOrderIdPagination(string orderId,Int64 sno, Int64 psize);
        /// <summary>
        /// 查询指定订单下所有票的数量
        /// </summary>
        /// <returns></returns>
        Int64 getTicketsNumByOrderId(string oId);


        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<lottery_ticket> getTicketsByOrderIdAndStates(string orderId,List<String> states);

        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<lottery_ticket> getTicketsByOrderIdAndStatesPagination(string orderId, List<String> states, Int64 sno, Int64 psize);
        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票的数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Int64 getTicketsNumByOrderIdAndStates(string orderId, List<String> states);
    }
}
