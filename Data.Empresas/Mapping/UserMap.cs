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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Id)
                    .UseSqlServerIdentityColumn()
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(m => m.Name).HasColumnType("varchar(100)").IsRequired().IsUnicode(false);
            builder.Property(m => m.Password).IsRequired();
            builder.Property(m => m.LastLoginDate).IsRequired(false);

            var streamReader = new StreamReader("..\\Data.Empresas\\JsonData\\SeedUsers.json");
            var dataUsers = JsonConvert.DeserializeObject<User[]>(streamReader.ReadToEnd());

            builder.HasData(dataUsers);
        }

    }
}
