using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.Appointments;
using MyHealth.Domain.Entities.People;

namespace MyHealth.Domain.Entities.Medical;

public class MedicalRecord : AuditableEntity
{
    public int AppointmentServiceId { get; set; }

    public int PatientId { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string Symptoms { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public string Recommendations { get; set; } = string.Empty;

    // Navigation
    public Patient Patient { get; set; } = null!;

    public AppointmentService AppointmentService { get; set; } = null!;

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public ICollection<MedicalRecordAttachment> Attachments { get; set; } = new List<MedicalRecordAttachment>();
}