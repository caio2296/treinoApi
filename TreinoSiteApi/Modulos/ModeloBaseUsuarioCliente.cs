using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreinoSiteApi.Modulos
{
    public abstract class ModeloBaseUsuarioCliente
    {
        [Required]
        public string Nome { get; set; }
        //[Required]
        public string Email { get; set; }
        //[Required]
        //[Range(18, 130)]
        public int Idade { get; set; }

        [Required]
        [Range(100000,99999999)]
        public int Senha { get; set; }

    }
}
