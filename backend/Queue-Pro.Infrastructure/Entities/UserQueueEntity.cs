namespace Queue_Pro.Infrastructure.Entities;

public class UserQueueEntity
{
    public Guid Id { get; }
    
    public UserEntity Headman { get; set; }
    
    public Guid HeadmanId { get; set; }
    
    public string Title { get; set; }
    
    public TimeOnly JoinWindowStartTime { get; set; }
    
    public TimeOnly JoinWindowEndTime { get; set; }
    
    public IList<UserQueueMembershipEntity> UserMemberships { get; set; }
}