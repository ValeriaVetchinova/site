using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class Provider
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Inn { get; set; }

    public virtual ICollection<OrdersApplication> OrdersApplications { get; set; } = new List<OrdersApplication>();
}
