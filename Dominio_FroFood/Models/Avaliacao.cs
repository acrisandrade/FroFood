namespace Dominio_FroFood.Models
{
    public class Avaliacao : ClasseBase
    {
        public string Comentario { get; set; }
        public int Nota { get; set; }
        public Pedido Pedido { get; set; }
    }
}
