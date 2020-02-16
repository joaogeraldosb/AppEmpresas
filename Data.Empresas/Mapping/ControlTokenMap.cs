using Domain.Empresas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Empresas.Mapping
{
    public class ControlTokenMap : IEntityTypeConfiguration<ControlToken>
    {
        public void Configure(EntityTypeBuilder<ControlToken> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(m => m.Client).HasColumnType("varchar(50)").IsUnicode(false).IsRequired();
            builder.Property(m => m.Token).HasColumnType("varchar(250)").IsRequired();
            builder.Property(m => m.SolicitationDate).IsRequired();
            builder.Property(m => m.AuthenticationDate).IsRequired(false);
        }
    }
}
