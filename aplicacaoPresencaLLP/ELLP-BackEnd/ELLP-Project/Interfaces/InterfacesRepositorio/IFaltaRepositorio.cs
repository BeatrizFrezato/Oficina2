using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesRepositorio
{
    public interface IFaltaRepositorio
    {
        void AdicionarFalta(FaltaModel falta);
        void RemoverFalta(int id);
        void AtualizarFalta(int faltaId, FaltaModel falta);
        IEnumerable<FaltaModel> GetAllFaltas();
        FaltaModel? GetFaltaById(int id);
    }
}
