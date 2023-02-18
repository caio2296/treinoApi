using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinoSiteApi.Modulos;
using TreinoSiteApi.Repositorios;
using TreinoSiteApi.Services;

namespace TreinoSiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private IUsuarioClienteRepositorioSql _usuarioClienteRepositorioSql;

        public readonly ITokenService _tokenService;

        public ControllerBase(IUsuarioClienteRepositorioSql usuarioClienteRepositorioSql, ITokenService tokenService)
        {
            _usuarioClienteRepositorioSql = usuarioClienteRepositorioSql;
            _tokenService = tokenService;
        }

        protected ActionResult<List<ModeloUsuarioClienteDto>> ResponseGet(List<ModeloUsuarioClienteDto> resultado)
        {

            if (resultado.Count == 0)
            {
                return NotFound();
            }

            return Ok(resultado);
        }


        protected ActionResult<ModeloUsuarioClienteVerificacaoDto> ResponsePost(ModeloUsuarioClienteVerificacaoDto resultado)
        {
            if (ModelState.IsValid)
            {
                if (resultado == null)
                {
                    return NoContent();
                }

                this._usuarioClienteRepositorioSql.CadastrarUsuario(resultado);
                return Created("http://localhost:43787", resultado);
            }

            return BadRequest();

        }
        

        protected ActionResult<ModeloUsuarioClienteDto> ResponsePutPatch(int id, ModeloUsuarioClienteDto novosDadosUsuario)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ModeloUsuarioClienteDto> antigoCadastro = new List<ModeloUsuarioClienteDto>();

                antigoCadastro = this._usuarioClienteRepositorioSql.LerUsuario(id);



                if (VerificarUsuario.VerificarAtualizacaoUsuario(novosDadosUsuario, antigoCadastro))
                {
                    this._usuarioClienteRepositorioSql.AtualizarUsuario(id, novosDadosUsuario);

                    return NoContent();
                }

                return BadRequest(new ValidationProblemDetails());
            }

            return BadRequest(new ValidationProblemDetails());

        }
    
    
        protected ActionResult<ModeloUsuarioClienteDto> ResponseDelete(int id)
        {
            var itemUsuario = this._usuarioClienteRepositorioSql.LerUsuario(id);

            if (id > 0)
            {
                if (itemUsuario == null)
                    return NoContent();


                this._usuarioClienteRepositorioSql.DeletarUsuario(id); 
                return Ok(itemUsuario); 
            }

            return BadRequest(new ValidationProblemDetails());
        }


        protected ActionResult<string> ResponsiveAutenticar(ModeloUsuarioClienteVerificacaoDto model)
        {
            if (ModelState.IsValid)
            {
                var usuario = this._usuarioClienteRepositorioSql.VerificarUsuario(model);

                if (usuario == null)
                {
                    return NotFound(new { message = "usuario ou senha invalidos!" });
                }

                var token = _tokenService.GenerationToken(usuario);
                model.Senha = 0;

                return new
                {
                    usuario = usuario,
                    token = token
                }.ToString();


            }

            return BadRequest(new { message = "usuario ou senha invalidos!" });
        }


    }
}
