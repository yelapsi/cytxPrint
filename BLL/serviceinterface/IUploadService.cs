using Maticsoft.BLL.singleUploadParser;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using System.Collections.Generic;

namespace Maticsoft.BLL.serviceinterface
{
    public interface IUploadService : IBaseService
    {
        /// <summary>
        /// 解析排列三单式上传文件
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="playId"></param>
        /// <param name="testCode"></param>
        /// <returns></returns>
        string parsePls(int licenseId, int playId, string line);

        /// <summary>
        /// <summary>
        /// 生成单式上传订单
        /// </summary>
        /// <param name="lotteryOrder"></param>
        int createSingleOrder(lottery_order lotteryOrder);

        /// <summary>
        /// 解析txt文件 竞彩足球 竞彩篮球
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="playId"></param>
        /// <param name="fileContent"></param>
        /// <param name="schNum"></param>
        /// <param name="passLen"></param>
        /// <param name="withSch"></param>
        /// <returns></returns>
        string parseGuessLine(int licenseId, int playId, string fileContent, int schNum, int passLen, bool withSch);

        /// <summary>
        /// 解析txt文件
        /// </summary>
        /// <param name="licenseId"></param>
        /// <param name="line"></param>
        string parse(int licenseId, string line);

        /// <summary>
        /// 生成单式上传订单
        /// </summary>
        /// <param name="lt"></param>
        int createSingleTicket(IList<lottery_ticket> lt);

        /// <summary>
        /// 判断单式上传票表是否存在 不存在则创建
        /// </summary>
        /// <returns></returns>
        bool isSingleOrderExist();

        /// <summary>
        /// 创建单式上传订单表
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        bool isSingleTicketExist();

        /// <summary>
        /// 查找单式上传订单id 负数
        /// </summary>
        int GetSingleOrderId();
    }
}
