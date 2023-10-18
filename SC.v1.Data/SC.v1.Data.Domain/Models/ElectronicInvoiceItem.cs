using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar ítems de factura electrónica
/// </summary>
public partial class ElectronicInvoiceItem
{
    public int ItemId { get; set; }

    public int? InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual ElectronicInvoice Invoice { get; set; }

    public virtual Inventory Product { get; set; }
}
