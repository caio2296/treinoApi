using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreinoSiteApi.Modulos
{
    public class ProdutoContexto :DbContext
    {

        public ProdutoContexto(DbContextOptions<ProdutoContexto> options):base(options)
        {


        }

        public DbSet<Produto> Produtos { get; set; }

    }
}
