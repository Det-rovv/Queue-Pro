using Queue_Pro.Domain.Models;

namespace Queue_Pro.Domain.Abstractions;

public interface IUsersService
{
    Task<Guid> RegisterUser(User user);
    
    Task<User?> GetUserById(Guid id);
    
    Task<List<User>> GetAllUsers();
}