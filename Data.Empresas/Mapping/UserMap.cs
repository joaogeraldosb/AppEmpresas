using Domain.Empresas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Empresas.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(m => m.Id)
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(m => m.Name).HasColumnType("varchar(100)").IsRequired().IsUnicode(false);
            builder.Property(m => m.Senha).IsRequired();
            builder.Property(m => m.UltimoLogin).IsRequired(false);
        }

    }
}
