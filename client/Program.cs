using client.Models;
using System;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            // (Array datum, string operation, int id = -1)
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

            Console.ReadKey();


            // if the program start, create a file

            // sign up, sign in or guest 

            // what you want
            // add, sub, mult, div, sqrt, query, exit

            // if exit, destroy all id files


        }
    }
}
