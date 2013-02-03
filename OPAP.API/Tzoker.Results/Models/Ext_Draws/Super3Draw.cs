using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tzoker.Results.Base;

namespace Tzoker.Results.Models
{
    public class Super3Draw : Draw
    {
        public static readonly int NumOfResults = 5;
        public static string URL = @"http://www.opap.gr/el/web/guest/super3-draw-results?p_p_id=super3drawresults_WAR_Super3DrawResultsportlet_INSTANCE_KA4n&p_p_lifecycle=2&p_p_resource_id=draw&draw=";
        public Super3Draw(string Json, int NumOfResults)
            : base(Json, NumOfResults)
        {
            this.Header.Type = Models.Header.DrawType.Super3;
        }
    }
}