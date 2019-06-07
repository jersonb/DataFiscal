using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataFiscal.Models;
using DataFiscal.Facedes;

namespace DataFiscal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<OperacaoFiscal> Cfop { get; set; }

        public DbSet<SituacaoTributaria> Cst { get; set; }

        public DbSet<OrigemImposto> Origem { get; set; }

        public DbSet<Aliquota> Aliquota { get; set; }

        public DbSet<NomenclaturaComum> Ncm { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<Operacao> Operacao { get; set; }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }

        public DbSet<Arquivo> Arquivo { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<OrigemImposto>().HasData(Seed.Origens);
        //    builder.Entity<SituacaoTributaria>().HasData(Seed.Csts);
        //    builder.Entity<Aliquota>().HasData(Seed.Aliquotas);
        //    builder.Entity<OperacaoFiscal>().HasData(Seed.Cfops);
        //    builder.Entity<NomenclaturaComum>().HasData(Seed.Ncms);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging();
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
