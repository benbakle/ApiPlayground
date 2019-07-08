using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiPlayground_WebApplication
{
    public partial class Startup
    {

        static void Mvc(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        static void Swagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info {
                        Title = "PSI.ZDD",
                        Version = "v1"
                    });

                    //c.IncludeXmlComments(AppDomain.CurrentDomain.BaseDirectory + "api.doc.xml");
                    //c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    //{
                    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"" + Environment.NewLine + "<b style='font-size:24px;'>Add the word 'Bearer' and a space before below Value</b>",
                    //    Name = "Authorization",
                    //    In = "header",
                    //    Type = "apiKey"
                    //});
                    //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    //{
                    //    {"Bearer", new string[] { }},
                    //});
                });
        }
    }
}
