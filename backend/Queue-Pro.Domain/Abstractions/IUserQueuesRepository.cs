using Queue_Pro.Domain.Models;

namespace Queue_Pro.Domain.Abstractions;

public interface IUserQueuesRepository
{
    Task<Guid> Create(UserQueue queue);
    
    Task AddUser(Guid queueId, User user);
    
    Task<UserQueue> Get(Guid queueId);
}