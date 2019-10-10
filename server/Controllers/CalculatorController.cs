using System.Web.Mvc; // for implement : Controller

using Newtonsoft.Json;

using server.Models;

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
            AddResponse response = server.Server.AddingCalculation(calc.Addens);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/mult
        [Route("Calculator/mult")]
        [Route("calculator/mult")]
        [HttpPost]
        [ActionName("mult")]
        public string MultPost(MultRequest calc)
        {
            MultResponse response = server.Server.MultiplyingCalculation(calc.Factors);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/sub
        [Route("Calculator/sub")]
        [Route("calculator/sub")]
        [HttpPost]
        [ActionName("sub")]
        public string SubPost(SubRequest calc)
        {
            SubResponse response = server.Server.SubtractingCalculation(calc.Minuend, calc.substrahend);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/div
        [Route("Calculator/div")]
        [Route("calculator/div")]
        [HttpPost]
        [ActionName("div")]
        public string DivPost(DivRequest calc)
        {
            DivResponse response = server.Server.DividingCalculation(calc.Dividend, calc.Divisor);
            return JsonConvert.SerializeObject(response);
        }

        // POST: Calculator/sqrt
        [Route("Calculator/sqrt")]
        [Route("calculator/sqrt")]
        [HttpPost]
        [ActionName("sqrt")]
        public string SqrtPost(SqrtRequest calc)
        {
            SqrtResponse response = server.Server.SquareRooCalculation(calc.Number);
            return JsonConvert.SerializeObject(response);
        }

    }
}