using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tzoker.Results.Models;
using Newtonsoft.Json.Linq;

namespace Tzoker.Results.Base
{
    public class Draw:IDraw
    {
        public DateTime Date { get; set; }
        public Header Header { get; set; }
        public PrizeCategory[] Prizes { get; set; }
        public Draw(string Json, int NumOfResults)
        {
            ParseJson(Json, NumOfResults);
        }

        public void ParseJson(string Json, int NumOfResults)
        {
            this.Header = new Header(Json);

            dynamic jsonVal = JValue.Parse(Json);
            dynamic Result = jsonVal.prizes;

            this.Prizes = new PrizeCategory[NumOfResults];

            this.Date = Convert.ToDateTime(jsonVal.date.ToString());

            JArray jsonArr = JArray.Parse(Result.ToString()) as JArray;

            for (int i = 0; i < jsonArr.Count - 1; i++)
            {
                this.Prizes[i] = new PrizeCategory(jsonArr[i]);
            }
        }
    }
}
