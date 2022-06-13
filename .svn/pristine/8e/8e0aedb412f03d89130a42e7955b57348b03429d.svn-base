using System;

namespace Maticsoft.BLL.singleUploadParser
{
    public class PlsSingleUploadParser : SingleUploadParserWithPlayId
    {
        public const int ZHX_DS = 1;
        public const int Z3_DS = 6;
        public const int Z6_DS = 10;

        public string parseLine(int playId, string line)
        {
            string retObj = null;
            switch (playId)
            {
                case ZHX_DS:
                    retObj = this.parseLine(line);
                    break;
                case Z3_DS:
                    retObj = this.parseZ6Line(line);
                    break;
                case Z6_DS:
                    retObj = this.parseZ6Line(line);
                    break;
            }
            return retObj;
        }

        public string parseLine(string fileContent)
        {
            fileContent = fileContent.Replace(",", "").Trim();
            string retObj = "";
            //号码长度为3
            if (fileContent.Length != 3)
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

        /// <summary>
        /// 组3、组6单式校验
        /// </summary>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        private string parseZ6Line(String fileContent)
        {
            fileContent = fileContent.Replace(",", "");
            string retObj = "";
            //号码长度为3
            if (fileContent.Length != 3)
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
