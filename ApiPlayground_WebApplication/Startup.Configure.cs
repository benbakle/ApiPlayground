using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace ApiPlayground_WebApplication
{
    public partial class Startup
    {
        private static void HandleExceptions(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        }

        static void Swagger(IApplicationBuilder app)
        {
            app.UseSwagger(c => c.RouteTemplate = @"api/{documentName}/metadata");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/v1/metadata", "PSI");
                c.RoutePrefix = "api/docs";
                //c.InjectJavascript("/scripts/autoAuth.js");
            });
        }
    }
}
