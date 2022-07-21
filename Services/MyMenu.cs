using Assingment2_Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Services
{
    public  class MyMenu
    {
        My_Queries queries = new My_Queries();

        public bool Menu(List<Coin> coinData,List<Trader> traderData)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Given the name  of a coin, retrieve all its details");
            Console.WriteLine("2) Display top 50 coins in the market based on price");
            Console.WriteLine("3) For a given trader, show his portfolio");
            Console.WriteLine("4) For a given trader, display the total profit or loss they have made trading in the cryptomarket.");
            Console.WriteLine("5) Show top 5 and bottom 5 traders based on their profit/loss");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Name the coin you want to search for ");
                    string inp = Console.ReadLine();
                    queries.DisplayCoin(inp,coinData);
                    return true;
                case "2":
                    queries.TopCoins(coinData);
                    return true;
                case "3":
                    Console.WriteLine("Type the name of the trader you want to search for");
                    string trader_name = Console.ReadLine();
                    queries.DisplayPortfolio(trader_name,traderData);
                    return true;
                case "4":
                    Console.WriteLine("Type the name of the trader  you want to search for");
                    string traders_name = Console.ReadLine();
                    queries.GainOfTrader(traders_name,traderData);
                    return true;
                case "5":
                    queries.PerformanceRaked(traderData);
                    return true;
                default:
                    return true;
            }

        }
    }
}
