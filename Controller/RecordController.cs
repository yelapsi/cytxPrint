using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common.model;

namespace Maticsoft.Controller
{
    public class RecordController
    {
        private IRecordService trs = new RecordServiceImpl();

        /// <summary>
        /// 查询起始时间到结束时间内的所有已处理的订单的统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getRecordStatisticsBy(String strLicense, String strState, String strOrderId, String startPageNo, String  pageSize)
        {
            try
            {
                return trs.getRecordStatisticsBy(strLicense, strState, strOrderId,startPageNo, pageSize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有已处理的订单的统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public TicketRecordStatistics getAllTicketedRecordStatistics(String startTime, String endTime)
        {
            try
            {
                return trs.getAllTicketedRecordStatistics(startTime, endTime);
            }
            catch (Exception)
            {
                return null;//throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有已处理的订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllTicketedRecord(String startTime, String endTime, String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllTicketedRecord(startTime, endTime, pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询所有订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllRecord(String startTime, String endTime, String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllTicketedRecord(startTime, endTime, pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有已处理的订单数量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int getAllTicketedRecordNum(String startTime, String endTime)
        {
            try
            {
                return trs.getAllTicketedRecordNum(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 查询起始时间到结束时间内的所有已反馈的订单的统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public TicketRecordStatistics getAllFeedBackTicketedRecordStatistics(String startTime, String endTime)
        {
            try
            {
                return trs.getAllFeedBackTicketedRecordStatistics(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有反馈的订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllFeedBackTicketedRecord(String startTime, String endTime, String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllFeedBackTicketedRecord(startTime, endTime, pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有反馈的订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllRecord(String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllRecord(pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有反馈的订单数量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int getAllFeedBackTicketedRecordNum(String startTime, String endTime)
        {
            try
            {
                return trs.getAllFeedBackTicketedRecordNum(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 查询所有订单数量
        /// </summary>
        /// <returns></returns>
        public int getAllRecordNum()
        {
            try
            {
                return trs.getAllRecordNum();
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// 查询起始时间到结束时间内的所有未反馈的订单的统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public TicketRecordStatistics getAllNotFeedBackTicketedRecordStatistics(String startTime, String endTime)
        {
            try
            {
                return trs.getAllNotFeedBackTicketedRecordStatistics(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有未反馈的订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllNotFeedBackTicketedRecord(String startTime, String endTime, String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllNotFeedBackTicketedRecord(startTime, endTime, pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 查询起始时间到结束时间内的所有未反馈的订单数量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int getAllNotFeedBackTicketedRecordNum(String startTime, String endTime)
        {
            try
            {
                return trs.getAllNotFeedBackTicketedRecordNum(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 查询起始时间到结束时间内的所有撤票的订单的统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public TicketRecordStatistics getAllCancelTicketedRecordStatistics(String startTime, String endTime)
        {
            try
            {
                return trs.getAllCancelTicketedRecordStatistics(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有撤票的订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllCancelTicketedRecord(String startTime, String endTime, String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllCancelTicketedRecord(startTime, endTime, pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有撤票的订单数量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int getAllCancelTicketedRecordNum(String startTime, String endTime)
        {
            try
            {
                return trs.getAllCancelTicketedRecordNum(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// 查询起始时间到结束时间内的所有逾期的订单的统计
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public TicketRecordStatistics getAllOverdueTicketedRecordStatistics(String startTime, String endTime)
        {
            try
            {
                return trs.getAllOverdueTicketedRecordStatistics(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有逾期的订单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<lottery_order> getAllOverdueTicketedRecord(String startTime, String endTime, String pageSize, String pageNo)
        {
            try
            {
                return trs.getAllOverdueTicketedRecord(startTime, endTime, pageSize, pageNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询起始时间到结束时间内的所有逾期的订单数量
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int getAllOverdueTicketedRecordNum(String startTime, String endTime)
        {
            try
            {
                return trs.getAllOverdueTicketedRecordNum(startTime, endTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据orderId查询所有彩票
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketListById(long orderId)
        {
            try
            {
                return trs.getTicketsByOrderId(orderId.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 通过订单号，起始票号，结束票号查询
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="startId">起始票号</param>
        /// <param name="endId">结束票号结束票号</param>
        /// <returns></returns>
        public IList<lottery_ticket> getTicketListByIdAndStartIndexAndEndIdex(int orderId, int startId, int endId)
        {
            try
            {
                return trs.getTicketListByIdAndStartIndexAndEndIdex(orderId, startId, endId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据orderId查询所有彩票
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<lottery_ticket> getTicketsByOrderIdPagination(long orderId, Int64 sno, Int64 psize)
        {
            try
            {
                return trs.getTicketsByOrderIdPagination(orderId.ToString(),sno,psize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<lottery_ticket> getTicketsByOrderIdAndTicketIdPagination(long orderId, string ticketId, long sno, long psize)
        {
            try
            {
                return trs.getTicketsByOrderIdAndTicketIdPagination(orderId.ToString(), ticketId, sno, psize);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据orderId查询所有彩票——数量
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Int64 getTicketsNumByOrderId(long orderId)
        {
            try
            {
                return trs.getTicketsNumByOrderId(orderId.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long getTicketsNumByOrderIdAndTicketId(long orderId, string ticketId)
        {
            try
            {
                return trs.getTicketsNumByOrderIdAndTicketId(orderId.ToString(), ticketId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long getRecordStatisticsNumBy(string strLicense, string strState, string strOrderId)
        {
            try
            {
                return trs.getRecordStatisticsNumBy(strLicense, strState, strOrderId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
