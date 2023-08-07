using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar facturas electrónicas
/// </summary>
public partial class ElectronicInvoice
{
    public int InvoiceId { get; set; }

    public int? TransactionId { get; set; }

    public string InvoiceNumber { get; set; }

    public DateOnly IssueDate { get; set; }

    public virtual ICollection<ElectronicInvoiceItem> ElectronicInvoiceItems { get; set; } = new List<ElectronicInvoiceItem>();

    public virtual Transaction Transaction { get; set; }
}
