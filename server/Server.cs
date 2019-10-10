using System;
using System.Collections.Generic;

using server.Models;

namespace server
{
    public class Server
    {
        public static AddResponse AddingCalculation(double[] values)
        {
            double total = 0;
            for (var i = 0; i < values.Length; i++)
            {
                total += values[i];
            }
            return new AddResponse(total);
        }

        public static MultResponse MultiplyingCalculation(double[] values)
        {
            double total = 1;
            for (var i = 0; i < values.Length; i++)
            {
                total = total * values[i];
            }
            return new MultResponse(total);
        }

        public static IEnumerable<SubResponse> SubtractingCalculation(double minuend, double substrahend)
        {
            var e2 = new List<SubResponse>();
            e2.Add(new SubResponse(minuend - substrahend));
            // you can add as much as you want
            //e2.Add(new SubResponse(minuend - substrahend));
            return e2;
        }

        public static Tuple<DivResponse> DividingCalculation(double dividend, double divisor)
        {
            return Tuple.Create(new DivResponse(dividend / divisor, dividend % divisor));
        }

        public static SqrtResponse SquareRooCalculation(double number)
        {
            return new SqrtResponse(Math.Sqrt(number));
        }

        public static string[] GetOperationsById(int id)
        {
            return new string[] { "dsf", "dfgs" };
        }

    } // class
}
