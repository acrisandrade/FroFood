using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using FroFoodService.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TService> : ControllerBase
                                                   where T : ClasseBase
                                                   where TService : IServicoBase<T>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        // GET: api/Avaliacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var resultado = await _service.BuscarAsync();
            return Ok(resultado);
        }

        // GET: api/Avaliacoes/5
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> Get(Guid id)
        {
            var entity = await _service.BuscarAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Avaliacoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(T entity)
        {
            var resultado = await _service.EditarAsync(entity);

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
        public async Task<ActionResult<T>> Post(T entity)
        {
            var resultado = await _service.AdicionarAsync(entity);

            return CreatedAtAction("GetAvaliacao", new { id = resultado.Id });
        }

        // DELETE: api/Avaliacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
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
