using Microsoft.EntityFrameworkCore;
using ProjetoLinx.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoLinx.Infra.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable<Address>("Address");

            builder.HasKey(x => x.AddressId);

            builder.Property(x => x.AddressId)
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasMaxLength(10);

            builder.Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Neighborhood)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.State)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
