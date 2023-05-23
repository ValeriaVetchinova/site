using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class Means
{
    public int Id { get; set; }

    public int ToolFromTheGuideId { get; set; }

    public string? Price { get; set; }

    public int ConsignmentNote { get; set; }

    public string? WholesalePrice { get; set; }

    public int ReturnNoteId { get; set; }

    public virtual ConsignmentNote ConsignmentNoteNavigation { get; set; } = null!;

    public virtual ICollection<GoodsFromTheCheck> GoodsFromTheChecks { get; set; } = new List<GoodsFromTheCheck>();

    public virtual ReturnNote ReturnNote { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ResourceGuideItem ToolFromTheGuide { get; set; } = null!;
}
