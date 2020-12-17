using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio_FroFood.Models;
using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.ViewModels;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _service;
        private readonly IPedidoRepositorio _pedido;
        private readonly IClienteRepositorio _cliente;
        private readonly IRestauranteRepositorio _restaurante;

        public AvaliacoesController(IAvaliacaoRepositorio service, IPedidoRepositorio pedido, IClienteRepositorio cliente, IRestauranteRepositorio restaurante)
        {
            _service = service;
            _pedido = pedido;
            _cliente = cliente;
            _restaurante = restaurante;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacao()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(Guid id)
        {
            var avaliacao = await _service.BuscarAsync(id);

            if (avaliacao == null)
            {
                return NotFound();
            }

            return avaliacao;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Avaliacao>> PutAvaliacao(Avaliacao avaliacao)
        {
            var resultado = await _service.EditarAsync(avaliacao);

            if (resultado != null)
            {
                return resultado;
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(AvaliacaoView avaliacao)
        {
            var a = new Avaliacao()
            {
                Nota = avaliacao.Nota,
                Comentario = avaliacao.Comentario,
                Pedido = await _pedido.BuscarAsync(avaliacao.Pedido.Id),
                Restaurante = await _restaurante.BuscarAsync(avaliacao.RestauranteID),
                Cliente = await _cliente.BuscarAsync(avaliacao.ClienteID),
            };
            var resultado = await _service.AdicionarAsync(a);

            return CreatedAtAction("GetAvaliacao", new { id = resultado.Id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAvaliacao(Guid id)
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
