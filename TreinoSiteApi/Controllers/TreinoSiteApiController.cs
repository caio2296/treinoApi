using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;
using TreinoSiteApi.Repositorios;
using Newtonsoft.Json;
using TreinoSiteApi.Services;
using Microsoft.AspNetCore.Authorization;



namespace TreinoSiteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreinoSiteApiController : ControllerBase
    {

       

        private readonly IUsuarioClienteRepositorioSql _RepositorioUsuarioCliente;

       

        public TreinoSiteApiController(IUsuarioClienteRepositorioSql repositorioUsuarioCliente, ITokenService tokenService) :
            base(repositorioUsuarioCliente, tokenService)
        {
            
            _RepositorioUsuarioCliente = 
                repositorioUsuarioCliente ?? throw new ArgumentNullException(nameof(repositorioUsuarioCliente));
           
        }

        


        [HttpGet]
        //[Authorize(Roles = "1")]
        public IEnumerable<ModeloUsuarioClienteDto> Gets()
        {
            return this._RepositorioUsuarioCliente.LerTodosOsUsuarioRegistrados();
        }

        [HttpGet("{id}")]
        public ActionResult<List<ModeloUsuarioClienteDto>> Get(int id)
        {

            return ResponseGet(this._RepositorioUsuarioCliente.LerUsuario(id));
        }

        [HttpPost]
        public ActionResult<ModeloUsuarioClienteVerificacaoDto> Post([FromBody] ModeloUsuarioClienteVerificacaoDto cadastro)
        {

            var jsonCadastro = JsonConvert.SerializeObject(cadastro);

            ModeloUsuarioClienteVerificacaoDto usuarioClienteCadastro = JsonConvert.DeserializeObject<ModeloUsuarioClienteVerificacaoDto>(jsonCadastro);


            return ResponsePost(usuarioClienteCadastro);
        }

        [HttpPatch("{id}")]
        public ActionResult<ModeloUsuarioClienteDto> Patch(int id, [FromBody] ModeloUsuarioClienteDto novosDadosUsuario)
        {
            var jsonCadastro = JsonConvert.SerializeObject(novosDadosUsuario);

            ModeloUsuarioClienteDto cadastroAtualizado = JsonConvert.DeserializeObject<ModeloUsuarioClienteDto>(jsonCadastro);

            return ResponsePutPatch(id, cadastroAtualizado);
        }
        
        [HttpDelete("{id}")]
        public ActionResult<ModeloUsuarioClienteDto> Delete(int id)
        {


            return ResponseDelete(id);
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<string> Autenticar([FromBody] ModeloUsuarioClienteVerificacaoDto model)
        {
            
            
            return ResponsiveAutenticar(model);

        }


     }
}
