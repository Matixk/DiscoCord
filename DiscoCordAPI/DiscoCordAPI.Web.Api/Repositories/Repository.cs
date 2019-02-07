using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoCordAPI.Models;
using DiscoCordAPI.Models.Context;
using DiscoCordAPI.Models.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DiscoCordAPI.Web.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;

        public Repository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<List<T>> GetAll() => await entities.ToListAsync();

        public async Task<T> Get(int id) => await entities.FirstOrDefaultAsync(e => e.Id == id);

        public async Task Insert(T entity)
        {
            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            if (id != entity.Id)
            {
                throw new ArgumentException("Id doesn't match!");
            }

            if (!await Exists(id))
            {
                throw new NotFoundException();
            }

            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<T> Delete(int id)
        {
            var entity = await entities.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }

            entities.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exists(int id) => entities.Any(e => e.Id == id);
    }
}