using Dominio_FroFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.MapeamentoDeModelos
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Rua).IsRequired();
            builder.Property(e => e.Bairro).IsRequired();
            builder.Property(e => e.Cidade).IsRequired();
            builder.Property(e => e.Estado).IsRequired();
            builder.Property(e => e.Numero).HasMaxLength(4).IsRequired();
        }
    }
}
