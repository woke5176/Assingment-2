using Assingment2_Crypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Services
{
    public class AddVolume
    {

        public List<Coin> VolumeChange(List<Coin> coinData,string coinName,long newVolume)
        {
                Hashing h = new Hashing();
            Thread hasher3 = new Thread(() =>
            {
                h.getBlockHash();
            });
            hasher3.IsBackground = true;
            hasher3.Start();
            foreach(var item in coinData)
            {
                if(item.Name == coinName)
                {
                    item.Circulating_Supply += newVolume;
                }
            }
            return coinData;
        }
    }
}
