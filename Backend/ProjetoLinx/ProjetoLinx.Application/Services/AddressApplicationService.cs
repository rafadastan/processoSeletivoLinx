using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Application.Contracts;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Domain.Contracts.Services;

namespace ProjetoLinx.Application.Services
{
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly IAddressDomainService _addressDomainService;

        public AddressApplicationService(IAddressDomainService addressDomainService)
        {
            _addressDomainService = addressDomainService;
        }

        public Task<AddressDto> CreateAddressAsync(AddressDto address)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> UpdateAddressAsync(CustomerDto address)
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> DeleteAddressAsync(Guid addressId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AddressDto>> GetAllAddressAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AddressDto> GetById(Guid addressId)
        {
            throw new NotImplementedException();
        }
    }
}
