using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IAlunoEntidade
    {
        int NumeroFaltas();
        List<FaltaModel> FaltasAluno();
        void AdicionarFalta(FaltaModel falta);
        void removerFalta(int faltaId);
        void AlterarFalta(int faltaId, DateOnly? novaData = null, string? novaJustificativa = null, bool? justificada = null);
        List<OficinaModel> OficinasAluno();
        void AlterarAlunoNome(string nome);
    }
}
