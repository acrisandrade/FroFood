using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class AvaliacaoMap : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.ToTable("Avaliacao");
            builder.HasKey(e => e.Id);
            builder.Property(a => a.Comentario).HasMaxLength(250);
            builder.Property(a => a.Nota).IsRequired();
            builder.HasOne(a => a.Pedido);
            
        }
    }
}
