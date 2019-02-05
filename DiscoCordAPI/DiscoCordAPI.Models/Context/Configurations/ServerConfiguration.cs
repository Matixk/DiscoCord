using DiscoCordAPI.Models.Servers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoCordAPI.Models.Context.Configurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder
                .Property(s => s.Owner)
                .IsRequired();

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(s => s.IsPrivate)
                .IsRequired();

            builder
                .HasOne(s => s.Owner)
                .WithMany(u => u.OwnedServers)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(s => s.Channels)
                .WithOne(c => c.Server)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(s => s.Users)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
