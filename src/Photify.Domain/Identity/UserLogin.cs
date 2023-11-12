using Microsoft.AspNetCore.Identity;

namespace Photify.Domain.Identity;

public class UserLogin : IdentityUserLogin<string>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}