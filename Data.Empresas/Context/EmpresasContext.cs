using Domain.Empresas.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data.Empresas.Context
{
    public class EmpresasContext : DbContext
    {
        public EmpresasContext(DbContextOptions<EmpresasContext> options) : base(options) 
        { }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseType> EnterpriseTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ControlToken> ControlTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Ignore<BaseEntity>();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
