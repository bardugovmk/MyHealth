using MyHealth.Domain.Entities.Common;
using System.Numerics;

namespace MyHealth.Domain.Entities.People;

public class Specialization : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}