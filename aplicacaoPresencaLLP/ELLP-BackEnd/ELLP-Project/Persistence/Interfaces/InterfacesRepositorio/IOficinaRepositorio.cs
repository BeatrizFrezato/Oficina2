using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesRepositorio
{
    public interface IOficinaRepositorio
    {
        IEnumerable<OficinaModel> GetAllOficinas();
        OficinaModel? GetOficinaById(int oficinaId);
        void AdicionarOficina(OficinaModel oficina);
        bool DeleteOficina(int oficinaId);
        bool AtualizarOficina(int oficinaId, OficinaModel oficina);
    }
}
