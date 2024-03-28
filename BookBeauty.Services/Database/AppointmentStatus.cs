using System;
using System.Collections.Generic;

namespace BookBeauty.Services.Database;

public partial class AppointmentStatus
{
    public int AppointmentStatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
