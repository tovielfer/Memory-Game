using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class HumanPlayer:Player
    {
        public HumanPlayer()
        {
            Console.WriteLine("what is the name of the player?");
            Name=Console.ReadLine();
        }
        public override int ChoosePlace(int range)
        {
            Console.WriteLine(Name+" ,choose a place between 1 and "+range);
            return int.Parse(Console.ReadLine());
        }
    }
}
