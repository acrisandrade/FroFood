using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            var converter = new EnumToStringConverter<FormaPagamento>();
            builder.ToTable("Pedido");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Valor).IsRequired();
            builder.Property(p => p.Observacao).HasMaxLength(200);
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Pagamento).HasConversion(converter);
        }
    }
}
