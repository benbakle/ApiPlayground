using System.Net.Http;
using System.Threading.Tasks;

namespace ApiPlayground_WebApplication
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string path);
        void GetAsync();
    }
}