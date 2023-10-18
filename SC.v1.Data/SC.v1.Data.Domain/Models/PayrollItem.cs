using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar ítems de nómina
/// </summary>
public partial class PayrollItem
{
    public int ItemId { get; set; }

    public int? PayrollId { get; set; }

    public int? EmployeeId { get; set; }

    public decimal Amount { get; set; }

    public virtual ThirdParty Employee { get; set; }

    public virtual Payroll Payroll { get; set; }
}
