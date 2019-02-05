using System.Threading.Tasks;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(string name, string password);
        Task<User> Login(string name, string password);
        Task<bool> UserExists(string name);
    }
}