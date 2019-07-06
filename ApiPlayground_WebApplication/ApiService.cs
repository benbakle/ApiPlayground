using System.Net.Http;
using System.Threading.Tasks;

namespace ApiPlayground_WebApplication
{
    public class ApiService : IApiService
    {
        private readonly IHttpClient _client;


        public int RequestId { get; set; } = -1;

        public void IncrementRequestId()
        {
            RequestId = RequestId + 1;
        }

        public ApiService(IHttpClient client)
        {
            _client = client;
        }

        public virtual async Task<ApiResponse> FetchAsync(string path)
        {
            IncrementRequestId();
            var response = new ApiResponse { RequestId = RequestId };

            HttpResponseMessage message = await _client.GetAsync(path);
            if (message.IsSuccessStatusCode)
            {
                //response = await message.Content.ReadAsAsync<ApiResponse>();
                response.RequestId = RequestId;
            }

            return response;
        }
    }
}
