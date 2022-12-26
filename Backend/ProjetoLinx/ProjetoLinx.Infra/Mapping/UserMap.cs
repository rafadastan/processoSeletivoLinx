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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable<User>("User");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserId)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.Name)
                .HasMaxLength(200)
                .IsRequired();


        }
    }
}
