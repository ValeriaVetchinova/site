using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ServiceStaff
{
    public int Id { get; set; }

    public string? Position { get; set; }

    public string? Fio { get; set; }

    public string? Experience { get; set; }

    public virtual ICollection<ServiceProvided> ServiceProvideds { get; set; } = new List<ServiceProvided>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<ShiftSchedule> ShiftSchedules { get; set; } = new List<ShiftSchedule>();
}
