using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// 自定义异常对象
    /// </summary>
   public class CustomException:Exception
    {
        private String exceptionCode;//异常编码
        private String exceptionMsg;//异常信息
        private String remark;//备注

        public CustomException(String exceptionCode, String exceptionMsg, String remark) {
            this.ExceptionCode = exceptionCode;
            this.ExceptionMsg = exceptionMsg;
            this.Remark = remark;
        }

        public CustomException(String exceptionMsg)
        {
            this.ExceptionMsg = exceptionMsg;
        }

        public String Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        public String ExceptionCode
        {
            get { return exceptionCode; }
            set { exceptionCode = value; }
        }
        public String ExceptionMsg
        {
            get { return exceptionMsg; }
            set { exceptionMsg = value; }
        }
    }
}
