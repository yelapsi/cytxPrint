using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class GuessBasketballSingleUploadParser : GuessSingleUploadParser
    {
        public static Dictionary<string, string> JCLQ_SFC_TRANSF_R = new Dictionary<string, string>()
        {
            {"01", "0"},
		    {"02", "1"},
		    {"03", "2"},
		    {"04", "3"},
		    {"05", "4"},
		    {"06", "5"},
		
		    {"11", "6"},
		    {"12", "7"},
		    {"13", "8"},
		    {"14", "9"},
		    {"15", "10"},
		    {"16", "11"}
        };

        /**
	 *  标准格式要求：
		1、只接受后缀名为“.txt”的记事本文本文档。
		2、一行一注。
		3、支持逗号、空格、横杠进行分隔，不投的场次用*或者#占位（仅支持*和#）。
		4、逗号、空格、横杠均为半角格式下。
		5、支持两种（冒号、箭头）带场次编号的格式。
		标准格式如下：
		<br>胜平负/让球
		（3代表胜，1代表平，0代表负）
		不带场次
		3,3,1,0,3,1
		3-3-1-0-3-1
		331303
		3 3 1 0 3 1
		3,3,1,*,0,3,*,*,1,*,*
		331#03##1
		带场次
		1001:[3]/1002:[3]/1003:[1]/1004:[0]/1005:[3]/1006:[1]
		1001→3,1002→3,1003→1,1004→0,1005→3,1006→1
		
		（说明：1001代表场次编号周一001，2001代表场次编号周二001，依次类推…）
	
	 */

        public string parseSingleFileLine(int playId, string fileContent, int schNum, int passLen, bool withSch)
        {
            fileContent = fileContent.Replace(",", "").Replace("-", "").Replace("\\s+", "");
            string list = null;
            switch (playId)
            {
                case 1:
                    if (!withSch)
                    {
                        list = parseSf(fileContent, schNum, passLen);
                    }
                    break;
                case 2:
                    if (!withSch)
                    {
                        list = parseSf(fileContent, schNum, passLen);
                    }
                    break;
                case 3:
                    if (!withSch)
                    {
                        list = parseSfc(fileContent, schNum, passLen);
                    }
                    break;
                case 4:
                    if (!withSch)
                    {
                        list = parseDxf(fileContent, schNum, passLen);
                    }
                    break;
            }
            return list;
        }

        /// <summary>
        /// 胜负
        ///（3代表胜0代表负）
        ///不带场次
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="schNum"></param>
        /// <param name="passLen"></param>
        /// <returns></returns>
        private string parseSf(string fileContent, int schNum, int passLen)
        {
            string list = "";
            char[] chs = fileContent.ToCharArray();
            if (chs.Length != schNum)
            {
                return null;
            }
            int index = 0;

            foreach (char c in chs)
            {
                if (!(c == '3' || c == '0' || c == '#' || c == '*'))
                {
                    return null;
                }
                if (c == '3' || c == '0')
                {
                    index++;
                }
                list += c + ",";
            }
            if (index != passLen)
            {
                return null;
            }
            list = list.Substring(0, list.Length - 1);
            return list;
        }

        private string parseSfc(string fileContent, int schNum, int passLen)
        {
            string list = "";
            char[] chs = fileContent.ToCharArray();
            if (chs.Length / 2 != schNum)
            {
                return null;
            }
            int index = 0;
            for (int i = 0; i < chs.Length; i = i + 2)
            {
                if ("**".Equals(chs[i] + "" + chs[i + 1]) || "##".Equals(chs[i] + "" + chs[i + 1])
                        || "*#".Equals(chs[i] + "" + chs[i + 1]) || "#*".Equals(chs[i] + "" + chs[i + 1]))
                {

                }
                else if (JCLQ_SFC_TRANSF_R[(chs[i] + "" + chs[i + 1]).ToString()] == null)
                {
                    return null;
                }
                else
                {
                    index++;
                }
                list += JCLQ_SFC_TRANSF_R[(chs[i] + "" + chs[i + 1]).ToString()] + ",";
            }
            if (index != passLen)
            {
                return null;
            }
            list = list.Substring(0, list.Length - 1);
            return list;
        }

        /// <summary>
        /// 大小分
	    ///0代表大小1代表小分）
		///不带场次
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="schNum"></param>
        /// <param name="passLen"></param>
        /// <returns></returns>
        private string parseDxf(string fileContent, int schNum, int passLen)
        {
            string list = "";
            char[] chs = fileContent.ToCharArray();
            if (chs.Length != schNum)
            {
                return null;
            }
            int index = 0;

            foreach (char c in chs)
            {
                if (!(c == '1' || c == '0' || c == '#' || c == '*'))
                {
                    return null;
                }
                if (c == '1' || c == '0')
                {
                    index++;
                }
                list += c + ",";
            }
            if (index != passLen)
            {
                return null;
            }
            list = list.Substring(0, list.Length - 1);
            return list;
        }
        public string parseLine(string line)
        {
            return null;
        }
    }
}
