using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    enum TypeCard { Color, ColorChar, Ex }
    enum StateCard {Cover, Discover, Taken }
    internal abstract class Card
    {
        public StateCard State { get; set; }
        public override bool Equals(object obj)
        {
            return this.GetType()==obj.GetType()&&IsMatching((Card)obj);
        }
        public abstract bool IsMatching(Card card);
        public abstract void PrintValue();
        public void PrintCard()
        {
            switch (State)
            {
                case StateCard.Cover:
                    {
                        Console.Write("* ");
                        break;
                    }
                case StateCard.Discover:
                    {
                        PrintValue();
                        break;
                    }
                default:
                    {
                        Console.Write("! ");
                        break;
                    }
            }
        }
    }
}