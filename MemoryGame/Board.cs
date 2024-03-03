using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Board
    {
        static Random  rnd=new Random();
        public List<Card> BoardCards { get; set; }
        public Board()
        {
            Console.WriteLine("how many pairs do you want in the board?");
            int pairs = int.Parse(Console.ReadLine());
            while(pairs<1||pairs>16)
            {
                Console.WriteLine("the amount of the pairs must be between 1 and 16, enter again");
                pairs = int.Parse(Console.ReadLine());
            }
            Console.Write("what kind of game do you want? ");
            var t =Enum.GetValues(typeof(TypeCard));
            foreach (Enum item in t)
            {
                Console.Write("enter "+item.GetHashCode() + " to " + item + " ,");
            }
            Console.WriteLine();
           // Console.WriteLine("what kind of game do you want? 0 to color cards, 1 to color and char, and 2 to exercise");
            TypeCard type=(TypeCard)int.Parse(Console.ReadLine());
            Card[] b = new Card[pairs * 2];
            GetListCards(pairs,type).CopyTo(0, b, 0, pairs);
            if(type==TypeCard.Ex)
            for (int i = 0; i < pairs; i++)
            {
                ((CardEx)b[i]).isEx = true;
            }
            GetListCards(pairs, type).CopyTo(0, b, pairs, pairs);
            BoardCards = b.OrderBy(c => rnd.Next()).ToList();
        }
        public List<Card> GetListCards(int pairs, TypeCard type)
        {
            var list = new List<Card>();
            switch (type)
            {
                case TypeCard.Color:
                    {
                        list = CardColor.GetCards();
                        break;
                    }
                case TypeCard.ColorChar:
                    {
                        list = CardColorChar.GetCards();
                        break;
                    }
                default:
                    {
                        list = CardEx.GetCards();
                        break;
                    }
            }
            return list;                                   
        }
        public void PrintBoard()
        {
            for (int i = 0; i < BoardCards.Count; i++)
            {
                BoardCards[i].PrintCard();
            }
            Console.WriteLine();
        }
        public bool PlaceIsValid(int place)
        {
            return place > 0 && place <= BoardCards.Count() && BoardCards[place - 1].State == StateCard.Cover;
        }
        public bool ThereAreCards()
        {
            for (int i = 1; i <= BoardCards.Count(); i++)
            {
                if (PlaceIsValid(i))
                    return true;
            }
            return false;
        }
    }
}
