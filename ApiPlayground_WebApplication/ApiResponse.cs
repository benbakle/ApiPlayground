using System.Collections.Generic;

namespace ApiPlayground_WebApplication
{
    public class ApiResponse
    {
        public int RequestId { get; set; }
        public List<Show> Shows{ get; set; }
    }
}