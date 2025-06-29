using Microsoft.EntityFrameworkCore;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure.Repositories;

public class UsersRepository(AppDbContext _dbContext) : IUsersRepository
{
    public async Task<Guid> Create(User user)
    {
        await _dbContext.Users.AddAsync(CreateUserEntity(user));
        await _dbContext.SaveChangesAsync();
        
        return user.Id;
    }

    public async Task<User?> GetById(Guid userId)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (userEntity is null) return null;

        return CreateUser(userEntity);
    }

    public async Task<User?> GetByUsername(string username)
    {
        var userEntity = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Username == username);
        
        if (userEntity is null) return null;
        
        return CreateUser(userEntity);
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Select(ue => CreateUser(ue))
            .ToListAsync();
    }
    
    public async Task<User?> DeleteById(Guid userId)
    {
        var user = await (_dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == userId));
        if (user is null) return null;
        
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        
        return CreateUser(user);
    }

    public Task<User?> Update(Guid userId, string firstName, string lastName, string sureName)
    {
        throw new NotImplementedException();
    }
    
    public static UserEntity CreateUserEntity(User u)
    {
        return new UserEntity()
        {
            Id = u.Id,
            Username = u.Username,
            FirstName = u.FirstName,
            LastName = u.LastName,
            PasswordHash = u.Password,
            Surname = u.Surname
        };
    }

    public static User CreateUser(UserEntity entity)
    {
        return new User()
        {
            Id = entity.Id,
            Username = entity.Username,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Surname = entity.Surname,
            Password = entity.PasswordHash,
        };
    }
}