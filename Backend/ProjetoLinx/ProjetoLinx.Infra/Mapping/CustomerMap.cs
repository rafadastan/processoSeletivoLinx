using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoLinx.Infra.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable<Customer>("Customer");

            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithOne()
                .HasForeignKey<Address>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
