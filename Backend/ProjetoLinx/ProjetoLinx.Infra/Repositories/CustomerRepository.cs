using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Entities;
using ProjetoLinx.Infra.Context;
using SUC.Domain.Notifications;

namespace ProjetoLinx.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, 
        ICustomerRepository
    {
        private readonly SqlContext _sqlContext;
        public CustomerRepository(SqlContext sqlContext, 
            NotificationContext notificationContext) 
            : base(sqlContext, notificationContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var query = from customer in _sqlContext.Customer
                join address in _sqlContext.Address
                    on customer.CustomerId equals address.CustomerId
                where address.CustomerId.Equals(customer.CustomerId)
                select new Customer(customer.CustomerId, customer.Name, customer.Cpf)
                {
                    Address = address
                };

            return query.ToList();
        }

        public async Task<Customer> GetByCustomer(Guid customerId)
        {
            var query = from customer in _sqlContext.Customer
                join address in _sqlContext.Address
                    on customer.CustomerId equals address.CustomerId
                where customer.CustomerId.Equals(customerId)
                select new Customer(customer.CustomerId, customer.Name, customer.Cpf)
                {
                    Address = address
                };

            return await Task.FromResult(query.FirstOrDefault());
        }
    }
}
