namespace SC.v1.Presentation.Configuration.Filters
{

    /// <summary>
    /// Atributo personalizado que indica que el controlador o acción produce una cabecera de respuesta específica.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class ProducesResponseHeaderAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statusCode"></param>
        /// <param name="type"></param>
        /// <param name="description"></param>
        public ProducesResponseHeaderAttribute(string name, int statusCode, Type type, string description)
        {
            Name = name;
            StatusCode = statusCode;
            Type = type.Name;
            Description = description;
        }
    }
}
