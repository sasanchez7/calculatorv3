using client.Models;
using System;

namespace client
{
    class Program
    {
        public static int num = -1;

        public static int singingAs(int num)
        {
            return num;
        }

        public static void MainMenu()
        {
            // if the program start, create a file
            // what you want
            // add, sub, mult, div, sqrt, query, exit
            int opt = 0;
            Console.Title = "CalculatorService by SrG";
            Console.WriteLine("Welcome and greetings \n");
            do
            {
                // sign up, sign in or guest 
                Console.WriteLine("What you want to do?");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Sign up");
                Console.WriteLine("2 - Sign in");
                Console.WriteLine("3 - Sign as a guest");

                ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
                                                              // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    num = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }

                if (num < -1 || num > 3)
                {
                    Console.Clear();
                    Console.WriteLine("\nPlease, introduce one of the following\n");
                }

            } while (num < 0 || num > 3);

            do
            {
                Console.Clear();
                Console.WriteLine("\nWhat do you want to do?\n");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Substraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - Square root");
                Console.WriteLine("6 - Journal query\n");
                // (int)(Console.ReadKey().KeyChar);

                ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
                                                              // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    opt = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                }

                Console.WriteLine("\nnKey vale {0}\n", opt);

                switch (opt)
                {
                    case 0:
                        //i tried to kill the proccess to stop execution
                        break;
                    case 1:
                        // ask for 2 or + double values
                        Client.Addition();
                        break;
                    case 2:
                        // ask just for 2 double values
                        Client.Substraction();
                        break;
                    case 3:
                        // ask for 2 or + double values
                        Client.Multiplication();
                        break;
                    case 4:
                        // ask just for 2 double values
                        Client.Division();
                        break;
                    case 5:
                        // ask just for 1 double value
                        Client.SquareRoot();
                        break;
                    case 6:
                        // ask just for 1 int value
                        Client.JournalQuery();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n\nPlease, introduce one of the following\n");
                        break;
                }

            } while (opt != 0);


            // if exit, destroy all num files
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}
