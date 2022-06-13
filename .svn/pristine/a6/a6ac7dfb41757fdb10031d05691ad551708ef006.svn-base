using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class FootballRxjSingleUploadParser : SingleUploadParser
    {
        public string parseLine(string line)
        {
            String _line = line.Replace(",", "").Replace("-", "").Replace("\\*", "#").Replace("\\s+", "");
            if (_line.Length == 14)
            {
                char[] chs = _line.ToCharArray();
                String retObj = "";
                int index = 0;
                foreach (char ch in chs)
                {
                    retObj += ch + ",";
                    //字符必须为3,1,0
                    if (ch != '3' && ch != '1' && ch != '0' && ch != '#')
                    {
                        return null;
                    }
                    if (ch == '#')
                    {
                        index++;
                    }
                }
                if (index > 5)
                {
                    return null;
                }
                else if (index < 5)
                {
                    return parseComplex(line);
                }
                retObj = retObj.Substring(0, retObj.Length - 1);
                return retObj;
            }
            else
            {
                // 复式上传
                return parseComplex(line);
            }
        }

        public String parseComplex(String line)
        {
            String[] bets = line.Split(',');
            if (bets.Length == 14)
            {
                String retObj = "";
                int index = 1;
                foreach (String bet in bets)
                {
                    if (bet.Length > 3)
                    {
                        return null;
                    }
                    char[] chs = bet.ToCharArray();
                    foreach (char ch in chs)
                    {
                        //字符必须为3,1,0
                        if (ch != '3' && ch != '1' && ch != '0' && ch != '#' && ch != '*')
                        {
                            return null;
                        }
                    }
                    retObj += index + ":" + bet.Replace("[*]+", "*").Replace("[#]+", "#") + "`1" + ",";
                    index++;
                }
                retObj = retObj.Substring(0, retObj.Length - 1);
                return retObj;
            }
            else
            {
                return null;
            }
        }
    }
}
