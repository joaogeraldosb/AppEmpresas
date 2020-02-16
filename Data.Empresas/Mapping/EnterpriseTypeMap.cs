using Domain.Empresas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.Empresas.Mapping
{
    public class EnterpriseTypeMap : IEntityTypeConfiguration<EnterpriseType>
    {
        public void Configure(EntityTypeBuilder<EnterpriseType> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(50)").IsRequired();

            var streamReader = new StreamReader("..\\Data.Empresas\\JsonData\\SeedEnterpriseTypes.json");
            var dataEnterpriseTypes = JsonConvert.DeserializeObject<EnterpriseType[]>(streamReader.ReadToEnd());

            builder.HasData(dataEnterpriseTypes);
        }
    }
}
