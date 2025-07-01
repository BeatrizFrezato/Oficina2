
using ELLP_Project.Models;
using ELLP_Project.Persistence.Interfaces.InterfacesRepositorio;

namespace ELLP_Project.Persistence.Repositorios;


public class AlunoRepositorio : IAlunoRepositorio
{

    private readonly List<AlunoModel> _alunos = new List<AlunoModel>();

    public AlunoModel AdicionarAluno(AlunoModel aluno)
    {
        _alunos.Add(aluno);
        return aluno;
    }

    public AlunoModel AtualizarAluno(int alunoId, AlunoModel aluno)
    {
        AlunoModel getAluno = _alunos.FirstOrDefault(aluno => aluno.AlunoId == alunoId);
        if (getAluno == null)
            return null;
        getAluno.AlterarAlunoNome(aluno.AlunoNome);
        if (aluno.AlunoFaltas.Count!=0)
        {
            getAluno.AlunoFaltas = aluno.AlunoFaltas.ToList(); 
        }
        aluno.OficinaAluno(aluno.AlunoOficinas);
        
        return getAluno;
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