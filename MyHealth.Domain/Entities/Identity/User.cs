using MyHealth.Domain.Entities.Common;
using MyHealth.Domain.Entities.People;

namespace MyHealth.Domain.Entities.Identity;

public class User : AuditableEntity
{
    public string UserName { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    // Navigation Properties
    public Patient? Patient { get; set; }

    public Employee? Employee { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}