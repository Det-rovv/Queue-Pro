namespace Queue_Pro.Infrastructure.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    
    public string Username { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string? Surname { get; set; }
    
    public string PasswordHash { get; set; }
    
    public IList<UserQueueMembershipEntity> QueueMemberships { get; set; } =  new List<UserQueueMembershipEntity>();
}