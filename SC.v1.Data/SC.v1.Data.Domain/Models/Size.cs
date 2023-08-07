using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar tallas de productos
/// </summary>
public partial class Size
{
    public int SizeId { get; set; }

    public string SizeName { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
