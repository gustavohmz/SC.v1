using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar nómina
/// </summary>
public partial class Payroll
{
    public int PayrollId { get; set; }

    public int? TransactionId { get; set; }

    public DateOnly PayrollDate { get; set; }

    public virtual ICollection<PayrollItem> PayrollItems { get; set; } = new List<PayrollItem>();

    public virtual Transaction Transaction { get; set; }
}
