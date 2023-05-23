using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class Service
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public int ServiceStaffId { get; set; }

    public int MeansId { get; set; }

    public virtual Means Means { get; set; } = null!;

    public virtual ICollection<ServiceApplication> ServiceApplications { get; set; } = new List<ServiceApplication>();

    public virtual ServiceStaff ServiceStaff { get; set; } = null!;
}
