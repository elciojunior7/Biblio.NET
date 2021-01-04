using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class KartConfiguration : IEntityTypeConfiguration<Kart>
    {
        public void Configure(EntityTypeBuilder<Kart> builder)
        {
            // Gera Chave Primaria Composta
            builder.HasKey(c => c.KartID);
        }
    }
}