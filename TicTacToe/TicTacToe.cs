using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe :IGame
    {
        public const uint Width = 3;
        public const uint Height = 3;

        public Fields[,] Board = new Fields[Width, Height];

        public Fields Player = 0;


        public Winner GetWinner()
        {
            Winner winner;

            bool full  = false; 

            for(int i = 0; i<  Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    if (Board[i, j] == Fields.empty)
                        break;
                    else if (i == Width && j == Height)
                        full = true;

                }
            }
            if (full)
            {
                if (Board[0, 0] == Fields.cross && Board[1, 1] == Fields.cross && Board[2, 2] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[0, 1] == Fields.cross && Board[1, 1] == Fields.cross && Board[2, 1] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[0, 2] == Fields.cross && Board[1, 1] == Fields.cross && Board[2, 0] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[0, 0] == Fields.cross && Board[1, 0] == Fields.cross && Board[2, 0] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[0, 2] == Fields.cross && Board[1, 2] == Fields.cross && Board[2, 2] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[0, 0] == Fields.circle && Board[1, 1] == Fields.circle && Board[2, 2] == Fields.circle)
                    winner = Winner.circle;
                else if (Board[0, 1] == Fields.circle && Board[1, 1] == Fields.circle && Board[2, 1] == Fields.circle)
                    winner = Winner.circle;
                else if (Board[0, 2] == Fields.circle && Board[1, 1] == Fields.circle && Board[2, 0] == Fields.circle)
                    winner = Winner.circle;
                else if (Board[0, 0] == Fields.circle && Board[1, 0] == Fields.circle && Board[2, 0] == Fields.circle)
                    winner = Winner.circle;
                else if (Board[0, 2] == Fields.circle && Board[1, 2] == Fields.circle && Board[2, 2] == Fields.circle)
                    winner = Winner.circle;
                else
                    winner = Winner.remis;
            }
            else
                return winner = Winner.none;

            return winner; 
        }

        public Fields GetActPlayer()
        {
            return Player; 
        }

        public void SetActPlayer(Fields player)
        {
            Player = player; 
        }




        public Move[] GetMoves()
        {
            Move[] move = new Move[Width*Height]; 
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j <Height; j++)
                {
                   if(Board[i,j] == Fields.empty)
                    {
                        move[i + j] = new Move(i, j);                        
                    }
                }
            }
            return move; 
        }

        public String OutputToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    switch(Board[i,j])
                    {
                        case Fields.cross:
                            sb.Append(i.ToString());
                            sb.Append(j.ToString());
                            sb.Append(Fields.cross.ToString()); 
                            break;
                        case Fields.circle:
                            sb.Append(i.ToString());
                            sb.Append(j.ToString());
                            sb.Append(Fields.circle.ToString());
                            break;
                        case Fields.empty:
                            sb.Append(i.ToString());
                            sb.Append(j.ToString()); 
                            sb.Append(Fields.empty.ToString()); 
                            break;
                    }
                }
            }
            return sb.ToString();
        }

        public IGame ApplyMove(Move move)
        {
            TicTacToe nextTurn = new TicTacToe();
            for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j <Width; j++)
                {
                    nextTurn.Board[i, j] = this.Board[i, j];
                }
            }
            switch (this.Player)
            {
                case Fields.cross:
                    nextTurn.Board[move.x, move.y] = Fields.cross;
                    break;
                case Fields.circle:
                    nextTurn.Board[move.x, move.y] = Fields.circle; 
                    break;

            }
            if (Player == Fields.cross)
                nextTurn.SetActPlayer(Fields.circle);
            else if (Player == Fields.circle)
                nextTurn.SetActPlayer(Fields.cross);


            return nextTurn; 
        }
    }
}
