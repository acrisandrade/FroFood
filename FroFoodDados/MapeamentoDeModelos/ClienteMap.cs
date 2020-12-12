using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(e => e.Id);
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Telefone).HasMaxLength(9).IsRequired();
            builder.HasMany(c => c.HistoricoPedidos);
        }
    }
}
