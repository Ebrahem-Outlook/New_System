using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using New_System.Domain.Users;

namespace New_System.Infrastructure.Configurations.Users;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.Password)
            .HasMaxLength(50)
            .IsRequired();
    }
}
