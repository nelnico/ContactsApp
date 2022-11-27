using Contacts.Core.Enums;

namespace Contacts.Core.Dtos;

public class PersonSearchOptionsDto
{
    public IList<GenderEnum> Genders { get; } = Enumeration.GetAll<GenderEnum>().ToList();
    public IList<RegionEnum> Regions { get; } = Enumeration.GetAll<RegionEnum>().ToList();
}