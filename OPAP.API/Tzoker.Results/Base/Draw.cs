using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tzoker.Results.Models;
using Newtonsoft.Json.Linq;
using Tzoker.Results.Models.Base;

namespace Tzoker.Results.Base
{
    public class Draw : Entity, IDraw
    {

        public DateTime Date { get; set; }
        public Header Header { get; set; }
        public PrizeCategory[] Prizes { get; set; }
        public string ResultType { get; private set; }
        public int DrawNumber { get; set; }


        public Draw(string Json, int NumOfResults, DrawType _Type)
            : base(_Type)
        {
            ParseJson(Json, NumOfResults);
            this.ResultType = "Details";
            this.DrawNumber = Header.DrawNumber;
        }

        public void ParseJson(string Json, int NumOfResults)
        {
            this.Header = new Header(Json, this.Type);

            dynamic jsonVal = JValue.Parse(Json);
            dynamic Result = jsonVal.prizes;

            this.Prizes = new PrizeCategory[NumOfResults];

            this.Date = Lib.Helper.ToGreekDate(jsonVal.date.ToString());

            JArray jsonArr = JArray.Parse(Result.ToString()) as JArray;

            for (int i = 0; i < jsonArr.Count; i++)
            {
                this.Prizes[i] = new PrizeCategory(jsonArr[i]);
            }
        }

    }
}
