using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreinoEntityFrameworkCore.Models
{
    public class InicializaDB
    {

        public static void Inicializa(ProdutoContext contexto)
        {
            contexto.Database.EnsureCreated();

            if (contexto.Produtos.Any())
            {
                return;
            }

            var produtos = new Produto[]
            {
                new Produto {Nome = "Caneta", Preco = 3.12M },
                new Produto {Nome = "Borracha", Preco = 3.52M }
            };
            foreach (Produto p in produtos)
            {
                contexto.Produtos.Add(p);
            }
            contexto.SaveChanges();


        }

    }
}
