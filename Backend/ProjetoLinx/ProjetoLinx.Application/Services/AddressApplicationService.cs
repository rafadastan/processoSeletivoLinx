using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjetoLinx.Application.Contracts;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Application.Model;
using ProjetoLinx.Domain.Contracts.Services;
using ProjetoLinx.Domain.Entities;
using SUC.Domain.Notifications;

namespace ProjetoLinx.Application.Services
{
    public class AddressApplicationService : IAddressApplicationService
    {
        private readonly IAddressDomainService _addressDomainService;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;

        public AddressApplicationService(
            IAddressDomainService addressDomainService, 
            IMapper mapper, 
            NotificationContext notificationContext)
        {
            _addressDomainService = addressDomainService;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<AddressDto> CreateAddressAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            address = await _addressDomainService.CreateAddress(address);
            if (_notificationContext.HasNotifications)
                return null;

            var response = new AddressDto
            {
                Street = address.Street,
                City = address.City,
                State = address.State,
                Neighborhood = address.Neighborhood,
                Number = address.Number,
                Cep = address.Cep
            };

            return _notificationContext.HasNotifications ? null : response;
        }

        public async Task<AddressDto> UpdateAddressAsync(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            address = await _addressDomainService.UpdateAddress(address);
            if (_notificationContext.HasNotifications)
                return null;

            var response = new AddressDto
            {
                Street = address.Street,
                City = address.City,
                State = address.State,
                Neighborhood = address.Neighborhood,
                Number = address.Number,
                Cep = address.Cep
            };

            return _notificationContext.HasNotifications ? null : response;
        }

        public async Task DeleteAddressAsync(Guid addressId)
        {
            var addressDto = GetById(addressId);

            if (addressDto != null)
            {
                var address = _mapper.Map<Address>(addressDto);
                await _addressDomainService.Delete(address);
                if (_notificationContext.HasNotifications)
                    return;
            }
        }

        public async Task<List<AddressDto>> GetAllAddressAsync()
        {
            var addressList = await _addressDomainService.GetAll();

            return _mapper.Map<List<AddressDto>>(addressList);
        }

        public async Task<AddressDto> GetById(Guid addressId)
        {
            var address = await _addressDomainService.GetById(addressId);

            return _mapper.Map<AddressDto>(address);
        }
    }
}
