using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class CardColorChar : CardColor
    {
        public char Icon { get; set; }
        public CardColorChar(ConsoleColor color, char icon) : base(color)
        {
            this.Icon = icon;
        }
        public static List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 16; i++)
            {
                cards.Add(new CardColorChar((ConsoleColor)i, (char)(i + 'A')));
            }
            return cards;
        }
        public override void PrintValue()
        {
            Console.BackgroundColor = Color;
            Console.Write(Icon+" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public override bool IsMatching(Card card)
        {
            return base.IsMatching(card)&&Icon==((CardColorChar)card).Icon;
        }
    }
}
