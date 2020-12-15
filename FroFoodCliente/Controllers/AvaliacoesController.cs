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

        public AvaliacoesController(IAvaliacaoRepositorio service, IPedidoRepositorio pedido)
        {
            _service = service;
            _pedido = pedido;
        }

        // GET: api/Avaliacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacao()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        // GET: api/Avaliacoes/5
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

        // PUT: api/Avaliacoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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

        // POST: api/Avaliacoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(AvaliacaoView avaliacao)
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

        // DELETE: api/Avaliacoes/5
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
