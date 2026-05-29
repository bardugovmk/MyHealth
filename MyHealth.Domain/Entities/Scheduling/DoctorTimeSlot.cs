using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.Appointments;

namespace MyHealth.Domain.Entities.Scheduling;

public class DoctorTimeSlot : BaseEntity
{
    public int ScheduleId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsBooked { get; set; }

    // Navigation
    public DoctorSchedule Schedule { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}