using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tzoker.Results.Base;

namespace Tzoker.Results.Models
{
    public class Extra5Draw : Draw
    {
        public static readonly int NumOfResults = 3;
        public static string URL = @"http://www.opap.gr/el/web/guest/extra5-draw-results?p_p_id=extra5drawresults_WAR_Extra5DrawResultsportlet_INSTANCE_SF4i&p_p_lifecycle=2&p_p_resource_id=draw&draw=";
        public Extra5Draw(string Json, int NumOfResults)
            : base(Json, NumOfResults, DrawType.Extra5)
        {
        }
    }
}