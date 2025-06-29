using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure.Configurations;

public class UserQueueConfiguration : IEntityTypeConfiguration<UserQueueEntity>
{
    public void Configure(EntityTypeBuilder<UserQueueEntity> builder)
    {
        builder.ToTable("UserQueues");
        
        builder.HasKey(q => q.Id);

        builder.HasOne(q => q.Headman)
            .WithMany()
            .HasForeignKey(q => q.HeadmanId)
            .IsRequired();
        
        builder.HasMany(q => q.UserMemberships)
            .WithOne(m => m.UserQueue)
            .HasForeignKey(m => m.UserQueueId)
            .IsRequired();
        
        builder.Property(q => q.HeadmanId)
            .IsRequired();
        
        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(q => q.JoinWindowStartTime)
            .IsRequired();
        
        builder.Property(q => q.JoinWindowEndTime)
            .IsRequired();
    }
}