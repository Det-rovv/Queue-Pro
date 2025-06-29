namespace Queue_Pro.Infrastructure.Entities;

public class UserQueueMembershipEntity
{
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
    public Guid UserQueueId { get; set; }
    public UserQueueEntity UserQueue { get; set; }
    
    public int Order { get; set; }
}