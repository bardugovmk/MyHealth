using MyHealth.Domain.Entities.Common;

namespace MyHealth.Domain.Entities.Medical;

public class MedicalRecordAttachment : BaseEntity
{
    public int MedicalRecordId { get; set; }

    public string FileUrl { get; set; } = string.Empty;

    public string FileType { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    // Navigation
    public MedicalRecord MedicalRecord { get; set; } = null!;
}