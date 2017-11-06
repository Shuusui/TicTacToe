﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class RandomAI : IAI
    {

        public Random rand = new Random();

        public Move SelectMove(IGame game)
        {
            Move[] move = game.GetMoves();
            int x = rand.Next(move.Length);

            return move[x]; 
        }
    }
}
