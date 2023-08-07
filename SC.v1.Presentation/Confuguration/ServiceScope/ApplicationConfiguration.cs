using Microsoft.OpenApi.Models;

namespace SC.v1.Presentation.Configuration
{
    internal static class ApplicationConfiguration
    {
        public static void UseOpenApiDoc(this IApplicationBuilder builder, ConfigurationManager configuration)
        {
            string basePath = configuration?["SwaggerConfig:BasePath"] ?? string.Empty;
            string scheme = configuration?["SwaggerConfig:Scheme"] ?? "https";
            string host = configuration?["SwaggerConfig:Host"] ?? "localhost";


            builder.UseSwagger(setup =>
            {
                setup.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = httpReq.Host.Host != "localhost" ? new List<OpenApiServer> { new OpenApiServer { Url = $"{scheme}://{host}{basePath}" } } : new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
                });
            });

            string prefixReDoc = "v2";
#if (DEBUG)

            prefixReDoc = string.Empty;
#endif

            builder.UseSwaggerUI(setup => {
                setup.SwaggerEndpoint("../swagger/v1/swagger.json",
                                  "API Plataforma SC v1");
            });

            builder.UseReDoc(setup =>
            {
                //setup.InjectStylesheet("styles/custom-redoc-styles.css");
                setup.DocumentTitle = "Api SC.v1";
                setup.SpecUrl("swagger/v1/swagger.json");
                setup.RoutePrefix = prefixReDoc;
                setup.ExpandResponses("1000"); // set on purpose to disable expand behavior.
            });
        }
    }
}
