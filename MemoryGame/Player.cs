using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal abstract class Player
    {
        public int Score { get; set; }
        public List<Card> PrivateCards { get; set; } = new List<Card>();
        public string Name { get; protected set; }
        public abstract int ChoosePlace (int range);
    }
}
