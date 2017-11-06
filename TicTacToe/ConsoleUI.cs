using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class ConsoleUI
    {
        public Fields Player;
        public IAI randomAI = new RandomAI();

        public void Play(IGame game)
        {
            Player = game.GetActPlayer();
            while(true)
            {
                if (game.GetWinner() == Winner.none)
                {
                    game = PlayTurn(game);
                }
                else
                {
                    Winner winner = game.GetWinner();
                    Console.WriteLine(winner.ToString());
                    break;
                }
            }
        }

        public IGame PlayTurn(IGame game)
        {
            if (game.GetActPlayer() == Player)
            {
                game.GetMoves();
                String s = game.OutputToString();
                Console.WriteLine(s);
                Console.WriteLine("Gib nun die x Koordinate ein :");
                string x = Console.ReadLine();
                Console.WriteLine("Gib nun die y Koordinate ein :");
                string y = Console.ReadLine();
                Move move = new Move(Int32.Parse(x), Int32.Parse(y));
                game = game.ApplyMove(move);
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
