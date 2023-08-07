using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar las transacciones
/// </summary>
public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? TypeId { get; set; }

    public DateOnly TransactionDate { get; set; }

    public decimal TotalAmount { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<ElectronicInvoice> ElectronicInvoices { get; set; } = new List<ElectronicInvoice>();

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    public virtual ICollection<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();

    public virtual TransactionType Type { get; set; }

    public virtual User User { get; set; }
}
