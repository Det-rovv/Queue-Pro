using Queue_Pro.Domain.Models;

namespace Queue_Pro.Domain.Abstractions;

public interface IUsersRepository
{
    Task<Guid> Create(User user);
    
    Task<User?> GetById(Guid userId);

    Task<User?> GetByUsername(string username);

    Task<List<User>> GetAll();
    
    Task<User?> DeleteById(Guid userId);
    
    Task<User?> Update(Guid userId, string firstName, string lastName, string sureName);
}