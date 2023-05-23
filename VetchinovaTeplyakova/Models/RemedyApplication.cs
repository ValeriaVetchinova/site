using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class RemedyApplication
{
    public int ToolFromTheGuideId { get; set; }

    public int ApplicationId { get; set; }

    public virtual OrdersApplication Application { get; set; } = null!;

    public virtual ResourceGuideItem ToolFromTheGuide { get; set; } = null!;
}
