using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;

using Newtonsoft.Json;

using server.Models;


namespace server
{
    public class ServerCalc
    {
        public static string ROOT = Directory.GetCurrentDirectory();
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
            string path = String.Format(@"C:\Users\{0}\Documents\allquerys.json", Environment.UserName);

            List<Query> items = new List<Query>();

            if (!File.Exists(path))
            {
                using (var stream = File.Create(path)) { }
            }

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
            string path = String.Format(@"C:\Users\{0}\Documents\allquerys.json", Environment.UserName);

            if (id != -1)
            {
                using (var writetext = new StreamWriter(path, true))
                {
                    var operation = JsonConvert.SerializeObject(new History(id, query), new Newtonsoft.Json.Converters.StringEnumConverter());
                    writetext.WriteLine(operation);
                }

            }

        } // class

        public static int getIdHeader(NameValueCollection headerRequest)
        {
            foreach (string key in headerRequest.AllKeys)
            {
                Console.WriteLine("\t{0}:{1}", key, headerRequest[key]);
                if (key == "X-Evi-Tracking-Id")
                {
                    return Int32.Parse(headerRequest[key]);
                }
            }
            return -1;
        }
    }
}