using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ServiceApplication
{
    public int Id { get; set; }

    public int ApplicationId { get; set; }

    public int ServiceId { get; set; }

    public virtual Applicationss Application { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual ICollection<ServiceProvided> ServiceProvideds { get; set; } = new List<ServiceProvided>();
}
