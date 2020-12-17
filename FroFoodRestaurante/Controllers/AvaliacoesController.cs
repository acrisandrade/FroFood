using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio_FroFood.Interfaces.Repositorio;
using Dominio_FroFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace FroFoodRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _service;
        private readonly IPedidoRepositorio _pedido;

        public AvaliacoesController(IAvaliacaoRepositorio service, IPedidoRepositorio pedido)
        {
            _service = service;
            _pedido = pedido;
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
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            var a = new Avaliacao()
            {
                Nota = avaliacao.Nota,
                Comentario = avaliacao.Comentario,
                Pedido = await _pedido.BuscarAsync(avaliacao.Pedido.Id),
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

        [HttpGet("historico/{id}")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> Historico(Guid id)
        {
            try
            {
                var r = await _service.buscarAvalicaoesRestaurante(id);
                return Ok(r);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
