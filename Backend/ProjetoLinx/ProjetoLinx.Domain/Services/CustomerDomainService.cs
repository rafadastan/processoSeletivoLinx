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
    public class CustomerDomainService : BaseDomainService<Customer, Guid>, 
        ICustomerDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly NotificationContext _notificationContext;

        public CustomerDomainService(IUnitOfWork unitOfWork, 
            ICustomerRepository customerRepository, 
            IAddressRepository addressRepository, 
            NotificationContext notificationContext) 
            : base(unitOfWork.CustomerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using (var uow = _unitOfWork.BeginTransaction())
            {
                customer = await _customerRepository.Insert(customer);
                if (_notificationContext.HasNotifications)
                {
                    await _unitOfWork.RollBack();
                    return null;
                }

                customer.Address = await _addressRepository.Insert(customer.Address);
                if (_notificationContext.HasNotifications)
                {
                    await _unitOfWork.RollBack();
                    return null;
                }
                await _unitOfWork.Commit();

                await _unitOfWork.Save();
            }
            
            return customer;
        }

        public override async Task<List<Customer>> GetAll()
        {
            var customerList = await _customerRepository.GetAllCustomers();

            if (customerList == null)
                _notificationContext.AddNotification(Guid.NewGuid().ToString(), "Erro ao buscar cliente.");

            return _notificationContext.HasNotifications ? null : customerList;
        }
    }
}
