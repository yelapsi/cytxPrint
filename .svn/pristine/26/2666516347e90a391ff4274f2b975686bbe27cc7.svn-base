using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common.Util;

namespace Maticsoft.Common.model
{
    /// <summary>
    /// 用于初始化内存——主要是用于修改彩机的速度级别后不需要重启而立即生效
    /// </summary>
    public class SpeedConfigCmd : speed_level_config
    {
        public SpeedConfigCmd() { }
        public SpeedConfigCmd(speed_level_config slc, List<speed_level_cmd> cmdlist)
        {
            this.digital_interval = slc.digital_interval;
            this.dynamic_interval_max = slc.dynamic_interval_max;
            this.dynamic_interval_min = slc.dynamic_interval_min;
            this.enter_interval = slc.enter_interval;
            this.speed_level = slc.speed_level;
            this.state = slc.state;
            this.ticket_interval = slc.ticket_interval;

            if (null != cmdlist && cmdlist.Count > 0)
            {
                foreach (speed_level_cmd pc in cmdlist)
                {
                    //解密
                    pc.Decrypt(GlobalConstants.KEY);
                    //100——200之间的都是11选5，所有只用一个即可
                    this.slmDic.Add(((pc.license_id >= 100 && pc.license_id < 200) ? "100" : pc.license_id.ToString()) + "_" + pc.play_id.ToString() + ((pc.license_id == LicenseContants.License.GAMEIDJCZQ || pc.license_id == LicenseContants.License.GAMEIDJCLQ) ? "_" + pc.ggfs_dfs : ""), pc);                    
                }
            }
        }

        private Dictionary<String, speed_level_cmd> slmDic = new Dictionary<string, speed_level_cmd>();
        public Dictionary<String, speed_level_cmd> SlmDic
        {
            get { return slmDic; }
            set { slmDic = value; }
        }
    }
}
