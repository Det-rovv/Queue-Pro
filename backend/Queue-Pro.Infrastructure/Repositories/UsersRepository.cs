using Microsoft.EntityFrameworkCore;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure.Repositories;

public class UsersRepository(AppDbContext _dbContext) : IUsersRepository
{
    public async Task<Guid> Create(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = Guid.NewGuid(),
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Surname = user.Surname,
            PasswordHash = user.Password
        };

        await _dbContext.Users.AddAsync(userEntity);
        await _dbContext.SaveChangesAsync();
        
        return userEntity.Id;
    }

    public async Task<User?> GetById(Guid id)
    {
        var userEntity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (userEntity is null) return null;

        var user = new User()
        {
            Id = userEntity.Id,
            Username = userEntity.Username,
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Surname = userEntity.Surname,
            Password = userEntity.PasswordHash,
        };
        
        return user;
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.Select(ue => new User()
        {
            Id = ue.Id,
            Username = ue.Username,
            FirstName = ue.FirstName,
            LastName = ue.LastName,
            Surname = ue.Surname,
            Password = ue.PasswordHash,
        }).AsNoTracking()
            .ToListAsync();
    }
}