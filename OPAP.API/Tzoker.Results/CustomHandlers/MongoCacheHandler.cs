using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Tzoker.Results.CustomHandlers
{
    public class MongoCacheHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(request.GetRouteData().Values["id"].ToString());
            string DrawType = request.GetRouteData().Values["Controller"].ToString();
            string Action = request.GetRouteData().Values["Action"].ToString();
            
            
            return base.SendAsync(request, cancellationToken);

        }
    }
}