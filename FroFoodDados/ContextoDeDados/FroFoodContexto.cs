using Dominio_FroFood.Models;
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
        public DbSet<Usuario> Usuario { get; set; }

        public FroFoodContexto(DbContextOptions<FroFoodContexto> options) : base(options)
        {

        }
        public DbSet<Dominio_FroFood.ViewModels.ClienteView> Cliente { get; set; }

    }
}
