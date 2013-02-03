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
            string id = HttpUtility.ParseQueryString(request.RequestUri.Query).Get("id");
            return base.SendAsync(request, cancellationToken);

        }
    }
}