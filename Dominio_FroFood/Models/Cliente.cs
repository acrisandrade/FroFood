using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_FroFood.Models
{
    public class Cliente : Usuario
    {
        public IEnumerable<Pedido> HistoricoPedidos { get; set; }
    }
}
