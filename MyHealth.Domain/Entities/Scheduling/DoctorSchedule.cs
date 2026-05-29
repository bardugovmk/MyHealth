using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.People;

namespace MyHealth.Domain.Entities.Scheduling;

public class DoctorSchedule : BaseEntity
{
    public int DoctorId { get; set; }

    public int CabinetId { get; set; }

    public int DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsActive { get; set; }

    // Navigation
    public Doctor Doctor { get; set; } = null!;

    public Cabinet Cabinet { get; set; } = null!;

    public ICollection<DoctorTimeSlot> TimeSlots { get; set; } = new List<DoctorTimeSlot>();
}