using DiscoCordAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscoCordAPI.Models.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.OwnedServers)
                .WithOne(s => s.Owner)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(u => u.ConnectedServers)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
