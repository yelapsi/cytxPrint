﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Maticsoft.Common.Util;
using System.Configuration;
using Maticsoft.Common.model;
using Maticsoft.Common.model.logmodel;
using System.IO;

namespace Maticsoft.Common
{
    public static class Global
    {
        public static Boolean IS_WORKING=false;//开始出票按钮是否被点击

        public static bool isScrolled = false;
        public static bool isLogin = false;

        //音频文件目录
        public static DirectoryInfo AUDIO_FILES_BASEDIR = new DirectoryInfo(ConfigHelper.GetConfigString("AudioFilesPath"));

        //超时次数,用来记录网络访问的超时次数，并作为街面上网络情况的更新依据
        public static int TIME_OUT_TIMES = 0;

        //前一张票，用来作为是否切换界面的依据
        public static lottery_ticket REVIOUSLT = null;

        /// <summary>
        /// 消息队列
        /// </summary>
        public static Queue<LogQueueItem> debugCMDInfoQueue = new Queue<LogQueueItem>();

        //一些当前正在处理的订单的信息
        public static class CURRENT_PRINTTING_ORDER
        {
            public static string orderId = "";
            public static string orderState = "";
        }

        //系统配置
        public static Dictionary<String,String>SYSTEM_CONFIG_MAP = new Dictionary<string,string>();
        public static List<error_handling> errorhandlist = new List<error_handling>();//错误处理选择列表

        /// <summary>
        /// 彩机列表——把列表写成全局的，是为了在修改时能及时同步，不需要重启
        /// </summary>
        public static List<store_machine> storeMachineList = new List<store_machine>();

        /// <summary>
        /// 每个彩机可出票的采种
        /// </summary>
        public static Dictionary<String, Dictionary<String, machine_can_print_license>> MachineCanPrintLicenseDic = new Dictionary<string, Dictionary<String, machine_can_print_license>>();
        /// <summary>
        /// 速度级别字典表
        /// </summary>
        public static Dictionary<String, SpeedConfigCmd> SLC_DICTIONARY = new Dictionary<String, SpeedConfigCmd>();

        //当前界面中已经加载的错漏票数量
        //在添加错漏票时用作列表索引
        //'监控线程'中,每处理完一条错漏票,就把Global.ERROR_TICKET_NUM减一
        //点击'删除'按钮,Global.ERROR_TICKET_NUM减一
        public static int ERROR_TICKET_NUM = 0;

        public static class Transcode
        {
            public static string SYNCH_CODE = "100201";
            public static string SYNCH_CODE_PRO = "100202";
            public static string LOGIN = "1003";
        }

        /// <summary>
        /// 消息队列
        /// </summary>
        public static Queue<string> serialPortInfo = new Queue<string>();        

        /// <summary>
        /// 加载票的线程是否在执行
        /// </summary>
        public static bool isCanClickItemOrder = true;

        /// <summary>
        /// 店铺ID
        /// </summary>
        public static object STORE_ID;

        /// <summary>
        /// 服务器当前时间的毫秒表示
        /// </summary>
        public static Int64 SysDateMillisecond = 0;


        /// <summary>
        /// 取票请求的orderId
        /// </summary>
        public static Int64 ORDER_ID = -1;

        /// <summary>
        /// 是否重新发送取票请求
        /// </summary>
        public static bool TICKET_REQUEST_REPEAT = false;
    }
}
