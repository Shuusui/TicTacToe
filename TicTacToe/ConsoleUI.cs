using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ConsoleUI
    {
        public Fields? Player;
        public IAI randomAI = new RandomAI();

        public void Play(IGame game)
        {
            Winner? winner; 
            Player = game.GetActPlayer();
            while(true)
            {
                if (game.GetMoves().Count != 0)
                {
                    game = PlayTurn(game);
                    winner = game.GetWinner();
                    if (winner.HasValue)
                        break;
                }
                else
                    break;
            }
            winner = game.GetWinner();
            if (!winner.HasValue)
                winner = Winner.remis;
            Console.WriteLine(winner.ToString());
        }

        public IGame PlayTurn(IGame game)
        {
            if (game.GetActPlayer() == Player)
            {
                String moves = String.Join(",", game.GetMoves());
                Console.WriteLine(moves);
                String s = game.OutputToString();
                Console.WriteLine(s);
                Console.WriteLine("Gib nun die x Koordinate ein :");
                string x = Console.ReadLine();
                Console.WriteLine("Gib nun die y Koordinate ein :");
                string y = Console.ReadLine();
                Move move = new Move(Int32.Parse(x), Int32.Parse(y));
                game = game.ApplyMove(move);
                Console.Clear();
                return game;
            }
            else
            {
                game = game.ApplyMove(randomAI.SelectMove(game));
                return game;
            }
        }


    }
}
