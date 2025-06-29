using Queue_Pro.Domain.Models;

namespace Queue_Pro.Domain.Abstractions;

public interface IUsersRepository
{
    Task<Guid> Create(User user);
    
    Task<User?> GetById(Guid id);
    
    Task<List<User>> GetAll();
}