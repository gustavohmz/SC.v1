using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar el inventario
/// </summary>
public partial class Inventory
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public int? CategoryId { get; set; }

    public int? ColorId { get; set; }

    public int? SizeId { get; set; }

    public int Quantity { get; set; }

    public virtual Category Category { get; set; }

    public virtual Color Color { get; set; }

    public virtual ICollection<ElectronicInvoiceItem> ElectronicInvoiceItems { get; set; } = new List<ElectronicInvoiceItem>();

    public virtual Size Size { get; set; }
}
