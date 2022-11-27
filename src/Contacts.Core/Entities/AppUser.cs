using Microsoft.AspNetCore.Identity;

namespace Contacts.Core.Entities;

public class AppUser : IdentityUser
{
    public bool IsActive { get; set; } = false;
    public string Otp { get; set; }
    public DateTime? OtpCreatedAt { get; set; }
}