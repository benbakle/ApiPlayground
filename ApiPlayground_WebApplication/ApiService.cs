using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace ApiPlayground_WebApplication
{
    public class ApiService : IApiService
    {
        private readonly IHttpHandler _client;


        public int RequestId { get; set; } = -1;

        public void IncrementRequestId()
        {
            RequestId = RequestId + 1;
        }

        public ApiService(IHttpHandler client)
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
                var data = await message.Content.ReadAsAsync<Show[]>();
                //var shows = new ResponseData
                //{
                //    Shows = JsonConvert.DeserializeObject<Show[]>(data.ToString())
                //};

                var shows = data;

                response.RequestId = RequestId;
                response.Shows = shows;
            }

            return response;

            //var response = await _client.GetAsync(path);
            //response.EnsureSuccessStatusCode();
            //var data = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<ResponseData>(data);
        }
    }
}
