using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicos.ViewModel
{
    public class EmpresaRatingDbContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Debito> Debitos { get; set; }

        public EmpresaRatingDbContext(DbContextOptions<EmpresaRatingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Debitos)
                .WithOne(d => d.Empresa);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.NotasFicais)
                .WithOne(n => n.Empresa);

            modelBuilder.Entity<Empresa>().Ignore(e => e.DebitosEsteMes);
            modelBuilder.Entity<Empresa>().Ignore(e => e.NotasEsteMes);
                

            string[] nomeEmpresas;

            nomeEmpresas = new string[6]{"Serasa", "ProWay", "LivrariaNerd",
                "UniMasters", "Code.Org", "Udemy"};

            for (int i = 0; i < nomeEmpresas.Length; i++)
            {
                modelBuilder.Entity<Empresa>().HasData(
                    new Empresa
                    {
                        Id = (i + 1),
                        Nome = nomeEmpresas[i]
                    }
                 );
            }
        }
    }
}
