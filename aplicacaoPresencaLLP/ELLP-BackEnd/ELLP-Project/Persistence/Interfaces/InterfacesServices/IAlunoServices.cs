using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesServices
{
    public interface IAlunoServices
    {
        void CadastrarAluno(AlunoModel aluno);
        bool AtualizarAluno(AlunoModel aluno);
        bool RemoverAluno(int alunoId);
        AlunoModel? GetAlunoById(int alunoId);
        IEnumerable<AlunoModel> GetAlunos();
    }
}
