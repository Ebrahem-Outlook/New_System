using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using New_System.Domain.Users;

namespace New_System.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
            .HasColumnType("varChar(50)")
            .IsRequired();

        builder.Property(user => user.LastName)
            .HasColumnType("varChar(50)")
            .IsRequired();

        builder.Property(user => user.Email)
            .HasColumnType("varChar(50)")
            .IsRequired();

        builder.Property(user => user.Password)
            .HasColumnType("varChar(50)")
            .IsRequired();
    }
}
