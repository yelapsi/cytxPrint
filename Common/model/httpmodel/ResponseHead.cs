using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.httpmodel
{
    public class ResponseHead : HttpHead
    {
        private String _resultCode;
        private String _resultMsg;

        public ResponseHead(string encoding,
        string transcode,
        string storeId,
        string version,
           String resultCode ,
            String resultMsg)
            : base(encoding,
                transcode,
                storeId,
                version) {
                    this.resultCode = resultCode;
                    this.resultMsg = resultMsg;
                }

        public String resultCode
        {
            get { return _resultCode; }
            set { _resultCode = value; }
        }
        public String resultMsg
        {
            get { return _resultMsg; }
            set { _resultMsg = value; }
        }
    }
}
