using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domain.Empresas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Data.Empresas.Mapping
{
    public class EnterpriseMap : IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(m => m.Description).HasColumnType("varchar(250)").IsRequired();
            builder.Property(m => m.RegistrationDate).HasColumnType("datetime").IsRequired();

            builder.HasOne(m => m.EnterpriseType)
                .WithMany(m => m.Enterprises)
                .HasForeignKey(m => m.IdEnterpriseType)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(m => m.Contact, contact =>
            {
                contact.Property(m => m.ContactName).HasColumnType("varchar(100)").HasColumnName("ContactName").IsRequired(true);
                contact.Property(m => m.Phone).HasColumnType("varchar(15)").HasColumnName("Phone").IsRequired(false);
                contact.Property(m => m.CellPhone).HasColumnType("varchar(15)").HasColumnName("CellPhone").IsRequired(true);
                contact.Property(m => m.Email).HasColumnType("varchar(100)").HasColumnName("Email").IsRequired(true);
            });

            var streamReader = new StreamReader("..\\Data.Empresas\\JsonData\\SeedEnterprises.json");
            var dataEnterprises = JsonConvert.DeserializeObject<Enterprise[]>(streamReader.ReadToEnd());

            //builder.HasData(dataEnterprises);
        }
    }
}
