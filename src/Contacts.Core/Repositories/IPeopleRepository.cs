using Contacts.Core.Common.Pagination;
using Contacts.Core.Dtos;
using Contacts.Core.Entities;

namespace Contacts.Core.Repositories;

public interface IPeopleRepository : IRepository<Person>
{
    Task<PagedList<PersonDto>> SearchAsync(PersonSearchParams parameters);
}