using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProjetoLinx.Application.Contracts;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Domain.Contracts.Services;
using ProjetoLinx.Domain.Entities;
using SUC.Domain.Notifications;
using SUC.Validations;

namespace ProjetoLinx.Application.Services
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerDomainService _customerDomainService;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;
        
        public CustomerApplicationService(ICustomerDomainService customerDomainService, 
            IMapper mapper, 
            NotificationContext notificationContext)
        {
            _customerDomainService = customerDomainService;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);

            if (!CpfValidation.IsValid(customer.Cpf))
                _notificationContext.AddNotification(customer.Cpf, "Cpf Inválido");

            if (_notificationContext.HasNotifications)
                return null;

            customerEntity = await _customerDomainService.CreateCustomerAsync(customerEntity);
            
            return new CustomerDto
            {
                Name = customerEntity.Name,
                Cpf = customerEntity.Cpf,
                AddressDto = _mapper.Map<AddressDto>(customerEntity.Address)
            };
        }

        public Task<CustomerDto> UpdateCustomerAsync(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = await _customerDomainService.GetById(customerId);

            if(customer == null)
                _notificationContext.AddNotification(customerId.ToString(), "Erro ao deletar");

            if (!_notificationContext.HasNotifications)
                await _customerDomainService.Delete(customer);
            else
                return;
        }

        public async Task<CustomerDto> GetByCustomer(Guid customerId)
        {
            var customer = await _customerDomainService.GetByCustomer(customerId);

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetAllCustomerAsync()
        {
            var customerList = await _customerDomainService.GetAll();

            return _mapper.Map<List<CustomerDto>>(customerList);
        }

        public async Task<CustomerDto> GetById(Guid customerId)
        {
            var customer =  await _customerDomainService.GetById(customerId);
            
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
