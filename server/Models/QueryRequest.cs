namespace server.Models
{
    public class QueryRequest
    {
        public int Id { get; set; }

        public QueryRequest()
        {

        }

        public QueryRequest(int Id)
        {
            this.Id = Id;
        }
    }
}
