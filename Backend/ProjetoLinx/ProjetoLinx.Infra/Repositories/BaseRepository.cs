using Microsoft.EntityFrameworkCore;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Infra.Context;
using SUC.Domain.Notifications;

namespace ProjetoLinx.Infra.Repositories
{
    public abstract class BaseRepository<T, TKey> : IBaseRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        private readonly SqlContext _sqlContext;
        private readonly NotificationContext _notificationContext;
        
        public BaseRepository(SqlContext sqlContext, 
            NotificationContext notificationContext)
        {
            _sqlContext = sqlContext;
            _notificationContext = notificationContext;
        }

        public virtual async Task<T> Insert(T obj)
        {
            _sqlContext.Entry(obj).State = EntityState.Added;
            _sqlContext.SaveChanges();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _sqlContext.Entry(obj).State = EntityState.Modified;
            _sqlContext.SaveChanges();

            if (obj == null)
                _notificationContext.AddNotification(
                    _sqlContext.ContextId.ToString(), "Erro ao atualizar");

            return obj;
        }

        public virtual async Task Delete(T obj)
        {
            _sqlContext.Entry(obj).State = EntityState.Deleted;
            _sqlContext.SaveChanges();

            if(obj == null)
                _notificationContext.AddNotification(
                    _sqlContext.ContextId.ToString(), "Erro ao atualizar");
        }

        public virtual async Task<List<T>> GetAll()
        {
            return _sqlContext.Set<T>()
                .AsNoTracking()
                .ToList();
        }

        public async Task<T> GetById(TKey id)
        {
            var entity = _sqlContext.Set<T>()
                .Find(id);

            return entity;
        }
    }
}
