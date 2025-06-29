using Microsoft.EntityFrameworkCore;
using Queue_Pro.Infrastructure.Configurations;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserQueueEntity> UserQueues { get; set; }
    public DbSet<UserQueueMembershipEntity> UserQueueMemberships { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new UserQueueConfiguration())
            .ApplyConfiguration(new UserQueueMembershipConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}