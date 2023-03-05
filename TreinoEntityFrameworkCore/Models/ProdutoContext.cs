using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoEntityFrameworkCore.Models.Interface;

namespace TreinoEntityFrameworkCore.Models
{
    public class ProdutoContext : DbContext, IDbContext
    {

        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {


        }


        public DbSet<Produto> Produtos { get; set; }




    }
}
