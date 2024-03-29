﻿using System;
using System.Collections.Generic;

namespace BookBeauty.Services.Database;

public partial class Order
{
    public int OrderId { get; set; }

    public float? TotalPrice { get; set; }

    public DateTime? DateTime { get; set; }

    public int CustomerId { get; set; }

    public int OrderStatusId { get; set; }

    public string? OrderNumber { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;
}
