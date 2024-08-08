using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using New_System.Domain.Messages;

namespace New_System.Infrastructure.Configurations.Messages;

internal sealed class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        throw new NotImplementedException();
    }
}
