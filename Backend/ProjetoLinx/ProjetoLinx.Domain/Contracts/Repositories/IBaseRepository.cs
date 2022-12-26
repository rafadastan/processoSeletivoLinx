using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T, TKey> 
        where T : class
        where TKey : struct
    {
        Task<T> Insert(T obj);
        Task<T> Update(T obj);
        Task Delete(T obj);
        Task<List<T>> GetAll();
        Task<T> GetById(TKey id);
    }
}
