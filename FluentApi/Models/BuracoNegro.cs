using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class BuracoNegro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Galaxia Galaxia { get; set; }

    }
}
