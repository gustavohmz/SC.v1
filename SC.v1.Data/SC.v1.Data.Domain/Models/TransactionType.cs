using System;
using System.Collections.Generic;

namespace SC.v1.Data.Domain.Models;

/// <summary>
/// Tabla para manejar los diferentes tipos de transacciones
/// </summary>
public partial class TransactionType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
