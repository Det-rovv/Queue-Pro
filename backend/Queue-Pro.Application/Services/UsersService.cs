using Microsoft.AspNetCore.Identity;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;

namespace Queue_Pro.Application.Services;

public class UsersService(IUsersRepository _usersRepository) : IUsersService
{
    public async Task<Guid> RegisterUser(User user)
    {
        var passHash = new PasswordHasher<User>();
        user.Password = passHash.HashPassword(user, user.Password);
        
        return await _usersRepository.Create(user);
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _usersRepository.GetById(id);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _usersRepository.GetAll();
    }
}