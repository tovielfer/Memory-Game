using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryGame
{
    internal class Game
    {
        List<Player> players=new List<Player>();
        public Board BoardGame { get; set; }
        public int CurrentPlayer { get; set; }
        public Game()
        {
            BeginGame();
        }
        public void BeginGame()
        {
            InitPlayers();
            CurrentPlayer = 0;
            BoardGame = new Board();
            Play();
        }
        public void Play()
        {           
            Console.Clear();
            Console.WriteLine("start the game!!!!!!!!!!!!!!!!");
            Thread.Sleep(1000);
            Console.Clear();
            int indexCard1, indexCard2;
            while (BoardGame.ThereAreCards())
            {
                BoardGame.PrintBoard();
                indexCard1 = ChooseCard();
                indexCard2 = ChooseCard();
                if (BoardGame.BoardCards[indexCard1].Equals(BoardGame.BoardCards[indexCard2]))
                    WasFoundMatch(indexCard1, indexCard2);
                else
                {
                    BoardGame.BoardCards[indexCard1].State = StateCard.Cover;
                    BoardGame.BoardCards[indexCard2].State = StateCard.Cover;
                    Console.WriteLine("the cards don't match");
                }
                CurrentPlayer = CurrentPlayer < players.Count() - 1 ? CurrentPlayer + 1 : 0;
                Thread.Sleep(1500);
                Console.Clear();
            }
            EndGame();
        }
        public void EndGame()
        {
            var maxScore = players.Max(p => p.Score);
            var winners = players.Where(p => p.Score == maxScore);
            foreach (Player item in winners)
            {
                Console.WriteLine(item.Name + " is the winner!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("your cards are:");
                item.PrivateCards.ForEach(c => c.PrintValue());
                Console.WriteLine();
            }
        }
        public void InitPlayers()
        {
            Console.WriteLine("how many players do you want in your game?");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                players.Add(CreatePlayer());
            }
        }
        public Player CreatePlayer()
        {
            Console.WriteLine("what kind of player do you want? 0 to computer, 1 to human");
            if (int.Parse(Console.ReadLine()) == 0)
                return new ComputerPlayer();
            return new HumanPlayer();
        }
        public void WasFoundMatch(int index1,int index2)
        {
            players[CurrentPlayer].Score++;
            Console.WriteLine(players[CurrentPlayer].Name+" ,very nice!! your score is " + players[CurrentPlayer].Score);
            Thread.Sleep(1000);
            players[CurrentPlayer].PrivateCards.Add(BoardGame.BoardCards[index1]);
            BoardGame.BoardCards[index1].State = StateCard.Taken;
            BoardGame.BoardCards[index2].State = StateCard.Taken;
        }
        public int ChooseCard()
        {
            int place=players[CurrentPlayer].ChoosePlace(BoardGame.BoardCards.Count());
            while (!BoardGame.PlaceIsValid(place))
            {
                if (players[CurrentPlayer] is HumanPlayer)
                    Console.WriteLine("this place is not valid");
                place = players[CurrentPlayer].ChoosePlace(BoardGame.BoardCards.Count());
            }
            if (players[CurrentPlayer] is ComputerPlayer)
                Console.WriteLine("the computer chose place: " + place);
            BoardGame.BoardCards[place-1].State = StateCard.Discover;
            BoardGame.PrintBoard();            
            Thread.Sleep(2000);
            return place-1;
        }

    }
}
