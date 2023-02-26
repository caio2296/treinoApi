using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityFrameworkCore2._0.Models
{
    [Table("Autores")]
    public class Autor
    {
        
        public int AutorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
