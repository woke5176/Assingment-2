using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Crypto.JsonReader
{
    public class JsonData
    {
        public class Data
        {
            public string coin { get; set; }
            public int quantity { get; set; }
            public string wallet_address { get; set; }
            public float price { get; set; }
            public int volume { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public Data data { get; set; }
        }
    }
}
