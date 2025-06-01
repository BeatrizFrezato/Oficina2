using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesRepositorio
{
    public interface IOficinaRepositorio
    {
        IEnumerable<OficinaModel> GetAllOficinas();
        OficinaModel? GetOficinaById(int oficinaId);
        void AdicionarOficina(OficinaModel oficina);
        void DeleteOficina(int oficinaId);
        void AtualizarOficina(int oficinaId,OficinaModel oficina);
    }
}
