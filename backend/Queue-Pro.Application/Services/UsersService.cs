using Microsoft.AspNetCore.Identity;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;

namespace Queue_Pro.Application.Services;

public class UsersService(IUsersRepository _usersRepository, JwtService _jwtService) : IUsersService
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
    
    public async Task<User?> GetUserByUsername(string username)
    {
        return await _usersRepository.GetByUsername(username);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _usersRepository.GetAll();
    }
    
    public Task<User?> DeleteUserById(Guid userId)
    {
        return _usersRepository.DeleteById(userId);
    }

    public Task<User?> UpdateUser(Guid userId, string firstName, string lastName, string sureName)
    {
        return _usersRepository.Update(userId, firstName, lastName, sureName);
    }
    
    public async Task<string?> Login(string username, string password)
    {
        var user = await GetUserByUsername(username);

        if (await VerifyPassword(user, password))
        {
            return _jwtService.GenerateToken(user);
        }
        return null;
    }

    public async Task<bool> VerifyPassword(User user, string password)
    {
        var userEntity = await _usersRepository.GetById(user.Id);
        
        var passHash = new PasswordHasher<User>();
        
        return passHash.VerifyHashedPassword(user, userEntity.Password, password) == PasswordVerificationResult.Success;
    }
}