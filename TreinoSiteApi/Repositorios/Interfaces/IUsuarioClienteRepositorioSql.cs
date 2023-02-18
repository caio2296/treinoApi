using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;

namespace TreinoSiteApi.Repositorios
{
    public interface IUsuarioClienteRepositorioSql
    {
        public IEnumerable<ModeloUsuarioClienteDto> LerTodosOsUsuarioRegistrados();

        public List<ModeloUsuarioClienteDto> LerUsuario(int id);

        public ModeloUsuarioClienteVerificacaoDto CadastrarUsuario(ModeloUsuarioClienteVerificacaoDto UsuarioCadastrado);

        public void AtualizarUsuario(int id,ModeloUsuarioClienteDto NovosDadosUsuario);

        public void DeletarUsuario(int id);

        public ModeloUsuarioClienteVerificacaoDto VerificarUsuario(ModeloUsuarioClienteVerificacaoDto model);


    }
}
