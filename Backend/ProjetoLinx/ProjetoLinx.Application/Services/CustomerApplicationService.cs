using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using AutoMapper.Execution;
using ProjetoLinx.Application.Contracts;
using ProjetoLinx.Application.DTO;
using ProjetoLinx.Application.Model;
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
        public CustomerApplicationService(
                ICustomerDomainService customerDomainService,
                IMapper mapper, 
                NotificationContext notificationContext
            )
        {
            _customerDomainService = customerDomainService;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<CustomerModel> CreateCustomerAsync(CustomerModel customerModel)
        {
            CustomerDto customerDto = null;

            if (customerModel != null)
            {
                customerDto = new CustomerDto
                {
                    Name = customerModel.Name,
                    Cpf = customerModel.Cpf,
                    AddressDto = new AddressDto
                    {
                        Street = customerModel.Street,
                        City = customerModel.City,
                        State = customerModel.State,
                        Neighborhood = customerModel.Neighborhood,
                        Number = customerModel.Number,
                        Cep = customerModel.Cep
                    }
                };
            }

            var customer = _mapper.Map<Customer>(customerDto);

            if (!CpfValidation.IsValid(customerModel.Cpf))
                _notificationContext.AddNotification(customerModel.Cpf, "Cpf Inválido");

            if (_notificationContext.HasNotifications)
                return null;

            customer = await _customerDomainService.CreateCustomerAsync(customer);
            if (_notificationContext.HasNotifications)
                return null;

            var response = new CustomerModel
            {
                Name = customer.Name,
                Cpf = customer.Cpf,
                Street = customer?.Address.Street,
                City = customer?.Address.City,
                State = customer?.Address.State,
                Neighborhood = customer?.Address.Neighborhood,
                Number = customer?.Address.Number,
                Cep = customer?.Address.Cep
            };

            return _notificationContext.HasNotifications ? null : response;
        }

        public async Task<UpdateCustomer> UpdateCustomerAsync(Guid customerId, UpdateCustomer updateCustomer)
        {
            CustomerDto customerDto = null;

            if (updateCustomer != null)
            {
                customerDto = new CustomerDto
                {
                    Name = updateCustomer.Name,
                    Cpf = updateCustomer.Cpf,
                    AddressDto = new AddressDto
                    {
                        Street = updateCustomer.Street,
                        City = updateCustomer.City,
                        State = updateCustomer.State,
                        Neighborhood = updateCustomer.Neighborhood,
                        Number = updateCustomer.Number,
                        Cep = updateCustomer.Cep
                    }
                };
            }
            
            var customer = _mapper.Map<Customer>(customerDto);
            
            customer = await _customerDomainService.UpdateCustomerAsync(customerId, customer);
            if (_notificationContext.HasNotifications)
                return null;
            
            var response = new UpdateCustomer
            {
                Name = customer.Name,
                Cpf = customer.Cpf,
                Street = customer.Address.Street,
                City = customer.Address.City,
                State = customer.Address.State,
                Neighborhood = customer.Address.Neighborhood,
                Number = customer.Address.Number,
                Cep = customer.Address.Cep
            };

            return _notificationContext.HasNotifications ? null : response;
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
