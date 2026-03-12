using backend.Domain.Entitles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace backend.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
                builder.ToTable("Users");
                builder.HasKey(u => u.Id);
    
                builder.Property(u => u.FirstName).IsRequired()
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.LastName).IsRequired()
                    .IsRequired()
                    .HasMaxLength(100);

                builder.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(100);
                builder.HasIndex(u => u.Username)
                    .IsUnique();

                builder.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                builder.HasIndex(u => u.Email)
                    .IsUnique();

                builder.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                builder.Property(u => u.PhoneNumber)
                    .HasMaxLength(20);

                builder.Property(u => u.LastLoginIp)
                      .HasMaxLength(45);

                builder.Property(u => u.FailedLoginAttempts)
                       .HasDefaultValue(0);

        }
    }
}
