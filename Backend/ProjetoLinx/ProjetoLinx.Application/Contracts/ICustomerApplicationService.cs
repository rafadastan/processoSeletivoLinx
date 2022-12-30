using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Application.Model;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Application.Contracts
{
    public interface ICustomerApplicationService
    {
        Task<CustomerModel> CreateCustomerAsync(CustomerModel customerModel);
        Task<UpdateCustomer> UpdateCustomerAsync(Guid customerId, UpdateCustomer customer);
        Task DeleteCustomerAsync(Guid customerId);

        Task<CustomerDto> GetByCustomer(Guid customerId);
        Task<List<CustomerDto>> GetAllCustomerAsync();
        Task<CustomerDto> GetById(Guid customerId);
    }
}
