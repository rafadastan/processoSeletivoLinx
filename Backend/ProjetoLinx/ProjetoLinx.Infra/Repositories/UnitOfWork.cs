using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Infra.Context;

namespace ProjetoLinx.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _sqlContext;
        private readonly IDbContextTransaction _contextTransaction;

        public UnitOfWork(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task BeginTransaction()
        {
            _sqlContext.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            _sqlContext.Database.CommitTransaction();
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
            await _sqlContext.SaveChangesAsync();
        }

        public IAddressRepository AddressRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
    }
}
