using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tzoker.Results.Base;

namespace Tzoker.Results.Models
{
    public class ProtoDraw : Draw
    {
        public static readonly int NumOfResults = 6;
        public static string URL = @"http://www.opap.gr/el/web/guest/proto-draw-results?p_p_id=protodresultsx_WAR_ProtoDrawResultsportlet_INSTANCE_vo3N&p_p_lifecycle=2&p_p_resource_id=draw&draw=";
        public ProtoDraw(string Json, int NumOfResults)
            : base(Json, NumOfResults)
        {
            this.Header.Type = Models.Header.DrawType.Proto;
        }
    }
}