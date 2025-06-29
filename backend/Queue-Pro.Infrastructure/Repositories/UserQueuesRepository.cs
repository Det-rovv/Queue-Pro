using Microsoft.EntityFrameworkCore;
using Queue_Pro.Domain.Abstractions;
using Queue_Pro.Domain.Models;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure.Repositories;

public class UserQueuesRepository(AppDbContext _dbContext) : IUserQueuesRepository
{
    public async Task<Guid> Create(UserQueue queue)
    {
        var queueEntity = new UserQueueEntity()
        {
            Id = queue.Id,
            Headman = CreateUserEntity(queue.Headman),
            HeadmanId = queue.Headman.Id,
            Title = queue.Title,
            JoinWindowStartTime = queue.JoinWindowStartTime,
            JoinWindowEndTime = queue.JoinWindowEndTime
        };
        
        await _dbContext.UserQueues.AddAsync(queueEntity);
        await _dbContext.SaveChangesAsync();

        return queue.Id;
    }

    private UserEntity CreateUserEntity(User u)
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

    private User CreateUser(UserEntity entity)
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

    public Task AddUser(Guid queueId, User user)
    {
        throw new NotImplementedException();
    }

    public Task<UserQueue> Get(Guid queueId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserQueue?> GetById(Guid queueId)
    {
        var entity = await _dbContext.UserQueues
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == queueId);
        
        return new UserQueue(entity.Id, CreateUser(entity.Headman), entity.Title, entity.JoinWindowStartTime, entity.JoinWindowEndTime, GetAllUserMemberships(entity.UserMemberships.ToList(), entity.Id));
    }

    public IList<OrderedItem<User>> GetAllUserMemberships(List<UserQueueMembershipEntity> memberships, Guid userId)
    {
        return memberships
            .Where(m => m.UserId == userId)
            .Select(m => new  OrderedItem<User>(CreateUser(m.User), m.Order)).ToList();
    }
}