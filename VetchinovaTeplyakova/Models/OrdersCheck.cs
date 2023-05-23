using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class OrdersCheck
{
    public int Id { get; set; }

    public string? Data { get; set; }

    public virtual ICollection<GoodsFromTheCheck> GoodsFromTheChecks { get; set; } = new List<GoodsFromTheCheck>();
}
