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
        Task<Customer> UpdateCustomerAsync(Guid customerId, Customer customer);
        Task<Customer> GetByCustomer(Guid customerId);
    }
}
