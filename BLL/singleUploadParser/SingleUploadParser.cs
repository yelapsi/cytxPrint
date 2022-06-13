using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public interface SingleUploadParser
    {
        string parseLine(String line);
    }
}
