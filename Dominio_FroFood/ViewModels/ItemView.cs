﻿using Dominio_FroFood.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.ViewModels
{
    public class ItemView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public Guid RestauranteId { get; set; }
        public int Tamanho { get; set; }
        public Decimal Valor { get; set; }
        public string NomeImagem { get; set; }
        public IFormFile Imagem { get; set; }
    }
}
