using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPlayground_WebApplication
{
    public partial class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Mvc(services);
            Register(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            HandleExceptions(app, env);
            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
