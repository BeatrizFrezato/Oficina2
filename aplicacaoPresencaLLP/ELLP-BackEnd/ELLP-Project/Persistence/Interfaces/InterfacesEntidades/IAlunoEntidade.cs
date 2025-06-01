using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesEntidades
{
    public interface IAlunoEntidade
    {
        int NumeroFaltas();
        List<FaltaModel> FaltasAluno();
        void AdicionarFalta(FaltaModel falta);
        bool RemoverFalta(int faltaId);
        bool AlterarFalta(int faltaId, DateOnly? novaData = null, string? novaJustificativa = null, bool? justificada = null);
        List<OficinaModel> OficinasAluno();
        void AlterarAlunoNome(string nome);
    }
}
