﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace ApiPlayground_WebApplication
{
    public class ApiService
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
                //var data = await message.Content.ReadAsAsync<Show[]>();
                //response.RequestId = RequestId;
                //response.Shows = data.Where(s=> s.StartDate >= DateTime.Now).OrderBy(s=>s.StartDate).ToArray();
            }

                return response;
        }
    }
}
