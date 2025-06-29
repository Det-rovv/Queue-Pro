using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queue_Pro.Infrastructure.Entities;

namespace Queue_Pro.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(x => x.Id);

        builder.HasMany(u => u.QueueMemberships)
            .WithOne(q => q.User);

        builder.HasIndex(u => u.Username)
            .IsUnique();
            
        builder.Property(u => u.Username)
            .HasMaxLength(15);
        
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.PasswordHash)
            .IsRequired();
        
        builder.Property(u => u.Surname)
            .HasMaxLength(20);
    }
}