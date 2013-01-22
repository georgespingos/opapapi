using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tzoker.Results.Models;
using Tzoker.Results.Base;

namespace Tzoker.Results.Controllers
{
    public class LottoController : ApiController
    {
        /// <summary>
        /// Returns the summary of the draw, including the winning numbers.
        /// </summary>
        /// <param name="id">The drawId as it appears on the ticket, eg: 1351</param>
        /// <returns>JSON with the summary of the draw</returns>
        [HttpGet]
        public Header GetSummary(int id)
        {
            Header h = new Header(new Lib.Helper(id, LottoDraw.URL).JsonResponse);
            return h;
        }
        /// <summary>
        /// Returns detailed draw results for the given draw.
        /// </summary>
        /// <param name="id">The drawId as it appears on the ticket, eg: 1351</param>
        /// <returns>JSON draw details object</returns>
        [HttpGet]
        public Draw GetDetails(int id)
        {
            Draw d = new LottoDraw(new Lib.Helper(id, LottoDraw.URL).JsonResponse, LottoDraw.NumOfResults);
            return d;
        }
    }
}
