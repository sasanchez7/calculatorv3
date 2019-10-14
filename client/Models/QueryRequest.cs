namespace client.Models
{
    public class QueryRequest
    {
        public int Id { get; set; }

        public QueryRequest(int Id)
        {
            this.Id = Id;
        }
    }
}
