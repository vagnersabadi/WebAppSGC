using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGC.ApplicationCore.Entity;

namespace SGC.Infrastructure.Data
{
    public static class DbInitializer
    {

        public static void Initialize(ClienteContext context)
        {
            //se ja foi povoado
            if (context.Clientes.Any())
            {
                return;
            }

            var clientes = new Cliente[]
            {
                new Cliente
                {
                    Nome = "Fulano da Silva",
                    CPF = "12345678912"
                },
                new Cliente
                {
                    Nome = "Beltrano da Silva",
                    CPF = "22222222222"
                }
            };

            context.AddRange(clientes);

            var contatos = new Contato[]
            {
                new Contato
                {
                    Nome = "Contato 1",
                    Telefone = "99999999",
                    Email = "teste@mail",
                    Cliente = clientes[0]
                },
                new Contato
                {
                    Nome = "Contato 2",
                    Telefone = "99999999",
                    Email = "teste2@mail",
                    Cliente = clientes[1]
                }
            };
            
            context.AddRange(contatos);


            //salva
            context.SaveChanges();

        }

    }
}
