using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityFrameworkCore2._0.Models
{
    public class LivrariaContext: DbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }

        public LivrariaContext(DbContextOptions<LivrariaContext> options): base(options)
        {

        }

        //fluent API

        protected  override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<LivroAutor>().HasKey(al => new { al.AutorId, al.LivroId });
        }

    }
}
