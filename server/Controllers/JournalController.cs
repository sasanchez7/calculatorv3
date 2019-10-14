using System.Web.Mvc;

using Newtonsoft.Json;

using server.Models;

namespace server.Controllers
{
    public class JournalController : Controller
    {

        // POST: Journal/query
        [Route("Journal/query")]
        [Route("journal/query")]
        [HttpPost]
        [ActionName("query")]
        public string QueryPost(QueryRequest calc)
        {
            QueryResponse response = ServerCalc.readQuery(calc.Id);
            return JsonConvert.SerializeObject(response);
        }

    }
}