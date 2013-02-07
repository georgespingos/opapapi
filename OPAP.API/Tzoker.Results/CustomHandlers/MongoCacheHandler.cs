using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Tzoker.Results.Dd;
using Tzoker.Results.Models.Base;

namespace Tzoker.Results.CustomHandlers
{
    public class MongoCacheHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int DrawId = Convert.ToInt32(request.GetRouteData().Values["id"].ToString());
            string DrawType = request.GetRouteData().Values["Controller"].ToString();
            string ResultType = request.GetRouteData().Values["Action"].ToString().Remove(0,3);
            int DrawTypeValue = (int)Enum.Parse(typeof(Entity.DrawType), Enum.GetNames(typeof(Entity.DrawType)).Where(n => n == DrawType).FirstOrDefault());
                

            DbHelper d = new DbHelper();
            d.Exists(DrawId, DrawTypeValue, ResultType);
            
            return base.SendAsync(request, cancellationToken);

        }
    }
}