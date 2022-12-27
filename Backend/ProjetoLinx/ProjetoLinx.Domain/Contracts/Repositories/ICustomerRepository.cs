using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Domain.Contracts.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, Guid>
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetByCustomer(Guid customerId);
    }
}
