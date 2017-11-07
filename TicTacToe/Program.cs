using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    enum Fields { cross, circle};
    enum Winner { cross, circle, remis };


    class Program
    {
       
        static void Main(string[] args)
        {
            IGame tictactoe = new TicTacToe(3,3,new Fields?[3,3], null);
            ConsoleUI ui = new ConsoleUI();
            while (tictactoe.GetActPlayer() == null)
            {
                Console.WriteLine("Welchen Spieler möchtest du wählen? Druecke 1 für Kreuz oder 2 für Kreis");
                string s = Console.ReadLine();
                int x = Int32.Parse(s);
                if (x != 1 && x != 2)
                    continue;
                else if (x == 1)
                    tictactoe.SetActPlayer(Fields.cross);
                else
                    tictactoe.SetActPlayer(Fields.circle);

            }
            ui.Play(tictactoe);
            Console.ReadKey(); 
        }
    }
}
