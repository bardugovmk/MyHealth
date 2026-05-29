using MyHealth.Domain.Entities.Common;

namespace MyHealth.Domain.Entities.Medical;

public class ServiceComponent : BaseEntity
{
    public int ParentServiceId { get; set; }

    public int ChildServiceId { get; set; }

    public int Quantity { get; set; }

    public bool IsRequired { get; set; }

    // Navigation
    public MedicalService ParentService { get; set; } = null!;

    public MedicalService ChildService { get; set; } = null!;
}