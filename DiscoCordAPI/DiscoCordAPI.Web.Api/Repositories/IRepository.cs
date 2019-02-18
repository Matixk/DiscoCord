using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        DbSet<T> GetDbSet();
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task Update(int id, T entity);
        Task<T> Delete(int id);
        Task<bool> Exists(int id);
    }
}
