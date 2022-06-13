using Maticsoft.Common.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.logmodel
{
    
   public class LogQueueItem
    {
        private String msg;
        private GlobalConstants.LOGTYPE_ENUM logtype;

        public LogQueueItem(GlobalConstants.LOGTYPE_ENUM logtype, String msg) {
            this.logtype = logtype;
            this.msg = msg;
        }
        public string Msg
        {
            get
            {
                return msg;
            }

            set
            {
                msg = value;
            }
        }

        public GlobalConstants.LOGTYPE_ENUM Logtype
        {
            get
            {
                return logtype;
            }

            set
            {
                logtype = value;
            }
        }
    }
}
