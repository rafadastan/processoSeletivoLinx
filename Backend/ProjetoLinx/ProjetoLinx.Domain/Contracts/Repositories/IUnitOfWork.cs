using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task BeginTransactionAsync();
        Task Commit();
        Task CommitAsync();
        Task RollBack();

        Task Save();
        Task SaveAsync();

        IAddressRepository AddressRepository { get; }
        ICustomerRepository CustomerRepository { get; }
    }
}
