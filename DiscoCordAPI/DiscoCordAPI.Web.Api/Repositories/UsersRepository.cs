using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationContext context;

        public UsersRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Add(user);
        }

        public void Delete(User user)
        {
            context.Remove(user);
        }

        public async Task<bool> SaveAll()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await context.Users.Include("OwnedServers").Include("ConnectedServers").ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await context.Users.Include("OwnedServers").Include("ConnectedServers")
                .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}