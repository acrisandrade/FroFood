using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Dominio_FroFood.Models
{
    public class Item : ClasseBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public int Tamanho { get; set; }
        public string Categoria { get; set; }
        public Restaurante Restaurante { get; set; }
        public IEnumerable<ItemPedido> Pedidos { get; set; }
        public string NomeImagem { get; set; }
        public IFormFile Imagem { get; set; }
    }
}
