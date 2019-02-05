using DiscoCordAPI.Models.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoCordAPI.Models.Context.Configurations
{
    public class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder
                .HasOne(c => c.Server)
                .WithMany(s => s.Channels)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(c => c.Messages)
                .WithOne(m => m.Channel)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
