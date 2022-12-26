using ProjetoLinx.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Domain.Contracts.Services
{
    public interface ICustomerDomainService : IBaseDomainService<Customer, Guid>
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
