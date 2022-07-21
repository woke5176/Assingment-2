using Assingment2_Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Services
{
    class Sell
    {
        public List<Trader> TraderInfoChange(string walletAdress, string coinName, float price, int quantity, List<Trader> traderData)
        {
            Hashing h = new Hashing();
            Thread hasher1 = new Thread(() =>
            {
                h.getBlockHash();
            });
            hasher1.IsBackground = true;
            hasher1.Start();


            foreach (var item in traderData)
            {
                
                if (item.walletAddress == walletAdress)
                {
                    item.money_on_buy += quantity * price;


                    if (item.money_on_buy > item.money_on_sell)
                    {
                        item.gain = (item.money_on_sell - item.money_on_buy);
                        item.gain_status = "Loss";
                    }
                    else
                    {
                        item.gain = (-item.money_on_sell + item.money_on_buy);
                        item.gain_status = "Profit";
                    }


                    if (!(item.tradercoins == null))
                    {
                        if (item.tradercoins.Where(c => c.typeofcoin == coinName).Count() == 0)
                        {

                            Console.WriteLine("Warning !!! You dont have enough coins");
                        }
                        else
                        {

                            foreach (var res in item.tradercoins.Where(c => c.typeofcoin == coinName))
                            {
                                res.units -= quantity;
                            }

                        }
                    }
                    else
                    {
                        item.tradercoins.Add(new CoinOfTrader
                        {
                            typeofcoin = coinName,
                            units = quantity,

                            currentprice = price
                        });
                    }
                }
            }
            return traderData;

        }

        public List<Coin> CoinCollectionChange(string coinName, int quantity, List<Coin> coinData)
        {
            foreach (var item in coinData)
            {
                if (item.Name == coinName)
                {
                    item.Circulating_Supply += quantity;
                }
            }
            return coinData;
        }
    }
}
