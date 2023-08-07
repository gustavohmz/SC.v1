using SC.v1.Common.Common.PaginationConfiguration;
using Newtonsoft.Json;
using SC.v1.Common.Common.Models;
using System.Net;
using System.Text.Json.Serialization;

namespace SC.v1.Common.Common.Models
{
    /// <summary>
    ///     Formato estándard de respuesta: https://jsonapi.org/format/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Pagination? Pagination { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public T? Data { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ErrorResponseAttribute? Errors { get; set; }

        public HttpStatusCode HttpCode { get; set; } = HttpStatusCode.OK;

    }
}
