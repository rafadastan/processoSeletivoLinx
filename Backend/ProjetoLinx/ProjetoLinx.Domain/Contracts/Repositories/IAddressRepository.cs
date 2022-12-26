using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Domain.Contracts.Repositories
{
    public interface IAddressRepository : IBaseRepository<Address, Guid>
    {
        Task<Address> GetByCustomerIdAsync(Guid id);
    }
}
