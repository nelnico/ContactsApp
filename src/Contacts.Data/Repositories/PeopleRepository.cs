using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contacts.Core.Common.Pagination;
using Contacts.Core.Dtos;
using Contacts.Core.Entities;
using Contacts.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public PeopleRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _dataContext.People.ToListAsync();
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await _dataContext.People.FindAsync(id);
    }

    public void Update(Person entity)
    {
        entity.Updated = DateTime.Now;
        _dataContext.Entry(entity).State = EntityState.Modified;
    }

    public void Add(Person entity)
    {
        _dataContext.People.Add(entity);
    }

    public void Delete(Person entity)
    {
        _dataContext.People.Remove(entity);
    }

    public async Task<PagedList<PersonDto>> SearchAsync(PersonSearchParams parameters)
    {
        var query = _dataContext.People.AsQueryable();

        if (!string.IsNullOrWhiteSpace(parameters.Query))
            query = query.Where(x =>
                x.FirstName.ToLower().Contains(parameters.Query.ToLower()) ||
                x.Surname.Contains(parameters.Query) ||
                x.Email.Contains(parameters.Query) ||
                x.Phone.Contains(parameters.Query));

        if (parameters.RegionIds != null && parameters.RegionIds.Any())
            query = query.Where(x => parameters.RegionIds.Contains(x.RegionId));

        if (parameters.GenderId is > 0) query = query.Where(x => parameters.GenderId.Equals(x.GenderId));

        return await PagedList<PersonDto>.CreateAsync(query
                .ProjectTo<PersonDto>(_mapper
                    .ConfigurationProvider).AsNoTracking(),
            parameters.PageNumber, parameters.PageSize);
    }
}