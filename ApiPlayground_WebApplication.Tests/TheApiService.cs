using FakeItEasy;
using System.Threading.Tasks;
using Xunit;

namespace ApiPlayground_WebApplication.Tests
{
    public class TheApiService
    {
        private IHttpHandler _fakeClient = A.Fake<IHttpHandler>();

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
            var api = new ApiService(_fakeClient);
            var response = await api.FetchAsync("api/call");
            A.CallTo(() => _fakeClient.GetAsync("api/call")).MustHaveHappened();
        }

        [Fact]
        public async Task GivenTheCallReturnsSuccessfully_ReturnsTheDataAsAnApiResponse()
        {
            var result = new ApiResponse { RequestId = 1 };
            var _fakeApi = A.Fake<ApiService>();
            A.CallTo(() => _fakeApi.FetchAsync("")).Returns(Task.FromResult(result));

            var response = await _fakeApi.FetchAsync("");
            Assert.Equal(1, response.RequestId);
        }

        private ApiService MockApiService()
        {
            return new ApiService(_fakeClient);
        }
    }
}
