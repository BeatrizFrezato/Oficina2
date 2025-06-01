using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesRepositório
{
    public interface IAlunoRepositorio
    {
        IEnumerable<AlunoModel> GetAllAlunos();
        AlunoModel? GetAlunoById(int id);
        void AdicionarAluno(AlunoModel aluno);
        void AtualizarAluno(int alunoId, AlunoModel aluno);
        void DeleteAluno(int id);
    }
}
