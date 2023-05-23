using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class OrdersApplication
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Date { get; set; }

    public string? IsFulfilled { get; set; }

    public int ProviderId { get; set; }

    public virtual Provider Provider { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
