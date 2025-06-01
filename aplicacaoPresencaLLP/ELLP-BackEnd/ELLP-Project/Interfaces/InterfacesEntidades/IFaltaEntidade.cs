using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IFaltaEntidade
    {
        void FaltaJustificada();
        void FaltaNaoJustificada();
        void DataFalta(DateOnly data);
        void AlterarData(DateOnly data);
        void AdicionarJustificativa(string justificativa);
        void AlterarJustificativa(string justificativa);
        void AlterarAluno(AlunoModel aluno);

    }
}
