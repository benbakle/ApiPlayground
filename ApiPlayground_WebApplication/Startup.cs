using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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
            Swagger(services);
            Mvc(services);
            Register(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Swagger(app);
            HandleExceptions(app, env);
            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
