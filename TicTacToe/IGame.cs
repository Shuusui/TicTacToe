﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IGame
    {
        Winner? GetWinner();
        Fields? GetActPlayer();
        void SetActPlayer(Fields? player);
        IEnumerable<Move> GetMoves();
        String OutputToString();
        IGame ApplyMove(Move move);
        IEnumerable<Move> GetPlayerFields(Fields? player);
    }
}
