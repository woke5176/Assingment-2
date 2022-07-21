using Assingment2_Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Services
{
    class UpdatePrice
    {
        public List<Coin> PriceChange(List<Coin> coinData,String coinName,float newPrice)
        {
            Hashing h = new Hashing();
            Thread hasher4 = new Thread(() =>
            {

                 h.getBlockHash();
            });
            hasher4.IsBackground = true;
            hasher4.Start();

            foreach (var item in coinData)
            {
                if(item.Name == coinName)
                {
                    item.Price = newPrice;
                }
            }
            return coinData;
        }
    }
}
