using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ResourceGuideItem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Means> Means { get; set; } = new List<Means>();
}
