using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;

namespace TreinoSiteApi.Services
{
    public class VerificarUsuario
    {



        public static bool VerificarAtualizacaoUsuario(ModeloUsuarioClienteDto usuarioNovosDados, IEnumerable<ModeloUsuarioClienteDto> usuarioAntigosDados)
        {

            string idadeAntiga = usuarioAntigosDados.Select(x => x.Idade).ToArray<int>().GetValue(0).ToString();
            string senhaAntiga = usuarioAntigosDados.Select(x => x.Senha).ToArray<int>().GetValue(0).ToString();
            string emailAntigo = usuarioAntigosDados.Select(x => x.Email).ToArray<string>().GetValue(0).ToString();
            string nomeAntigo = usuarioAntigosDados.Select(x => x.Nome).ToArray<string>().GetValue(0).ToString();

            return (usuarioNovosDados.Idade != int.Parse(idadeAntiga)
                 || usuarioNovosDados.Senha!= int.Parse(senhaAntiga)
                  || usuarioNovosDados.Email != emailAntigo
                   || usuarioNovosDados.Nome != nomeAntigo);


        }


    }
}
