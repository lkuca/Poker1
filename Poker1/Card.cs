using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker1
{
    public class Card
    {
        public enum SUIT
        {
            heart,
            diamond,
            club,
            spade
        }

        public SUIT MySuit { get; set; }
        public string MyValue { get; set; }
    }
}
