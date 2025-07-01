using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Services;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OficinaController : ControllerBase
    {
        private readonly OficinaServices _oficinaServices;

        public OficinaController(OficinaServices oficinaServices)
        {
            _oficinaServices = oficinaServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OficinaModel>> GetAll()
        {
            try
            {
                var oficinas = _oficinaServices.GetOficinas();
                return Ok(oficinas);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }  
        }

        [HttpGet("{id}")]
        public ActionResult<OficinaModel> GetById(int id)
        {
            try
            {
                return Ok(_oficinaServices.GetOficinaById(id));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            } 
        }

        [HttpPost]
        public IActionResult Create(OficinaModel oficina)
        {
            try
            {
                _oficinaServices.CadastrarOficina(oficina);
                return CreatedAtAction(nameof(GetById), new { id = oficina.OficinaId }, oficina);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

        [HttpPut("AtualizarOficina/{id}")]
        public IActionResult Update(int id, OficinaModel oficina)
        {
            try
            {
                return Ok(_oficinaServices.AtualizarOficina(id,oficina));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _oficinaServices.RemoverOficina(id);
                return Ok("Oficina excluída.");
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
        }

        [HttpPut("AlterarNomeOficina/{id}")]
        public IActionResult AlterarNome(int id, [FromBody] string novoNome)
        {
            try
            {
                var oficina = _oficinaServices.GetOficinaById(id);
                oficina.AlterarNomeOficina(novoNome);
                return Ok(_oficinaServices.AtualizarOficina(id, oficina));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }

        }

        [HttpPut("AlterarProfessor/{id}")]
        public IActionResult AlterarProfessor(int id, int professorId)
        {
            try
            {
                return Ok(_oficinaServices.AlterarProfessor(id, professorId));
            }
            catch(ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno: " + ex.Message);
            }
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
