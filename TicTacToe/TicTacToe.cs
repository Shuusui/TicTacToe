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
        private uint Width;
        private uint Height;

        private Fields?[,] Board;

        private Fields? Player;



        public TicTacToe(uint width, uint height, Fields?[,] board, Fields? player)
        {
            this.Width = width;
            this.Height = height;
            this.Board = new Fields?[Width , Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Board[i, j] = board[i, j];
                }
            }
            this.Player = player; 

        }

        public Winner? GetWinner()
        {
            Winner? winner;

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
                    winner = null;

            return winner; 
        }

        public Fields? GetActPlayer()
        {
            return Player; 
        }

        public void SetActPlayer(Fields? player)
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
                   if(Board[i,j] == null)
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
                            sb.Append("/");
                            sb.Append(j.ToString());
                            sb.Append(Fields.cross.ToString());
                            sb.Append(" | ");
                            break;
                        case Fields.circle:
                            sb.Append(i.ToString());
                            sb.Append("/");
                            sb.Append(j.ToString());
                            sb.Append(Fields.circle.ToString());
                            sb.Append(" | ");
                            break;
                        case null:
                            sb.Append(i.ToString());
                            sb.Append("/");
                            sb.Append(j.ToString()); 
                            sb.Append(" none | "); 
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
            Fields?[,] nextBoard = new Fields?[Width, Height]; 
            for (int i = 0; i < Width; i++)
            {
                for(int j = 0; j <Width; j++)
                {
                    nextBoard[i, j] = this.Board[i, j];
                }
            }
            switch (this.Player)
            {
                case Fields.cross:
                    nextBoard[move.XProperty, move.YProperty] = Fields.cross;
                    break;
                case Fields.circle:
                    nextBoard[move.XProperty, move.YProperty] = Fields.circle; 
                    break;

            }
            TicTacToe nextTurn = new TicTacToe(Width, Height, nextBoard, Player == Fields.cross ? Fields.circle : Fields.cross);

            return nextTurn; 
        }

        public Fields? this[Move index]
        {
            get { return Board[index.XProperty, index.YProperty]; }
            set { Board[index.XProperty, index.YProperty] = value; }
        }
    }
}
