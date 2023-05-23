using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ReturnNote
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Means> Means { get; set; } = new List<Means>();

    public virtual User User { get; set; } = null!;
}
