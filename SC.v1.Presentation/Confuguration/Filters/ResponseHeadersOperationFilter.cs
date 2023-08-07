using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SC.v1.Presentation.Configuration.Filters
{
    /// <summary>
    /// Filtro personalizado para agregar encabezados de respuesta a la documentación de Swagger.
    /// </summary>
    public class ResponseHeadersOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Método para aplicar el filtro a la operación Swagger.
        /// </summary>
        /// <param name="operation">La operación Swagger a la que se aplicará el filtro.</param>
        /// <param name="context">El contexto del filtro de operación.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Get all response header declarations for a given operation
            ProducesResponseHeaderAttribute[] producesResponseHeaderAttributes =
                context.ApiDescription.CustomAttributes().OfType<ProducesResponseHeaderAttribute>().ToArray();

            if (producesResponseHeaderAttributes.Any())
            {
                foreach (var responseCode in operation.Responses.Keys)
                {
                    // Do we have one or more headers for the specific response code
                    IEnumerable<ProducesResponseHeaderAttribute> responseHeaders =
                        producesResponseHeaderAttributes.Where(resp => resp.StatusCode.ToString() == responseCode);

                    if (responseHeaders.Any())
                    {
                        OpenApiResponse response = operation.Responses[responseCode];
                        response.Headers ??= new Dictionary<string, OpenApiHeader>();

                        foreach (ProducesResponseHeaderAttribute responseHeader in responseHeaders)
                        {
                            response.Headers[responseHeader.Name] = new OpenApiHeader
                            {
                                Description = responseHeader.Description,
                                Schema = new OpenApiSchema
                                {
                                    Type = responseHeader.Type
                                }
                            };
                        }
                    }
                }
            }
        }
    }
}
