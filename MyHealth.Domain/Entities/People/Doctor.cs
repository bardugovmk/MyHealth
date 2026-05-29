using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.Scheduling;

namespace MyHealth.Domain.Entities.People;

public class Doctor : AuditableEntity
{
    public int EmployeeId { get; set; }

    public int SpecializationId { get; set; }

    public int ExperienceYears { get; set; }

    public string About { get; set; } = string.Empty;

    // Navigation Properties
    public Employee Employee { get; set; } = null!;

    public Specialization Specialization { get; set; } = null!;

    public ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
}