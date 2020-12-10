using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Entities
{
    public class Service
    {
        public string baseURL { get; set; }
        public string datatype { get; set; }
        public bool enabled { get; set; }
        public Endpoint[] endpoints { get; set; }
        public Identifier[] identifiers { get; set; }
    }
}
