using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Domain.Contracts.Services
{
    public interface IBaseDomainService<T, TKey>
        where T : class 
        where TKey : struct 
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);

        Task<List<T>> GetAll();
        Task<T> GetById(TKey entity);
    }
}
