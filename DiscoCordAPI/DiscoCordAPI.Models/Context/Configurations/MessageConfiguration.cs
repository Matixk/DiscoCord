using DiscoCordAPI.Models.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoCordAPI.Models.Context.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasOne(m => m.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Channel)
                .WithMany(c => c.Messages)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
