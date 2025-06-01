using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepositorio _professorRepositorio;

        public ProfessoresController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProfessorModel>> GetAll()
        {
            var professores = _professorRepositorio.GetAllProfessores();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public ActionResult<ProfessorModel> GetById(int id)
        {
            var professor = _professorRepositorio.GetProfessorById(id);
            if (professor == null)
            {
                return NotFound($"Professor com ID {id} não encontrado.");
            }
            return Ok(professor);
        }

        [HttpPost]
        public ActionResult AdicionarProfessor([FromBody] ProfessorModel professor)
        {
            if (professor == null)
            {
                return BadRequest("Dados do professor inválidos.");
            }

            _professorRepositorio.AdicionarProfessor(professor);
            return CreatedAtAction(nameof(GetById), new { id = professor.Id }, professor);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarProfessor(int id, [FromBody] ProfessorModel professorAtualizado)
        {
            var professorExistente = _professorRepositorio.GetProfessorById(id);
            if (professorExistente == null)
            {
                return NotFound($"Professor com ID {id} não encontrado.");
            }

            _professorRepositorio.AlterarProfessor(id, professorAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProfessor(int id)
        {
            var professor = _professorRepositorio.GetProfessorById(id);
            if (professor == null)
            {
                return NotFound($"Professor com ID {id} não encontrado.");
            }

            _professorRepositorio.DeleteProfessor(id);
            return NoContent();
        }
    }
}
