using Monitorias.Models;
using Monitorias.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Monitorias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoriasController : ControllerBase
    {
        private readonly MonitoriaService _MonitoriaService;

        public MonitoriasController(MonitoriaService MonitoriaService)
        {
            _MonitoriaService = MonitoriaService;
        }

        [HttpGet]
        public ActionResult<List<Monitoria>> Get() =>
            _MonitoriaService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMonitoria")]
        public ActionResult<Monitoria> Get(string id)
        {
            var Monitoria = _MonitoriaService.Get(id);

            if (Monitoria == null)
            {
                return NotFound();
            }

            return Monitoria;
        }

        [HttpPost]
        public ActionResult<Monitoria> Create(Monitoria Monitoria)
        {
            _MonitoriaService.Create(Monitoria);

            return CreatedAtRoute("GetMonitoria", new { id = Monitoria.Id.ToString() }, Monitoria);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Monitoria MonitoriaIn)
        {
            var Monitoria = _MonitoriaService.Get(id);

            if (Monitoria == null)
            {
                return NotFound();
            }

            _MonitoriaService.Update(id, MonitoriaIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteMonitoria")]
        public ActionResult<List<Monitoria>> Delete(string id)
        {
            var Monitoria = _MonitoriaService.Get(id);

            if (Monitoria == null)
            {
                return NotFound();
            }

            _MonitoriaService.Remove(Monitoria.Id);
            var Monitorias = _MonitoriaService.Get();
            return Monitorias;
        }
    }
}