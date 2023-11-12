using Microsoft.AspNetCore.Identity;

namespace Photify.Domain.Identity;

public class User : IdentityUser
{
    private ICollection<UserRole> _userRoles;
    private ICollection<UserClaim> _userClaims;
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<UserRole> UserRoles
    {
        get => _userRoles ?? (_userRoles = new List<UserRole>());
        private set => _userRoles = value;
    }
    public ICollection<UserClaim> UserClaims
    {
        get => _userClaims ?? (_userClaims = new List<UserClaim>());
        private set => _userClaims = value;
    }
    public void RemoveClaim(string type)
    {
        if (this.UserClaims.Any(x => x.ClaimType == type))
        {
            this.UserClaims.Remove(this.UserClaims.ToList().FirstOrDefault(x => x.ClaimType == type));
        }
    }
    public void SetClaim(string type, string value)
    {
        this.RemoveClaim(type);
        if (!string.IsNullOrEmpty(value))
            this.UserClaims.Add(new UserClaim() { ClaimType = type, ClaimValue = value });
    }
}
