using AutoMapper;
using Contacts.Core.Repositories;
using Contacts.Core.Services;
using Contacts.Data.Repositories;

namespace Contacts.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _dataContext;

    public UnitOfWork(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        People = new PeopleRepository(_dataContext, mapper);
    }

    public IPeopleRepository People { get; }

    public async Task<bool> CompleteAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }

    public bool Complete()
    {
        return _dataContext.SaveChanges() > 0;
    }
}