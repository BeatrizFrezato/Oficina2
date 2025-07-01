using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Services;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OficinaController : ControllerBase
    {
        private readonly IOficinaRepositorio _oficinaRepositorio;

        public OficinaController(IOficinaRepositorio oficinaRepositorio)
        {
            _oficinaRepositorio = oficinaRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OficinaModel>> GetAll()
        {
            var oficinas = _oficinaRepositorio.GetAllOficinas();
            return Ok(oficinas);
        }

        [HttpGet("{id}")]
        public ActionResult<OficinaModel> GetById(int id)
        {
            var oficina = _oficinaRepositorio.GetOficinaById(id);
            if (oficina == null)
                return NotFound();

            return Ok(oficina);
        }

        [HttpPost]
        public IActionResult Create(OficinaModel oficina)
        {
            _oficinaRepositorio.AdicionarOficina(oficina);
            return CreatedAtAction(nameof(GetById), new { id = oficina.OficinaId }, oficina);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OficinaModel oficina)
        {
            var existente = _oficinaRepositorio.GetOficinaById(id);
            if (existente == null)
                return NotFound();

            _oficinaRepositorio.AtualizarOficina(id, oficina);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existente = _oficinaRepositorio.GetOficinaById(id);
            if (existente == null)
                return NotFound();

            _oficinaRepositorio.DeleteOficina(id);
            return NoContent();
        }

        [HttpPatch("{id}/nome")]
        public IActionResult AlterarNome(int id, [FromBody] string novoNome)
        {
            var oficina = _oficinaRepositorio.GetOficinaById(id);
            if (oficina == null)
                return NotFound();

            oficina.AlterarNomeOficina(novoNome);
            _oficinaRepositorio.AtualizarOficina(id, oficina);
            return NoContent();
        }

        [HttpPatch("{id}/professor")]
        public IActionResult AlterarProfessor(int id, [FromBody] ProfessorModel novoProfessor)
        {
            var oficina = _oficinaRepositorio.GetOficinaById(id);
            if (oficina == null)
                return NotFound();

            oficina.AlterarProfessorOficina(novoProfessor);
            _oficinaRepositorio.AtualizarOficina(id, oficina);
            return NoContent();
        }

        [HttpDelete("{id}/aluno/{alunoId}")]
        public IActionResult RemoverAluno(int id, int alunoId)
        {
            var oficina = _oficinaRepositorio.GetOficinaById(id);
            if (oficina == null)
                return NotFound();

            oficina.RemoverAlunoOficina(alunoId);
            _oficinaRepositorio.AtualizarOficina(id, oficina);
            return NoContent();
        }

        [HttpDelete("{id}/monitor/{monitorId}")]
        public IActionResult RemoverMonitor(int id, int monitorId)
        {
            var oficina = _oficinaRepositorio.GetOficinaById(id);
            if (oficina == null)
                return NotFound();

            oficina.RemoverMonitorOficina(monitorId);
            _oficinaRepositorio.AtualizarOficina(id, oficina);
            return NoContent();
        }
    }
}
