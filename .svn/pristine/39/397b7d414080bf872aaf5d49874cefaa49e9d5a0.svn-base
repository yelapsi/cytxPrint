using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public static class ReservedFieldsHelper
    {
        /// <summary>
        /// 保留字段表ReservedFields的字段的数据类型描述
        /// </summary>
        public enum ReservedFieldsType
        {
            TrueOrFalse,
            Number,
            String
        };

        public static string getReservedFieldsType(ReservedFieldsType type)
        {
            string result = string.Empty;
            switch (type)
            {
                case ReservedFieldsType.TrueOrFalse:
                    result = "TrueOrFalse";
                    break;
                case ReservedFieldsType.Number:
                    result = "Number";
                    break;
                default:
                    result = "String";
                    break;
            }
            return result;
        }
    }
}
