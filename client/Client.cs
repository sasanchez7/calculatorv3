using Newtonsoft.Json;// to use Json parse
using System;
using System.IO; // to use StreamWriter
using System.Net; // to use HttpWebRequest
using client.Models;
using System.Collections.Generic;

namespace client
{
    public class Client
    {
        public static string askForValue()
        {
            Console.WriteLine("Enter the number that you want:");
            return Console.ReadLine();
        }
        public static double[] askForJustTwoValues()
        {
            double[] twoValues = new double[2];
            for (int i = 0; i < 2; i++)
            {
                bool fail;
                do
                {
                    Console.WriteLine("Enter the parameter number {0}:", i + 1);
                    string numberStr = Console.ReadLine();
                    double number;
                    if (Double.TryParse(numberStr, out number))
                    {
                        // Console.WriteLine("'{0}' --> {1}", numberStr, number);
                        fail = false;
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
        public static List<double> askForTwoOrMoreValues()
        {
            bool fail;
            double number;
            List<double> values = new List<double>();

            Console.WriteLine("\nREMINDER: Enter 0 to stop adding parameters and calculate\n");
            do
            {
                Console.WriteLine("Enter parameters that you want to calculate: ");
                string numberStr = Console.ReadLine();

                if (Double.TryParse(numberStr, out number) && number != 0)
                {
                    // Console.WriteLine("'{0}' --> {1}", numberStr, number);
                    fail = false;
                    values.Add(number);
                }
                else
                {
                    Console.WriteLine("Unable to parse '{0}'.", numberStr);
                    fail = true;
                }
            } while (fail == true || number == 0 && values.Capacity >= 2);
            Console.WriteLine("\nCalculating, wait a second please\n");
            return values;
        }

        public static void addition()
        {
            Console.Clear();
            Console.WriteLine("ADDITION");

            List<double> valuesList = askForTwoOrMoreValues();
            double[] values = new double[valuesList.Capacity];
            int i = 0;
            foreach (int value in valuesList)
            {
                values[++i] = value;
            }
            addRequest(new AddRequest(values));
        }
        public static void substraction()
        {
            Console.Clear();
            Console.WriteLine("SUBSTRACTION");
            Double[] values = askForJustTwoValues();
            subRequest(new SubRequest(values[0], values[1]));
        }
        public static void multiplication()
        {
            Console.Clear();
            Console.WriteLine("MULTIPLICATION");
            List<double> valuesList = askForTwoOrMoreValues();
            double[] values = new double[valuesList.Capacity];
            int i = 0;
            foreach (int value in valuesList)
            {
                values[++i] = value;
            }
            multRequest(new MultRequest(values));

        }
        public static void division()
        {
            Console.Clear();
            Console.WriteLine("DIVISION");
            Double[] values = askForJustTwoValues();
            divRequest(new DivRequest(values[0], values[1]));

        }
        public static void squareRoot()
        {
            Console.Clear();
            Console.WriteLine("SQUARE ROOT");
            double number;
            string numberStr;
            do
            {
                numberStr = askForValue();
            } while (!Double.TryParse(numberStr, out number) && number == 0);
            Console.WriteLine("\nCalculating, wait a second please\n");
            sqrtRequest(new SqrtRequest(number));
        }

        /// <summary>
        /// This method recieves 2 parameters to create an http request  
        /// </summary>
        public static void sendRequest(HttpWebRequest httpWebRequest, string ObjSerialized)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(ObjSerialized);
            }
        }


        /// <summary>
        /// This method recieves 2 parameters to build a http header 
        /// </summary>
        public static HttpWebRequest headerBuilder(string controller, string action, int id = -1)
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

        #region method_add_Request
        public static void addRequest(AddRequest calc, int id = -1)
        {
            try
            {
                var httpWebRequest = headerBuilder("Calculator", "add", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                sendRequest(httpWebRequest, json);

                // get response from the server
                AddResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<AddResponse>(result);
                }

                Console.WriteLine("Sum: " + response.Sum + "\n press two times enter if you wont to continue.");
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

        #region method_mult_request
        public static void multRequest(MultRequest calc, int id = -1)
        {
            try
            {
                var httpWebRequest = headerBuilder("Calculator", "mult", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                sendRequest(httpWebRequest, json);

                // get response from the server
                MultResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<MultResponse>(result);
                }

                Console.WriteLine("Product: " + response.Product + "\n press two times enter if you wont to continue.");
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

        #region method_sub_request
        public static void subRequest(SubRequest calc, int id = -1)
        {
            try
            {
                // change
                var httpWebRequest = headerBuilder("Calculator", "sub", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                sendRequest(httpWebRequest, json);

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
                Console.WriteLine("Difference: " + response.Difference + "\n press two times enter if you wont to continue.");
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

        #region method_div_request
        public static void divRequest(DivRequest calc, int id = -1)
        {
            try
            {
                var httpWebRequest = headerBuilder("Calculator", "div", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                sendRequest(httpWebRequest, json);

                // get response from the server
                DivResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DivResponse>(result);
                }

                Console.WriteLine("Quotient: {0} Remainder: {1}", response.Quotient, response.Remainder + "\n press two times enter if you wont to continue.");
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

        #region method_sqrt_request
        public static void sqrtRequest(SqrtRequest calc, int id = -1)
        {
            try
            {
                var httpWebRequest = headerBuilder("Calculator", "sqrt", id);

                string json = JsonConvert.SerializeObject(calc);

                // send request
                sendRequest(httpWebRequest, json);

                // get response from the server
                SqrtResponse response = null;
                // var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<SqrtResponse>(result);
                }

                Console.WriteLine("Square: {0}", response.Square + "\n press two times enter if you wont to continue.");
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