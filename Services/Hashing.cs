using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.Services
{
    public class Hashing
    {
        public  void getBlockHash()
        {
            String SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder transactionHash = new StringBuilder();
            Random rnd = new Random();
            for (double i = 0; i < 199999999; i++)
            {
                i = i;
            }
            while (transactionHash.Length < 128)
            {
                int index = (int)(rnd.NextSingle() * SALTCHARS.Length);
                transactionHash.Append(SALTCHARS.ElementAt(index));
            }
          
        }
    }
}
