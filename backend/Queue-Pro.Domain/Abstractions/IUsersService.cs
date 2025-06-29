using Queue_Pro.Domain.Models;

namespace Queue_Pro.Domain.Abstractions;

public interface IUsersService
{
    Task<Guid> RegisterUser(User user);
    
    Task<User?> GetUserById(Guid id);

    Task<User?> GetUserByUsername(string username);

    Task<string?> Login(string username, string password);

    Task<bool> VerifyPassword(User user, string password);
    
    Task<List<User>> GetAllUsers();
}