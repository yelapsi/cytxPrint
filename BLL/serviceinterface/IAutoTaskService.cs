using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common.model;

namespace Maticsoft.BLL.serviceinterface
{
   public interface IAutoTaskService
    {
       /// <summary>
       /// 是否存在可备份的数据
       /// </summary>
       /// <returns></returns>
       Boolean isHasCanBackUpData();

       /// <summary>
       /// 备份数据
       /// </summary>
       Boolean backUpData();

       /// <summary>
       /// 清理过期数据
       /// </summary>
       Boolean clearExpiredData();

       /// <summary>
       /// 修改速度级别
       /// </summary>
       /// <param name="slclist"></param>
       /// <param name="slcmdlist"></param>
       /// <returns></returns>
       Boolean updateSpeedLevel(List<SpeedLevelConfig> slclist, List<SpeedLevelCmd> slcmdlist);
    }
}
