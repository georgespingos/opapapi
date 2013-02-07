using System;
using System.Collections.Generic;using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tzoker.Results.Base;
using Tzoker.Results.Models;

namespace Tzoker.Results.Controllers
{
    public class Super3Controller : ApiController
    {
        /// <summary>
        /// Returns the summary of the draw, including the winning numbers.
        /// </summary>
        /// <param name="id">The drawId as it appears on the ticket, eg: 1351</param>
        /// <returns>JSON with the summary of the draw</returns>
        [HttpGet]
        public Header GetSummary(int id)
        {
            Header h = new Header(new Lib.Helper(id, Super3Draw.URL).JsonResponse, Models.Base.Entity.DrawType.Super3);
            h.Insert<Header>(h);
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
            Draw d = new Super3Draw(new Lib.Helper(id, Super3Draw.URL).JsonResponse, Super3Draw.NumOfResults);
            d.Insert<Draw>(d);
            return d;
        }
    }
}
