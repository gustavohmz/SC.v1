using SC.v1.Core.Implementations.Commands;
using SC.v1.Core.Interfaces;
using SC.v1.Data.Persistence.Repositories.Users;

namespace SC.v1.Presentation.Configuration.ServiceScopes
{

    /// <summary>
    /// Clase que representa el ámbito del servicio MX.
    /// </summary>
    public static class ServiceScopeMX
    {
        /// <summary>
        /// Configura los servicios relacionados con el servicio MX en la aplicación web.
        /// </summary>
        /// <param name="builder">Constructor de la aplicación web.</param>
        public static void ConfigureAppMX(this WebApplicationBuilder builder)
        {//  Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //  Queries and commands
            builder.Services.AddScoped<ISignUp, SignUp>();
        }
    }
}
