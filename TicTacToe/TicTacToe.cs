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
        
        public IEnumerable<Move> GetPlayerFields(Fields? player)
        {
            Move move; 
            for (int i = 0; i< Width; i++)
                for (int j = 0; j <Height; j++)
                {
                    if (Board[i, j] == player)
                        yield return move = new Move(i, j);
                }
        }
        public Winner? GetWinner()
        {
            IEnumerable<IEnumerable<Move>> rows = GetRows();
            IEnumerable<IEnumerable<Move>> columns = GetColumns();
            var query = rows.Concat(columns).Concat(GetDiagonals());

            if (query.Any(row => row.All(move => this[move] == Fields.cross)))
                return Winner.cross;
            else if (query.Any(row => row.All(move => this[move] == Fields.circle)))
                return Winner.circle;
            else if (query.Any(row => row.Any(move => this[move] == null)))
                return null;
            else
                return Winner.remis;
        }

        public Fields? GetActPlayer()
        {
            return Player; 
        }

        public void SetActPlayer(Fields? player)
        {
            Player = player; 
        }
        public IEnumerable<Move> GetMoves()
        {
            return GetPlayerFields(null); 
        }
        private IEnumerable<Move>GetLine(Move StartPosition, int x, int y)
        {
            int actX = StartPosition.XProperty, actY = StartPosition.YProperty;
            
            for (int i = 0; i < Width; i++)
            {
                if (actY < Height && actX < Width && actX >= 0 && actY >= 0)
                    yield return new Move(StartPosition.XProperty + actX, StartPosition.YProperty + actY);
                else break;
                actX += x;
                actY += y;
            }
        }
        public IEnumerable<IEnumerable<Move>> GetRows()
        {
            for (int i = 0; i < Height; i++)
            {
                yield return GetLine(new Move(0, i), 1, 0);
            }
        }

        public IEnumerable<IEnumerable<Move>> GetColumns()
        {
            for(int i = 0; i < Width; i++)
            {
                yield return GetLine(new Move(i, 0), 0, 1);
            }
        }

        public IEnumerable<IEnumerable<Move>> GetDiagonals()
        {
            yield return GetLine(new Move(0, 0), 1, 1);
            yield return GetLine(new Move(0, 2), 1, -1);
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
