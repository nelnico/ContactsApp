namespace Contacts.Core.Enums;

public class GenderEnum : Enumeration
{
    public static GenderEnum Female = new(1, "Female");
    public static GenderEnum Male = new(2, "Male");

    public GenderEnum(int id, string name)
        : base(id, name, string.Empty)
    {
    }
}