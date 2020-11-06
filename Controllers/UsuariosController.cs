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

         [HttpGet("{mail}/{password}")]
        public ActionResult<Usuario> Get(string mail, string password)
        {
            var usuariosAux = _UsuarioService.Get();
            var existe = false;

            foreach (var usuarioActual in usuariosAux)
            {
                if (usuarioActual.mail == mail)
                {
                    if (password == usuarioActual.password)
                    {
                        existe = true;
                    }
                }
            }

            if (existe)
            {
                return Content(mail);
            }
            else
            {
                return Content("error");
            }
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