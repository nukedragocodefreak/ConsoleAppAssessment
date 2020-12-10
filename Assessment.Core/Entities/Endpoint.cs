using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Entities
{
    public class Endpoint
    {
        public bool enabled { get; set; }
        public string resource { get; set; }
        public string method { get; set; }
        public string requestBody { get; set; }
        public Response[] response { get; set; }
    }
}
