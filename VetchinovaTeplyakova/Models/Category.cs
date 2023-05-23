using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ResourceGuideItem> ResourceGuideItems { get; set; } = new List<ResourceGuideItem>();
}
