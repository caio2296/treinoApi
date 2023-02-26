using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entityFrameworkCore2._0.Models
{
    [Table("LivroAutores")]
    public class LivroAutor
    {
        public int LivroId { get; set; }
        public int AutorId { get; set; }

        public Livro Livro { get; set; }

        public Autor Autor { get; set; }

    }
}
