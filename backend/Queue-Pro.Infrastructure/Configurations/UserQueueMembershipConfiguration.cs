using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure.Configurations;

public class UserQueueMembershipConfiguration : IEntityTypeConfiguration<UserQueueMembershipEntity>
{
    public void Configure(EntityTypeBuilder<UserQueueMembershipEntity> builder)
    {
        builder.ToTable("UserQueueMemberships");
        
        builder.HasKey(m => new { m.UserId, m.UserQueueId });

        builder.HasOne(m => m.UserQueue)
            .WithMany(q => q.UserMemberships)
            .HasForeignKey(m => m.UserQueueId)
            .IsRequired();
        
        builder.HasOne(m => m.User)
            .WithMany(u => u.QueueMemberships)
            .HasForeignKey(m => m.UserId)
            .IsRequired();
        
        builder.Property(m => m.Order)
            .IsRequired();
    }
}