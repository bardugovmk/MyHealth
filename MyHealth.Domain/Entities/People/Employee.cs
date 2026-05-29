using MyHealth.Domain.Entities.Appointments;
using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.Identity;
using MyHealth.Domain.Entities.People;

public class Employee : AuditableEntity
{
    public int UserId { get; set; }
    public DateOnly HireDate { get; set; }
    public string Department { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public User User { get; set; } = null!;

    public Doctor? Doctor { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}