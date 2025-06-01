using ELLP_Project.Models;

namespace ELLP_Project.Interfaces.InterfacesEntidades
{
    public interface IMonitorEntidade
    {
        void AlterarNome(string nome);
        void AdicionarOficina(OficinaModel oficina);

    }
}
