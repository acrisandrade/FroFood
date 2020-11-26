using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_FroFood.Models;
using Dominio_FroFood.ViewModels;
using FroFoodDados.ContextoDeDados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FroFoodCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicialController : ControllerBase
    {
        /*private readonly FroFoodContexto _configuration;
        public InicialController(FroFoodContexto configuration)
        {
            _configuration = configuration;
        }*/
        [HttpGet]
        public List<RestauranteView> BuscarTopDoze()
        {
            IEnumerable<RestauranteView> res = new List<RestauranteView>() {
                new RestauranteView { Nome = "primeiro", Avaliacao = 4.5m },
                new RestauranteView { Nome = "segundo", Avaliacao = 1.5m },
                new RestauranteView { Nome = "terceiro", Avaliacao = 2.5m },
                new RestauranteView { Nome = "quarto", Avaliacao = 3.5m },
                new RestauranteView { Nome = "quinto", Avaliacao = 2.5m },
                new RestauranteView { Nome = "sexto", Avaliacao = 4.5m },
                new RestauranteView { Nome = "sétimo", Avaliacao = 5m },
                new RestauranteView { Nome = "oitavo", Avaliacao = 5m },
                new RestauranteView { Nome = "nono", Avaliacao = 3.5m },
                new RestauranteView { Nome = "decimo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "decimo primeiro", Avaliacao = 0m },
                new RestauranteView { Nome = "decimo segundo", Avaliacao = 0m },
                new RestauranteView { Nome = "decimo terceiro", Avaliacao = 4.5m },
                new RestauranteView { Nome = "FroFood o decimo quarto", Avaliacao = 1.5m },
                new RestauranteView { Nome = "FroFood o decimo quinto", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o decimo sexto", Avaliacao = 3.5m },
                new RestauranteView { Nome = "FroFood o decimo sétimo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o decimo oitavo", Avaliacao = 4.5m },
                new RestauranteView { Nome = "FroFood o decimo nono", Avaliacao = 5m },
                new RestauranteView { Nome = "FroFood o vigesimo", Avaliacao = 5m },
                new RestauranteView { Nome = "FroFood o vigesimo primeiro", Avaliacao = 3.5m },
                new RestauranteView { Nome = "FroFood o vigesimo segundo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o vigesimo terceiro", Avaliacao = 0m },
                new RestauranteView { Nome = "FroFood o vigesimo quarto", Avaliacao = 5m },
            };

            var maioresAvaliacoes = res.Where(r => r.Avaliacao >= 4.5m).ToList();

            return maioresAvaliacoes;
        }

        [HttpPost]
        public List<RestauranteView> Buscar(string Nome) 
        { 
            IEnumerable<RestauranteView> res = new List<RestauranteView>() {
                new RestauranteView { Nome = "primeiro", Avaliacao = 4.5m },
                new RestauranteView { Nome = "segundo", Avaliacao = 1.5m },
                new RestauranteView { Nome = "terceiro", Avaliacao = 2.5m },
                new RestauranteView { Nome = "quarto", Avaliacao = 3.5m },
                new RestauranteView { Nome = "quinto", Avaliacao = 2.5m },
                new RestauranteView { Nome = "sexto", Avaliacao = 4.5m },
                new RestauranteView { Nome = "sétimo", Avaliacao = 5m },
                new RestauranteView { Nome = "oitavo", Avaliacao = 5m },
                new RestauranteView { Nome = "nono", Avaliacao = 3.5m },
                new RestauranteView { Nome = "decimo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "decimo primeiro", Avaliacao = 0m },
                new RestauranteView { Nome = "decimo segundo", Avaliacao = 0m },
                new RestauranteView { Nome = "decimo terceiro", Avaliacao = 4.5m },
                new RestauranteView { Nome = "FroFood o decimo quarto", Avaliacao = 1.5m },
                new RestauranteView { Nome = "FroFood o decimo quinto", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o decimo sexto", Avaliacao = 3.5m },
                new RestauranteView { Nome = "FroFood o decimo sétimo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o decimo oitavo", Avaliacao = 4.5m },
                new RestauranteView { Nome = "FroFood o decimo nono", Avaliacao = 5m },
                new RestauranteView { Nome = "FroFood o vigesimo", Avaliacao = 5m },
                new RestauranteView { Nome = "FroFood o vigesimo primeiro", Avaliacao = 3.5m },
                new RestauranteView { Nome = "FroFood o vigesimo segundo", Avaliacao = 2.5m },
                new RestauranteView { Nome = "FroFood o vigesimo terceiro", Avaliacao = 0m },
                new RestauranteView { Nome = "FroFood o vigesimo quarto", Avaliacao = 5m },
        };

            return res.Where(r => r.Nome.ToLower().Contains(Nome.ToLower())).ToList();
                
                
        }



        /*[HttpGet("{id}")]
        public async Task<ActionResult<ClienteView>> GetCliente(Guid id)
        {
            var amigos = await _configuration.Cliente.FindAsync(id);
            var vModel = new ClienteView();

            vModel.Id = amigos.Id.ToString();
            vModel.Nome = amigos.Nome;
            vModel.Telefone = amigos.Telefone;
            vModel.Email = amigos.Email;
            if (amigos == null)
            {
                return NotFound();
            }

            return vModel;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostCliente([FromBody] Usuario clientes)
        {
            var cliente = new ClienteView();
            cliente.Id = clientes.Id.ToString();
            cliente.Nome = clientes.Nome;
            cliente.Telefone = clientes.Telefone;
            cliente.Email = clientes.Email;

            _configuration.Cliente.Add(cliente);
            await _configuration.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }*/


    }
}