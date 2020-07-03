using Microsoft.EntityFrameworkCore;
using Copa.Domain.Entities;
using Copa.Infra.Data.Contexto.Configurations;

namespace Copa.Infra.Data.Contexto
{
    public class ContextoAplicacao : DbContext
    {
        public ContextoAplicacao()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Banco;user id=lesins;password=123;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Banco;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #region Entities

        public DbSet<Equipe> Equipes { get; set; }

        #endregion Entities
    }
}