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



            #region Cliente

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ClienteId);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Contatos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(c => c.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);


            modelBuilder.Entity<Cliente>().Property(e => e.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            modelBuilder.Entity<Cliente>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            #endregion

            #region Contato

            modelBuilder.Entity<Contato>()
                .HasOne(x => x.Cliente)//contato te u cliente
                .WithMany(x => x.Contatos)
                .HasForeignKey(x => x.ClienteId)
                .HasPrincipalKey(x => x.ClienteId);


            modelBuilder.Entity<Contato>().Property(e => e.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();


            modelBuilder.Entity<Contato>().Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();


            modelBuilder.Entity<Contato>().Property(e => e.Telefone)
                .HasColumnType("varchar(15)");

            #endregion

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

            #region Endereço


            modelBuilder.Entity<Endereco>().Property(e => e.Bairro)
                .HasColumnType("varchar(200)")
                 .IsRequired();


            modelBuilder.Entity<Endereco>().Property(e => e.CEP)
                .HasColumnType("varchar(15)")
                 .IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.Logradouro)
                .HasColumnType("varchar(200)")
                .IsRequired();

            modelBuilder.Entity<Endereco>().Property(e => e.Referencia)
                .HasColumnType("varchar(200)");

            #endregion

            #region Profissao Cliente

            modelBuilder.Entity<ProfissaoCliente>()
                .HasKey(c => c.Id);


            modelBuilder.Entity<ProfissaoCliente>()
                .HasOne(x => x.Cliente)//contato te u cliente
                .WithMany(x => x.ProfissoesClientes)
                .HasForeignKey(x => x.ClienteId);


            modelBuilder.Entity<ProfissaoCliente>()
              .HasOne(x => x.Profissao)//contato te u cliente
              .WithMany(x => x.ProfissoesClientes)
              .HasForeignKey(x => x.ProfissaoId);


            #endregion


            #region Menu

            modelBuilder.Entity<Menu>()
                .HasMany(x => x.SubMenu)
                .WithOne()
                .HasForeignKey(x => x.MenuId);
            #endregion
        }
    }
}
