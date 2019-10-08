using System.Web.Mvc; // for implement : Controller
using server.Models; // UC_CALC_SUB
using Newtonsoft.Json; // JSON ser/des
using System.Linq;
using System;

namespace server.Controllers
{
    public class CalculatorController : Controller
    {
        // POST: calculator/add
        [HttpGet]
        public string add()
        {
            return "<h1>add get</h1>";
        }

        // POST: Calculator/add
        [Route("Calculator/add")]
        [Route("calculator/add")]
        [HttpPost]
        [ActionName("add")]
        public string addPost(AddRequest calc)
        {
            // var total = calc.Addens.Sum();
            var response = new AddResponse();
            response.Sum = server.Server.addOrSumCalc("add", calc.Addens);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/mult
        [Route("Calculator/mult")]
        [Route("calculator/mult")]
        [HttpPost]
        [ActionName("mult")]
        public string multPost(MultRequest calc)
        {
            var response = new MultResponse();
            response.Product = server.Server.addOrSumCalc("mult", calc.Factors);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/sub
        [Route("Calculator/sub")]
        [Route("calculator/sub")]
        [HttpPost]
        [ActionName("sub")]
        public string subPost(SubRequest calc)
        {
            var response = new SubResponse();
            response.Difference = server.Server.subCalc(calc.Minuend, calc.substrahend);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/div
        [Route("Calculator/div")]
        [Route("calculator/div")]
        [HttpPost]
        [ActionName("div")]
        public string divPost(DivRequest calc)
        {
            var response = new DivResponse();
            double[] array = server.Server.divCalc(calc.Dividend, calc.Divisor);
            response.Quotient = array[0];
            response.Remainder = array[1];
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/sqrt
        [Route("Calculator/sqrt")]
        [Route("calculator/sqrt")]
        [HttpPost]
        [ActionName("sqrt")]
        public string sqrtPost(SqrtRequest calc)
        {
            var response = new SqrtResponse();
            response.Square = server.Server.sqrtCalc(calc.Number);
            return JsonConvert.SerializeObject(response);
        }

    }
}