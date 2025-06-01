using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesServices
{
    public interface IOficinaServices
    {
        void CadastrarOficina(OficinaModel oficina);
        bool AtualizarOficina(OficinaModel oficina);
        bool RemoverOficina(int oficinaId);
        IEnumerable<OficinaModel> GetOficinas();
        OficinaModel? GetOficinaById(int oficinaId);
    }
}
