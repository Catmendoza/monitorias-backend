using Monitorias.Models;
using Monitorias.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Monitorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ComentarioService _ComentarioService;

        public ComentariosController(ComentarioService ComentarioService)
        {
            _ComentarioService = ComentarioService;
        }

        [HttpGet]
        public ActionResult<List<Comentario>> Get() =>
            _ComentarioService.Get();



        [HttpGet("{id:length(24)}", Name = "GetComentario")]
        public ActionResult<Comentario> Get(string id)
        {
            var Comentario = _ComentarioService.Get(id);

            if (Comentario == null)
            {
                return NotFound();
            }

            return Comentario;
        }

        [HttpPost]
        public ActionResult<Comentario> Create(Comentario Comentario)
        {
            _ComentarioService.Create(Comentario);

            return CreatedAtRoute("GetComentario", new { id = Comentario.Id.ToString() }, Comentario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Comentario ComentarioIn)
        {
            var Comentario = _ComentarioService.Get(id);

            if (Comentario == null)
            {
                return NotFound();
            }

            _ComentarioService.Update(id, ComentarioIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteComentario")]
        public ActionResult<List<Comentario>> Delete(string id)
        {
            var Comentario = _ComentarioService.Get(id);

            if (Comentario == null)
            {
                return NotFound();
            }

            _ComentarioService.Remove(Comentario.Id);
            var Comentarios = _ComentarioService.Get();
            return Comentarios;
        }
    }
}