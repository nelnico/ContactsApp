namespace Contacts.Core.Enums;

public class RegionEnum : Enumeration
{
    public static RegionEnum EasternCape = new(1, "Eastern Cape");
    public static RegionEnum FreeState = new(2, "Free State");
    public static RegionEnum Gauteng = new(3, "Gauteng");
    public static RegionEnum KwaZuluNatal = new(4, "KwaZulu-Natal");
    public static RegionEnum Limpopo = new(5, "Limpopo");
    public static RegionEnum Mpumalanga = new(6, "Mpumalanga");
    public static RegionEnum NorthernCape = new(7, "Northern Cape");
    public static RegionEnum NorthWest = new(8, "North West");
    public static RegionEnum WesternCape = new(9, "Western Cape");
    
    public RegionEnum(int id, string name) : base(id, name, string.Empty)
    {
    }
}