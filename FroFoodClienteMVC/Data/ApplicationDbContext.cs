using System;
using System.Collections.Generic;
using System.Text;
using FroFoodClienteMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dominio_FroFood.Models;

namespace FroFoodClienteMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dominio_FroFood.Models.Endereco> Endereco { get; set; }
    }
}
