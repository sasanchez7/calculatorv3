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

        public Operations Operation { get; private set; }
        public string Calculation { get; private set; }
        public DateTime Date { get; private set; }

    }
}