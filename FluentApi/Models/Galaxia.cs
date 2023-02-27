using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class Galaxia
    {
        public Galaxia()
        {
            buracoNegros = new List<BuracoNegro>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public double Tamanho { get; set; }

        public Planeta Planeta { get; set; }

        

        public List<BuracoNegro> buracoNegros { get; set; }


    }
}
