using MyHealth.Domain.Entities.Common;

namespace MyHealth.Domain.Entities.Scheduling;

public class Cabinet : BaseEntity
{
    public string Number { get; set; } = string.Empty;

    public int Floor { get; set; }

    public string Department { get; set; } = string.Empty;

    // Navigation
    public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
}