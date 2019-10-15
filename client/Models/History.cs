using System;

namespace client.Models
{
    public class History
    {
        public int Id { get; set; }
        public Query Query { get; set; }

        public History(int Id, Query Query)
        {
            this.Id = Id;
            this.Query = Query;
        }
    }
}