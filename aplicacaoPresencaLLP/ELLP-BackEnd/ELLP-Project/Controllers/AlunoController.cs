using Microsoft.AspNetCore.Mvc;
using ELLP_Project.Models;
using ELLP_Project.Services;
 
namespace ELLP_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoServices _alunoServices;

        public AlunoController(AlunoServices alunoServices)
        {
            _alunoServices = alunoServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlunoModel>> GetTodos()
        {
            var alunos = _alunoServices.GetAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public ActionResult<AlunoModel> GetPorId(int alunoId)
        {
            var aluno = _alunoServices.GetAlunoById(alunoId);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public ActionResult CreateAluno([FromBody] AlunoModel novoAluno)
        {
            _alunoServices.CadastrarAluno(novoAluno);
            return CreatedAtAction(nameof(GetPorId), new { id = novoAluno.AlunoId }, novoAluno);
        }

        [HttpPut("atualizarAluno/{id}")]
        public ActionResult Atualizar(int id, [FromBody] AlunoModel alunoAtualizado)
        {
      
            if (_alunoServices.GetAlunoById(id) == null)
                return NotFound("Aluno não encontrado.");

            _alunoServices.AtualizarAluno(id, alunoAtualizado);
            return Ok("Aluno atualizado.");
        }

        [HttpDelete("excluirAluno/{id}")]
        public ActionResult Deletar(int id)
        {
            var alunoExistente = _alunoServices.GetAlunoById(id);
            if (alunoExistente == null)
                return NotFound("Aluno não encontrado.");

            _alunoServices.RemoverAluno(id);
            return Ok("Aluno removido.");
        }

        [HttpPut("{id}/nome")]
        public ActionResult AlterarNome(int id, [FromBody] string novoNome)
        {
            var aluno = _alunoServices.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            aluno.AlunoNome = novoNome;
            _alunoServices.AtualizarAluno(id, aluno);
            return Ok("Nome alterado.");
        }

        [HttpGet("{id}/oficina")]
        public ActionResult <OficinaModel> ListarOficinas(int id)
        {
            var aluno = _alunoServices.GetAlunoById(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado.");

            return Ok(aluno.AlunoOficinas);
        }
    }
}
