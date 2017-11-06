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
                else if (Board[0, 0] == Fields.cross && Board[0, 1] == Fields.cross && Board[0, 2] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[1, 0] == Fields.cross && Board[1, 1] == Fields.cross && Board[1, 2] == Fields.cross)
                    winner = Winner.cross;
                else if (Board[2, 0] == Fields.cross && Board[2, 1] == Fields.cross && Board[2, 2] == Fields.cross)
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
                else if (Board[0, 0] == Fields.circle && Board[0, 1] == Fields.circle && Board[0, 2] == Fields.circle)
                    winner = Winner.circle;
                else if (Board[1, 0] == Fields.circle && Board[1, 1] == Fields.circle && Board[1, 2] == Fields.circle)
                    winner = Winner.circle;
                else if (Board[2, 0] == Fields.circle && Board[2, 1] == Fields.circle && Board[2, 2] == Fields.circle)
                    winner = Winner.circle;
                else
                    winner = Winner.none;

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




        public IList<Move> GetMoves()
        {
            IList<Move> move = new List<Move>();
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j <Height; j++)
                {
                   if(Board[i,j] == Fields.empty)
                    {
                        Move tempMove = new Move(i, j);
                        move.Add(tempMove);

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
                    if (j == 2)
                        sb.AppendLine();
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
                    nextTurn.Board[move.XProperty, move.YProperty] = Fields.cross;
                    break;
                case Fields.circle:
                    nextTurn.Board[move.XProperty, move.YProperty] = Fields.circle; 
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
