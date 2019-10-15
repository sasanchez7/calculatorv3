using System;
using System.IO;
using System.Net; // to use HttpWebRequest
using System.Collections.Generic;

using Newtonsoft.Json;

using client.Models;

namespace client
{
    public class Client
    {
        public static bool idExists(int id)
        {
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
                        return true;
                    }
                }
            }
            return false;
        }

        public static void SignUp()
        {

            Console.WriteLine("\n\nSIGN UP");
            int id;
            string numberStr;
            do
            {
                numberStr = AskForValue();

                if (!Int32.TryParse(numberStr, out id))
                    Console.WriteLine("\n Please, enter only numerical values\n");

            } while (!Int32.TryParse(numberStr, out id) && id == -1);
            Console.WriteLine("\nchecking whether the ID entered can be assigned...\n");
            // call sign up function that
            // check if id exits that if
            if (idExists(id))
            {
                // does exist, tell him to ask another id or exit 
                Console.WriteLine("\nthis number exist, please introduce another one\n");
                SignUp();
            }
            else
                // doesnt exist, let me sign up and keep going with the program
                Program.id = id;
        }

        public static void SignIn()
        {

            Console.WriteLine("\n\nSIGN IN");
            int id;
            string numberStr;
            do
            {
                numberStr = AskForValue();

                if (!Int32.TryParse(numberStr, out id))
                    Console.WriteLine("\n Please, enter only numerical values\n");

            } while (!Int32.TryParse(numberStr, out id) && id == -1);
            Console.WriteLine("\nchecking if you can login with that ID...\n");

            // check if id exits that if
            if (idExists(id))
                // does exist, sign in 
                Program.id = id;
            else
            {
                // doesnt exist, ask for a id again or exit
                Console.WriteLine("\nthis number doesnt exist, please introduce another one that does\n");
                SignIn();
            }
        }

        public static string AskForValue()
        {
            Console.Write("Enter the number that you want:");
            return Console.ReadLine();
        }
        public static double[] AskForJustTwoValues()
        {
            double[] twoValues = new double[2];
            for (int i = 0; i < 2; i++)
            {
                bool fail;
                do
                {
                    fail = false;
                    Console.Write("Enter the parameter number {0}:", i + 1);
                    string numberStr = Console.ReadLine();
                    double number;
                    if (Double.TryParse(numberStr, out number))
                    {
                        // Console.WriteLine("'{0}' --> {1}", numberStr, number);
                        if (number > 0)
                        {
                            twoValues[i] = number;
                        }
                        if (number == 0 && twoValues.Length >= 1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unable to parse '{0}'.", numberStr);
                        fail = true;
                    }
                } while (fail == true);
            }
            Console.WriteLine("\nCalculating, wait a second please\n");
            return twoValues;
        }
        public static List<double> AskForTwoOrMoreValues()
        {
            bool fail;
            double number;
            List<double> values = new List<double>();

            Console.WriteLine("\nREMINDER: Enter 0 to stop adding parameters and calculate\n");
            do
            {
                fail = false;
                Console.Write("Enter parameters that you want to calculate: ");
                string numberStr = Console.ReadLine();
                // string numberStr = "5";

                if (Double.TryParse(numberStr, out number))
                {
                    // Console.WriteLine("'{0}' --> {1}", numberStr, number);
                    fail = false;
                    if (number > 0)
                    {
                        values.Add(number);
                    }
                    else
                    {
                        fail = true;
                    }
                    if (number == 0 && values.Count >= 2)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Unable to parse '{0}'.", numberStr);
                    fail = true;
                }

            } while (fail == true || number > 0);
            Console.WriteLine("\nCalculating, wait a second please\n");
            return values;
        }

        public static void Addition(int id)
        {
            Console.Clear();
            Console.WriteLine("ADDITION");

            List<double> valuesList = AskForTwoOrMoreValues();
            double[] values = valuesList.ToArray();

            AdditionPetition(new AddRequest(values), id);

            // quicktest
            // double[] values = { 5, 5, 5 };
            // AdditionPetition(new AddRequest(values), 1);
        }
        public static void Substraction(int id)
        {
            Console.Clear();
            Console.WriteLine("SUBSTRACTION");
            Double[] values = AskForJustTwoValues();
            SubtractionPetition(new SubRequest(values[0], values[1]), id);
        }
        public static void Multiplication(int id)
        {
            Console.Clear();
            Console.WriteLine("MULTIPLICATION");
            List<double> valuesList = AskForTwoOrMoreValues();
            double[] values = valuesList.ToArray();
            MultiplicationPetition(new MultRequest(values), id);

        }
        public static void Division(int id)
        {
            Console.Clear();
            Console.WriteLine("DIVISION");
            Double[] values = AskForJustTwoValues();
            DivisionPetition(new DivRequest(values[0], values[1]), id);

        }
        public static void SquareRoot(int id)
        {
            Console.Clear();
            Console.WriteLine("SQUARE ROOT");
            double number;
            string numberStr;
            do
            {
                numberStr = AskForValue();

                if (!Double.TryParse(numberStr, out number))
                    Console.WriteLine("\n Please, enter only numerical values\n");

            } while (!Double.TryParse(numberStr, out number) && number == 0);
            Console.WriteLine("\nCalculating, wait a second please\n");
            SquareRootPetition(new SqrtRequest(number), id);
        }

        public static void JournalQuery()
        {
            Console.Clear();
            Console.WriteLine("JOURNAL QUERY");
            int number;
            string numberStr;
            do
            {
                numberStr = AskForValue();

                if (!Int32.TryParse(numberStr, out number))
                    Console.WriteLine("\n Please, enter only numerical values\n");

            } while (!Int32.TryParse(numberStr, out number) && number == 0);
            Console.WriteLine("\nCalculating, wait a second please\n");
            JournalQueryPetition(new QueryRequest(number), number);
        }

        /// <summary>
        /// This method recieves 2 parameters to create an http request  
        /// </summary>
        public static void SendRequest(HttpWebRequest httpWebRequest, string ObjSerialized)
        {
            httpWebRequest.ContentLength = ObjSerialized.Length;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(ObjSerialized);
            }
        }


        /// <summary>
        /// This method recieves 2 parameters to build a http header 
        /// </summary>
        public static HttpWebRequest HeaderBuilder(string controller, string action, int id)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:55555/" + controller + "/" + action);
            httpWebRequest.ProtocolVersion = HttpVersion.Version11; // could fail
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            if (id != -1 && action != "query")
            {
                httpWebRequest.Headers["X-Evi-Tracking-Id"] = id.ToString();
            }
            return httpWebRequest;
        }

        #region method_AddingPetition
        public static void AdditionPetition(AddRequest calc, int id)
        {
            try
            {
                var httpWebRequest = HeaderBuilder("Calculator", "add", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                SendRequest(httpWebRequest, json);

                // get response from the server
                AddResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<AddResponse>(result);
                }

                Console.WriteLine("Sum: " + response.Sum + "\n\npress enter to continue.");
                Console.ReadKey();
            }
            // handle error exceptions
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    Console.WriteLine(text);
                }
            }

        }
        #endregion

        #region method_MultiplicationPetition
        public static void MultiplicationPetition(MultRequest calc, int id)
        {
            try
            {
                var httpWebRequest = HeaderBuilder("Calculator", "mult", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                SendRequest(httpWebRequest, json);

                // get response from the server
                MultResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<MultResponse>(result);
                }

                Console.WriteLine("Product: " + response.Product + "\n\npress enter to continue.");
                Console.ReadKey();
            }
            // handle error exceptions
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }

        } // class
        #endregion

        #region method_SubtractionPetition
        public static void SubtractionPetition(SubRequest calc, int id)
        {
            try
            {
                // change
                var httpWebRequest = HeaderBuilder("Calculator", "sub", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                SendRequest(httpWebRequest, json);

                // get response from the server
                // change
                SubResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    // change
                    response = JsonConvert.DeserializeObject<SubResponse>(result);
                }

                // change
                Console.WriteLine("Difference: " + response.Difference + "\n\npress enter to continue.");
                Console.ReadKey();
            }
            // handle error exceptions
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }

        } // class
        #endregion

        #region method_DivisionPetition
        public static void DivisionPetition(DivRequest calc, int id)
        {
            try
            {
                var httpWebRequest = HeaderBuilder("Calculator", "div", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                SendRequest(httpWebRequest, json);

                // get response from the server
                DivResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DivResponse>(result);
                }

                Console.WriteLine("Quotient: {0} Remainder: {1}", response.Quotient, response.Remainder + "\n\npress enter to continue.");
                Console.ReadKey();

            }
            // handle error exceptions
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }

        } // class
        #endregion

        #region method_SquareRootPetition
        public static void SquareRootPetition(SqrtRequest calc, int id)
        {
            try
            {
                var httpWebRequest = HeaderBuilder("Calculator", "sqrt", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                SendRequest(httpWebRequest, json);

                // get response from the server
                SqrtResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<SqrtResponse>(result);
                }

                Console.WriteLine("Square: {0}", response.Square + "\n\npress enter to continue.");
                Console.ReadKey();
            }
            // handle error exceptions
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }

        } // class
        #endregion


        public static void JournalQueryPetition(QueryRequest calc, int id)
        {
            try
            {
                var httpWebRequest = HeaderBuilder("Journal", "query", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                SendRequest(httpWebRequest, json);

                // get response from the server
                QueryResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<QueryResponse>(result);
                }
                Console.WriteLine("Type of calc; Operation; Date;");
                foreach (Query qry in response.Operations)
                {
                    Console.WriteLine($"{qry.Calculation} | {qry.Operation} | {qry.Date}");
                }
                Console.WriteLine("\n\npress enter to continue.");
                Console.ReadKey();
            }
            // handle error exceptions
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                }
            }

        } // class

    }
}