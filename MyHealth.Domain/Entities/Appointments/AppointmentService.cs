using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.Medical;

namespace MyHealth.Domain.Entities.Appointments;

public class AppointmentService : BaseEntity
{
    public int MedicalServiceId { get; set; }

    public int AppointmentId { get; set; }

    public decimal PriceAtMoment { get; set; }

    public int Quantity { get; set; }

    public string? Notes { get; set; }

    // Navigation
    public Appointment Appointment { get; set; } = null!;

    public MedicalService MedicalService { get; set; } = null!;

    public ICollection<MedicalRecord> MedicalRecords { get; set; }
    = new List<MedicalRecord>();
}