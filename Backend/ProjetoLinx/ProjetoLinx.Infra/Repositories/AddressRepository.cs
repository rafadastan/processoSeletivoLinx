using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Entities;
using ProjetoLinx.Infra.Context;
using SUC.Domain.Notifications;

namespace ProjetoLinx.Infra.Repositories
{
    public class AddressRepository : BaseRepository<Address, Guid>, 
        IAddressRepository
    {
        private readonly SqlContext _sqlContext;
        private readonly NotificationContext _notificationContext;

        public AddressRepository(SqlContext sqlContext, 
            NotificationContext notificationContext) 
            : base(sqlContext, notificationContext)
        {
            _sqlContext = sqlContext;
            _notificationContext = notificationContext;
        }

        public async Task<Address> GetByCustomerIdAsync(Guid id)
        {
            var query = from address in _sqlContext.Address
                where address.AddressId == id
                select address;

            return query.FirstOrDefault();
        }
    }
}
