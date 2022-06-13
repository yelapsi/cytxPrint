using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;

namespace Maticsoft.Controller
{
    public class SystemSettingsController
    {
        SystemSettingsServiceImpl sysImpl = new SystemSettingsServiceImpl();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public int initSystemConfig ( ) {
            try
            {
                return sysImpl.initSystemConfig ( );
            }
            catch ( Exception e )
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询系统配置对象
        /// </summary>
        /// <returns></returns>
        public List<system_config> getSysConfig ( )
        {
            try
            {
                return sysImpl.getSystemConfig();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        /// <summary>
        /// 修改sys_config信息
        /// </summary>
        /// <returns></returns>
        public Boolean updateSystemConfig ( Dictionary<String, String> kv )
        {
            try
            {
                return sysImpl.updateSystemConfig ( kv );
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 查询所有店铺彩机
        /// </summary>
        /// <returns></returns>
        public List<store_machine> getAllStoreMachine()
        {
            try
            {
                return sysImpl.getAllStoreMachine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据Id获取机器信息
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public store_machine getStoreMachineById(String mId)
        {
            try
            {
                return sysImpl.getStoreMachineById(mId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public Boolean insertStoreMachine(store_machine machine, List<machine_can_print_license> l)
        {
            try
            {
                return sysImpl.insertStoreMachine(machine, l);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="machine"></param>
        /// <returns></returns>
        public Boolean updateStoreMachine(store_machine machine, List<machine_can_print_license> l)
        {
            try
            {
                return sysImpl.updateStoreMachine(machine, l);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public Boolean deleteStoreMachineById(String mId)
        {
            try
            {
                return sysImpl.deleteStoreMachineById(mId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取指定彩机所有的支持采种信息
        /// </summary>
        /// <returns></returns>
        public List<machine_supported_license> getMachineSupportedLicenseByTId(String mId)
        {
            try
            {
                return sysImpl.getMachineSupportedLicenseByTId(mId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取指定彩机所有的采种信息
        /// </summary>
        /// <returns></returns>
        public List<machine_can_print_license> getMachineCanPrintLicenseByTId(String mId)
        {
            try
            {
                return sysImpl.getMachineCanPrintLicenseByTId(mId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除表中对应机器的数据
        /// </summary>
        /// <returns></returns>
        public Boolean delMachineLicenseBymId(String mId)
        {
            try
            {
                return sysImpl.delMachineLicenseBymId(mId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public void insertMachineLicense(store_machine sm, List<machine_can_print_license> l)
        {
            try
            {
                sysImpl.insertMachineLicense(sm, l);
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region 速度等级
        public List<speed_level_config> getAllSpeedLevelConfig()
        {
            try
            {
                return sysImpl.getAllSpeedLevelConfig();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion 速度等级

        #region 流程控制
        /// <summary>
        /// 根据参数查询对应的流程控制记录
        /// </summary>
        /// <param name="machine_id"></param>
        /// <param name="license_id"></param>
        /// <param name="numbering"></param>
        /// <returns></returns>
        public List<speed_level_cmd> getProConfigByParams(Dictionary<String, String> param)
        {
            try
            {
                return sysImpl.getSpeedLevelCmdByParams(param);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion 流程控制

        /// <summary>
        /// 查询所有的错误处理方式
        /// </summary>
        /// <returns></returns>
        public List<error_handling> getAllErrorHandling()
        {
            try
            {
                return sysImpl.getAllErrorHandling();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 修改错误处理方式
        /// </summary>
        /// <param name="errorhandling"></param>
        /// <returns></returns>
        public Boolean updateErrorHandling(error_handling errorhandling)
        {
            try
            {
                return sysImpl.updateErrorHandling(errorhandling);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 根据速度级别取其对应的命令
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<speed_level_cmd> getSpeedCmdByLevel(string level)
        {
            try
            {
                return sysImpl.getSpeedLevelCmdByParams(new Dictionary<String, String>() { { "speed_level", level } });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
