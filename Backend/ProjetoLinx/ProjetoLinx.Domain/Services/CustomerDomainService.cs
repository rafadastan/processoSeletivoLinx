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
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationContext _notificationContext;

        public CustomerDomainService( 
            ICustomerRepository customerRepository,
            IAddressRepository addressRepository,
            IUnitOfWork unitOfWork,
            NotificationContext notificationContext) 
            : base(unitOfWork.CustomerRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            using (var uow = _unitOfWork.BeginTransaction())
            {
                customer = await _unitOfWork.CustomerRepository.CreateCustomer(customer);
                if (_notificationContext.HasNotifications)
                {
                    await _unitOfWork.RollBack();
                    return null;
                }

                await _unitOfWork.Commit();
                await _unitOfWork.Save();
            }

            return _notificationContext.HasNotifications ? null : customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Guid customerId, Customer customer)
        {
            var hasCustomer = await GetByCustomer(customerId);

            if (hasCustomer == null)
                _notificationContext
                    .AddNotification(customerId.ToString(), "Cliente não existe");

            if (_notificationContext.HasNotifications)
                return null;

            MapperUpdateCustomer(customerId, customer, hasCustomer);

            using (var uow = _unitOfWork.BeginTransaction())
            {
                customer = await _unitOfWork.CustomerRepository.UpdateCustomer(customer);
                if (_notificationContext.HasNotifications)
                {
                    await _unitOfWork.RollBack();
                    return null;
                }

                await _unitOfWork.Commit();
                await _unitOfWork.SaveAsync();
            }
            
            return _notificationContext.HasNotifications ? null : customer;
        }

        

        public async Task<Customer> GetByCustomer(Guid customerId)
        {
            var customer = await _customerRepository.GetByCustomer(customerId);

            if (customer == null)
                _notificationContext.AddNotification(customerId.ToString(), "Erro ao buscar cliente.");

            return _notificationContext.HasNotifications ? null : customer;
        }

        public override async Task<List<Customer>> GetAll()
        {
            var customerList = await _customerRepository.GetAllCustomers();

            if (customerList == null)
                _notificationContext.AddNotification(Guid.NewGuid().ToString(), "Erro ao buscar cliente.");

            return _notificationContext.HasNotifications ? null : customerList;
        }

        public override async Task<Customer> GetById(Guid entity)
        {
            return await _customerRepository.GetById(entity);
        }

        private void MapperUpdateCustomer(Guid customerId, Customer customer, Customer? hasCustomer)
        {
            customer.CustomerId = customerId;
            if (hasCustomer != null) customer.Address.AddressId = hasCustomer.Address.AddressId;
        }
    }
}
