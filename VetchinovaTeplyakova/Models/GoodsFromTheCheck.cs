using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class GoodsFromTheCheck
{
    public int Id { get; set; }

    public int CheckId { get; set; }

    public int MeansId { get; set; }

    public string? Quantity { get; set; }

    public string? Price { get; set; }

    public virtual OrdersCheck Check { get; set; } = null!;

    public virtual Means Means { get; set; } = null!;
}
