using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Interfaces.InterfacesRepositório;

namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlunoModel>> GetTodos()
        {
            var alunos = _alunoRepositorio.GetAllAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public ActionResult<AlunoModel> GetPorId(int id)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public ActionResult Criar([FromBody] AlunoModel novoAluno)
        {
            _alunoRepositorio.AdicionarAluno(novoAluno);
            return CreatedAtAction(nameof(GetPorId), new { id = novoAluno.AlunoId }, novoAluno);
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, [FromBody] AlunoModel alunoAtualizado)
        {
            var alunoExistente = _alunoRepositorio.GetAlunoById(id);
            if (alunoExistente == null)
                return NotFound("Aluno não encontrado.");

            _alunoRepositorio.AtualizarAluno(id, alunoAtualizado);
            return Ok("Aluno atualizado.");
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            var alunoExistente = _alunoRepositorio.GetAlunoById(id);
            if (alunoExistente == null)
                return NotFound("Aluno não encontrado.");

            _alunoRepositorio.DeleteAluno(id);
            return Ok("Aluno removido.");
        }

        [HttpPost("{id}/faltas")]
        public ActionResult AdicionarFalta(int id, [FromBody] FaltaModel falta)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            aluno.AdicionarFalta(falta);
            _alunoRepositorio.AtualizarAluno(id, aluno);
            return Ok("Falta adicionada.");
        }

        [HttpPut("{id}/faltas/{faltaId}")]
        public ActionResult AlterarFalta(int id, int faltaId, [FromBody] FaltaModel faltaAtualizada)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            try
            {
                aluno.AlterarFalta(faltaId, faltaAtualizada.DataFalta, faltaAtualizada.JustificativaFalta, faltaAtualizada.FaltaJustificada);
                _alunoRepositorio.AtualizarAluno(id, aluno);
                return Ok("Falta atualizada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}/faltas/{faltaId}")]
        public ActionResult RemoverFalta(int id, int faltaId)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            aluno.removerFalta(faltaId);
            _alunoRepositorio.AtualizarAluno(id, aluno);
            return Ok("Falta removida.");
        }

        [HttpGet("{id}/faltas")]
        public ActionResult<List<FaltaModel>> ListarFaltas(int id)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno.FaltasAluno());
        }

        [HttpPut("{id}/nome")]
        public ActionResult AlterarNome(int id, [FromBody] string novoNome)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            aluno.AlterarAlunoNome(novoNome);
            _alunoRepositorio.AtualizarAluno(id, aluno);
            return Ok("Nome alterado.");
        }

        [HttpGet("{id}/oficinas")]
        public ActionResult<List<OficinaModel>> ListarOficinas(int id)
        {
            var aluno = _alunoRepositorio.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno.OficinasAluno());
        }
    }
}
