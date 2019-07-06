using FakeItEasy;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ApiPlayground_WebApplication.Tests
{
    public class TheApiService
    {

        private IApiService _api = A.Fake<IApiService>();
        private IHttpClient _client = A.Fake<IHttpClient>();

        [Fact]
        public void HasARequestId()
        {
            var api = MockApiService();
            Assert.Equal(-1, api.RequestId);
        }

        [Fact]
        public async Task WhenFetchingFromTheApiService_IncrementsTheRequestId()
        {
            var api = MockApiService();
            api.RequestId = -1;
            var response = await api.FetchAsync("");
            Assert.Equal(0, response.RequestId);

        }

        [Fact]
        public async Task WhenFetchingFromTheApiService_CallsTheHttpClientWithGivenPath()
        {
            var api = new ApiService(_api, _client);
            var response = await api.FetchAsync("api/call");
            A.CallTo(() => _client.GetAsync("api/call")).MustHaveHappened();
        }

        [Fact]
        public async Task GivenTheCallReturnsSuccessfully_ReturnsTheDataAsAnApiResponse()
        {
            var result = new ApiResponse { RequestId = 1 };
            A.CallTo(() => _api.FetchAsync("")).Returns(Task.FromResult(result));
            var response = await _api.FetchAsync("");
            Assert.Equal(1, response.RequestId);
        }
        private ApiService MockApiService()
        {
            return new ApiService(_api, _client);
        }
    }
}