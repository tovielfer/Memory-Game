using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class CardEx:Card
    {
        static Random rnd = new Random();
        public string Ex { get; set; }
        public string Solution { get; set; }

        static char[] operators = { '+', '-', ':' };
        public bool isEx { get; set; }
        public CardEx(int num,char op)
        {
            Solution = num.ToString();
            int  x=op=='+'?rnd.Next(0,num):op=='-'?rnd.Next(num,num+20):num*rnd.Next(1,10);
            Ex = x + "" + op;
            Ex+=op=='+'?(num-x).ToString():op=='-'?(x-num).ToString():(x/num).ToString();
        }
        public override void PrintValue()
        {
            Console.Write( isEx ?" "+Ex+" ":" "+Solution+" ");
        }
        public override bool IsMatching(Card card)
        {
            return this.Solution == ((CardEx)card).Solution;
        }
        public static List<Card> GetCards()
        {
            List<Card> cards = new List<Card>();
            for (int i = 1; i <= 16; i++)
            {
                cards.Add(new CardEx(i, operators[rnd.Next(0,3)]));
            }
            return cards;
        }
    }
}
