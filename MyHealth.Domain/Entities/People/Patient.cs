using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.Identity;
using MyHealth.Domain.Entities.Appointments;
using MyHealth.Domain.Entities.Medical;
using MyHealth.Domain.Enums;

namespace MyHealth.Domain.Entities.People;

public class Patient : AuditableEntity
{
    public int UserId { get; set; }

    public DateOnly BirthDate { get; set; }

    public Gender Gender { get; set; }

    public string Address { get; set; } = string.Empty;

    public string EmergencyContact { get; set; } = string.Empty;

    public string BloodType { get; set; } = string.Empty;

    // Navigation Properties
    public User User { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}