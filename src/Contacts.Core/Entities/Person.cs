namespace Contacts.Core.Entities;

public class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderId { get; set; }
    public int RegionId { get; set; }
    
}