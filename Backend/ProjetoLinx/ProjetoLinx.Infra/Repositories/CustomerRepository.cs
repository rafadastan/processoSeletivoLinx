using Microsoft.EntityFrameworkCore;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Entities;
using ProjetoLinx.Infra.Context;
using SUC.Domain.Notifications;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

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

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            _sqlContext.Customer.Add(customer);
            _sqlContext.Address.Add(customer.Address);

            _sqlContext.Entry(customer).State = EntityState.Added;

            _sqlContext.SaveChanges();

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _sqlContext.Customer.Update(customer);
            _sqlContext.Address.Update(customer.Address);

            await _sqlContext.SaveChangesAsync();
            
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var query = _sqlContext
                .Customer
                .Include(c => c.Address)
                .ToList();

            return query;
        }

        public async Task<Customer> GetByCustomer(Guid customerId)
        {
            var query = _sqlContext.Customer
                .Include(c => c.Address)
                .FirstOrDefault(c => c.CustomerId == customerId);
            
            return await Task.FromResult(query);
        }
    }
}
