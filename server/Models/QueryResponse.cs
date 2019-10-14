using System.Collections.Generic;

namespace server.Models
{
    public class QueryResponse
    {
        public int Id { get; set; }
        public IEnumerable<Query> Operations { get; set; }

        public QueryResponse(int Id, IEnumerable<Query> operation)
        {
            this.Id = Id;
            this.Operations = operation;
        }
    }
}
