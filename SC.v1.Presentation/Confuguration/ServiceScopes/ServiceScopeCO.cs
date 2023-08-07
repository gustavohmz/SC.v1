using Microsoft.Extensions.Localization;
using SC.v1.Common.Common.Localization;
using SC.v1.Core.Implementations.Commands;
using SC.v1.Core.Interfaces;
using SC.v1.Data.Persistence.Repositories.Users;

namespace SC.v1.Presentation.Configuration.ServiceScopes
{
    /// <summary>
    /// Clase que representa un ámbito de servicio personalizado para la inyección de dependencias.
    /// </summary>
    public static class ServiceScopeCO
    {
        /// <summary>
        /// Método para agregar y configurar servicios en el ámbito.
        /// </summary>
        /// <param name="builder">La colección de servicios a la que se agregarán los servicios configurados.</param>
        public static void ConfigureAppCO(this WebApplicationBuilder builder)
        {

            //  Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //  Queries and commands
            builder.Services.AddScoped<ISignUp, SignUp>();

            


        }
    }
}
