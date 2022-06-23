using Main.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Main.DataRepository
{
    public interface IRepository
    {
        Task<TEntity> Create<TEntity>(TEntity entity)
            where TEntity : MainModel;
        Task<IEnumerable<TEntity>> GetAll<TEntity>()
            where TEntity : MainModel;
        Task<TEntity> Get<TEntity>(Guid id)
            where TEntity : MainModel;
        void Delete<TEntity>(TEntity entity)
            where TEntity : MainModel;
        TEntity Update<TEntity>(TEntity entity)
            where TEntity : MainModel;

        Task<int> Complete();
    }
}
