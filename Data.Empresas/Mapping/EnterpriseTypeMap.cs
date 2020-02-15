using Domain.Empresas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Empresas.Mapping
{
    public class EnterpriseTypeMap : IEntityTypeConfiguration<EnterpriseType>
    {
        public void Configure(EntityTypeBuilder<EnterpriseType> builder)
        {
            
        }
    }
}
