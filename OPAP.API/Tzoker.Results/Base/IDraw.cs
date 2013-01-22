using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tzoker.Results.Base
{
    public interface IDraw
    {
        void ParseJson(string Json,int NumOfResults);
    }
}
