using Contacts.Core.Entities;

namespace Contacts.Core.Services;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
    string GenerateOneTimePin(int length = 5);
}