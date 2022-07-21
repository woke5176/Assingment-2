using Assingment2_Crypto.Models;
using Assingment2_Crypto.Services;
using CsvHelper.Configuration;
using System.Globalization;
using System.Threading;
using System.Text.Json;
using static Assingment2_Crypto.JsonReader.JsonData;

namespace Assingment2_Crypto
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Coin> coinData = new List<Coin>();
            List<Trader> traderData = new List<Trader>();
            List<Root> transactionData = new List<Root>();

            var reader = new StreamReader(@"D:\Assingment2_Crypto\CsvData\coins.csv");
            var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            coinData = csv.GetRecords<Coin>().ToList();


            var reader1 = new StreamReader(@"D:\Assingment2_Crypto\CsvData\traders.csv");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null

            };

            var csv1 = new CsvHelper.CsvReader(reader1, config);
            traderData = csv1.GetRecords<Trader>().ToList();

        
                        
                         
                             string filename = @"D:\Assingment2_Crypto\JsonData\test_transaction.json";
                             string jsonString = File.ReadAllText(filename);
                             transactionData = JsonSerializer.Deserialize<List<Root>>(jsonString);
                      

            Buy b = new Buy();
            Sell s = new Sell();
            UpdatePrice up = new UpdatePrice();
            AddVolume av = new AddVolume();

            Thread transact = new Thread(() => { 
            foreach (var item in transactionData)
            {
                if (item.type == "BUY")
                {
                    foreach (var i in coinData)
                    {
                        if (i.Symbol == item.data.coin)
                        {
                            ThreadStart buy_thread = new ThreadStart(() =>
                           {
                               traderData = b.TraderInfoChange(item.data.wallet_address, item.data.coin, i.Price, item.data.quantity, traderData);
                               coinData = b.CoinCollectionChange(item.data.coin, item.data.quantity, coinData);
                           });
                                Thread thread_buy = new Thread(buy_thread);
                                thread_buy.Start();
                        }
                    }


                }


                if (item.type == "SELL")
                {

                    foreach (var i in coinData)
                    {
                        if (i.Symbol == item.data.coin)
                        {
                            ThreadStart sell_thread = new ThreadStart(
                                () => { traderData = b.TraderInfoChange(item.data.wallet_address, item.data.coin, i.Price, item.data.quantity, traderData);
                                    coinData = s.CoinCollectionChange(item.data.coin, item.data.quantity, coinData);
                                });
                                Thread thread_sell = new Thread(sell_thread);
                                thread_sell.Start();

                            }

                    }

                }

                if (item.type == "UPDATE_PRICE")
                {
                    foreach (var i in coinData)
                    {

                        if (i.Symbol == item.data.coin)
                        {
                            ThreadStart update_thread = new ThreadStart(
                           () =>
                           {
                               coinData = up.PriceChange(coinData, item.data.coin, item.data.price);
                           });
                                Thread thread_up = new Thread(update_thread);
                                thread_up.Start();
                            }

                    }

                }

                if (item.type == "Add_VOLUME")

                {
                    ThreadStart add_vol_thread = new ThreadStart(
                          () =>
                          {
                              coinData = av.VolumeChange(coinData, item.data.coin, item.data.volume);
                          });
                        Thread thread_ad = new Thread(add_vol_thread);
                        thread_ad.Start();
                    }

            }
             });
            
            transact.Start();

            MyMenu menu = new MyMenu();
            bool showMenu = true;
            
                ThreadStart menu_thread = new ThreadStart(() =>
                {
                    while (showMenu)
                    {
                        showMenu = menu.Menu(coinData, traderData);
                    }
                });
                Thread menu_th = new Thread(menu_thread);
                menu_th.Start();

            }


        }






    }
  
