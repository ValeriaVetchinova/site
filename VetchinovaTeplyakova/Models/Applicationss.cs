using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class Applicationss
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public DateTime? DateTime { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<ServiceApplication> ServiceApplications { get; set; } = new List<ServiceApplication>();
}
