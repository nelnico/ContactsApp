using Contacts.Core.Repositories;

namespace Contacts.Core.Services;

public interface IUnitOfWork
{
    IPeopleRepository People { get; }
    Task<bool> CompleteAsync();
    bool Complete();
}