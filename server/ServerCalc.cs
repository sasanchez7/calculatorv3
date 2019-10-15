using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using server.Models;
using System.Web.Script.Serialization;
using System.Linq;

namespace server
{
    public class ServerCalc
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

        public static QueryResponse GetOperationsById(int id)
        {
            throw new NotImplementedException();
        }

        public static double[] CleanArrayOfZeroValues(double[] array)
        {
            var listOfNumbers = new List<double>();

            foreach (double number in array)
                if (number != 0)
                    listOfNumbers.Add(number);


            return listOfNumbers.ToArray();
        }


        public static QueryResponse readQuery(int id)
        {
            string folder = "Data"; // your code goes here
            // check if folder exist, and if dont he creates it
            // Directory.CreateDirectory(folder);
            string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string path2 = $@"..\..\Users\{currentUser}\Documents\Visual Studio 2015\Projects\CalculatorV3\server\Data\allquerys.json";
            string path3 = String.Format(@"..\..\Users\{0}\Documents\Visual Studio 2015\Projects\CalculatorV3\server\Data\allquerys.json", currentUser);

            string path = @"C:\Users\Sergio\Documents\Visual Studio 2015\Projects\CalculatorV3\server\Data\allquerys.json";

            List<Query> items = new List<Query>();

            using (StreamReader streamReader = new StreamReader(path))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {

                    var item = JsonConvert.DeserializeObject<History>(line, new Newtonsoft.Json.Converters.StringEnumConverter());

                    if (item != null && id == item.Id)
                    {
                        var query = new Query(item.Query);
                        items.Add(query);
                    }
                }
            }

            QueryResponse response = new QueryResponse(id, items);

            return response;
        }

        public static void writeQuery(int id, Query query)
        {
            // comprobar si existe la carpeta y crearla
            string path = String.Format(@"..\..\Users\{0}\Documents\Visual Studio 2015\Projects\CalculatorV3\server\Data\allquerys.json", Environment.UserName);

            if (id != -1)
            {
                if (File.Exists(path))
                {
                    using (var writetext = new StreamWriter(path, true))
                    {
                        // escribir en el fichero
                        var operation = JsonConvert.SerializeObject(new History(id, query), new Newtonsoft.Json.Converters.StringEnumConverter());
                        writetext.WriteLine(operation);
                    }
                }
            }

        } // class
    }
}