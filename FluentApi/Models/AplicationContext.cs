using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class AplicationContext: DbContext
    {
        public DbSet<Planeta> Planetas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniversoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Galaxia>()
                .ToTable("Galaxias")
                 .Property(g => g.Nome).HasMaxLength(100);

            mb.Entity<Planeta>()
               .ToTable("Planetas")
                .Property(g => g.Nome).HasMaxLength(100);

            //definir relacionamento um-para-um 



            mb.Entity<Planeta>()
                .HasOne(g => g.Galaxia)
                .WithOne(p => p.Planeta)
                
                .HasForeignKey<Planeta>(p => p.GalaxiaId);

            mb.Entity<BuracoNegro>()
               .ToTable("BuracosNegros")
                .Property(g => g.Nome).HasMaxLength(100);

            //definir relacionamento um-para-muitos 
            mb.Entity<BuracoNegro>()
                .HasOne(g => g.Galaxia)
                .WithMany(bm => bm.buracoNegros);

        }

    }
}
