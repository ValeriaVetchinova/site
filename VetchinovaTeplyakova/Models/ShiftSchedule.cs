using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ShiftSchedule
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Data { get; set; }

    public string? Time { get; set; }

    public int ServiceStaffId { get; set; }

    public virtual ServiceStaff ServiceStaff { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
