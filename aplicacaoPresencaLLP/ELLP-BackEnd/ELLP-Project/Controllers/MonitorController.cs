using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorController : ControllerBase
    {
        private readonly IMonitorRepositorio _monitorRepositorio;

        public MonitorController(IMonitorRepositorio monitorRepositorio)
        {
            _monitorRepositorio = monitorRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MonitorModel>> GetAll()
        {
            var monitores = _monitorRepositorio.GetAllMonitor();
            return Ok(monitores);
        }

        [HttpGet("{id}")]
        public ActionResult<MonitorModel> GetById(int id)
        {
            var monitor = _monitorRepositorio.GetMonitorById(id);
            if (monitor == null)
                return NotFound($"Monitor com ID {id} não encontrado.");
            return Ok(monitor);
        }

        [HttpPost]
        public ActionResult Add([FromBody] MonitorModel monitor)
        {
            if (monitor == null)
                return BadRequest("Dados inválidos.");

            _monitorRepositorio.AdicionarMonitor(monitor);
            return CreatedAtAction(nameof(GetById), new { id = monitor.Id }, monitor);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] MonitorModel monitorAtualizado)
        {
            var monitorExistente = _monitorRepositorio.GetMonitorById(id);
            if (monitorExistente == null)
                return NotFound($"Monitor com ID {id} não encontrado.");

            _monitorRepositorio.AlterarMonitor(id, monitorAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var monitor = _monitorRepositorio.GetMonitorById(id);
            if (monitor == null)
                return NotFound($"Monitor com ID {id} não encontrado.");

            _monitorRepositorio.DeleteMonitor(id);
            return NoContent();
        }
    }
}

