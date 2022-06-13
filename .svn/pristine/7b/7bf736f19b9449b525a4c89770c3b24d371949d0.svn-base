using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;

namespace Maticsoft.Controller
{
    /// <summary>
    /// 出票模块控制器
    /// </summary>
    public class PrintTicketController
    {
        PrintTicketServiceImpl printImpl = new PrintTicketServiceImpl();
        /// <summary>
        /// 修改订单及其下对应的彩票的状态（带着之前的状态作为条件——主要用于出票首页）
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        public Boolean updateOrderAndTicketState(String oId, String oldState, String newState)
        {
            try
            {
                lottery_order lo = printImpl.getLotteryOrderById(oId);
                if (lo.total_tickets_num <= (lo.ticket_num + lo.canceled_num + lo.expired_num + lo.errticket_num) && newState.Equals(GlobalConstants.ORDER_TICKET_STATE.PAUSE.ToString()))
                {
                    return false;
                }
                return printImpl.updateOrderAndTicketState(oId, oldState, newState);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 处理出票结果
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="ticketId"></param>
        /// <param name="ticketstate"></param>
        /// <param name="ticketInfo"></param>
        /// <returns></returns>
        public bool ticketResultHandler(lottery_ticket lt)
        {
            try
            {
                return printImpl.ticketResultHandler(lt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据state查询指定订单下一张票
        /// </summary>
        /// <param name="oId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public lottery_ticket getTopOneTicket(String oId, String[] stateList)
        {
            return printImpl.getTopOneTicket(oId, stateList);
        }

        /// <summary>
        /// 把订单置为手工处理
        /// </summary>
        /// <returns></returns>
        public Boolean orderToManualProcess(String oId)
        {
            try
            {
                return printImpl.orderToManualProcess(oId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 今日出票金额
        /// </summary>
        /// <returns>今日出票额</returns>
        public int selectTodayTicketMoney()
        {
            try
            {
                return printImpl.selectTodayTicketMoney();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据机器id取其对应的彩种
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public List<machine_can_print_license> getMachineLicenseListByMID(String mid)
        {
            try
            {
                return printImpl.getMachineLicenseListByMID(mid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据licenseId、彩机类别和速度级别查询对应的流程配置数据(lids可以是0-n个，为0时表示查询所有)
        /// </summary>
        /// <param name="llist"></param>
        /// <param name="machineId"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public List<speed_level_cmd> getProConfigByLicenseIds(List<machine_can_print_license> llist, String speed)
        {
            try
            {
                return printImpl.getProConfigByLicenseIds(llist, speed);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderId(string orderId)
        {
            try
            {
                return printImpl.getTicketsByOrderId(orderId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票——分页
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderIdPagination(string orderId, Int64 sno, Int64 psize)
        {
            try
            {
                return printImpl.getTicketsByOrderIdPagination(orderId, sno, psize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Int64 getTicketsNumByOrderId(string orderId)
        {
            try
            {
                return printImpl.getTicketsNumByOrderId(orderId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderIdAndStatesPagination(string orderId, List<String> states, Int64 sno, Int64 psize)
        {
            try
            {
                return printImpl.getTicketsByOrderIdAndStatesPagination(orderId, states, sno, psize);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票的数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Int64 getTicketsNumByOrderIdAndStates(string orderId, List<String> states)
        {
            try
            {
                return printImpl.getTicketsNumByOrderIdAndStates(orderId, states);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long getSingleTicketsNumByOrderIdAndStates(string orderId, List<string> states)
        {
            try
            {
                return printImpl.getSingleTicketsNumByOrderIdAndStates(orderId, states);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改对应订单是否在反馈界面状态
        /// </summary>
        /// <param name="lol"></param>
        /// <returns></returns>
        public Boolean updateIsInPrintForm(List<lottery_order> lol, bool isInForm)
        {
            try
            {
                return printImpl.updateIsInPrintForm(lol, isInForm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询所有可放置于出票界面上的订单——用于第一次加载
        /// </summary>
        /// <returns></returns>
        public Queue<lottery_order> getAllCanInPrintFormOrders(out int errorNum)
        {
            try
            {
                return printImpl.getAllCanInPrintFormOrders(out errorNum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据状态查询订单列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderListByState(String state)
        {
            try
            {
                return printImpl.getLotteryOrderListByState(state);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据状态查询订单列表，显示在出票界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderListByStateInForm(String state)
        {
            try
            {
                return printImpl.getLotteryOrderListByStateInForm(state);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据状态查询订单列表，未显示在出票界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderListByStateNotInForm(String state)
        {
            try
            {
                return printImpl.getLotteryOrderListByStateNotInForm(state);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据状态查询订单列表，未显示在出票界面上的订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderListByStateNotInForm2(String state)
        {
            try
            {
                return printImpl.getLotteryOrderListByStateNotInForm2(state);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据订单id查询订单
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        public lottery_order getLotteryOrderById(String oId)
        {
            try
            {
                return printImpl.getLotteryOrderById(oId);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据排序条件查询订单
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IList<lottery_order> getLotteryOrderListForSort(int sortBy)
        {
            try
            {
                return printImpl.getLotteryOrderListForSort(sortBy);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 根据状态查询订单列表，未显示在出票界面上的单式上传订单
        /// </summary>
        /// <returns></returns>
        public List<lottery_order> getLotteryOrderSingleListByStateNotInForm(string state)
        {
            try
            {
                return printImpl.getLotteryOrderSingleListByStateNotInForm(state);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 把单式上传订单置为手工处理
        /// </summary>
        /// <returns></returns>
        public bool orderToManualProcessSingle(string oId)
        {
            try
            {
                return printImpl.orderToManualProcessSingle(oId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改对应订单是否在反馈界面状态
        /// </summary>
        /// <param name="lol"></param>
        /// <returns></returns>
        public bool updateIsInPrintFormSingle(List<lottery_order> lol, bool isInForm)
        {
            try
            {
                return printImpl.updateIsInPrintFormSingle(lol, isInForm);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据订单id查询订单
        /// </summary>
        /// <param name="oId"></param>
        /// <returns></returns>
        public lottery_order getLotteryOrderSingleById(string oId)
        {
            try
            {
                return printImpl.getLotteryOrderSingleById(oId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id和状态获取订单下的所有票
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getSingleTicketsByOrderIdAndStatesPagination(string orderId, List<String> states, Int64 sno, Int64 psize)
        {
            try
            {
                return printImpl.getSingleTicketsByOrderIdAndStatesPagination(orderId, states, sno, psize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票数量
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Int64 getSingleTicketsNumByOrderId(string orderId)
        {
            try
            {
                return printImpl.getSingleTicketsNumByOrderId(orderId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 根据订单Id获取订单下的所有票——分页
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<lottery_ticket> getSingleTicketsByOrderIdPagination(string orderId, Int64 sno, Int64 psize)
        {
            try
            {
                return printImpl.getSingleTicketsByOrderIdPagination(orderId, sno, psize);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
