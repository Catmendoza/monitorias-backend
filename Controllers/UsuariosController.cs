using Usuarios.Models;
using Usuarios.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Usuarios.Controllers
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
            var Usuario = _UsuarioService.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario Usuario)
        {
            _UsuarioService.Create(Usuario);

            return CreatedAtRoute("GetUsuario", new { id = Usuario.Id.ToString() }, Usuario);
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