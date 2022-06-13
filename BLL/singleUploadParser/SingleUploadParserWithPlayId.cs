using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public interface SingleUploadParserWithPlayId : SingleUploadParser
    {
        String parseLine(int playId, String line);
    }
}
