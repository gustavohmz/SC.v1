using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar terceros como clientes, proveedores y asesores
/// </summary>
public partial class ThirdParty
{
    public int ThirdPartyId { get; set; }

    public string ThirdPartyName { get; set; }

    public string ThirdPartyType { get; set; }

    public string IdType { get; set; }

    public string IdNumber { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();
}
