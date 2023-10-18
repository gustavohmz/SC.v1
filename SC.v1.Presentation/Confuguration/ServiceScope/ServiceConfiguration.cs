using SC.v1.Common.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using SC.v1.Presentation.Configuration.ServiceScopes;
using SC.v1.Common.Utils;
using Microsoft.Extensions.Localization;
using SC.v1.Common.Common.Localization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace SC.v1.Presentation.Configuration
{
    internal static class ServiceConfiguration
    {

        public static void ConfigureAppInversionOfControl(this WebApplicationBuilder builder)
        {
            var country = Utils.GetValueFromDescription<CountriesEnum>(builder.Configuration.GetValue<string>("CountryConfiguration:SupportedCountry")!);

            //  Global Interfaces
            builder.Services.AddScoped<IServiceProvider, ServiceProvider>();


            //Service configuration by country
            switch (country)
            {
                case CountriesEnum.Colombia:
                    builder.ConfigureAppCO();
                    break;
                case CountriesEnum.Mexico:
                    builder.ConfigureAppMX();
                    break;
            }
        }

        public static void ConfigureOpenApi(this WebApplicationBuilder builder)
        {
            var country = Utils.GetValueFromDescription<CountriesEnum>(builder.Configuration.GetValue<string>("CountryConfiguration:SupportedCountry")!);

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(setup =>
            {

                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Plataforma SC " + country.ToString(),
                    Description = @"Servicios internos y de integración para la plataforma SC",
                    Extensions = new Dictionary<string, IOpenApiExtension>
                        {
                            {
                                "x-logo", new OpenApiObject {
                                    {"url", new OpenApiString("")},
                                    { "altText", new OpenApiString("SISTEMA CONTABLE, version 1") }
                                }
                            }
                        }
                });

                setup.EnableAnnotations();

                setup.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = @"Requiere autenticación y autorización a través de un token de acceso de Azure B2C.<br/>",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
                setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SC.v1.Presentation.xml"));
            });
        }

        public static void ConfigureLocalization(this WebApplicationBuilder builder)
        {

            builder.Services.AddLocalization();
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                string[] languages = builder.Configuration.GetSection("Localization:SupportedLangs").GetChildren().Select(x => x.Value).ToArray();
                CultureInfo[] cultures = new CultureInfo[languages.Length + 1];

                cultures[0] = new CultureInfo(builder.Configuration.GetValue<string>("Localization:DefaultLang"));
                for (int l = 0; l < languages.Length; l++)
                {
                    cultures[l + 1] = new CultureInfo(languages[l]);
                }

                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;

                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    string language = context.Request.Headers.ContainsKey(builder.Configuration.GetValue<string>("Localization:HttpHeaderKey"))
                                      ? context.Request.Headers[builder.Configuration.GetValue<string>("Localization:HttpHeaderKey")].ToString()
                                      : builder.Configuration.GetValue<string>("Localization:DefaultLang");

                    if (!cultures.Any(s => s.Name.Equals(language, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        language = builder.Configuration.GetValue<string>("Localization:DefaultLang");
                    }

                    return Task.FromResult(new ProviderCultureResult(language, language))!;
                }));
            });

        }
    }
}
