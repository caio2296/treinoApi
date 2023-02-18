using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreinoSiteApi.Modulos
{
    public class ModeloUsuarioClienteVerificacaoDto: ModeloBaseUsuarioCliente
    {

        public int Id_Usuario { get; set; }

        public int Role { get; set; }


    }
}
