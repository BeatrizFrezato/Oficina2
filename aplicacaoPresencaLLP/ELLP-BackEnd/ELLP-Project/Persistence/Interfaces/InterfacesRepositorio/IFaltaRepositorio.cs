using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesRepositorio
{
    public interface IFaltaRepositorio
    {
        void AdicionarFalta(FaltaModel falta);
        bool RemoverFalta(int id);
        bool AtualizarFalta(int faltaId, FaltaModel falta);
        IEnumerable<FaltaModel> GetAllFaltas();
        FaltaModel? GetFaltaById(int id);
    }
}
