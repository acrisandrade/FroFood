using Dominio_FroFood.Models;
using FroFoodDados.MapeamentoDeModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.ContextoDeDados
{
    public class FroFoodContexto : DbContext
    {
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Cliente> Usuario { get; set; }

        public FroFoodContexto(DbContextOptions<FroFoodContexto> options) : base (options)
        {

        }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Avaliacao>(new AvaliacaoMap().Configure);
            builder.Entity<Cliente>(new ClienteMap().Configure);
            builder.Entity<Endereco>(new EnderecoMap().Configure);
            builder.Entity<Item>(new ItemMap().Configure);
            builder.Entity<Pedido>(new PedidoMap().Configure);
            builder.Entity<Restaurante>(new RestauranteMap().Configure);
        }

    }
}
