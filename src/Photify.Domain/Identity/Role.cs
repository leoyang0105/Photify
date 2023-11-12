using Microsoft.AspNetCore.Identity;

namespace Photify.Domain.Identity;

public class Role : IdentityRole
{
    private ICollection<UserRole> _userRoles;
    public string DisplayName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<UserRole> UserRoles
    {
        get => _userRoles ?? (_userRoles = new List<UserRole>());
        private set => _userRoles = value;
    }
}
