using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Insert(T entity);
        Task Update(int id, T entity);
        Task<T> Delete(int id);
        bool Exists(int id);

    }
}
