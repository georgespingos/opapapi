using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tzoker.Results.Base;

namespace Tzoker.Results.Models
{
    public class LottoDraw:Draw
    {
        public static readonly int NumOfResults = 5;
        public static string URL = @"http://www.opap.gr/el/web/guest/lotto-draw-results?p_p_id=lottodrawresults_WAR_LottoDrawResultsportlet_INSTANCE_E0oq&p_p_lifecycle=2&p_p_resource_id=draw&draw=";
        public LottoDraw(string Json, int NumOfResults)
            : base(Json, NumOfResults, DrawType.Lotto)
        {
        }
    }
}