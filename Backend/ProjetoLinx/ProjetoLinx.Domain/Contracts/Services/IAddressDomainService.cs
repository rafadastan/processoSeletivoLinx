using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Domain.Contracts.Services
{
    public interface IAddressDomainService : IBaseDomainService<Address, Guid>
    {
        Task<Address> CreateAddress(Address address);
        Task<Address> UpdateAddress(Address address);
    }
}
