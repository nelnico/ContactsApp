namespace Contacts.Core.Enums;

public class UserRoleEnum : Enumeration
{
    public static UserRoleEnum UserRole = new(1, "User");
    public static UserRoleEnum AdminRole = new(1, "Admin");

    public UserRoleEnum(int id, string name) : base(id, name, string.Empty)
    {
    }
}