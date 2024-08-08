using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using New_System.Domain.Posts.Entity;

namespace New_System.Infrastructure.Configurations.Posts;

internal sealed class ShareConfiguration : IEntityTypeConfiguration<Share>
{
    public void Configure(EntityTypeBuilder<Share> builder)
    {
        throw new NotImplementedException();
    }
}
