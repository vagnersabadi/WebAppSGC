using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.Data
{
    public class ClienteContext: DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {



        }



        //manipulaçõa do CRUD
        public DbSet<Cliente> Clientes { get; set; }

        //responsavel pela config do enty framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //renomear antes de criar (mapear)
            modelBuilder.Entity<Cliente>().ToTable("Tb_Cliente");
        }
    }
}
