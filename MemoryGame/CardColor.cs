using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class CardColor : Card
    {
        public ConsoleColor Color { get; set; }
        public CardColor(ConsoleColor color)
        {
            this.Color = color;
        }
        public static List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 16; i++)
            {
                cards.Add(new CardColor((ConsoleColor)i));
            }
            return cards;
        }
        public override void PrintValue()
        {
            Console.BackgroundColor = Color;
            Console.Write("#");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public override bool IsMatching(Card card)
        {
            return Color == ((CardColor)card).Color;
        }
    }
}
