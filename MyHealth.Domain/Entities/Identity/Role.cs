using MyHealth.Domain.Entities.Common;

namespace MyHealth.Domain.Entities.Identity;

public class Role : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}