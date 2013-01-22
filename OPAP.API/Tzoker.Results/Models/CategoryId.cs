using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Tzoker.Results.Models
{
    public class CategoryId
    {
        public int GameCd { get; set; }
        public int DrawCd { get; set; }
        public int CatId { get; set; }

        public CategoryId(dynamic Json)
        {
            dynamic jsonVal = JValue.Parse(Json);
            dynamic Result = jsonVal;
            this.CatId = Convert.ToInt32(Result.categoryCd.ToString());
            this.DrawCd = Convert.ToInt32(Result.drawCd.ToString());
            this.GameCd = Convert.ToInt32(Result.gameCd.ToString());
        }
    }
}