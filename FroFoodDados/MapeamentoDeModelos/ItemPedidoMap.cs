using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(bc => new { bc.PedidoId, bc.ItemId });
            builder.HasOne(bc => bc.Pedido)
                .WithMany(b => b.Itens)
                .HasForeignKey(bc => bc.PedidoId);
            builder.HasOne(bc => bc.Item)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(bc => bc.ItemId);
        }
    }
}
