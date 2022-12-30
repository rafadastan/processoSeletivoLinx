using ProjetoLinx.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Application.Contracts
{
    public interface IAddressApplicationService
    {
        Task<AddressDto> CreateAddressAsync(AddressDto addressDto);
        Task<AddressDto> UpdateAddressAsync(AddressDto addressDto);
        Task DeleteAddressAsync(Guid addressId);

        Task<List<AddressDto>> GetAllAddressAsync();
        Task<AddressDto> GetById(Guid addressId);
    }
}
