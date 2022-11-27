using AutoMapper;
using Contacts.Core.Common.Extensions;
using Contacts.Core.Dtos;
using Contacts.Core.Entities;
using Contacts.Core.Enums;

namespace Contacts.Core.Common.Mappings;

public class PersonMappingProfile : Profile
{
    public PersonMappingProfile()
    {
        CreateMap<Person, PersonDto>()
            .ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.FirstName} {s.Surname}"))
            .ForMember(d => d.Gender, o => o.MapFrom(s => Enumeration.GetById<GenderEnum>(s.GenderId)))
            .ForMember(d => d.Region, o => o.MapFrom(s => Enumeration.GetById<RegionEnum>(s.RegionId)))
            .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()));
    }
}