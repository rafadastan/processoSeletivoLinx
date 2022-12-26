using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Contracts.Services;

namespace ProjetoLinx.Domain.Services
{
    public abstract class BaseDomainService<T, TKey> : IBaseDomainService<T, TKey>
        where T : class
        where TKey : struct
    {
        private readonly IBaseRepository<T, TKey> _repository;

        protected BaseDomainService(IBaseRepository<T, TKey> repository)
        {
            _repository = repository;
        }

        public virtual Task Create(T entity)
        {
            return _repository.Insert(entity);
        }

        public virtual Task Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public virtual Task Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual Task<List<T>> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<T> GetById(TKey entity)
        {
            return _repository.GetById(entity);
        }
    }
}
