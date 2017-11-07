using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    struct Move
    {
        private int x;
        private int y; 
        public Move(int x, int y)
        {
            this.x = x;
            this.y = y; 
        }
        public Move MoveProperty
        {
            get { return this; }
        }
        public int XProperty
        {
            get { return x; }
        }
        public int YProperty
        {
            get { return y; }
        }
        override public String ToString()
        {
            return String.Format("{0}/{1} |",x, y);
        }
    }
}
