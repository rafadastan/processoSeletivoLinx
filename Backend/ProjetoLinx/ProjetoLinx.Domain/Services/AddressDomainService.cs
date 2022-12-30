using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Contracts.Services;
using ProjetoLinx.Domain.Entities;
using SUC.Domain.Notifications;

namespace ProjetoLinx.Domain.Services
{
    public class AddressDomainService : BaseDomainService<Address, Guid>,
        IAddressDomainService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;
        
        public AddressDomainService(
            IAddressRepository addressRepository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext) 
            : base(unitOfWork.AddressRepository)
        {
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
            _addressRepository = addressRepository;
        }

        public async Task<Address> CreateAddress(Address address)
        {
            using (var uow = _unitOfWork.BeginTransaction())
            {
                address = await _addressRepository.Insert(address);
                if (_notificationContext.HasNotifications)
                {
                    await _unitOfWork.RollBack();
                    return null;
                }

                await _unitOfWork.Commit();

                await _unitOfWork.Save();
            }

            return _notificationContext.HasNotifications ? null : address;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            address = await _unitOfWork.AddressRepository.Update(address);
            if (_notificationContext.HasNotifications)
            {
                await _unitOfWork.RollBack();
                return null;
            }

            await _unitOfWork.Save();

            return _notificationContext.HasNotifications ? null : address;
        }
    }
}
