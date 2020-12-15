using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Dominio_FroFood.Interfaces.Servico;
using Dominio_FroFood.ViewModels;
using FroFoodCrossCut.Mappings;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IRestauranteService _res;
        private readonly IItemService _item;
        private readonly IClienteService _cli;

        public PedidosController(IPedidoService service, IRestauranteService res, IItemService item, IClienteService cli)
        {
            _service = service;
            _res = res;
            _item = item;
            _cli = cli;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        [HttpGet("listar/{id}")]
        public async Task<ActionResult<IEnumerable<PedidoView>>> GetPedidoBuUser(Guid id)
        {
            var resultado = await _service.buscarPorUsuario(id);
            var pview = new List<PedidoView>();
            foreach(var p in resultado)
            {
                pview.Add(ViewToModel.PedidoToPedidoView(new PedidoView(), p));
            }
            return Ok(pview);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoView>> GetPedido(Guid id)
        {
            var pedido = await _service.BuscarAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return ViewToModel.PedidoToPedidoView(new PedidoView(), pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pedido>> PutPedido(Pedido pedido)
        {
            var resultado = await _service.EditarAsync(pedido);

            if (resultado != null)
            {
                return Ok(resultado);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PedidoView>> PostPedido(PedidoView pedido)
        {
            var p = new Pedido()
            {
                Restaurante = await _res.BuscarAsync(pedido.Restaurante),
                Cliente = await _cli.BuscarAsync(pedido.Cliente),
                Status = "Pendente",
                Observacao = pedido.Observacao,
                Valor = pedido.Valor,
                Pagamento = pedido.Pagamento,
            };

            var l = new List<ItemPedido>();
            var ip = new ItemPedido
            {
                ItemId = pedido.Item.Id
            };
            l.Add(ip);

            try
            {
                p.Itens = l;
            } catch (Exception e)
            {
                throw e;
            }
            var resultado = await _service.AdicionarAsync(p);

            return CreatedAtAction("GetPedido", new { id = resultado.Id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePedido(Guid id)
        {
            var resultado = await _service.ExcluirAsync(id);

            if (resultado == false)
            {
                return NotFound();
            }

            return resultado;
        }
    }
}
