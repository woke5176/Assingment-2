using Assingment2_Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Services
{
    public class My_Queries
    {
       

        public void DisplayCoin(string coinName,List<Coin> coinData)
    {
        var ans = coinData.Where(c => (c.Name == coinName) || (c.Symbol == coinName));
        foreach (var i in ans)
        {
            Console.WriteLine(" Name: " + i.Name);
            Console.WriteLine(" Symbol: " + i.Symbol);
            Console.WriteLine("Current Price: " + i.Price);
            Console.WriteLine(" Volume Present: " + i.Circulating_Supply);
            Console.WriteLine(" Ranking: " + i.Rank);

        }

    }

    public void TopCoins(List<Coin> coinData)
    {
        var ans = coinData.OrderByDescending(p => p.Price).Take(50);
        int itr = 1;
        foreach (var i in ans)
        {
            Console.WriteLine(itr++ + " " + i.Name);

        }
    }

    public void DisplayPortfolio(string name, List<Trader> traderData)
    {

        var res = traderData.Where(n => (n.firstName + " " + n.lastName) == name);
        foreach (var i in res)
        {

            Console.WriteLine(i.firstName + " " + i.lastName);
            Console.WriteLine(i.walletAddress);
            Console.WriteLine(i.phone);

        }
    }

    public void GainOfTrader(string trader_name, List<Trader> traderData)
    {

        var res = traderData.Where(n => (n.firstName + " " + n.lastName) == trader_name);
        foreach (var i in res)
        {
            Console.WriteLine("The trader " + trader_name + " has made a " + i.gain_status + " of " + (i.gain > 0 ? i.gain : -i.gain));
        }
    }

    public void PerformanceRaked(List<Trader> traderData)
    {
        var top = traderData.Where(x => x.gain_status == "Profit").OrderByDescending(x => x.gain).Take(5);
        Console.WriteLine("Top Five Traders are: ");
        foreach (var item in top)
        {
            Console.WriteLine(item.firstName + " " + item.lastName);

        }
        var bot = traderData.Where(x => x.gain_status == "Loss").OrderByDescending(x => x.gain).Take(5);
        Console.WriteLine("Worst 5 traders are: ");
        foreach (var item in bot)
        {
            Console.WriteLine(item.firstName + " " + item.lastName);

        }
    }

}
}
