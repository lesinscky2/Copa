using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Copa.Domain.Entities;

namespace Copa.Infra.Data.Contexto.Configurations
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Anuncios");

            builder.HasIndex(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sigla)
                .IsRequired();

            builder.Property(x => x.Gols)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}