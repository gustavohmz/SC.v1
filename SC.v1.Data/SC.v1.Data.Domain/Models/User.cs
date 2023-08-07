using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models
{
    /// <summary>
    /// Tabla para manejar usuarios y autenticación
    /// </summary>
    public partial class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public UserRoles UserRole { get; set; }

        public int? CompanyId { get; set; } 

        public virtual Company Company { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
