using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<ActionResult<IEnumerable<T>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<T>> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<T>> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }
    }
}