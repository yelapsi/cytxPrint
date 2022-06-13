using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.httpmodel
{
    public class Body1002Response
    {
        public Body1002Response()
        {
        }
        public Body1002Response(List<SpeedLevelConfig> speedconlist, List<SpeedLevelCmd> speedcmdlist)
        {
            this.speedconlist = speedconlist;
            this.speedcmdlist = speedcmdlist;
        }

        private List<SpeedLevelConfig> speedconlist;
        private List<SpeedLevelCmd> speedcmdlist;

        public List<SpeedLevelConfig> Speedconlist
        {
            get { return speedconlist; }
            set { speedconlist = value; }
        }

        public List<SpeedLevelCmd> Speedcmdlist
        {
            get { return speedcmdlist; }
            set { speedcmdlist = value; }
        }
    }
}
