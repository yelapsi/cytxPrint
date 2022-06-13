using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class DltSingleUploadParser : SingleUploadParser
    {
        public string parseLine(string fileContent)
        {
            String retObj = "";
            fileContent = fileContent.Replace("|", "").Replace("+", "").Replace("\\|", "").Replace("\\+", "").Replace(",", "").Replace(" ", "");
            if (fileContent.Length != 14)
            {
                return null;
            }
            String[] qianLines = new String[5];
            String[] houLines = new String[2];
            char[] chs = fileContent.ToCharArray();
            for (int i = 0; i < 5; i++)
            {
                qianLines[i] = chs[i * 2] + "" + chs[i * 2 + 1];
            }
            for (int i = 0; i < 2; i++)
            {
                houLines[i] = chs[10 + i * 2] + "" + chs[10 + i * 2 + 1];
            }

            //遍历前区号码
            foreach (String qianLine in qianLines)
            {
                //前区号码长度为2，且在01-35之间
                if (qianLine.Length == 2
                        && (int.Parse(qianLine) <= 35 && int
                                .Parse(qianLine) > 0))
                {
                    retObj += qianLine + ",";
                }
                else
                {
                    return null;
                }
            }
            retObj = retObj.Substring(0, retObj.Length - 1) + "+";
            //遍历后区号码
            foreach (String houLine in houLines)
            {
                //后区号码长度为2，且在01-12之间
                if (houLine.Length == 2
                        && (int.Parse(houLine) <= 12 && int.Parse(houLine) > 0))
                {
                    retObj += houLine + ",";
                }
                else
                {
                    return null;
                }
            }
            retObj = retObj.Substring(0, retObj.Length - 1);
            return retObj;
        }
    }
}
