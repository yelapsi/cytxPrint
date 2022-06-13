using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.BLL;
using System.ComponentModel;
using System.Collections;
using Maticsoft.Common;
using System.Data;
using Maticsoft.BLL.serviceimpl;
using Maticsoft.Common.model;
using Maticsoft.Common.model.httpmodel;

namespace Maticsoft.Controller
{
    public class SynchronizationController
    {
        ////消息对象
        ////MessageTemplet mt = new MessageTemplet();
        //private SystemSettingsServiceImpl syssettingImpl = new SystemSettingsServiceImpl();


        //private void SetMT(string Transcode)
        //{
        //    mt.key = "53A255D02F16326ACF11BF6091C58E2B";
        //    mt.partnerid = "95508";
        //    mt.msg.head.encoding = "";
        //    mt.msg.head.partnerId = "95508";
        //    mt.msg.head.version = "1.0";
        //    mt.msg.head.encoding = "UTF-8";
        //    mt.transcode = Transcode;
        //    mt.msg.head.transcode = Transcode;
        //}

        ///// <summary>
        ///// 获取从服务器下载同步协议的json
        ///// </summary>
        ///// <returns></returns>
        //public string GetSyncProtocolRequestObj(string ProtocolCode)
        //{
        //    SetMT(Global.Transcode.SYNCH_CODE);
        //    mt.msg.body = new Body100201(ProtocolCode);
        //    return JSonHelper.ObjectToJson(mt);
        //}


        //public string Synchronization(int index)
        //{
        //    mt.key = "53A255D02F16326ACF11BF6091C58E2B";
        //    mt.partnerid = "95508";
        //    mt.msg.head.encoding = "";
        //    mt.msg.head.partnerId = "95508";
        //    mt.msg.head.version = "1.0";

        //    string result = "";
        //    switch (index)
        //    {
        //        //1.license,系统支持的所有彩种 transcode：10041
        //        case 1:
        //            //SetTranscode(1);
        //            result = "syncLicense()";
        //            break;
        //        //2.machine_config：所有机型的配置 transcode：10042
        //        case 2:
        //            //SetTranscode(2);
        //            result = "syncMachineConfig()";
        //            break;
        //        //3.store_machine:店铺下的彩票机 transcode：10043
        //        case 3:
        //            //SetTranscode(3);
        //            result = syncStoreMachine();
        //            break;
        //        //4.store_machine_can_print_license:店铺下各个机器支持打印采种配置 transcode：10044
        //        case 4:
        //            //SetTranscode(4);
        //            result = syncStoreMachineLicense("mId");//彩机编号
        //            break;
        //        //5.speed_level_cmd：各机型的出票流程 transcode：10045
        //        case 5:
        //            //SetTranscode(5);
        //            result = syncProcedureConfiguration();
        //            break;
        //        //6.sys_config:系统配置 transcode：10046
        //        case 6:
        //            //SetTranscode(6);
        //            result = syncSysConfig();
        //            break;
        //        default:
        //            break;
        //    }
        //    //result = HTTPHelper.HttpHandler(result, Global.URL.GET_TICKETS);
        //    return result;
        //}
        ////1.license,系统支持的所有彩种 transcode：10041
        ////private string syncLicense()
        ////{
        ////    List<license> licenseList = syssettingImpl.getAllLicense();
        ////    mt.msg.body = licenseList;
        ////    return JSonHelper.ObjectToJson(mt);
        ////}
        ////2.machine_config：所有机型的配置 transcode：10042
        ////private string syncMachineConfig()
        ////{
        ////    IList<machine_config> machineConfigList = syssettingImpl.getAllMachineConfig();
        ////    mt.msg.body = machineConfigList;
        ////    return JSonHelper.ObjectToJson(mt);
        ////}
        ////3.store_machine:店铺下的彩票机 transcode：10043
        //private string syncStoreMachine()
        //{
        //    List<store_machine> storeMachineList = syssettingImpl.getAllStoreMachine();
        //    mt.msg.body = storeMachineList;
        //    return JSonHelper.ObjectToJson(mt);
        //}
        ////4.store_machine_can_print_license:店铺下各个机器支持打印采种配置 transcode：10044
        //private string syncStoreMachineLicense(string mId)
        //{
        //    List<machine_can_print_license> machineLicenseList = syssettingImpl.getMachineCanPrintLicenseByTId(mId);
        //    mt.msg.body = machineLicenseList;
        //    return JSonHelper.ObjectToJson(mt);
        //}
        ////5.speed_level_cmd：各机型的出票流程 transcode：10045
        //private string syncProcedureConfiguration()
        //{
        //    //string sql = @"SELECT numbering,license_id FROM speed_level_cmd";
        //    //DataSet ds = proConfigBLL.query(sql);
        //    //IList<temp> list = CollectionHelper.ConvertTo<temp>(ds);

        //    //删除了proconfigBLL后临时改的下面两句代码，具体调试时可能需要修改
        //    List<speed_level_cmd> pclist = syssettingImpl.getSpeedLevelCmdByParams(null);
        //    mt.msg.body = pclist;
        //    return JSonHelper.ObjectToJson(mt);
        //}
        ////6.sys_config:系统配置 transcode：10046
        //private string syncSysConfig()
        //{
        //    sys_config sysConfig = syssettingImpl.getSysConfig();
        //    mt.msg.body = sysConfig;
        //    return JSonHelper.ObjectToJson(mt);
        //}
    }
}

class temp
{
    public string numbering { get; set; }
    //public string speed { get; set; }
    public string license_id { get; set; }
}