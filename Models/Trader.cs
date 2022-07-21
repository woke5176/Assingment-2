using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Models
{
     public class Trader
    {
        public Trader()
        {
            tradercoins = new List<CoinOfTrader>();
        }
        [Name("first_name")]
        public string? firstName { get; set; }
        [Name("last_name")]
        public string? lastName { get; set; }
        [Name("phone")]
        public string? phone { get; set; }
        [Name("Wallet Address")]
        public string? walletAddress { get; set; }

        public float? money_on_buy { get; set; } =0;

        public float? money_on_sell { get; set; } = 0;

        public float? gain { get; set; } = 0;

        public string? gain_status { get; set; } = "";

        public List<CoinOfTrader> tradercoins;

        

    }
}
