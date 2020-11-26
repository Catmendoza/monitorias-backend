using Monitorias.Models;
using Monitorias.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Monitorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _UsuarioService;

        public UsuariosController(UsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get() =>
            _UsuarioService.GetUsers();


        [HttpGet("{id:length(24)}", Name = "GetUsuario")]
        public ActionResult<Usuario> Get(string id)
        {
            var usuario = _UsuarioService.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<Usuario> Auth(Usuario credentials)
        {
            var usuario = _UsuarioService.GetOne(credentials.mail);
            var tokenAux = "";
            var errorAux = "";

            if (usuario == null)
            {
                errorAux = "Correo incorrecto";
            }
            else if (usuario.password != credentials.password)
            {
                errorAux = "Contraseña incorrecta";
            }
            else
            {

                tokenAux = usuario.Id;
            }

            return Ok(new { token = tokenAux, error = errorAux });
        }

        [HttpPost("register")]
        //[Route("register")]
        public ActionResult Create(Usuario usuario)
        {
            var aux = _UsuarioService.GetOne(usuario.mail);
            var tokenAux = "";
            var errorAux = "";

            if (aux != null)
            {
                errorAux = "Ya existe el correo";
            }
            else
            {
                tokenAux = _UsuarioService.Create(usuario).Id;
            }

            return Ok(new { token = tokenAux, error = errorAux });
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Usuario UsuarioIn)
        {
            var Usuario = _UsuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _UsuarioService.Update(id, UsuarioIn);

            return NoContent();
        }

        [HttpPut("change-rol/{id:length(24)}")]
        public ActionResult<List<Usuario>> changeRoll(string id, Usuario UsuarioIn)
        {
            var Usuario = _UsuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _UsuarioService.Update(id, UsuarioIn);

            var Usuarios = _UsuarioService.GetUsers();    
            return Usuarios;
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Usuario = _UsuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _UsuarioService.Remove(Usuario.Id);

            return NoContent();
        }
    }
}