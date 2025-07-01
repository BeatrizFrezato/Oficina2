using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Services;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaltaController : ControllerBase
    {
        private readonly FaltaServices _faltaServices;

        public FaltaController(FaltaServices faltaServices)
        {
            _faltaServices = faltaServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FaltaModel>> GetAll()
        {
            var faltas = _faltaServices.GetFaltas();
            return Ok(faltas);
        }

        [HttpGet("{id}")]
        public ActionResult<FaltaModel> GetById(int id)
        {
            try
            {
                return Ok(_faltaServices.GetFaltaById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public ActionResult Add([FromBody] FaltaModel falta)
        {
            if (falta == null)
                return BadRequest();

            _faltaRepositorio.AdicionarFalta(falta);
            return CreatedAtAction(nameof(GetById), new { id = falta.FaltaId }, falta);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] FaltaModel falta)
        {
            var existing = _faltaRepositorio.GetFaltaById(id);
            if (existing == null)
                return NotFound();

            _faltaRepositorio.AtualizarFalta(id, falta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var falta = _faltaRepositorio.GetFaltaById(id);
            if (falta == null)
                return NotFound();

            _faltaRepositorio.RemoverFalta(id);
            return NoContent();
        }
    }
}
