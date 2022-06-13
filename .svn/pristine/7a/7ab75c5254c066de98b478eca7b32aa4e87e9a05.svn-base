using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class QlcSingleUploadParser : SingleUploadParser
    {
        public string parseLine(string fileContent)
        {
            String retObj = "";
            fileContent = fileContent.Replace("\\|", "").Replace("\\+", "").Replace(",", "").Replace(" ", "");
            if (fileContent.Length != 14)
            {
                return null;
            }
            String[] qianLines = new String[7];
            char[] chs = fileContent.ToCharArray();
            for (int i = 0; i < 7; i++)
            {
                qianLines[i] = chs[i * 2] + "" + chs[i * 2 + 1];
            }

            foreach (String qianLine in qianLines)
            {

                if (qianLine.Length == 2
                        && (int.Parse(qianLine) <= 30 && int.Parse(qianLine) > 0))
                {
                    retObj += qianLine + ",";
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
