using System;
using System.Collections;
using System.Collections.Generic;
using Maticsoft.Common.model;
namespace Maticsoft.BLL.serviceinterface
{
    interface IPrintTicketService
    {
        /// <summary>
        /// 根据机器id取其对应的彩种
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        List<machine_can_print_license> getMachineLicenseListByMID(string mid);
        /// <summary>
        /// 根据licenseId、彩机类别和速度级别查询对应的流程配置数据(lids可以是0-n个，为0时表示查询所有)
        /// </summary>
        /// <param name="llist"></param>
        /// <param name="machineId"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        List<speed_level_cmd> getProConfigByLicenseIds(List<machine_can_print_license> llist, string speed);
        /// <summary>
        /// 根据订单状态查询一个订单,用来出票
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        lottery_order getTopOneLotteryOrderByState(string state);

        /// <summary>
      /// 修改对应订单是否在反馈界面状态
      /// </summary>
      /// <param name="lol"></param>
      /// <returns></returns>
        Boolean updateIsInPrintForm(List<lottery_order> lol,bool isInform);
        /// <summary>
        /// 根据state查询指定订单下一张票
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="stateList"></param>
        /// <returns></returns>
        lottery_ticket getTopOneTicket(string oId, string[] stateList);
        /// <summary>
        /// 把订单置为手工处理
        /// </summary>
        /// <returns></returns>
        bool orderToManualProcess(string oId);
        /// <summary>
        /// 今日出票金额
        /// </summary>
        /// <returns>今日出票额</returns>
        int selectTodayTicketMoney();
        /// <summary>
        /// 处理出票结果
        /// </summary>
        /// <param name="lt"></param>
        /// <returns></returns>
        bool ticketResultHandler(lottery_ticket lt);

        /// <summary>
        /// 修改订单及其下对应的彩票的状态（带着之前的状态作为条件——主要用于出票首页）
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        /// <returns></returns>        
        bool updateOrderAndTicketState(string oId, string oldState, string newState);

        /// <summary>
        /// 查询所有可放置于出票界面上的订单——用于第一次加载
        /// </summary>
        /// <returns></returns>
        Queue<lottery_order> getAllCanInPrintFormOrders(out int errorNum);
       /// <summary>
       /// 根据排序条件查询订单
       /// </summary>
       /// <param name="sortBy"></param>
       /// <returns></returns>
        IList<lottery_order> getLotteryOrderListForSort(int sortBy);

        /// <summary>
        /// 根据状态查询订单列表，显示在出票界面上的订单
        /// </summary>
        /// <returns></returns>
        List<lottery_order> getLotteryOrderListByStateInForm(String state);

        /// <summary>
        /// 根据状态查询订单列表，未显示在出票界面上的订单
        /// </summary>
        /// <returns></returns>
        List<lottery_order> getLotteryOrderListByStateNotInForm(String state);

         /// <summary>
        /// 取订单下可打印的票
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        lottery_ticket getTopOnePrintTicket(String oId);

    }
}
