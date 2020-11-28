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
        private readonly UsuarioService _UsuarioService;

        public MonitoriasController(MonitoriaService MonitoriaService, UsuarioService UsuarioService)
        {
            _MonitoriaService = MonitoriaService;
            _UsuarioService = UsuarioService;
        }

        [HttpGet]
        public ActionResult<List<Monitoria>> Get() =>
            _MonitoriaService.Get();
        
        [HttpGet("availablesusers")]
        public ActionResult<List<Monitoria>> GetMonitor() {
            var monitorias = _MonitoriaService.GetMonitor();
            List<Monitoria> list = new List<Monitoria>(monitorias);
            List<Monitoria> listQuotas = new List<Monitoria>();
            foreach (var item in list)
            {
            List<string> listStudents = new List<string>(item.students);
                if (listStudents.Count < item.initialQuotas)
                {
                    listQuotas.Add(item);
                }
            }
            return listQuotas;
        }

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
           
            var Monitoria = _MonitoriaService.Get(id);
            
 
            List<string> list = new List<string>(Monitoria.students);
            list.Add(student);
            Monitoria.students = list.ToArray();
            _MonitoriaService.Update(id, Monitoria);


            if (Monitoria == null)
            {
                return NotFound();
            }

            return _MonitoriaService.GetMonitor();
        }
        [HttpGet("removestudent/{id:length(24)}/{student:length(24)}")]
        public ActionResult<List<Monitoria>> removeStudent(string id, string student)
        {
           
            var Monitoria = _MonitoriaService.Get(id);
            
            List<string> list = new List<string>(Monitoria.students);
            var index = list.IndexOf(student);
            list.RemoveAt(index);
            Monitoria.students = list.ToArray();


            _MonitoriaService.Update(id, Monitoria);

            if (Monitoria == null)
            {
                return NotFound();
            }

            return _MonitoriaService.GetMonitor();
        }

        [HttpGet("list/{id:length(24)}")]
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

        [HttpGet("add-monitor/{id:length(24)}/{idMonitor:length(24)}")]
        public ActionResult<List<Monitoria>> addMonitor(string id, string idMonitor)
        {
            var Monitoria = _MonitoriaService.Get(id);

            if (Monitoria == null)
            {
                return NotFound();
            }

            Monitoria.monitor = idMonitor;

            _MonitoriaService.Update(id, Monitoria);

            return _MonitoriaService.GetMonitoriasMonitor(idMonitor);
        }

        public class usuariosMonitoria
        {
            string name {get;set;}
            string career {get;set;}

        }

        [HttpGet("getStudents/{id:length(24)}")]
        public ActionResult<List<object>> getStudents(string id)
        {
            var Monitoria = _MonitoriaService.Get(id);
            List<string> list = new List<string>(Monitoria.students);
            List<object> lista = new List<object>();

            foreach (var item in list)
            {
                var usuario = _UsuarioService.Get(item);
                var user = new {name = usuario.name, career = usuario.career};
                lista.Add(user);

            }

            

            return lista;
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