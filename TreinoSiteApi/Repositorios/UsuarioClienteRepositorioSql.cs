using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;
using System.Data.SqlClient;
using TreinoSiteApi.Services;

namespace TreinoSiteApi.Repositorios
{
    public class UsuarioClienteRepositorioSql : IUsuarioClienteRepositorioSql
    {

        

        private ModeloUsuarioClienteDto _usuario;

        private List<ModeloUsuarioClienteDto> _ListaUsuarios;

        private ConexaoSql _conexao; 

        public UsuarioClienteRepositorioSql()
        {
            _usuario = new ModeloUsuarioClienteDto();
            _ListaUsuarios = new List<ModeloUsuarioClienteDto>();

            _conexao = new ConexaoSql();

        }

        public void AtualizarUsuario(int id, ModeloUsuarioClienteDto NovosDadosUsuario)
        {
            _conexao.conectarAoSql();

            _conexao.AtualizarUsuario(id, NovosDadosUsuario);
            _conexao.DesconectarAoSql();



        }

        public ModeloUsuarioClienteVerificacaoDto CadastrarUsuario(ModeloUsuarioClienteVerificacaoDto UsuarioCadastrado)
        {
            _conexao.conectarAoSql();

            _conexao.CadastrarUsuarioSql(UsuarioCadastrado);
            _conexao.DesconectarAoSql();

            return UsuarioCadastrado;

        }

        public void DeletarUsuario(int id)
        {
            _conexao.conectarAoSql();
            _conexao.DeletarUsuario(id);
            _conexao.DesconectarAoSql();

        }

        public List<ModeloUsuarioClienteDto> LerUsuario(int id)
        {
            _conexao.conectarAoSql();

            _ListaUsuarios =  _conexao.RetornarLeituraSql(id).ToList();
            _conexao.DesconectarAoSql();

            return _ListaUsuarios;
        }

        public IEnumerable<ModeloUsuarioClienteDto> LerTodosOsUsuarioRegistrados()
        {

            _conexao.conectarAoSql();


            _ListaUsuarios = _conexao.RetornarLeiturasSql().ToList<ModeloUsuarioClienteDto>();
            _conexao.DesconectarAoSql();
                



            

            return _ListaUsuarios;

            //return _ListaUsuarios.Select(x => new ModeloUsuarioClienteDto { Nome = x.Nome, Email = x.Email } );

        }


        public ModeloUsuarioClienteVerificacaoDto VerificarUsuario(ModeloUsuarioClienteVerificacaoDto model)
        {
            ModeloUsuarioClienteVerificacaoDto usuario = new ModeloUsuarioClienteVerificacaoDto();



            _conexao.conectarAoSql();

            usuario = _conexao.VerificarUsuarioSql(model);

            _conexao.DesconectarAoSql();

            return usuario;
        }




    }



}
