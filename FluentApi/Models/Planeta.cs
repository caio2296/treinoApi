using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public double Tamanho { get; set; }

        public int GalaxiaId { get; set; }

        public Galaxia Galaxia { get; set; }
    }
}
