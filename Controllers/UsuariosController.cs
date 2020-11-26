using Monitorias.Models;
using Monitorias.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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



        [HttpPost]
        [Route("register")]
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

                tokenAux = usuario.Id + "-" + usuario.mail + "-" + usuario.name;
            }

            return Ok(new { token = tokenAux, error = errorAux });
        }
        /*[HttpGet("{mail}/{password}")]
        public ActionResult<Usuario> Get(string mail, string password)
        {
            var usuariosAux = _UsuarioService.Get();
            var existe = false;

            foreach (var usuarioActual in usuariosAux)
            {
                if (usuarioActual.mail == mail)
                {
                    if (usuarioActual.password != password)
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
        }*/

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