using Microsoft.AspNetCore.Identity;

namespace Movies.Application.Models;

public class User: IdentityUser
{
    // public Guid Id { get; set; }
    // public string FirstName { get; set; } = string.Empty;
    // public string LastName { get; set; } = string.Empty;
    // public string Password { get; set; } = string.Empty;
    // public string Salt { get; set; } = string.Empty;
    // public string Email { get; set; } = string.Empty;
    // public bool EmailConfirmed { get; set; } = false;
    // public bool TwoFactorEnabled { get; set; } = false;
    // public DateTime CreatedAt { get; set; } = DateTime.Now;
    // public bool LockoutEnabled { get; set; } = false;
    
    public ICollection<Rating>? Ratings { get; set; }

    // public Guid RoleId;
    // public Role Role = new Role();
}