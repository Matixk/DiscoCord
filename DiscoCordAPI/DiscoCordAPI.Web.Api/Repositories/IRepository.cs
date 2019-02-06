using System.Collections.Generic;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
