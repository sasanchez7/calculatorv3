using System;
using System.Linq;
using System.Web;
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

        public static SubResponse SubtractingCalculation(double minuend, double substrahend)
        {
            return new SubResponse(minuend - substrahend);
        }

        public static DivResponse DividingCalculation(double dividend, double divisor)
        {
            return new DivResponse(dividend / divisor, dividend % divisor);
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
