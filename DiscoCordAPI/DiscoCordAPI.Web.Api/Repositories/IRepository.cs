using System.Collections.Generic;
using System.Threading.Tasks;
using DiscoCordAPI.Models.Servers;
using Microsoft.AspNetCore.Mvc;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public interface IRepository<T>
    {
        Task<ActionResult<IEnumerable<T>>> GetAll();
        Task<T> Get(long id);
        Task<IActionResult> Insert(T entity);
        Task<ActionResult<T>> Update(T entity);
        Task<ActionResult<T>> Delete(T entity);
        bool Exists(int id);

    }
}
