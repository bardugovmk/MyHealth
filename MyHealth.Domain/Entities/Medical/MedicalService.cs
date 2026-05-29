using MyHealth.Domain.Entities.Appointments;
using MyHealth.Domain.Entities.Common;

namespace MyHealth.Domain.Entities.Medical;

public class MedicalService : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int ServiceType { get; set; }

    public decimal BasePrice { get; set; }

    public int DurationMinutes { get; set; }

    public bool RequiresDoctor { get; set; }

    public bool IsComposite { get; set; }

    public bool IsActive { get; set; }

    // Navigation
    public ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

    public ICollection<ServiceComponent> Components { get; set; } = new List<ServiceComponent>();
}