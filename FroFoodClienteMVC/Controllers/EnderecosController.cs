using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dominio_FroFood.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using FroFoodClienteMVC.Data;
using System.Linq;
using Dominio_FroFood.ViewModels;
using System;
using System.Collections.Generic;

namespace FroFoodClienteMVC.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;
        public EnderecosController(IConfiguration configuration, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }
        //// GET: Enderecos
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rua,Bairro,Cidade,Estado,Numero,Id,DataCriacao,DataAtualizao")] Endereco endereco)
        {
            var cliente = new ClienteView();
            var email = _contextAccessor.HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == email);

            cliente.Id = Guid.Parse(user.Id);
            cliente.Endereco = endereco;

            var c = new Cliente();

            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(endereco), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    var url = _configuration["UrlAPICliente:UrlBase"] + $"/Enderecos";
                    using var resposta = await httpClient.PostAsync(url, content);
                    string apiResposta = await resposta.Content.ReadAsStringAsync();
                    endereco = JsonConvert.DeserializeObject<Endereco>(apiResposta);

                    url = _configuration["UrlAPICliente:UrlBase"] + $"/Enderecos";
                    using var resp = await httpClient.GetAsync(url);
                    apiResposta = await resp.Content.ReadAsStringAsync();
                    TempData["enderecos"] = JsonConvert.DeserializeObject<List<Endereco>>(apiResposta);
                }
            }
            
            return RedirectToAction("Index", "Perfil");
        }

        // GET: Enderecos/Edit/5
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var endereco = await _context.BuscarAsync(id);
        //    if (endereco == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(endereco);
        //}

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Rua,Bairro,Cidade,Estado,Numero,Id,DataCriacao,DataAtualizao")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Endereco.FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(Guid id)
        {
            return _context.Endereco.Any(e => e.Id == id);
        }*/
    }
}
