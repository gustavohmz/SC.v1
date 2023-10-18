using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar las líneas de las transacciones
/// </summary>
public partial class TransactionLine
{
    public int LineId { get; set; }

    public int? TransactionId { get; set; }

    public int? AccountId { get; set; }

    public decimal Amount { get; set; }

    public virtual Transaction Transaction { get; set; }
}
