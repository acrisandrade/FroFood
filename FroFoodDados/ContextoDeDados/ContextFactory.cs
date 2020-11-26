﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace FroFoodDados.ContextoDeDados
{
    public class ContextFactory : IDesignTimeDbContextFactory<FroFoodContexto>
    {
        public FroFoodContexto CreateDbContext(string[] args)
        {
            var stringDeConexao = "Server = (localdb)\\mssqllocaldb;Database=FroFoodProject;Trusted_Connection=True;MultipleActiveResultSets=true";
            var opcoesDeConstrucao = new DbContextOptionsBuilder<FroFoodContexto>();
            opcoesDeConstrucao.UseSqlServer(stringDeConexao);
            return new FroFoodContexto(opcoesDeConstrucao.Options);
        }
    }
}
