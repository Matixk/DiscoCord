using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationContext context;

        public AuthRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<User> Register(string name, string password)
        {
            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var user = new User(name, passwordHash, passwordSalt);

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Login(string name, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Name == name);

            if (user == null) return null;

            return !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt) ? null : user;
        }

        public async Task<bool> UserExists(string username)
        {
            return await context.Users.AnyAsync(x => x.Name == username);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
            }
        }
    }
}