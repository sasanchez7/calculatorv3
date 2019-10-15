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
        // POST: Calculator/add
        [Route("Calculator/add")]
        [Route("calculator/add")]
        [HttpPost]
        [ActionName("add")]
        public string AddPost(AddRequest calc)
        {
            var headerRequest = this.Request.Headers;
            int id = ServerCalc.getIdHeader(headerRequest);

            calc.Addens = server.ServerCalc.CleanArrayOfZeroValues(calc.Addens);

            AddResponse response = server.ServerCalc.AddingCalculation(calc.Addens);

            if (id != -1)
            {
                var fecha = DateTime.UtcNow;
                fecha.ToString("O");
                Query addquery = new Query(Operations.Add, string.Join("+", calc.Addens) + "=" + response.Sum, fecha);
                ServerCalc.writeQuery(id, addquery);
            }

            return JsonConvert.SerializeObject(response, new Newtonsoft.Json.Converters.StringEnumConverter());
        }

        // POST: Calculator/mult
        [Route("Calculator/mult")]
        [Route("calculator/mult")]
        [HttpPost]
        [ActionName("mult")]
        public string MultPost(MultRequest calc)
        {
            var headerRequest = this.Request.Headers;
            int id = ServerCalc.getIdHeader(headerRequest);

            MultResponse response = server.ServerCalc.MultiplyingCalculation(calc.Factors);

            if (id != -1)
            {
                var fecha = DateTime.UtcNow;
                fecha.ToString("O");
                Query addquery = new Query(Operations.Mult, string.Join("*", calc.Factors) + "=" + response.Product, fecha);
                ServerCalc.writeQuery(id, addquery);
            }

            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/sub
        [Route("Calculator/sub")]
        [Route("calculator/sub")]
        [HttpPost]
        [ActionName("sub")]
        public string SubPost(SubRequest calc)
        {
            var headerRequest = this.Request.Headers;
            int id = ServerCalc.getIdHeader(headerRequest);

            IEnumerable<SubResponse> someCollection = server.ServerCalc.SubtractingCalculation(calc.Minuend, calc.substrahend);
            var list = someCollection.Cast<SubResponse>().ToList();

            if (id != -1)
            {
                var fecha = DateTime.UtcNow;
                fecha.ToString("O");
                Query addquery = new Query(Operations.Sub, $"{calc.Minuend}-{calc.substrahend}={list[0].Difference}", fecha);
                ServerCalc.writeQuery(id, addquery);
            }

            return JsonConvert.SerializeObject(list[0]);
        }

        // POST: Calculator/div
        [Route("Calculator/div")]
        [Route("calculator/div")]
        [HttpPost]
        [ActionName("div")]
        public string DivPost(DivRequest calc)
        {
            var headerRequest = this.Request.Headers;
            int id = ServerCalc.getIdHeader(headerRequest);

            var response = server.ServerCalc.DividingCalculation(calc.Dividend, calc.Divisor);

            if (id != -1)
            {
                var fecha = DateTime.UtcNow;
                fecha.ToString("O");
                Query addquery = new Query(Operations.Div, $"{calc.Dividend}-{calc.Divisor}={response.Item1.Quotient}c-{response.Item1.Remainder}", fecha);
                ServerCalc.writeQuery(id, addquery);
            }

            return JsonConvert.SerializeObject(response.Item1);
        }

        // POST: Calculator/sqrt
        [Route("Calculator/sqrt")]
        [Route("calculator/sqrt")]
        [HttpPost]
        [ActionName("sqrt")]
        public string SqrtPost(SqrtRequest calc)
        {
            var headerRequest = this.Request.Headers;
            int id = ServerCalc.getIdHeader(headerRequest);

            SqrtResponse response = server.ServerCalc.SquareRooCalculation(calc.Number);

            if (id != -1)
            {
                var fecha = DateTime.UtcNow;
                fecha.ToString("O");
                Query addquery = new Query(Operations.Sqrt, $"√{calc.Number}={response.Square}", fecha);
                ServerCalc.writeQuery(id, addquery);
            }

            return JsonConvert.SerializeObject(response);
        }

        // GET: calculator/add
        [HttpGet]
        public string Add()
        {
            return "<h1>add get</h1>";
        }

    }
}