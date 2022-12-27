using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Application.Contracts
{
    public interface ICustomerApplicationService
    {
        Task<CustomerDto> CreateCustomerAsync(CustomerDto customer);
        Task<CustomerDto> UpdateCustomerAsync(CustomerDto customer);
        Task DeleteCustomerAsync(Guid customerId);

        Task<CustomerDto> GetByCustomer(Guid customerId);
        Task<List<CustomerDto>> GetAllCustomerAsync();
        Task<CustomerDto> GetById(Guid customerId);
    }
}
