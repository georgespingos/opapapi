using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Tzoker.Results.Dd;
using Tzoker.Results.Models.Base;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace Tzoker.Results.CustomHandlers
{
    public class MongoCacheHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            DbHelper d = new DbHelper();
            BsonDocument Draw = new BsonDocument();

            int DrawId = Convert.ToInt32(request.GetRouteData().Values["id"].ToString());
            string DrawType = request.GetRouteData().Values["Controller"].ToString();
            string ResultType = request.GetRouteData().Values["Action"].ToString().Remove(0, 3);
// ReSharper disable SuggestUseVarKeywordEvident
            int DrawTypeValue = (int)Enum.Parse(typeof(Entity.DrawType), Enum.GetNames(typeof(Entity.DrawType)).Where(n => n == DrawType).FirstOrDefault());
// ReSharper restore SuggestUseVarKeywordEvident

            if (d.TryGet(DrawId, DrawTypeValue, ResultType, out Draw))
                return FetchFromCache(Draw);
            else
                return base.SendAsync(request, cancellationToken);
        }
        private Task<HttpResponseMessage> FetchFromCache(BsonDocument Draw)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(Draw.ToJson(new MongoDB.Bson.IO.JsonWriterSettings{ OutputMode = JsonOutputMode.Strict}));
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Task<HttpResponseMessage>.Factory.StartNew(() => response);
        }
    }
}