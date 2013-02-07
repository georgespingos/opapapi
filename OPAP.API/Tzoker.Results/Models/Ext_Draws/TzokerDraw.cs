using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Tzoker.Results.Base;

namespace Tzoker.Results.Models
{
    public class TzokerDraw : Draw
    {
        public static readonly int NumOfResults = 8;
        public static string URL = @"http://www.opap.gr/web/guest/joker-draw-results?p_p_id=jokerdrawresults_WAR_JokerDrawResultsportlet_INSTANCE_u9TZ&p_p_lifecycle=2&p_p_resource_id=draw&&draw=";
        public TzokerDraw(string Json, int NumOfResults)
            : base(Json, NumOfResults, DrawType.Tzoker)
        {
            
        }
    }
}