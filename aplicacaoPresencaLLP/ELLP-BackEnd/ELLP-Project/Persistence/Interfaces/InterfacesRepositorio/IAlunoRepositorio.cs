using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesRepositorio
{
    public interface IAlunoRepositorio
    {
        IEnumerable<AlunoModel> GetAllAlunos();
        AlunoModel? GetAlunoById(int id);
        void AdicionarAluno(AlunoModel aluno);
        bool AtualizarAluno(int alunoId, AlunoModel aluno);
        bool DeleteAluno(int id);
    }
}
