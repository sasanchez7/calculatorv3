using client.Models;
using System;
using System.IO; // StreamWriter

namespace client
{
    class Program
    {
        public static double[] askForValues()
        {

            return new double[] { 4.5, 5.5 };
        }
        public static void mainMenu()
        {
            // if the program start, create a file

            // sign up, sign in or guest 

            // what you want
            // add, sub, mult, div, sqrt, query, exit
            Console.Title = "CalculatorService by SrG";
            int num = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome and greetings \n");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Substraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division");
                Console.WriteLine("5 - square root\n");
                // (int)(Console.ReadKey().KeyChar);

                ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
                // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    num = int.Parse(UserInput.KeyChar.ToString()); // use Parse if it's a Digit
                    if (num < 0 && 5 < num)
                    {
                        Console.Error.WriteLine("\n\n ERROR! \num choose one of the following: \n\n");
                    }
                }
                else
                {
                    num = -1;
                }
                Console.WriteLine("\nnKey vale {0}\n", num);

                switch (num)
                {
                    case 1:
                        Console.WriteLine("Case 1 - Addition"); // ask for 2 or + double values
                        Client.addition();
                        break;
                    case 2:
                        Console.WriteLine("Case 2 - Substraction"); // ask just for 2 double values
                        Client.substraction();
                        break;
                    case 3:
                        Console.WriteLine("Case 3 - Multiplication"); // ask for 2 or + double values
                        Client.multiplication();
                        break;
                    case 4:
                        Console.WriteLine("Case 4 - Division"); // ask just for 2 double values
                        Client.division();
                        break;
                    case 5:
                        Console.WriteLine("Case 5 - square root"); // ask just for 1 string value
                        Client.squareRoot();
                        break;
                    /*
                    case 6:
                        Console.WriteLine("Case 5 - square root"); // ask just for 1 value
                        Client.squareRoot();
                        break;
                    */
                    default:
                        Console.WriteLine("\nYou should introduce one of the following\n");
                        break;
                }

            } while (num != 0);

            // if exit, destroy all id files
        }
        static void Main(string[] args)
        {
            mainMenu();
            /*
            int num = 0;
            do
            {
                Console.WriteLine("Introduce numero \n");
                num = (int)(Console.ReadKey().KeyChar);
                Console.WriteLine("\nnKey vale {0}", num);
            } while (num != 48);
            */

            // (Array datum, string operation, int id = -1)
            /*
            double[] datam = new double[5] { 1, 2, 3, 4, 5 };

            AddRequest add = new AddRequest()
            {
                Addens = datam
            };
            Client.addRequest(add, 5);

            MultRequest mult = new MultRequest()
            {
                Factors = datam
            };
            Client.multRequest(mult, 5);

            SubRequest sub = new SubRequest()
            {
                Minuend = 5.5,
                substrahend = 2.5
            };
            Client.subRequest(sub, 5);

            DivRequest div = new DivRequest()
            {
                Dividend = 7.1,
                Divisor = 3.5
            };
            Client.divRequest(div, 5);

            //Console.ReadKey();

        */


        }
    }
}
