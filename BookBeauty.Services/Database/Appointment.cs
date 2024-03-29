﻿using System;
using System.Collections.Generic;

namespace BookBeauty.Services.Database;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public DateTime? Date { get; set; }

    public int? UserId { get; set; }

    public string HairDresserId { get; set; } = null!;

    public int ServiceId { get; set; }

    public int? AppointmentStatusId { get; set; }

    public virtual AppointmentStatus? AppointmentStatus { get; set; }

    public virtual HairDresser HairDresser { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual User? User { get; set; }
}
