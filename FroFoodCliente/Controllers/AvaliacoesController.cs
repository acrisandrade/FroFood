﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio_FroFood.Models;
using Dominio_FroFood.Interfaces.Repositorio;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacaoRepositorio _context;

        public AvaliacoesController(IAvaliacaoRepositorio context)
        {
            _context = context;
        }

        // GET: api/Avaliacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetAvaliacao()
        {
            return Ok(await _context.BuscarAsync());
        }

        // GET: api/Avaliacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetAvaliacao(Guid id)
        {
            var avaliacao = await _context.BuscarAsync(id);

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
            var resultado = await _context.EditarAsync(avaliacao);
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
        public async Task<ActionResult<Avaliacao>> PostAvaliacao(Avaliacao avaliacao)
        {
            var resultado = await _context.AdicionarAsync(avaliacao);

            return CreatedAtAction("GetAvaliacao", new { id = resultado.Id }, resultado);
        }

        // DELETE: api/Avaliacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAvaliacao(Guid id)
        {
            var resutado = await _context.ExcluirAsync(id);
            return resutado;
        }
    }
}
