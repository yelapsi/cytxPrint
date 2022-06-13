using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class QxcSingleUploadParser : SingleUploadParser
    {
        public string parseLine(string fileContent)
        {
            fileContent = fileContent.Replace(",", "");
            String retObj = "";
            //长度为7
            if (fileContent.Length != 7)
            {
                return null;
            }
            char[] chs = fileContent.ToCharArray();
            foreach (char ch in chs)
            {
                //每个字符在0-9之间
                if (ch < 48 || ch > 57)
                {
                    return null;
                }
                retObj += ch + ",";
            }
            retObj = retObj.Substring(0, retObj.Length - 1);
            return retObj;
        }
    }
}
