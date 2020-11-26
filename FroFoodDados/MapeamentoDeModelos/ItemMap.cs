using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");
            builder.HasKey(e => e.Id);
            builder.Property(i => i.Nome).IsRequired();
            builder.Property(i => i.Descricao).HasMaxLength(200);
            builder.Property(i => i.Valor).IsRequired();
            builder.Property(i => i.Tamanho).HasDefaultValue(0);
            builder.Property(i => i.Categoria).IsRequired();
            builder.HasOne(i => i.Restaurante);
        }
    }
}
