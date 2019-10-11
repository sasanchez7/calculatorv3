using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class Query
    {
        public enum Operations
        {
            Unknown = 0,
            Sum = 1,
            Sub = 2,
            Div = 3,
            Mult = 4,
            Sqrt = 5
        }

        private Operations Operation;
        private string Calculation;
        private DateTime Date;

        public Query(Operations Operation, string calculation, DateTime Date)
        {
            this.Operation = Operation;
            this.Calculation = calculation;
            this.Date = Date;
        }
    }
}