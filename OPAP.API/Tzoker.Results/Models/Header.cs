using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Tzoker.Results.Models
{
    public class Header
    {
        public int Id { get; set; }
        public int DrawNumber { get; set; }
        public int ColumnPrice { get; set; }
        public int Status { get; set; }
        public int TotalColumns { get; set; }
        public int TotalColumns1 { get; set; }
        public string Results { get; set; }
        public DateTime DrawDate { get; set; }

        public Header(string JSONResult)
        {
            dynamic jsonVal = JValue.Parse(JSONResult);
            dynamic ResultHeader = jsonVal;
            this.DrawNumber = Convert.ToInt32(ResultHeader.header.drawNumber.ToString());
            this.Id = Convert.ToInt32(ResultHeader.header.id.ToString());
            this.Status = Convert.ToInt32(ResultHeader.header.status.ToString());
            this.TotalColumns = Convert.ToInt32(ResultHeader.header.totalColumns.ToString());
            this.TotalColumns1 = Convert.ToInt32(ResultHeader.header.totalColumns1.ToString());
            this.Results = ResultHeader.header.results.ToString();
            this.DrawDate = Convert.ToDateTime(ResultHeader.date.ToString());
        }
    }
}