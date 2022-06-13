using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model.httpmodel
{
    public class HttpRequestMsg<T> where T : new()
    {
        private RequestHead _head;//消息头
        private T _body;//消息体

        public HttpRequestMsg(string encoding,string transcode,string storeId,string version)
        {
            this.head = new RequestHead(encoding,transcode,storeId,version);
            _body = new T();
        }

        public RequestHead head
        {
            get { return _head; }
            set { _head = value; }
        }

        public T body
        {
            get { return _body; }
            set { _body = value; }
        }
    }
}
