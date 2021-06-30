using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    
    class Game
    {
        static Random random = new Random();
        public static void game()
        {
            Console.WriteLine("How much are you betting?");
            Console.WriteLine($"Current Player Chips: {Program.currentPlayer.chips}");
            int bet = Convert.ToInt32(Console.ReadLine());
            if (bet > Program.currentPlayer.chips)
            {
                Console.WriteLine("You don't have the right number of chips");
                game();
            }
            else if (Program.currentPlayer.chips == 0)
            {
                Console.WriteLine("You are out of chips. Game over");
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"You are betting {bet} chips.");
                Play(bet);
            }
        }
        public static void Play(int bet)
        {
            Program.currentPlayer.cardValue += random.Next(1, 12);
            Program.currentPlayer.cardValue += random.Next(1, 12);
            if (Program.currentPlayer.cardValue > 21)
            {
                Program.currentPlayer.cardValue -= 10;
            }
            else if (Program.currentPlayer.cardValue == 21)
            {
                Console.WriteLine("Congratulations you hit blackjack");
                Console.WriteLine($"Winnings: {bet}");
                Program.currentPlayer.chips += bet;
            }
            Program.dealer.cardValue += random.Next(1, 12);
            Program.dealer.cardValue += random.Next(1, 12);
            if (Program.dealer.cardValue > 21)
            {
                Program.dealer.cardValue -= 10;
            }
            else if (Program.dealer.cardValue == 21)
            {
                Console.WriteLine("Unlucky");
                Program.currentPlayer.chips -= bet;
            }
            choice(bet);
        }
        public static void choice(int bet)
        {
            Display();
            dealerDisplay();
            Console.WriteLine("(h)it    (s)tay");
            string input = Console.ReadLine();
            switch (input)
            {
                case "h":
                case "hit":
                    Console.WriteLine($"The dealer deals a card");
                    int card = random.Next(1, 12);
                    Console.WriteLine(card);
                    Program.currentPlayer.cardValue += card;
                    Console.WriteLine($"Player: {Program.currentPlayer.cardValue} card value");
                    if (Program.currentPlayer.cardValue == 21)
                    {
                        Console.WriteLine($"Congratulations you hit 21 and win {bet} chips!");
                        Program.currentPlayer.chips += bet;
                        Program.currentPlayer.cardValue = 0;
                        Program.dealer.cardValue = 0;
                        Console.ReadKey(); Console.Clear();
                        game();
                        break;
                    }
                    else if (Program.currentPlayer.cardValue > 21)
                    {
                        Console.WriteLine($"You busted and lost {bet} chips");
                        Program.currentPlayer.chips -= bet;
                        Program.currentPlayer.cardValue = 0;
                        Console.ReadKey(); Console.Clear();
                        game();
                        break;
                    }
                    else
                    {
                        choice(bet);
                    }
                    break;
                case "s":
                case "stay":
                    stay(bet);
                    break;
                default:
                    Console.WriteLine("Enter a valid response");
                    Console.ReadKey(); Console.Clear();
                    choice(bet);
                    break;
            }
        }
        public static void stay(int bet)
        {
            Console.WriteLine("You choose to stay. The dealer deals a card");
            int dcard = random.Next(1, 12);
            Console.WriteLine(dcard);
            Program.dealer.cardValue += dcard;
            Console.WriteLine($"Dealer: {Program.dealer.cardValue} card value");
            if (Program.dealer.cardValue > 21)
            {
                Console.WriteLine($"The Dealer busted and you won {bet} chips");
                Program.currentPlayer.chips += bet;
                Program.currentPlayer.cardValue = 0;
                Program.dealer.cardValue = 0;
                Console.ReadKey(); Console.Clear();
                game();

            }
            else if (Program.dealer.cardValue > Program.currentPlayer.cardValue)
            {
                Console.WriteLine("The Dealer beat your hand.");
                Program.currentPlayer.chips -= bet;
                Program.currentPlayer.cardValue = 0;
                Program.dealer.cardValue = 0;
                Console.ReadKey(); Console.Clear();
                game();
                
            }
            else if (Program.dealer.cardValue == Program.currentPlayer.cardValue)
            {
                Console.WriteLine("The dealer ties with you");
                Program.currentPlayer.cardValue = 0;
                Program.dealer.cardValue = 0;
                Console.ReadKey(); Console.Clear();
                game();

            }
            else if (Program.dealer.cardValue == 21)
            {
                Console.WriteLine($"The Dealer hit 21 and you lost {bet} chips!");
                Program.currentPlayer.chips -= bet;
                Program.currentPlayer.cardValue = 0;
                Program.dealer.cardValue = 0;
                Console.ReadKey(); Console.Clear();
                game();
            }
            else
            {
                stay(bet);
            }
        } 
        public static void Display()
        {
            Console.WriteLine($"{Program.currentPlayer.name} card value: {Program.currentPlayer.cardValue}");
        }
        public static void dealerDisplay()
        {
            Console.WriteLine($"dealer card value: {Program.dealer.cardValue}");
        }
    }

}
