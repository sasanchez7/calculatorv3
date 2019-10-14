using System.Collections.Generic;
using client.Models;

namespace client.Models
{
    public class QueryResponse
    {
        public int Id { get; set; }
        public IEnumerable<Query> Operations { get; set; }
    }
}
