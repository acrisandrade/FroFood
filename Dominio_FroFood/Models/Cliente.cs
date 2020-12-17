using System.Collections.Generic;

namespace Dominio_FroFood.Models
{
    public class Cliente : Usuario
    {
        public IEnumerable<Pedido> HistoricoPedidos { get; set; }
        public  IEnumerable<Endereco> Endereco { get; set; }
    }
}
