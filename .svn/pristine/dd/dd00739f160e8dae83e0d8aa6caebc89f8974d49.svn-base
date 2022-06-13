using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.BLL.serviceinterface;
using Maticsoft.Common.model;

namespace Maticsoft.Controller
{
    public class AutoTaskController
    {
        IAutoTaskService ats = new AutoTaskServiceImpl();

        /// <summary>
        /// 是否存在可备份的数据
        /// </summary>
        /// <returns></returns>
        public Boolean isHasCanBackUpData()
        {
            try
            {
                return ats.isHasCanBackUpData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 备份数据
        /// </summary>
        public Boolean backUpData()
        {
            try
            {
                return ats.backUpData();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 清理过期数据
        /// </summary>
        public Boolean clearExpiredData()
        {
            try
            {
                return ats.clearExpiredData();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 修改速度等级
        /// </summary>
        /// <param name="slclist"></param>
        /// <param name="slcmdlist"></param>
        /// <returns></returns>
        public Boolean updateSpeedLevel(List<SpeedLevelConfig> slclist, List<SpeedLevelCmd> slcmdlist)
        {
            try
            {
                return ats.updateSpeedLevel(slclist, slcmdlist);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
