using Dominio_FroFood.Models;
using FroFoodDados.ContextoDeDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FroFoodDados.InicializadorDeDados
{
    public class SemeadorDeDados
    {
        public static void Inicializar(IServiceProvider provedorServico)
        {
            using (var contexto = new FroFoodContexto(provedorServico.GetRequiredService<DbContextOptions<FroFoodContexto>>()))
            {
                if (contexto.Restaurante.Any())
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
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Los Lagostims",
                        Email = "llgostins@lagostims.com",
                        Telefone = "998765432",
                        Descricao = "Os melhores Lagostims!",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro, FormaPagamento.PicPay },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "P de Pizza",
                        Email = "ppizza@ppizza.com",
                        Telefone = "976543218",
                        Descricao = "Nome de Pizzaria de Itaguai.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro, FormaPagamento.Cartao },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Book Lanches",
                        Email = "booklanches@blch.com",
                        Telefone = "913456782",
                        Descricao = "Lanches para quem tem pensamentos livres.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Cartao },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Javateria",
                        Email = "javateria@javateria.com",
                        Telefone = "991345682",
                        Descricao = "Melhores sorvetes da primavera, e os melhores cafés.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.PicPay },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Humburguer do Burgão",
                        Email = "burgaoburguer@burgaoburguer.com",
                        Telefone = "997182935",
                        Descricao = "Um hamburguer burgado para desbugar sua fome!",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Dona Benta",
                        Email = "srbenta@srbenta.com",
                        Telefone = "998934558",
                        Descricao = "As melhores receitas do sítio do pica-pau amarelo.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Castlevania Delivery",
                        Email = "alucard@belmont.com",
                        Telefone = "98544568",
                        Descricao = "Tudo de melhor para sua presas.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Yu-Gi-Oh Petiscaria",
                        Email = "enigma@milenio.com",
                        Telefone = "98537568",
                        Descricao = "Os melhores petiscos do milenio.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Moizes Salgaderia",
                        Email = "mar@vermelho.com",
                        Telefone = "98596748",
                        Descricao = "Tudo feito com sal marinho.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Churrasquinho de Gato",
                        Email = "gatos@noespeto.com",
                        Telefone = "94231676",
                        Descricao = "Você sente o miado.",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
                    },
                    new Restaurante()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Senhora dos Bolos",
                        Email = "bolos@senhora.com",
                        Telefone = "99934568",
                        Descricao = "Os melhores bolos para sua festa",
                        //Pagamento = new List<FormaPagamento> { FormaPagamento.Dinheiro },
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
                        Restaurante = restaurantes[0],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Misto Mega",
                        //Tamanho = 0,
                        Descricao = "Com tudo que não presta",
                        Valor = 10.50m,
                        Categoria = "Lanche",
                        Restaurante = restaurantes[0],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Pai dos podrões",
                        //Tamanho = 22,
                        Descricao = "Com tudo que não presta",
                        Valor = 17.50m,
                        Categoria = "Lanche",
                        Restaurante = restaurantes[0],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Lagostim",
                        //Tamanho = 22,
                        Descricao = "Lagostim delicioso",
                        Valor = 11.50m,
                        Categoria = "Frutos do Mar",
                        Restaurante = restaurantes[1],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Lagosta",
                        //Tamanho = 22,
                        Descricao = "Leve seu babador",
                        Valor = 92m,
                        Categoria = "Frutos do Mar",
                        Restaurante = restaurantes[1],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Camarão",
                        //Tamanho = 22,
                        Descricao = "É maior, é melhor, senhoras e senhoras é demais!",
                        Valor = 55.50m,
                        Categoria = "Frutos do Mar",
                        Restaurante = restaurantes[1],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Mega power pizza",
                        Tamanho = 50,
                        Descricao = "50cm de tudo que vc quiser",
                        Valor = 62.50m,
                        Categoria = "Pizza",
                        Restaurante = restaurantes[2],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Pizza Muçarela",
                        Tamanho = 30,
                        Descricao = "Pizza de muçarela",
                        Valor = 2.50m,
                        Categoria = "Pizza",
                        Restaurante = restaurantes[2],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Pizza Calabresa",
                        Tamanho = 45,
                        Descricao = "Pizza de Calabresa",
                        Valor = 2.50m,
                        Categoria = "Pizza",
                        Restaurante = restaurantes[2],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Roupa Velha",
                        //Tamanho = 22,
                        Descricao = "O prato, feito com charque (uma carne salgada e defumada típica da região sul)",
                        Valor = 32.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[3],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Mão de Vaca",
                        //Tamanho = 22,
                        Descricao = "O guisado, com a perna traseira do boi, é nutritivo e revigorante.",
                        Valor = 25.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[3],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Amor-Perfeito",
                        //Tamanho = 22,
                        Descricao = "Também conhecido como Sequilho de Tocantins",
                        Valor = 40m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[3],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Gelado",
                        //Tamanho = 22,
                        Descricao = "Fica frio aí!",
                        Valor = 12.50m,
                        Categoria = "Sobremesa",
                        Restaurante = restaurantes[4],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Capitão Frio",
                        //Tamanho = 22,
                        Descricao = "Faça o plano, excute o plano. Espere que o plano dê errado, jogue o plano fora.",
                        Valor = 5.50m,
                        Categoria = "Sobremesa",
                        Restaurante = restaurantes[4],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Vanilla Ice",
                        //Tamanho = 22,
                        Descricao = "Ice Ice Baby",
                        Valor = 17m,
                        Categoria = "Sobremesa",
                        Restaurante = restaurantes[4],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Hamburguer Gurmet",
                        //Tamanho = 22,
                        Descricao = "Promete muito, mas nada demais.",
                        Valor = 54m,
                        Categoria = "Lanche",
                        Restaurante = restaurantes[5],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Podrão",
                        //Tamanho = 22,
                        Descricao = "Não da para saber o que tem dentro e é sempre o mais saboroso",
                        Valor = 15.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[5],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Hamburguer da Aparencia",
                        //Tamanho = 22,
                        Descricao = "Aquele hamburguer que só existe na foto.",
                        Valor = 2.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[5],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolinho de chuva",
                        //Tamanho = 22,
                        Descricao = "Chova chuva, chove sem parar.",
                        Valor = 8.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[6],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Suco da Cuca",
                        //Tamanho = 22,
                        Descricao = "Suco da Cuca",
                        Valor = 6.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[6],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolo de Visconde",
                        //Tamanho = 22,
                        Descricao = "Virou bolo",
                        Valor = 12.50m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[6],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Suco Vermelho",
                        //Tamanho = 22,
                        Descricao = "Dentes fortes, hein garoto!",
                        Valor = 72.50m,
                        Categoria = "Bebida",
                        Restaurante = restaurantes[7],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Desmiolado",
                        //Tamanho = 22,
                        Descricao = "Seu zumbi merece o melhor!",
                        Valor = 32.50m,
                        Categoria = "Lanche",
                        Restaurante = restaurantes[7],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Delirio da Succubus",
                        //Tamanho = 22,
                        Descricao = "Tudo que você mais deseja.",
                        Valor = 63m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[7],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Koshary",
                        //Tamanho = 22,
                        Descricao = "Os faraó pira!",
                        Valor = 27.50m,
                        Categoria = "Petisco",
                        Restaurante = restaurantes[8],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Molokheya",
                        //Tamanho = 22,
                        Descricao = "Um enigma a ser desvendado!",
                        Valor = 10m,
                        Categoria = "Petisco",
                        Restaurante = restaurantes[8],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Kunafa",
                        //Tamanho = 22,
                        Descricao = "De levar para o sarcófago",
                        Valor = 29.90m,
                        Categoria = "Petisco",
                        Restaurante = restaurantes[8],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Pão de trigo com cevada",
                        //Tamanho = 22,
                        Descricao = "Delicioso pão de trigo",
                        Valor = 1.90m,
                        Categoria = "Salgado",
                        Restaurante = restaurantes[9],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolinho de Carne de Cordeiro",
                        //Tamanho = 22,
                        Descricao = "Você vai agradecer pelo sacrifio do cordeiro",
                        Valor = 3.90m,
                        Categoria = "Salgado",
                        Restaurante = restaurantes[9],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolinho de faisão",
                        //Tamanho = 22,
                        Descricao = "Não temos pombo",
                        Valor = 2.10m,
                        Categoria = "Salgado",
                        Restaurante = restaurantes[9],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Picanha na Brasa",
                        //Tamanho = 22,
                        Descricao = "Deliciosa picanha de gato, você nem percebe a diferença",
                        Valor = 27.50m,
                        Categoria = "Petisco",
                        Restaurante = restaurantes[10],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Linguiça na farofa",
                        //Tamanho = 22,
                        Descricao = "A melhor liguiça com a melhor farofa",
                        Valor = 12.50m,
                        Categoria = "Petisco",
                        Restaurante = restaurantes[10],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Coração no espeto",
                        //Tamanho = 22,
                        Descricao = "Coração espetado",
                        Valor = 3.50m,
                        Categoria = "Petisco",
                        Restaurante = restaurantes[10],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolo de Cenoura",
                        //Tamanho = 22,
                        Descricao = "Bolo de chocolate com cobertura de cenoura.",
                        Valor = 15m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[11],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolo de Mandioca",
                        //Tamanho = 22,
                        Descricao = "Bolo de mandioca sem aipim",
                        Valor = 22m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[11],
                    },
                    new Item()
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Bolo de Fubá",
                        //Tamanho = 22,
                        Descricao = "Bolo de bolo",
                        Valor = 23.90m,
                        Categoria = "Doce",
                        Restaurante = restaurantes[11],
                    },
                };

                contexto.Restaurante.AddRange(restaurantes);
                contexto.Item.AddRange(items);
                contexto.SaveChanges();
            }
        }
    }
}
