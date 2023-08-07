using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar colores de productos
/// </summary>
public partial class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
