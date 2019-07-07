using System.Collections.Generic;

namespace ApiPlayground_WebApplication
{
    public class ApiResponse
    {
        public int RequestId { get; set; }
        public Show[] Shows{ get; set; }
    }
}