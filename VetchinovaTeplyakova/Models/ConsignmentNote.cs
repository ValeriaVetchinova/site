using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ConsignmentNote
{
    public int Id { get; set; }

    public string? Number { get; set; }

    public string? DateOfDelivery { get; set; }

    public virtual ICollection<Means> Means { get; set; } = new List<Means>();
}
