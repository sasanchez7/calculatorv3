using Newtonsoft.Json;// to use Json parse
using System;
using System.IO; // to use StreamWriter
using System.Net; // to use HttpWebRequest
using client.Models;

namespace client
{
    public class Client
    {
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
            // var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:55555/Calculator/"+action);
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

                Console.WriteLine("Sum: " + response.Sum);
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

                Console.WriteLine("Product: " + response.Product);
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
                Console.WriteLine("Difference: " + response.Difference);
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

                Console.WriteLine("Quotient: {0} Remainder: {1}", response.Quotient, response.Remainder);
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

                Console.WriteLine("Square: {0}", response.Square);
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