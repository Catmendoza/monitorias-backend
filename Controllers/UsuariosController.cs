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
            _UsuarioService.Get();


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

        [HttpPost("{mail}/{password}")]
        public ActionResult<Usuario> Auth(Usuario credentials)
        {
            var usuario = _UsuarioService.GetOne(credentials.mail);
            if (usuario == null)
            {
                return Ok(new { error = "correo incorrecto" });
            }

            if (usuario.password == credentials.password)
            {
                return Ok(new { token = usuario.Id });
            }
            else
            {
                return Ok(new { error = "contraseña incorrecto" });
            }

        }

        [HttpPost]
        public ActionResult Create(Usuario Usuario)
        {
            var aux = _UsuarioService.GetOne(Usuario.mail);

            if (aux != null)
            {
                return Ok(new { error = "Ya existe el correo" });
            }
            else
            {
                _UsuarioService.Create(Usuario);

                return Ok();
            }
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