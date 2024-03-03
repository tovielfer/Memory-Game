using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    
    internal class ComputerPlayer:Player
    {
        Random random = new Random();
        public ComputerPlayer()
        {
             Name = "computer";
        }
        public override int ChoosePlace(int range)
        {
            return random.Next(1, range + 1); 
        }
    }
}
