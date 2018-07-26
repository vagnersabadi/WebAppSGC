using Microsoft.EntityFrameworkCore;
using SGC.ApplicationCore.Entity;
using SGC.Infrastructure.EntityConfig;
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
        public DbSet<Contato> Contato { get; set; }


        //responsavel pela config do enty framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //renomear antes de criar (mapear)
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Profissao>().ToTable("Profissao");
            modelBuilder.Entity<ProfissaoCliente>().ToTable("ProfissaoCliente");

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new ProfissaoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new ProfissaoClienteMap());
            modelBuilder.ApplyConfiguration(new MenuMap());



          
            /* gambiarra
            #region Profissao

            modelBuilder.Entity<Profissao>().Property(e => e.Nome)
               .HasColumnType("varchar(400)")
               .IsRequired();


            modelBuilder.Entity<Profissao>().Property(e => e.CBO)
                .HasColumnType("varchar(10)")
                .IsRequired();


            modelBuilder.Entity<Profissao>().Property(e => e.Descricao)
                .HasColumnType("varchar(1005)")
                 .IsRequired();


            #endregion
            */
           


        }
    }
}
