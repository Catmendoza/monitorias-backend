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

        [HttpGet("bymonitoria/{id:length(24)}")]
        public ActionResult<List<Comentario>> GetByMonitoria(string id)
        {
            var Comentarios = _ComentarioService.GetByMonitoria(id);

            return Comentarios;
        }

        [HttpGet("{idMonitoria:length(24)}/{description}")]
        public ActionResult<List<Comentario>> Create(string idMonitoria, string description)
        {
            var newComment = new Comentario();
            newComment.idMonitoria = idMonitoria;
            newComment.description = description;
            _ComentarioService.Create(newComment);

            return _ComentarioService.GetByMonitoria(idMonitoria);
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

        [HttpDelete("{id:length(24)}/{idMonitoria:length(24)}", Name = "DeleteComentario")]
        public ActionResult<List<Comentario>> Delete(string id, string idMonitoria)
        {
            var Comentario = _ComentarioService.Get(id);

            if (Comentario == null)
            {
                return NotFound();
            }

            _ComentarioService.Remove(Comentario.Id);
            return _ComentarioService.GetByMonitoria(idMonitoria);
        }
    }
}