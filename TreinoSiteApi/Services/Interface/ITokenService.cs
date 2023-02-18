using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;

namespace TreinoSiteApi.Services
{
    public interface ITokenService
    {

        public string GenerationToken(ModeloUsuarioClienteVerificacaoDto Usuario); 
    }
}
