using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Applicationss> Applicationsses { get; set; } = new List<Applicationss>();

    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual ICollection<FeedbackAndWish> FeedbackAndWishes { get; set; } = new List<FeedbackAndWish>();
}
