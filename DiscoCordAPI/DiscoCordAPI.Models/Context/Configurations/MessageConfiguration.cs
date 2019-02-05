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
                .Property(m => m.Content)
                .IsRequired();

            builder
                .Property(m => m.Date)
                .IsRequired();

            builder
                .Property(m => m.Author)
                .IsRequired();

            builder
                .Property(m => m.Channel)
                .IsRequired();

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
