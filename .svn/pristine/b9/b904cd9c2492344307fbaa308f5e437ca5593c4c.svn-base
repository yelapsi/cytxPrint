using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public class MessageTemplet
    {
        private string _transcode;
        private string _key;
        private string _partnerid;
        private Message _message = new Message();

        public string transcode
        {
            get { return _transcode; }
            set { _transcode = value; }
        }
        public string key
        {
            get { return _key; }
            set { _key = value; }
        }
        public string partnerid
        {
            get { return _partnerid; }
            set { _partnerid = value; }
        }
        public Message msg
        {
            get { return _message; }
            set { _message = value; }
        }

        public class Message
        {
            private Head _head = new Head();
            public object body { get;set;}

            public Head head
            {
                get { return _head; }
                set { _head = value; }
            }

            public class Head
            {
                private string _encoding = "UTF-8";
                private string _transcode;
                private string _partnerId;
                private string _version;
                //private string _time;
                
                public string encoding
                {
                    get { return _encoding; }
                    set { _encoding = value; }
                }
                public string transcode
                {
                    get { return _transcode; }
                    set { _transcode = value; }
                }
                public string partnerId
                {
                    get { return _partnerId; }
                    set { _partnerId = value; }
                }
                public string version
                {
                    get { return _version; }
                    set { _version = value; }
                }
                //public string time
                //{
                //    get { return _time; }
                //    set { _time = value; }
                //}

            }
        }
    }
}
