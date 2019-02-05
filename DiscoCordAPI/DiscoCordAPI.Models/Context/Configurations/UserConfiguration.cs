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
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(u => u.PasswordHash)
                .IsRequired();

            builder
                .Property(u => u.PasswordSalt)
                .IsRequired();

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
