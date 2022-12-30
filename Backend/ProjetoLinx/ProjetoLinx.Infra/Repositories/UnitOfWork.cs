using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Infra.Context;
using SUC.Domain.Notifications;

namespace ProjetoLinx.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        private readonly NotificationContext _notificationContext;
        private readonly IDbContextTransaction _contextTransaction;

        public UnitOfWork(SqlContext sqlContext, 
            NotificationContext notificationContext)
        {
            _sqlContext = sqlContext;
            _notificationContext = notificationContext;
        }

        public async Task BeginTransaction()
        {
           _sqlContext.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync()
        {
           await _sqlContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
           _sqlContext.Database.CommitTransaction();
        }

        public async Task CommitAsync()
        {
            _sqlContext.Database.CommitTransactionAsync();
        }

        public async Task RollBack()
        {
            _sqlContext.Database.RollbackTransaction();
        }

        public async Task Save()
        {
            _sqlContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            _sqlContext.SaveChangesAsync();
        }

        public IAddressRepository AddressRepository 
            => new AddressRepository(_sqlContext, _notificationContext);

        public ICustomerRepository CustomerRepository 
            => new CustomerRepository(_sqlContext, _notificationContext);
    }
}
