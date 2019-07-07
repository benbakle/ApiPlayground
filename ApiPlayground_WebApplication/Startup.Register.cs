using Microsoft.Extensions.DependencyInjection;

namespace ApiPlayground_WebApplication
{
    public partial class Startup
    {
        private void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IHttpHandler), typeof(HttpClientHandler));
        }
    }
}
