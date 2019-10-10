using System.Web.Mvc;

using Newtonsoft.Json;

using server.Models;

namespace server.Controllers
{
    public class JournalController : Controller
    {
        // POST: Calculator/div
        [Route("Journal/query")]
        [Route("Journalr/query")]
        [HttpPost]
        [ActionName("query")]
        public string QueryPost(QueryRequest calc)
        {
            var response = new QueryResponse();
            //string[][] array = server.Server.GetOperationsById(calc.Id);
            //response.Quotient = array[0];
            //response.Remainder = array[1];
            return JsonConvert.SerializeObject(response);
        }
    }
}