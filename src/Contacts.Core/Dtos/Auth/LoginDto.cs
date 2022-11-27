using System.ComponentModel.DataAnnotations;

namespace Contacts.Core.Dtos.Auth;

public class LoginDto
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}