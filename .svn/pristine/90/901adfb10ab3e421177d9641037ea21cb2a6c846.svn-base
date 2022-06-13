using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class GuessFootballSingleUploadParser : GuessSingleUploadParser
    {
        public static Dictionary<string, string> JCZQ_BF_TRANSF_R = new Dictionary<string, string>()
        {
            {"3A", "0"},
		    {"10", "1"},
		    {"20", "2"},
		    {"21", "3"},
		    {"30", "4"},
		    {"31", "5"},
		    {"32", "6"},
		    {"40", "7"},
		    {"41", "8"},
		    {"42", "9"},
		    {"50", "10"},
		    {"51", "11"},
		    {"52", "12"},
		
		    {"1A", "13"},
		    {"00", "14"},
		    {"11", "15"},
		    {"22", "16"},
		    {"33", "17"},
		
		    {"0A", "18"},
		    {"01", "19"},
		    {"02", "20"},
		    {"12", "21"},
		    {"03", "22"},
		    {"13", "23"},
		    {"23", "24"},
		    {"04", "25"},
		    {"14", "26"},
		    {"24", "27"},
		    {"05", "28"},
		    {"15", "29"},
		    {"25", "30"}
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
		
		<br>比分（31代表3：1，3A代表胜其他，1A代表平其他，0A代表负其他）
		11,31,30
		11-31-30
		113130
		11 31 30
		11,31,30,**,**,**
		11##31######30##
		带场次
		1001:[11]/1002:[31]/1003:[30]
		1001→11,1002→31,1003→30
		
		<br>总进球
		0,1,2,4,5,6
		0-1-2-4-5-6
		012456
		0 1 2 4 5 6
		0,1,2,*,4,5,*,*,6
		带场次
		1001:[0]/1002:[1]/1003:[2]/1004:[4]/1005:[5]/1006:[6]
		1001→0,1002→1,1003→2,1004→4,1005→5,1006→6
		
		<br>半全场
		11,31,30,13,33,30
		11-31-30-13-33-30
		113130133330
		11 31 30 13 33 30
		11,31,30,**,13,33,**,**,30,**,**
		113130##1333####30
		带场次
		1001:[11]/1002:[31]/1003:[30]/1004:[13]/1005:[33]/1006:[30]
		1001→11,1002→31,1003→30,1004→13,1005→33,1006→30
		
		（说明：1001代表场次编号周一001，2001代表场次编号周二001，依次类推…）
	
	 */
        public string parseSingleFileLine(int playId, string fileContent, int schNum, int passLen, bool withSch)
        {
            /*if ( fileContent.indexOf('-') > -1 || fileContent.indexOf(',') > -1 ) {
			if ( playId == 4 || playId == 5 ) {
				passLen = fileContent.replaceAll("-", ",").split(",").length;
			}
		}*/
            fileContent = fileContent.Replace(",", "").Replace("-", "").Replace("\\s+", "");
            string list = null;
            switch (playId)
            {
                case 1:
                    if (!withSch)
                    {
                        list = parseSpf(fileContent, schNum, passLen);
                    }
                    break;
                case 2:
                    if (!withSch)
                    {
                        list = parseSpf(fileContent, schNum, passLen);
                    }
                    break;
                case 3:
                    if (!withSch)
                    {
                        list = parseZjq(fileContent, schNum, passLen);
                    }
                    break;
                case 4:
                    if (!withSch)
                    {
                        list = parseBqc(fileContent, schNum, passLen);
                    }
                    break;
                case 5:
                    if (!withSch)
                    {
                        list = parseBf(fileContent, schNum, passLen);
                    }
                    break;
            }
            return list;
        }

        public string parseLine(string line)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 胜平负/让球
        //* （3代表胜，1代表平，0代表负）
        //   不带场次
        //   3,3,1,0,3,1
        //   3-3-1-0-3-1
        //   331303
        //   3 3 1 0 3 1
        //   3,3,1,*,0,3,*,*,1,*,*
        //   331#03##1
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="schNum"></param>
        /// <param name="passLen"></param>
        /// <returns></returns>
        private string parseSpf(string fileContent, int schNum, int passLen)
        {
            string list = "";
            char[] chs = fileContent.ToCharArray();
            //if (chs.Length != schNum)
            //{
            //    return null;
            //}
            int index = 0;

            foreach (char c in chs)
            {
                if (!(c == '3' || c == '1' || c == '0' || c == '#' || c == '*'))
                {
                    return null;
                }
                if (c == '3' || c == '1' || c == '0')
                {
                    index++;
                }
                list += c + ",";
            }
            //if (index != passLen)
            //{
            //    return null;
            //}
            list = list.Substring(0, list.Length - 1);
            return list;
        }

        private String parseZjq(String fileContent, int schNum, int passLen)
        {
            String list = "";
            char[] chs = fileContent.ToCharArray();
            if (chs.Length != schNum)
            {
                return null;
            }
            int index = 0;
            for (int i = 0; i < chs.Length; i++)
            {
                try
                {
                    if (chs[i] == '#' || chs[i] == '*')
                    {

                    }
                    else if (int.Parse(chs[i] + "") > 7)
                    {
                        return null;
                    }
                    else
                    {
                        index++;
                    }
                }
                catch
                {
                    return null;
                }
                list += chs[i] + ",";
            }
            if (index != passLen)
            {
                return null;
            }
            list = list.Substring(0, list.Length - 1);
            return list;
        }

        private string parseBqc(string fileContent, int schNum, int passLen)
        {
            string list = "";
            char[] chs = fileContent.ToCharArray();
            if (chs.Length / 2 != schNum)
            {
                return null;
            }

            foreach (char c in chs)
            {
                if (!(c == '3' || c == '1' || c == '0' || c == '#' || c == '*'))
                {
                    return null;
                }
            }

            for (int i = 0; i < chs.Length; i = i + 2)
            {
                if ((chs[i] == '3' || chs[i] == '1' || chs[i] == '0') && (chs[i + 1] == '#' || chs[i + 1] == '*'))
                {
                    return null;
                }
                list += chs[i] + "" + chs[i + 1] + ",";
            }
            list = list.Substring(0, list.Length - 1);
            return list;
        }

        private string parseBf(string fileContent, int schNum, int passLen)
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
                else if (JCZQ_BF_TRANSF_R[(chs[i] + "" + chs[i + 1]).ToString()] == null)
                {
                    return null;
                }
                else
                {
                    index++;
                }
                list += JCZQ_BF_TRANSF_R[(chs[i] + "" + chs[i + 1]).ToString()] + ",";
            }
            if (index != passLen)
            {
                return null;
            }
            list = list.Substring(0, list.Length - 1);
            return list;
        }
    }
}
