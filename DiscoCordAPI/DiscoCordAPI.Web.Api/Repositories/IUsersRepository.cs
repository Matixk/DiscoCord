using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models.Users;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IUsersRepository
    {
        void Add(User entity);
        void Delete(User entity);
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}