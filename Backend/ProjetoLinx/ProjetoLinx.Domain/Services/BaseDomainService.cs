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

        public virtual async Task Create(T entity)
        {
            await _repository.Insert(entity);
        }

        public virtual async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public virtual async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> GetById(TKey entity)
        {
            return await _repository.GetById(entity);
        }
    }
}
