using System.Threading.Tasks;

namespace ApiPlayground_WebApplication
{
    public interface IApiService
    {
        Task<ApiResponse> FetchAsync(string path);
        void IncrementRequestId();
    }
}