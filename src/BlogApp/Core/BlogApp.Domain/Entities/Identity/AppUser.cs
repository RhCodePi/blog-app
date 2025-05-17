using Microsoft.AspNetCore.Identity;

namespace BlogApp.Domain.Entities.Identity
{
    public class AppUser: IdentityUser<string> 
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
