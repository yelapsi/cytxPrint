﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model
{
    public class system_config
    {
        private string _key;//保留字段的名称
        private string _value;//保留字段的值
        private string _type;//保留字段的数据类型描述
        private string _description;//保留字段用途描述

        public system_config()
        { }

        public string key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
