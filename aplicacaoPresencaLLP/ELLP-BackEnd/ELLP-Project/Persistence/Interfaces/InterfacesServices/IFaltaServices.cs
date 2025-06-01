using ELLP_Project.Models;

namespace ELLP_Project.Persistence.Interfaces.InterfacesServices;

public interface IFaltaServices
{
    void CadastrarFalta(FaltaModel falta);
    bool AtualizarFalta(FaltaModel falta);
    bool RemoverFalta(int faltaId);
    IEnumerable<FaltaModel> GetFaltas();
    FaltaModel? GetFaltaById(int faltaId);
}
