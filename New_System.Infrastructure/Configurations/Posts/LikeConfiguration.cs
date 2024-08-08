using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using New_System.Domain.Posts.Entity;

namespace New_System.Infrastructure.Configurations.Posts;

internal sealed class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        throw new NotImplementedException();
    }
}
