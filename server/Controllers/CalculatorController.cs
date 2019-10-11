using System;
using System.Web.Mvc; // for implement : Controller
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using server.Models;
using static server.Models.Query;

namespace server.Controllers
{
    public class CalculatorController : Controller
    {
        // POST: calculator/add
        [HttpGet]
        public string Add()
        {
            return "<h1>add get</h1>";
        }

        // POST: Calculator/add
        [Route("Calculator/add")]
        [Route("calculator/add")]
        [HttpPost]
        [ActionName("add")]
        public string AddPost(AddRequest calc)
        {
            // var total = calc.Addens.Sum();
            var headerRequest = this.Request.Headers;
            int id = -1;
            foreach (string key in headerRequest.AllKeys)
            {
                Console.WriteLine("\t{0}:{1}", key, headerRequest[key]);
                if (key == "X-Evi-Tracking-Id")
                {
                    id = Int32.Parse(headerRequest[key]);
                }
            }

            calc.Addens = server.ServerCalc.CleanArrayOfZeroValues(calc.Addens);
            var fecha = DateTime.UtcNow;
            fecha.ToString("o");
            Console.WriteLine(fecha);


            AddResponse response = server.ServerCalc.AddingCalculation(calc.Addens);
            // Query.Operations sum = Query.Operations.Sum;
            // server.ServerCalc.writeQuery(id, Query.Operations.Sum, string.Join("+", calc.Addens) + "=" + response.Sum, fecha);
            QueryResponse response2 = server.ServerCalc.readQuery(id);

            if (id != -1)
            {
                // mandar a escribir la petición, donde al metodo le tendre que pasar la peticion 
            }

            return JsonConvert.SerializeObject(response,
                new Newtonsoft.Json.Converters.StringEnumConverter());

            //return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/mult
        [Route("Calculator/mult")]
        [Route("calculator/mult")]
        [HttpPost]
        [ActionName("mult")]
        public string MultPost(MultRequest calc)
        {
            MultResponse response = server.ServerCalc.MultiplyingCalculation(calc.Factors);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/sub
        [Route("Calculator/sub")]
        [Route("calculator/sub")]
        [HttpPost]
        [ActionName("sub")]
        public string SubPost(SubRequest calc)
        {
            IEnumerable<SubResponse> someCollection = server.ServerCalc.SubtractingCalculation(calc.Minuend, calc.substrahend);
            var list = someCollection.Cast<SubResponse>().ToList();
            return JsonConvert.SerializeObject(list[0]);
        }

        // POST: Calculator/div
        [Route("Calculator/div")]
        [Route("calculator/div")]
        [HttpPost]
        [ActionName("div")]
        public string DivPost(DivRequest calc)
        {
            var response = server.ServerCalc.DividingCalculation(calc.Dividend, calc.Divisor);
            return JsonConvert.SerializeObject(response.Item1);
        }

        // POST: Calculator/sqrt
        [Route("Calculator/sqrt")]
        [Route("calculator/sqrt")]
        [HttpPost]
        [ActionName("sqrt")]
        public string SqrtPost(SqrtRequest calc)
        {
            SqrtResponse response = server.ServerCalc.SquareRooCalculation(calc.Number);
            return JsonConvert.SerializeObject(response);
        }

    }
}