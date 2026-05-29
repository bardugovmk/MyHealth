using MyHealth.Domain.Entities.Common;

namespace MyHealth.Domain.Entities.Medical;

public class Prescription : BaseEntity
{
    public int MedicalRecordId { get; set; }

    public string MedicationName { get; set; } = string.Empty;

    public string Dosage { get; set; } = string.Empty;

    public string Instructions { get; set; } = string.Empty;

    // Navigation
    public MedicalRecord MedicalRecord { get; set; } = null!;
}