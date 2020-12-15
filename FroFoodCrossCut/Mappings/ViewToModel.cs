using AutoMapper;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;

namespace FroFoodCrossCut.Mappings
{
    public class ViewToModel
    {
        public static ItemView ItemToItemView(ItemView iview, Item item)
        {

            iview.Id = item.Id;
            iview.Nome = item.Nome;
            iview.Descricao = item.Descricao;
            iview.Valor = item.Valor;
            iview.Tamanho = item.Tamanho;
            iview.Categoria = item.Categoria;
            iview.RestauranteId = item.Restaurante.Id;

            return iview;
        }

        public static PedidoView PedidoToPedidoView(PedidoView pView, Pedido pedido)
        {

            pView.Id = pedido.Id;
            pView.Valor = pedido.Valor;
            pView.Observacao = pedido.Observacao;
            pView.Restaurante = pedido.Restaurante.Id;
            pView.Cliente = pedido.Cliente.Id;
            pView.Status = pedido.Status;
            pView.Pagamento = pedido.Pagamento;
            foreach(var i in pedido.Itens)
            {
                pView.Item = ItemToItemView(new ItemView(), i.Item);
            }
            
            return pView;
        }
    }
}
