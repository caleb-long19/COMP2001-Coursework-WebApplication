using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2001___RESTful_API.Models
{
    public class ApiResponse
    {
        public Int32 code { get; set; }
        public string type { get; set; }
        public string message { get; set; }
    }
}
