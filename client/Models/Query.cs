using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace client.Models
{
    public class Query
    {
        public enum Operations
        {
            Unknown = 0,
            Add = 1,
            Sub = 2,
            Div = 3,
            Mult = 4,
            Sqrt = 5
        }

        public Operations Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }

        public Query()
        {
        }

        public Query(Operations Operation, string calculation, DateTime Date)
        {
            this.Operation = Operation;
            this.Calculation = calculation;
            this.Date = Date;
        }

        public Query(Query query)
        {
            this.Operation = query.Operation;
            this.Calculation = query.Calculation;
            this.Date = query.Date;
        }

    }
}