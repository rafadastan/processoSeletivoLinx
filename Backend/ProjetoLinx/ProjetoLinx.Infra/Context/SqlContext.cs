using Microsoft.EntityFrameworkCore;
using ProjetoLinx.Domain.Entities;
using ProjetoLinx.Infra.Mapping;
using System.Numerics;

namespace ProjetoLinx.Infra.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options){}

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }   
    }
}
