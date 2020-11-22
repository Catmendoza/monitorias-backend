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

        [HttpGet("availables")]
        public ActionResult<List<Monitoria>> GetAvailables() =>
            _MonitoriaService.GetAvailables();

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

        [HttpGet("monitor/{id:length(24)}")]
        public ActionResult<List<Monitoria>> GetMonitoriasMonitor(string id) =>
            _MonitoriaService.GetMonitoriasMonitor(id);

        [HttpPost("{id:length(24)}/{student:length(24)}")]
        public ActionResult<List<Monitoria>> AddStudent(string id, string student)
        {
           
            var Monitorias = _MonitoriaService.Get();
            var Monitoria = _MonitoriaService.Get(id);
            
 
            List<string> list = new List<string>(Monitoria.students);
            list.Add(student);
            Monitoria.students = list.ToArray();
            _MonitoriaService.Update(id, Monitoria);


            if (Monitoria == null)
            {
                return NotFound();
            }

            return Monitorias;
        }

        [HttpPost("list/{id:length(24)}")]
        public ActionResult<List<Monitoria>> getMonitoriasStudent(string id)
        {
            var Monitorias = _MonitoriaService.Get();
            List<Monitoria> list = new List<Monitoria>();

            foreach (var item in Monitorias)
            {
                foreach (var student in item.students)
                {
                    if(student == id){
                        list.Add(item);
                    }
                }
            }

            return list;
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
        
        [HttpGet("remove-monitor/{id:length(24)}/{idMonitor:length(24)}")]
        public ActionResult<List<Monitoria>> removeMonitor(string id, string idMonitor)
        {
            var Monitoria = _MonitoriaService.Get(id);

            if (Monitoria == null)
            {
                return NotFound();
            }

            Monitoria.monitor = "";

            _MonitoriaService.Update(id, Monitoria);

            return _MonitoriaService.GetMonitoriasMonitor(idMonitor);
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