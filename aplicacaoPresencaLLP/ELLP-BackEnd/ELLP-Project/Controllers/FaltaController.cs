using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaltaController : ControllerBase
    {
        private readonly IFaltaRepositorio _faltaRepositorio;

        public FaltaController(IFaltaRepositorio faltaRepositorio)
        {
            _faltaRepositorio = faltaRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FaltaModel>> GetAll()
        {
            var faltas = _faltaRepositorio.GetAllFaltas();
            return Ok(faltas);
        }

        [HttpGet("{id}")]
        public ActionResult<FaltaModel> GetById(int id)
        {
            var falta = _faltaRepositorio.GetFaltaById(id);
            if (falta == null)
                return NotFound();

            return Ok(falta);
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
