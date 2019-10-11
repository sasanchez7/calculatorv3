using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using server.Models;



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
        /*
        public static QueryResponse GetOperationsById(int id)
        {
            return new QueryResponse("dsf", "dfgs");
        }
        */

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
            string path = @"C:\Users\Sergio\Documents\Visual Studio 2015\Projects\CalculatorV3\server\Data\allquerys.json";

            List<QueryResponse> items = new List<QueryResponse>();

            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                // tw.WriteLine("The very first line!");
                tw.Close();
            }

            using (StreamReader r = new StreamReader(path))
            {
                string jsonstr = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<QueryResponse>>(jsonstr);
            }



            QueryResponse response = items[id];

            return response;
        }

        public static bool writeQuery(int id, Query.Operations calc, string calculation, DateTime Date)
        {
            Query query = new Query(calc, calculation, Date);
            string folder = "Data"; // your code goes here
            // check if folder exist, and if dont he creates it
            Directory.CreateDirectory(folder);
            string path = "Data/allquerys.json";

            List<QueryResponse> items = new List<QueryResponse>();

            using (StreamReader r = new StreamReader(path))
            {
                string jsonstr = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<QueryResponse>>(jsonstr);
                // añades lo que vaya a escribir
                // serializas y escribes otra vez
            }
            // items[id].Operations = items[id].Operations + query;
            List<Query> numberList = new List<Query>();
            numberList.Add(items[id].Operations);
            response2.Operations = response2.Operations + query;

            string json = JsonConvert.SerializeObject(items[id]);
            // check if file exist
            // if dont, create it
            // if exist, write in it
            // check if exist the id
            // if exist: get the values that it already had and add the new 
            // if dont: agregar un nuevo id al dictionary y insertar los valores
            return true;
        }

    } // class
}
