using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Models.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; } 
        public DbSet<Message> Messages { get; set; } 
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>()
                .HasOne(c => c.Server)
                .WithMany(s => s.Channels)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Channel>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Channel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Channel)
                .WithMany(c => c.Messages)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Server>()
                .HasOne(s => s.Owner)
                .WithMany(u => u.OwnedServers)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Server>()
                .HasMany(s => s.Channels)
                .WithOne(c => c.Server)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Server>()
                .HasMany(s => s.Users)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.OwnedServers)
                .WithOne(s => s.Owner)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ConnectedServers)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
