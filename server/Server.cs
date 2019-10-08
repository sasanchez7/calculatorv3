using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server
{
    public class Server
    {
        public static double addOrSumCalc(string operation, double[] values)
        {
            double result = 0;
            switch (operation)
            {
                case "add":
                    for (var i = 0; i < values.Length; i++)
                    {
                        result += values[i];
                    }
                    return result;
                case "mult":
                    result = 1;
                    for (var i = 0; i < values.Length; i++)
                    {
                        result = result * values[i];
                    }
                    return result;
            }
            return -1;
        }

        public static double subCalc(double minuend, double substrahend)
        {
            return minuend - substrahend;
        }

        public static double[] divCalc(double dividend, double divisor)
        {
            return new double[] { dividend / divisor, dividend % divisor };
        }

        public static double sqrtCalc(double number)
        {
            return Math.Sqrt(number);
        }

        public static string[] getOperationsById(int id)
        {
            return new string[] { "dsf", "dfgs" };
        }

    } // class
}
