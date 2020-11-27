using Monitorias.Models;
using Monitorias.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace Monitorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _UsuarioService;
        private readonly MonitoriaService _MonitoriaService;

        public UsuariosController(UsuarioService UsuarioService, MonitoriaService MonitoriaService)
        {
            _UsuarioService = UsuarioService;
            _MonitoriaService = MonitoriaService;
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
            //string expresion = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";

            /*if (Regex.IsMatch(credentials.mail, expresion))
            {
                if (Regex.Replace(credentials.mail, expresion, string.Empty).Length == 0)
                {
                    tokenAux = "Dirección de correo invalida";
                    Console.WriteLine(tokenAux);
                }

            }*/

            if (usuario == null)
            {
                errorAux = "Correo incorrecto";
            }
            else if (!BCrypt.Net.BCrypt.Verify(credentials.password, usuario.password))
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
            }/*
            else if (usuario.code.Length < 4)
            {
                errorAux = "La cedula debe tener más de 3 digitos";
            }
            else if (usuario.password.Length < 8)
            {
                errorAux = "La contraseña debe de ser mayor de 8 digitos";
            }*/
            else
            {
                usuario.password = BCrypt.Net.BCrypt.HashPassword(usuario.password, 12);


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

            var MonitoriasMonitor = _MonitoriaService.GetMonitoriasMonitor(UsuarioIn.Id);
            List<Monitoria> list = new List<Monitoria>(MonitoriasMonitor);
            if(UsuarioIn.roll == 3) {
                foreach (var item in list)
                {
                    item.monitor = "";
                    _MonitoriaService.Update(item.Id, item);
                }
            }
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