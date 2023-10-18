using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models
{
    /// <summary>
    /// Tabla para manejar los roles de usuario
    /// </summary>
    public partial class UserRoles
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        // Relación con la tabla de usuarios (uno a muchos)
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
