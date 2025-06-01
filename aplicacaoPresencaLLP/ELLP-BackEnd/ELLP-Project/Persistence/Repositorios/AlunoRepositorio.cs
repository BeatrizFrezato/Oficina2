
using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Persistence.Repositorios;


public class AlunoRepositorio : IAlunoRepositorio
{

    private readonly List<AlunoModel> _alunos = new List<AlunoModel>();

    public void AdicionarAluno(AlunoModel aluno)
    {
        _alunos.Add(aluno);
    }

    public bool AtualizarAluno(int alunoId, AlunoModel aluno)
    {
        AlunoModel getAluno = _alunos.FirstOrDefault(aluno => aluno.AlunoId == alunoId);
        if (getAluno == null)
            return false;
        getAluno.AlterarAlunoNome(aluno.AlunoNome);
        if (aluno.AlunoFaltas != null)
        {
            getAluno.AlunoFaltas = aluno.AlunoFaltas.ToList(); 
        }

        if (aluno.AlunoOficinas != null)
        {
            getAluno.AlunoOficinas = aluno.AlunoOficinas.ToList(); 
        }
        return true;
    }

    public bool DeleteAluno(int id)
    {
        if(_alunos.FirstOrDefault(aluno=>aluno.AlunoId==id) == null)
            return false;
        _alunos.RemoveAll(aluno => aluno.AlunoId == id);
        return true;
    }

    public IEnumerable<AlunoModel> GetAllAlunos()
    {
        return _alunos;
    }

    public AlunoModel? GetAlunoById(int alunoId)
    {
        return _alunos.FirstOrDefault(aluno => aluno.AlunoId == alunoId);
    }
}