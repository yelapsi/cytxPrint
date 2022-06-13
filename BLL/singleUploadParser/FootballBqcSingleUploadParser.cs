using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class FootballBqcSingleUploadParser : SingleUploadParser
    {
        public string parseLine(string line)
        {
            String _line = line.Replace("[^310]", "").Trim();
            if (_line.Length == 12)
            {
                char[] chs = _line.ToCharArray();
                String retObj = "";
                foreach (char ch in chs)
                {
                    retObj += ch + ",";
                    if (ch != '3' && ch != '1' && ch != '0')
                    {
                        return null;
                    }
                }
                retObj = retObj.Substring(0, retObj.Length - 1);
                return retObj;
            }
            else
            {
                // 复式上传
                String[] bets = line.Split(',');
                if (bets.Length == 12)
                {
                    foreach (String bet in bets)
                    {
                        if (bet.Length > 3)
                        {
                            return null;
                        }
                        char[] chs = bet.ToCharArray();
                        foreach (char ch in chs)
                        {
                            if (ch != '3' && ch != '1' && ch != '0')
                            {
                                return null;
                            }
                        }
                    }
                    return line;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
