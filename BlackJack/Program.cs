using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static Player dealer = new Player();
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            currentPlayer.name = Console.ReadLine();
            Console.WriteLine("Welcome to black jack!");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();
            Console.Clear();
            Game.game();
        }

    }
}
