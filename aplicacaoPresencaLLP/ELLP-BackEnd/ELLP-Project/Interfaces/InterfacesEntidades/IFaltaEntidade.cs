using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IFaltaEntidade
    {
        void FaltaJustificada();
        void FaltaNaoJustificada();
        void AlterarData(DateOnly data);
        void AlterarJustificativa(string justificativa);
        void AlterarAluno(AlunoModel aluno);

    }
}
