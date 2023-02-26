using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entityFrameworkCore2._0.Models
{
    [Table("Livros")]
    public class Livro
    {
        public int LivroId { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }


        public ICollection<LivroAutor>  livroAutores { get; set; }

        public Livro()
        {
            livroAutores = new Collection<LivroAutor>();
        }

    }
}
