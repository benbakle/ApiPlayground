using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace ApiPlayground_WebApplication
{
    public partial class Startup
    {

        static void Mvc(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IApiService), typeof(ApiService));
            services.AddScoped(typeof(IHttpClient), typeof(HttpClient));
        }
    }
}
