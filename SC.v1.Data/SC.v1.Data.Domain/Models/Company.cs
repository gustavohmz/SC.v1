using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models
{
    /// <summary>
    /// Tabla para manejar empresas
    /// </summary>
    public partial class Company
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyWebsite { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonEmail { get; set; }

        public string ContactPersonPhone { get; set; }

        public string RegistrationNumber { get; set; }

        public string TaxId { get; set; }

        // Relación con la tabla de usuarios (uno a muchos)
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
