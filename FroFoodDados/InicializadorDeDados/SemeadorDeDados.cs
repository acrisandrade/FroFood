using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FroFoodDados.InicializadorDeDados
{
    public class SemeadorDeDados
    {
        public static async Task Inicializar(IServiceProvider provedorServico)
        {
            using (var contexto = new FroFoodContexto(provedorServico.GetRequiredService<DbContextOptions<FroFoodContexto>>()))
            {
                if (await contexto.Restaurante.AnyAsync())
                {
                    return;
                }

                var restaurantes = new List<Restaurante>()
                {
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Super Podrão",
                        Email = "superpodrao@super.super.com",
                        Telefone = "991234568",
                        Descricao = "Um podrão que é super podre!",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Los Lagostims",
                        Email = "llgostins@lagostims.com",
                        Telefone = "9987654321",
                        Descricao = "Os melhores Lagostims!",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro, FormaPagamento.PicPay },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "P de Pizza",
                        Email = "ppizza@ppizza.com",
                        Telefone = "976543218",
                        Descricao = "Nome de Pizzaria de Itaguai.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro, FormaPagamento.Cartao },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Book Lanches",
                        Email = "booklanches@blch.com",
                        Telefone = "913456782",
                        Descricao = "Lanches para quem tem pensamentos livres.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Cartao },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Javateria",
                        Email = "javateria@javateria.com",
                        Telefone = "991345682",
                        Descricao = "Melhores sorvetes da primavera, e os melhores cafés.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.PicPay },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Humburguer do Burgão",
                        Email = "burgaoburguer@burgaoburguer.com",
                        Telefone = "997182935",
                        Descricao = "Um hamburguer burgado para desbugar sua fome!",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Dona Benta",
                        Email = "srbenta@srbenta.com",
                        Telefone = "998934558",
                        Descricao = "As melhores receitas do sítio do pica-pau amarelo.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Castlevania Delivery",
                        Email = "alucard@belmont.com",
                        Telefone = "98544568",
                        Descricao = "Tudo de melhor para sua presas.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Yu-Gi-Oh Petiscaria",
                        Email = "enigma@milenio.com",
                        Telefone = "98537568",
                        Descricao = "Os melhores petiscos do milenio.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Moizes Salgaderia",
                        Email = "mar@vermelho.com",
                        Telefone = "98596748",
                        Descricao = "Tudo feito com sal marinho.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Churrasquinho de Gato",
                        Email = "gatos@noespeto.com",
                        Telefone = "94231676",
                        Descricao = "Você morde o gato mia.",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Senhora dos Bolos",
                        Email = "bolos@senhora.com",
                        Telefone = "99934568",
                        Descricao = "Os melhores bolos para sua festa",
                        Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                };

                var items = new List<Item>()
                {
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Paquenca Super",
                        Tamanho = 18,
                        Descricao = "18cm de puro prazer",
                        Valor = 25m,
                        Categoria = "Lanche",
                        RestauranteId = restaurantes[0].Id,
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Paçoca",
                        Tamanho = 22,
                        Descricao = "22cm de puro prazer",
                        Valor = 2.50m,
                        Categoria = "Doce",
                        RestauranteId = restaurantes[0].Id,
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Paçoca",
                        Tamanho = 22,
                        Descricao = "22cm de puro prazer",
                        Valor = 2.50m,
                        Categoria = "Doce",
                        RestauranteId = restaurantes[0].Id,
                    },
                };

                await contexto.Restaurante.AddRangeAsync(restaurantes); 
            }
        }

        private static Guid GerarGuid()
        {
            return Guid.NewGuid();
        }
    }
}
