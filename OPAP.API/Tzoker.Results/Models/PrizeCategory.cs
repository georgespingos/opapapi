using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Tzoker.Results.Models
{
    public class PrizeCategory
    {
        public CategoryId Id { get; set; }
        public decimal Divident { get; set; }
        public int Winners { get; set; }
        public decimal WinningAmount { get; set; }
        public decimal Jackpot { get; set; }
        public decimal FixedWinningAmount { get; set; }

        public PrizeCategory(dynamic JsonPrize)
        {
            dynamic jsonVal = JValue.Parse(JsonPrize.ToString());
            dynamic Prize = jsonVal;
            this.Divident = Convert.ToDecimal(Prize.divident.ToString());
            this.FixedWinningAmount = Convert.ToDecimal(Prize.fixedWinningAmount.ToString());
            this.Jackpot = Convert.ToDecimal(Prize.jackpot.ToString());
            this.Winners = Convert.ToInt32(Prize.winners.ToString());
            this.WinningAmount = Convert.ToDecimal(Prize.winningAmount.ToString());
            this.Id = new CategoryId(Prize.id.ToString());
        }
    }
}