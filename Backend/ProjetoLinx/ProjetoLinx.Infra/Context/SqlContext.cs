using Microsoft.EntityFrameworkCore;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Infra.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }
        
    }
}
