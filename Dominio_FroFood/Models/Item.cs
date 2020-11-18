using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public int Tamanho { get; set; }
        public string Categoria { get; set; }
        public Guid RestauranteId { get; set; }

        //TODO
        //Adicionar Imagem
    }
}
