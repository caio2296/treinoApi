using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TreinoSiteApi.Modulos;

namespace TreinoSiteApi.Services
{
    public class ConexaoSql
    {
        private readonly static string connectionString =
                  @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Clientes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



        private static SqlConnection _conexao;


        private ModeloUsuarioClienteDto _usuario;

        private List<ModeloUsuarioClienteDto> _ListaUsuarios;

        private SqlDataReader _leitor;

        public ConexaoSql()
        {
            _conexao = new SqlConnection(connectionString);
            _ListaUsuarios = new List<ModeloUsuarioClienteDto>();

        }
        


        public void conectarAoSql()
        {

            _conexao.Open();

        }

        public void DesconectarAoSql()
        {
            _conexao.Close();

        }

        private static SqlDataReader  ComandarLeiturasSql()
        {

            var comando = new SqlCommand(
                    "select Nome, Idade, Senha, Email, Role from Usuario", _conexao);


            return comando.ExecuteReader();
        }

        public IEnumerable<ModeloUsuarioClienteDto> RetornarLeiturasSql()
        {
            
             _leitor = ComandarLeiturasSql();
            
                while (_leitor.Read())
                {
                    _usuario = new ModeloUsuarioClienteDto();

                    _usuario.Nome = _leitor["Nome"].ToString();
                    _usuario.Email = _leitor["Email"].ToString();
                    _usuario.Idade = int.Parse(_leitor["Idade"].ToString());
                    _usuario.Senha = int.Parse(_leitor["Senha"].ToString());
                    _usuario.Role = int.Parse(_leitor["Role"].ToString());


                    _ListaUsuarios.Add(_usuario);
                }
            _leitor.Close();
                return _ListaUsuarios;

            
        }


        private static SqlDataReader ComandarLeituraSql(int id)
        {
            var comando = new SqlCommand(
                   $"select Nome, Idade, Senha, Email, Role from Usuario  where id_Usuario ={id}", _conexao);


            return comando.ExecuteReader();

        }

        public IEnumerable<ModeloUsuarioClienteDto> RetornarLeituraSql(int id)
        {

            _leitor = ComandarLeituraSql(id);

            while (_leitor.Read())
            {
                _usuario = new ModeloUsuarioClienteDto();

                _usuario.Nome = _leitor["Nome"].ToString();
                _usuario.Email = _leitor["Email"].ToString();
                _usuario.Idade = int.Parse(_leitor["Idade"].ToString());
                _usuario.Senha = int.Parse(_leitor["Senha"].ToString());
                _usuario.Role = int.Parse(_leitor["Role"].ToString());


                _ListaUsuarios.Add(_usuario);
            }
            _leitor.Close();
            return _ListaUsuarios;


        }


        public void CadastrarUsuarioSql(ModeloUsuarioClienteVerificacaoDto cadastro)
        {
            
            using (var comando = new SqlCommand(
                $"insert into Usuario (Nome,Senha,Email)values('{cadastro.Nome}',{cadastro.Senha},'{cadastro.Email}') "
                , _conexao)){

                comando.ExecuteNonQuery();

                
            } 


        }


        public void AtualizarUsuario(int id, ModeloUsuarioClienteDto novoUsuario) {

            using (var comando = new SqlCommand($"update Usuario set Nome = '{novoUsuario.Nome}' ,Idade = {novoUsuario.Idade} ,Senha = {novoUsuario.Senha}, Email = '{novoUsuario.Email}'  where id_Usuario = {id}", _conexao))
            {

                comando.ExecuteNonQuery();
            } 
        
        }

        public void DeletarUsuario(int id)
        {

            using (var comando = new SqlCommand($"delete Usuario where id_Usuario = {id};",_conexao))
            {
                comando.ExecuteNonQuery();
            }


        }

        public ModeloUsuarioClienteVerificacaoDto VerificarUsuarioSql(ModeloUsuarioClienteVerificacaoDto model)
        {
            ModeloUsuarioClienteVerificacaoDto usuario = new ModeloUsuarioClienteVerificacaoDto();

            using (var comando = new SqlCommand($" select nome, email, senha, Role from Usuario  where nome ='{model.Nome}' and senha ={model.Senha}", _conexao))
            {

                using (SqlDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {

                        usuario.Nome = leitor["Nome"].ToString();
                        usuario.Senha = int.Parse(leitor["Senha"].ToString());
                        usuario.Role = int.Parse(leitor["Role"].ToString());

                    }
                }


            }

            return usuario;

        }

    }
}
