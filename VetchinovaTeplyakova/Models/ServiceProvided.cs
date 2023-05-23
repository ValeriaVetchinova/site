using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class ServiceProvided
{
    public int Id { get; set; }

    public int ServiceApplicationId { get; set; }

    public int ServiceStaffId { get; set; }

    public string? Price { get; set; }

    public string? Check { get; set; }

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual ICollection<FeedbackAndWish> FeedbackAndWishes { get; set; } = new List<FeedbackAndWish>();

    public virtual ServiceApplication ServiceApplication { get; set; } = null!;

    public virtual ServiceStaff ServiceStaff { get; set; } = null!;
}
