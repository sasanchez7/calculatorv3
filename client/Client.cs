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

        public static void Addition()
        {
            Console.Clear();
            Console.WriteLine("ADDITION");

            List<double> valuesList = AskForTwoOrMoreValues();
            double[] values = new double[valuesList.Capacity];
            int i = 0;
            foreach (int value in valuesList)
            {
                values[i++] = value;
            }
            AdditionPetition(new AddRequest(values));
        }
        public static void Substraction()
        {
            Console.Clear();
            Console.WriteLine("SUBSTRACTION");
            Double[] values = AskForJustTwoValues();
            SubtractionPetition(new SubRequest(values[0], values[1]));
        }
        public static void Multiplication()
        {
            Console.Clear();
            Console.WriteLine("MULTIPLICATION");
            List<double> valuesList = AskForTwoOrMoreValues();
            double[] values = new double[valuesList.Count];
            int i = 0;
            foreach (int value in valuesList)
            {
                values[i++] = value;
            }
            MultiplicationPetition(new MultRequest(values));

        }
        public static void Division()
        {
            Console.Clear();
            Console.WriteLine("DIVISION");
            Double[] values = AskForJustTwoValues();
            DivisionPetition(new DivRequest(values[0], values[1]));

        }
        public static void SquareRoot()
        {
            Console.Clear();
            Console.WriteLine("SQUARE ROOT");
            double number;
            string numberStr;
            do
            {
                numberStr = AskForValue();
            } while (!Double.TryParse(numberStr, out number) && number == 0);
            Console.WriteLine("\nCalculating, wait a second please\n");
            SquareRootPetition(new SqrtRequest(number));
        }

        /// <summary>
        /// This method recieves 2 parameters to create an http request  
        /// </summary>
        public static void SendRequest(HttpWebRequest httpWebRequest, string ObjSerialized)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(ObjSerialized);
            }
        }


        /// <summary>
        /// This method recieves 2 parameters to build a http header 
        /// </summary>
        public static HttpWebRequest HeaderBuilder(string controller, string action, int id = -1)
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
        public static void AdditionPetition(AddRequest calc, int id = -1)
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
                }
            }

        }
        #endregion

        #region method_MultiplicationPetition
        public static void MultiplicationPetition(MultRequest calc, int id = -1)
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
        public static void SubtractionPetition(SubRequest calc, int id = -1)
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
        public static void DivisionPetition(DivRequest calc, int id = -1)
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
        public static void SquareRootPetition(SqrtRequest calc, int id = -1)
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


    }
}