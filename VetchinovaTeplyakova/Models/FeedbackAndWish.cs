using System;
using System.Collections.Generic;

namespace VetchinovaTeplyakova.Models;

public partial class FeedbackAndWish
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ServiceProvidedId { get; set; }

    public string? Data { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ServiceProvided ServiceProvided { get; set; } = null!;
}
