using System.Web.Mvc;
using server.Models;
using Newtonsoft.Json;

namespace server.Controllers
{
    public class JournalController : Controller
    {
        // POST: Calculator/div
        [Route("Journal/query")]
        [Route("Journalr/query")]
        [HttpPost]
        [ActionName("query")]
        public string queryPost(QueryRequest calc)
        {
            var response = new QueryResponse();
            string[][] array = server.Server.getOperationsById(calc.Id);
            //response.Quotient = array[0];
            //response.Remainder = array[1];
            return JsonConvert.SerializeObject(response);
        }
    }
}