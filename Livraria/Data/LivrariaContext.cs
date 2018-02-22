using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Livraria.Models;

namespace Livraria.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext() : base("ConnectionDB")
        {

            //Database.SetInitializer<LivrariaContext>(new DropCreateDatabaseIfModelChanges<LivrariaContext>());
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<EntradaEstoque> EntradaEstoque { get; set; }
        public DbSet<PerdaEstoque> PerdaEstoque { get; set; }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                       .Where(p => p.Name == p.ReflectedType.Name + "Id")
                       .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Entity<UsuarioEmpresa>().HasKey(ue =>
            //new
            //{
            //    ue.UsuarioId,
            //    ue.EmpresaId
            //});

            modelBuilder.Entity<UsuarioEmpresa>()
            .HasRequired(ue => ue.Usuario)
            .WithMany(ue => ue.UsuariosEmpresas)
            .HasForeignKey(ue => ue.UsuarioId);

            modelBuilder.Entity<UsuarioEmpresa>()
                .HasRequired(t => t.Empresa)
                .WithMany(t => t.UsuariosEmpresas)
                .HasForeignKey(t => t.EmpresaId);

            modelBuilder.Entity<Cliente>()
                .HasRequired(c => c.Empresa)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.EmpresaId);

            modelBuilder.Entity<Fornecedor>()
             .HasRequired(f => f.Empresa)
             .WithMany(e => e.Fornecedores)
             .HasForeignKey(f => f.EmpresaId);

            modelBuilder.Entity<Livro>()
            .HasRequired(l => l.Autor)
            .WithMany(a => a.Livros)
            .HasForeignKey(l => l.AutorId);

            modelBuilder.Entity<Livro>()
                .HasRequired(l => l.Empresa)
                .WithMany(e => e.Livros)
                .HasForeignKey(l => l.EmpresaId);

            modelBuilder.Entity<EntradaEstoque>()
            .HasRequired(e => e.Livro)
            .WithMany(l => l.EntradasEstoque)
            .HasForeignKey(e => e.LivroId);

            modelBuilder.Entity<EntradaEstoque>()
               .HasRequired(e => e.Fornecedor)
               .WithMany(l => l.EntradasEstoque)
               .HasForeignKey(e => e.FornecedorId);

            modelBuilder.Entity<PerdaEstoque>()
               .HasRequired(pe => pe.EntradaEstoque)
               .WithMany(e => e.PerdasEstoque)
               .HasForeignKey(pe => pe.EntradaEstoqueId);

            modelBuilder.Entity<Venda>()
               .HasRequired(v => v.Cliente)
               .WithMany(c => c.Vendas)
               .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<Venda>()
               .HasRequired(v => v.Livro)
               .WithMany(l => l.Vendas)
               .HasForeignKey(v => v.LivroId);


            base.OnModelCreating(modelBuilder);
        }


    }
}