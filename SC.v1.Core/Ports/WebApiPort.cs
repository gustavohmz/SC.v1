
using SC.v1.Common.Common.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace SC.v1.Core.Ports
{
    public class WebApiPort<T>
    {
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LinksResponseAttribute? Links { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MetaResponseAttribute Meta { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ErrorResponseAttribute? Errors { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public HttpStatusCode HttpCode { get; set; }

        public WebApiPort(ServiceResponse<T> response)
        {
            Meta = new MetaResponseAttribute();
            Errors = response.Errors;
            Data = response.Data;
            HttpCode = response.HttpCode;

            if (response.Pagination != null)
            {
                Links = new LinksResponseAttribute();
                Links.pagination = response.Pagination;
            }

        }
    }
}
