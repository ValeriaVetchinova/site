using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? Position { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<OrdersApplication> OrdersApplications { get; set; } = new List<OrdersApplication>();

    public virtual ICollection<ReturnNote> ReturnNotes { get; set; } = new List<ReturnNote>();

    public virtual ICollection<ShiftSchedule> ShiftSchedules { get; set; } = new List<ShiftSchedule>();
}
