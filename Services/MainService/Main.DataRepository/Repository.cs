using Main.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Main.DataRepository
{
    public class Repository : IRepository
    {
        protected readonly DbContext Context;

        public Repository(
            DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> Create<TEntity>(TEntity entity) where TEntity : MainModel
        {
            var entityEntry = await Context.Set<TEntity>()
                .AddAsync(entity);
            return entityEntry.Entity;
        }

        public Task<int> Complete()
        {
            return Context.SaveChangesAsync();
        }


        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : MainModel
        {
            return await Context.Set<TEntity>()
                .ToListAsync();
        }

        public Task<TEntity> Get<TEntity>(Guid id) where TEntity : MainModel
        {
            return Context.Set<TEntity>()
                .FirstOrDefaultAsync(entity =>
                    entity.IsDeleted == false &&
                    entity.Id == id);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : MainModel
        {
            if (entity == null)
            {
                return;
            }
            entity.IsDeleted = true;
            Context.Update(entity);
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : MainModel
        {
            return Context.Set<TEntity>()
                .Update(entity)
                .Entity;
        }
    }
}
