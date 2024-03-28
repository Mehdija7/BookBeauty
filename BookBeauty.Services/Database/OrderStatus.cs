using System;
using System.Collections.Generic;

namespace BookBeauty.Services.Database;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
