using TreinoAPI.Ativos;
using TreinoAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TreinoAPI.Data
{
    public class UserDbInitiaizer
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                if (context.User.Any())
                {
                    return;
                }

                context.User.AddRange(
                    new User
                    {
                        Id = 1,
                        Usuario = "marcosvini",
                        Senha = "parli",
                        Idade = 24,
                        Nome = "Marcos Vinicius Oliveira Lima",
                        Role = "admin"
                    },
                    new User
                    {
                        Id = 2,
                        Usuario = "marcosvinigerente",
                        Senha = "1234",
                        Idade = 24,
                        Nome = "Marcos Vinicius Oliveira Lima",
                        Role = "gerente"
                    },
                    new User
                    {
                        Id = 3,
                        Usuario = "marcosvinicliente",
                        Senha = "123",
                        Idade = 24,
                        Nome = "Marcos Vinicius Oliveira Lima",
                        Role = "cliente",
                    }
                    );
                context.Carteira.AddRange(
                    new Carteira
                    {
                        Id = 1,
                        UserId = 3
                    }
                    );
                context.Ativos.Add(
                    new Ativo
                    {
                        Acoes = new List<Acao>() { new Acao { Descricao = "Ação", Saldo = 10000 } },
                        Fundos = new List<Fundo>() { new Fundo { Descricao = "Fundo", Saldo = 15000 } },
                        CriptoMoedas = new List<CriptoMoeda>() { new CriptoMoeda { Descricao = "CriptoMoeda", Saldo = 20000 } },
                        CarteiraId = 1
                    }
                    );
                
                context.SaveChanges();
            }
        }
    }
}


