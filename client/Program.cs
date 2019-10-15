using System;

namespace client
{
    class Program
    {
        public static int id = -1;

        public static void MainMenu()
        {
            // if the program start, create a file
            // what you want
            // add, sub, mult, div, sqrt, query, exit
            int num = -1;
            int opt = 0;
            Console.WriteLine();
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
            } while (num < 0 && 3 < num);

            switch (num)
            {
                case 0:
                    //i tried to kill the proccess to stop execution
                    break;
                case 1:
                    Client.SignUp();
                    break;
                case 2:
                    Client.SignIn();
                    break;
                case 3:
                    // sign as guest
                    id = -1;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\n\nPlease, introduce one of the following\n");
                    break;
            }

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

                switch (opt)
                {
                    case 0:
                        //i tried to kill the proccess to stop execution
                        break;
                    case 1:
                        // ask for 2 or + double values
                        Client.Addition(id);
                        break;
                    case 2:
                        // ask just for 2 double values
                        Client.Substraction(id);
                        break;
                    case 3:
                        // ask for 2 or + double values
                        Client.Multiplication(id);
                        break;
                    case 4:
                        // ask just for 2 double values
                        Client.Division(id);
                        break;
                    case 5:
                        // ask just for 1 double value
                        Client.SquareRoot(id);
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
