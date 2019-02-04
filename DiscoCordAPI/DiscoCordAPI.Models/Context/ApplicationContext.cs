using DiscoCordAPI.Models.Channels;
using DiscoCordAPI.Models.Messages;
using DiscoCordAPI.Models.Servers;
using DiscoCordAPI.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Models.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Channel> Channels { get; set; } 
        public DbSet<Message> Messages { get; set; } 
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
