using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class RestauranteMap : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            var converter = new EnumToStringConverter<FormaPagamento>();
            builder.ToTable("Restaurantes");
            builder.HasKey(e => e.Id);
            builder.HasIndex(r => r.Email).IsUnique();
            builder.Property(r => r.Descricao).HasMaxLength(250);
            builder.HasOne(r => r.Endereco);
            builder.HasMany(r => r.Cardapio);
            builder.Property(r => r.Pagamento).HasConversion(converter);
        }
    }
}
